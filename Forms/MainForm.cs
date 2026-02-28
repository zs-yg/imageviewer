using System.Drawing.Imaging;
using imageviewer.ImageHandlers;
using imageviewer.Utils;

namespace imageviewer.Forms;

public partial class MainForm : Form
{
    private List<string> imageFiles = new List<string>();
    private int currentImageIndex = -1;
    private float zoomFactor = 1.0f;
    private const float ZOOM_STEP = 0.2f;
    private IImageHandler? currentImageHandler;

    public MainForm()
    {
        InitializeComponent();
        InitializeUI();
    }

    private void InitializeUI()
    {
        // 初始化界面组件
        this.Text = "月光查看器 - 支持PNG格式";
        this.Size = new Size(1000, 700);
        
        // 初始化图片列表
        imageList.Images.Add("folder", SystemIcons.WinLogo);
        imageList.Images.Add("file", SystemIcons.Application);
        imageList.Images.Add("png", SystemIcons.Application); // PNG图标
        
        // 初始化树形视图
        InitializeTreeView();
        
        // 设置文件对话框过滤器
        UpdateFileDialogFilter();
    }

    private void InitializeTreeView()
    {
        // 添加示例文件夹
        TreeNode rootNode = new TreeNode("图片库");
        rootNode.ImageKey = "folder";
        rootNode.SelectedImageKey = "folder";
        
        TreeNode pngNode = new TreeNode("PNG图片");
        pngNode.ImageKey = "folder";
        pngNode.SelectedImageKey = "folder";
        pngNode.Tag = "png"; // 标记为PNG文件夹
        
        TreeNode jpegNode = new TreeNode("JPEG图片 (待实现)");
        jpegNode.ImageKey = "folder";
        jpegNode.SelectedImageKey = "folder";
        jpegNode.Tag = "jpeg"; // 标记为JPEG文件夹
        
        rootNode.Nodes.Add(pngNode);
        rootNode.Nodes.Add(jpegNode);
        
        treeView.Nodes.Add(rootNode);
        rootNode.Expand();
    }

    private void UpdateFileDialogFilter()
    {
        // 使用ImageHandlerFactory获取支持的过滤器
        string filter = ImageHandlerFactory.GetSupportedFilters();
        // 可以在这里设置OpenFileDialog的Filter属性
    }

