using System.Drawing;
using System.Drawing.Imaging;
using imageviewer.Models;

namespace imageviewer.ImageHandlers;

/// <summary>
/// PNG图片处理器
/// </summary>
public class PngHandler : IImageHandler
{
    public string[] SupportedExtensions => new[] { ".png", ".PNG" };

    public bool CanHandle(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            return false;

        string extension = Path.GetExtension(filePath);
        return SupportedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
    }

    public Image LoadImage(string filePath)
    {
        if (!CanHandle(filePath))
        {
            throw new ArgumentException($"不支持的文件格式: {Path.GetExtension(filePath)}", nameof(filePath));
        }

        try
        {
            // 使用Image.FromFile加载PNG图片
            return Image.FromFile(filePath);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"无法加载PNG图片: {ex.Message}", ex);
        }
    }

    public ImageInfo GetImageInfo(string filePath)
    {
        if (!CanHandle(filePath))
        {
            throw new ArgumentException($"不支持的文件格式: {Path.GetExtension(filePath)}", nameof(filePath));
        }

        try
        {
            var fileInfo = new FileInfo(filePath);
            using (var image = Image.FromFile(filePath))
            {
                return new ImageInfo
                {
                    FileName = Path.GetFileName(filePath),
                    FilePath = filePath,
                    FileSize = fileInfo.Length,
                    Width = image.Width,
                    Height = image.Height,
                    HorizontalResolution = image.HorizontalResolution,
                    VerticalResolution = image.VerticalResolution,
                    Format = "PNG",
                    CreationTime = fileInfo.CreationTime,
                    LastWriteTime = fileInfo.LastWriteTime
                };
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"无法获取PNG图片信息: {ex.Message}", ex);
        }
    }

    public void SaveImage(Image image, string filePath)
    {
        if (image == null)
            throw new ArgumentNullException(nameof(image));

        if (string.IsNullOrEmpty(filePath))
            throw new ArgumentException("文件路径不能为空", nameof(filePath));

        try
        {
            // 确保目录存在
            string directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // 保存为PNG格式
            image.Save(filePath, ImageFormat.Png);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"无法保存PNG图片: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// 检查图片是否为有效的PNG格式
    /// </summary>
    public bool IsValidPng(string filePath)
    {
        try
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                // PNG文件头: 89 50 4E 47 0D 0A 1A 0A
                byte[] pngHeader = new byte[8];
                if (stream.Read(pngHeader, 0, 8) != 8)
                    return false;

                return pngHeader[0] == 0x89 && pngHeader[1] == 0x50 && pngHeader[2] == 0x4E && 
                       pngHeader[3] == 0x47 && pngHeader[4] == 0x0D && pngHeader[5] == 0x0A && 
                       pngHeader[6] == 0x1A && pngHeader[7] == 0x0A;
            }
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 获取PNG图片的详细信息
    /// </summary>
    public string GetPngDetails(string filePath)
    {
        var info = GetImageInfo(filePath);
        return $"PNG图片信息:\n" +
               $"文件名: {info.FileName}\n" +
               $"尺寸: {info.GetDimensions()}\n" +
               $"文件大小: {info.GetFormattedFileSize()}\n" +
               $"分辨率: {info.GetResolution()}\n" +
               $"创建时间: {info.CreationTime:yyyy-MM-dd HH:mm:ss}\n" +
               $"修改时间: {info.LastWriteTime:yyyy-MM-dd HH:mm:ss}";
    }
}