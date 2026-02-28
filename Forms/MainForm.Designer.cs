namespace imageviewer.Forms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        menuStrip = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        openToolStripMenuItem = new ToolStripMenuItem();
        exitToolStripMenuItem = new ToolStripMenuItem();
        viewToolStripMenuItem = new ToolStripMenuItem();
        zoomInToolStripMenuItem = new ToolStripMenuItem();
        zoomOutToolStripMenuItem = new ToolStripMenuItem();
        actualSizeToolStripMenuItem = new ToolStripMenuItem();
        helpToolStripMenuItem = new ToolStripMenuItem();
        aboutToolStripMenuItem = new ToolStripMenuItem();
        toolStrip = new ToolStrip();
        openToolStripButton = new ToolStripButton();
        toolStripSeparator1 = new ToolStripSeparator();
        previousToolStripButton = new ToolStripButton();
        nextToolStripButton = new ToolStripButton();
        toolStripSeparator2 = new ToolStripSeparator();
        zoomInToolStripButton = new ToolStripButton();
        zoomOutToolStripButton = new ToolStripButton();
        actualSizeToolStripButton = new ToolStripButton();
        splitContainer = new SplitContainer();
        treeView = new TreeView();
        imageList = new ImageList(components);
        pictureBox = new PictureBox();
        statusStrip = new StatusStrip();
        statusLabel = new ToolStripStatusLabel();
        progressBar = new ToolStripProgressBar();
        // 
        // 菜单栏
        // 
        menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, helpToolStripMenuItem });
        menuStrip.Location = new Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new Size(984, 24);
        menuStrip.TabIndex = 0;
        menuStrip.Text = "menuStrip1";
        // 
        // 文件菜单项
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, exitToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(39, 20);
        fileToolStripMenuItem.Text = "文件(&F)";
        // 
        // 打开菜单项
        // 
        openToolStripMenuItem.Name = "openToolStripMenuItem";
        openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
        openToolStripMenuItem.Size = new Size(180, 22);
        openToolStripMenuItem.Text = "打开(&O)";
        openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
        // 
        // 退出菜单项
        // 
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
        exitToolStripMenuItem.Size = new Size(180, 22);
        exitToolStripMenuItem.Text = "退出(&X)";
        exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
        // 
        // 查看菜单项
        // 
        viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { zoomInToolStripMenuItem, zoomOutToolStripMenuItem, actualSizeToolStripMenuItem });
        viewToolStripMenuItem.Name = "viewToolStripMenuItem";
        viewToolStripMenuItem.Size = new Size(47, 20);
        viewToolStripMenuItem.Text = "查看(&V)";
        // 
        // 放大菜单项
        // 
        zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
        zoomInToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Add;
        zoomInToolStripMenuItem.Size = new Size(180, 22);
        zoomInToolStripMenuItem.Text = "放大";
        zoomInToolStripMenuItem.Click += ZoomInToolStripMenuItem_Click;
        // 
        // 缩小菜单项
        // 
        zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
        zoomOutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Subtract;
        zoomOutToolStripMenuItem.Size = new Size(180, 22);
        zoomOutToolStripMenuItem.Text = "缩小";
        zoomOutToolStripMenuItem.Click += ZoomOutToolStripMenuItem_Click;
        // 
        // 实际大小菜单项
        // 
        actualSizeToolStripMenuItem.Name = "actualSizeToolStripMenuItem";
        actualSizeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D0;
        actualSizeToolStripMenuItem.Size = new Size(180, 22);
        actualSizeToolStripMenuItem.Text = "实际大小";
        actualSizeToolStripMenuItem.Click += ActualSizeToolStripMenuItem_Click;
        // 
        // 帮助菜单项
        // 
        helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
        helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        helpToolStripMenuItem.Size = new Size(47, 20);
        helpToolStripMenuItem.Text = "帮助(&H)";
        // 
        // 关于菜单项
        // 
        aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        aboutToolStripMenuItem.Size = new Size(180, 22);
        aboutToolStripMenuItem.Text = "关于(&A)";
        aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
        // 
        // 工具栏
        // 
        toolStrip.Items.AddRange(new ToolStripItem[] { openToolStripButton, toolStripSeparator1, previousToolStripButton, nextToolStripButton, toolStripSeparator2, zoomInToolStripButton, zoomOutToolStripButton, actualSizeToolStripButton });
        toolStrip.Location = new Point(0, 24);
        toolStrip.Name = "toolStrip";
        toolStrip.Size = new Size(984, 25);
        toolStrip.TabIndex = 1;
        toolStrip.Text = "toolStrip";
        // 
        // 打开按钮
        // 
        openToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        openToolStripButton.Name = "openToolStripButton";
        openToolStripButton.Size = new Size(23, 22);
        openToolStripButton.Text = "打开";
        openToolStripButton.Click += OpenToolStripButton_Click;
        // 
        // 工具栏分隔符1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(6, 25);
        // 
        // 上一张按钮
        // 
        previousToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        previousToolStripButton.Name = "previousToolStripButton";
        previousToolStripButton.Size = new Size(23, 22);
        previousToolStripButton.Text = "上一张";
        previousToolStripButton.Click += PreviousToolStripButton_Click;
        // 
        // 下一张按钮
        // 
        nextToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        nextToolStripButton.Name = "nextToolStripButton";
        nextToolStripButton.Size = new Size(23, 22);
        nextToolStripButton.Text = "下一张";
        nextToolStripButton.Click += NextToolStripButton_Click;
        // 
        // 工具栏分隔符2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(6, 25);
        // 
        // 放大按钮
        // 
        zoomInToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        zoomInToolStripButton.Name = "zoomInToolStripButton";
        zoomInToolStripButton.Size = new Size(23, 22);
        zoomInToolStripButton.Text = "放大";
        zoomInToolStripButton.Click += ZoomInToolStripButton_Click;
        // 
        // 缩小按钮
        // 
        zoomOutToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        zoomOutToolStripButton.Name = "zoomOutToolStripButton";
        zoomOutToolStripButton.Size = new Size(23, 22);
        zoomOutToolStripButton.Text = "缩小";
        zoomOutToolStripButton.Click += ZoomOutToolStripButton_Click;
        // 
        // 实际大小按钮
        // 
        actualSizeToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        actualSizeToolStripButton.Name = "actualSizeToolStripButton";
        actualSizeToolStripButton.Size = new Size(23, 22);
        actualSizeToolStripButton.Text = "实际大小";
        actualSizeToolStripButton.Click += ActualSizeToolStripButton_Click;
        // 
        // 分割容器
        // 
        splitContainer.Dock = DockStyle.Fill;
        splitContainer.Location = new Point(0, 49);
        splitContainer.Name = "splitContainer";
        // 
        // 分割容器.面板1
        // 
        splitContainer.Panel1.Controls.Add(treeView);
        splitContainer.Panel1MinSize = 200;
        // 
        // 分割容器.面板2
        // 
        splitContainer.Panel2.Controls.Add(pictureBox);
        splitContainer.Size = new Size(984, 592);
        splitContainer.SplitterDistance = 250;
        splitContainer.TabIndex = 2;
        // 
        // 树形视图
        // 
        treeView.Dock = DockStyle.Fill;
        treeView.ImageList = imageList;
        treeView.Location = new Point(0, 0);
        treeView.Name = "treeView";
        treeView.Size = new Size(250, 592);
        treeView.TabIndex = 0;
        treeView.AfterSelect += TreeView_AfterSelect;
        // 
        // 图像列表
        // 
        imageList.ColorDepth = ColorDepth.Depth32Bit;
        imageList.ImageSize = new Size(16, 16);
        imageList.TransparentColor = Color.Transparent;
        // 
        // 图片框
        // 
        pictureBox.Dock = DockStyle.Fill;
        pictureBox.Location = new Point(0, 0);
        pictureBox.Name = "pictureBox";
        pictureBox.Size = new Size(730, 592);
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox.TabIndex = 0;
        pictureBox.TabStop = false;
        // 
        // 状态栏
        // 
        statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel, progressBar });
        statusStrip.Location = new Point(0, 641);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(984, 22);
        statusStrip.TabIndex = 3;
        statusStrip.Text = "statusStrip1";
        // 
        // 状态标签
        // 
        statusLabel.Name = "statusLabel";
        statusLabel.Size = new Size(59, 17);
        statusLabel.Text = "就绪";
        // 
        // 进度条
        // 
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(100, 16);
        progressBar.Visible = false;
        // 
        // 主窗体
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(984, 663);
        Controls.Add(splitContainer);
        Controls.Add(statusStrip);
        Controls.Add(toolStrip);
        Controls.Add(menuStrip);
        MainMenuStrip = menuStrip;
        Name = "MainForm";
        Text = "月光查看器";
        Load += MainForm_Load;
        ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
        splitContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        toolStrip.ResumeLayout(false);
        toolStrip.PerformLayout();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem viewToolStripMenuItem;
    private ToolStripMenuItem zoomInToolStripMenuItem;
    private ToolStripMenuItem zoomOutToolStripMenuItem;
    private ToolStripMenuItem actualSizeToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private ToolStrip toolStrip;
    private ToolStripButton openToolStripButton;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton previousToolStripButton;
    private ToolStripButton nextToolStripButton;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton zoomInToolStripButton;
    private ToolStripButton zoomOutToolStripButton;
    private ToolStripButton actualSizeToolStripButton;
    private SplitContainer splitContainer;
    private TreeView treeView;
    private PictureBox pictureBox;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel statusLabel;
    private ToolStripProgressBar progressBar;
    private ImageList imageList;
}