    #region 事件处理方法
    private void MainForm_Load(object sender, EventArgs e)
    {
        UpdateStatus("就绪 - 支持PNG格式图片");
    }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenImageFile();
    }

    private void OpenToolStripButton_Click(object sender, EventArgs e)
    {
        OpenImageFile();
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void PreviousToolStripButton_Click(object sender, EventArgs e)
    {
        ShowPreviousImage();
    }

    private void NextToolStripButton_Click(object sender, EventArgs e)
    {
        ShowNextImage();
    }

    private void ZoomInToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ZoomIn();
    }

    private void ZoomInToolStripButton_Click(object sender, EventArgs e)
    {
        ZoomIn();
    }

    private void ZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ZoomOut();
    }

    private void ZoomOutToolStripButton_Click(object sender, EventArgs e)
    {
        ZoomOut();
    }

    private void ActualSizeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ResetZoom();
    }

    private void ActualSizeToolStripButton_Click(object sender, EventArgs e)
    {
        ResetZoom();
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var supportedFormats = ImageHandlerFactory.GetAllSupportedExtensions();
        string formats = string.Join(", ", supportedFormats.Select(ext => ext.TrimStart('.').ToUpper()));
        
        MessageBox.Show($"月光查看器 v1.0\n支持格式: {formats}\n作者:zsyg", "关于", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
    {
        // 处理文件夹选择
        if (e.Node != null)
        {
            string? folderType = e.Node.Tag as string;
            if (folderType == "png")
            {
                LoadFolderImages(".png");
            }
            else if (folderType == "jpeg")
            {
                MessageBox.Show("JPEG支持待实现", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    #endregion

    #region 图片处理逻辑
    private void OpenImageFile()
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            // 使用ImageHandlerFactory获取支持的过滤器
            openFileDialog.Filter = ImageHandlerFactory.GetSupportedFilters();
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 过滤出支持的图片文件
                imageFiles.Clear();
                foreach (var file in openFileDialog.FileNames)
                {
                    if (ImageHandlerFactory.IsSupported(file))
                    {
                        imageFiles.Add(file);
                    }
                }
                
                if (imageFiles.Count > 0)
                {
                    currentImageIndex = 0;
                    LoadCurrentImage();
                }
                else
                {
                    MessageBox.Show("没有选择支持的图片文件", "提示", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }

    private void LoadFolderImages(string extension)
    {
        using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
        {
            folderDialog.Description = $"选择包含{extension.ToUpper()}图片的文件夹";
            folderDialog.ShowNewFolderButton = false;
            
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string[] extensions = { extension };
                imageFiles = FileHelper.GetImageFiles(folderDialog.SelectedPath, extensions).ToList();
                
                if (imageFiles.Count > 0)
                {
                    currentImageIndex = 0;
                    LoadCurrentImage();
                    UpdateStatus($"已加载 {imageFiles.Count} 张{extension.ToUpper()}图片");
                }
                else
                {
                    MessageBox.Show($"在选定的文件夹中未找到{extension.ToUpper()}图片", "提示", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

    private void LoadCurrentImage()
    {
        if (currentImageIndex >= 0 && currentImageIndex < imageFiles.Count)
        {
            try
            {
                string imagePath = imageFiles[currentImageIndex];
                
                // 获取对应的图片处理器
                currentImageHandler = ImageHandlerFactory.GetHandler(imagePath);
                if (currentImageHandler == null)
                {
                    MessageBox.Show($"不支持的文件格式: {Path.GetExtension(imagePath)}", "错误", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                // 使用处理器加载图片
                Image image = currentImageHandler.LoadImage(imagePath);
                pictureBox.Image = image;
                
                // 获取图片信息
                var imageInfo = currentImageHandler.GetImageInfo(imagePath);
                UpdateStatus($"正在显示: {imageInfo.FileName} ({currentImageIndex + 1}/{imageFiles.Count}) - {imageInfo.GetDimensions()}");
                
                ResetZoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法加载图片: {ex.Message}", "错误", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void ShowPreviousImage()
    {
        if (imageFiles.Count > 0)
        {
            currentImageIndex--;
            if (currentImageIndex < 0)
            {
                currentImageIndex = imageFiles.Count - 1;
            }
            LoadCurrentImage();
        }
    }

    private void ShowNextImage()
    {
        if (imageFiles.Count > 0)
        {
            currentImageIndex++;
            if (currentImageIndex >= imageFiles.Count)
            {
                currentImageIndex = 0;
            }
            LoadCurrentImage();
        }
    }

    private void ZoomIn()
    {
        if (pictureBox.Image != null)
        {
            zoomFactor += ZOOM_STEP;
            ApplyZoom();
        }
    }

    private void ZoomOut()
    {
        if (pictureBox.Image != null && zoomFactor > ZOOM_STEP)
        {
            zoomFactor -= ZOOM_STEP;
            ApplyZoom();
        }
    }

    private void ResetZoom()
    {
        zoomFactor = 1.0f;
        ApplyZoom();
    }

    private void ApplyZoom()
    {
        if (pictureBox.Image != null)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            // 在实际应用中，这里可以调整图片显示大小
            UpdateStatus($"缩放: {zoomFactor:P0}");
        }
    }

    private void UpdateStatus(string message)
    {
        statusLabel.Text = message;
    }
    
    private void ShowImageInfo()
    {
        if (currentImageIndex >= 0 && currentImageIndex < imageFiles.Count && currentImageHandler != null)
        {
            try
            {
                string imagePath = imageFiles[currentImageIndex];
                var imageInfo = currentImageHandler.GetImageInfo(imagePath);
                
                string info = $"文件名: {imageInfo.FileName}\n" +
                             $"路径: {imageInfo.FilePath}\n" +
                             $"尺寸: {imageInfo.GetDimensions()}\n" +
                             $"文件大小: {imageInfo.GetFormattedFileSize()}\n" +
                             $"格式: {imageInfo.Format}\n" +
                             $"分辨率: {imageInfo.GetResolution()}\n" +
                             $"创建时间: {imageInfo.CreationTime:yyyy-MM-dd HH:mm:ss}\n" +
                             $"修改时间: {imageInfo.LastWriteTime:yyyy-MM-dd HH:mm:ss}";
                
                MessageBox.Show(info, "图片信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法获取图片信息: {ex.Message}", "错误", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    #endregion
}