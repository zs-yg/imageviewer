namespace imageviewer.Models;

/// <summary>
/// 图片信息模型
/// </summary>
public class ImageInfo
{
    /// <summary>
    /// 文件名
    /// </summary>
    public string FileName { get; set; } = string.Empty;
    
    /// <summary>
    /// 文件路径
    /// </summary>
    public string FilePath { get; set; } = string.Empty;
    
    /// <summary>
    /// 文件大小（字节）
    /// </summary>
    public long FileSize { get; set; }
    
    /// <summary>
    /// 图片宽度
    /// </summary>
    public int Width { get; set; }
    
    /// <summary>
    /// 图片高度
    /// </summary>
    public int Height { get; set; }
    
    /// <summary>
    /// 水平分辨率
    /// </summary>
    public float HorizontalResolution { get; set; }
    
    /// <summary>
    /// 垂直分辨率
    /// </summary>
    public float VerticalResolution { get; set; }
    
    /// <summary>
    /// 图片格式
    /// </summary>
    public string Format { get; set; } = string.Empty;
    
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreationTime { get; set; }
    
    /// <summary>
    /// 修改时间
    /// </summary>
    public DateTime LastWriteTime { get; set; }
    
    /// <summary>
    /// 获取文件大小的人类可读格式
    /// </summary>
    public string GetFormattedFileSize()
    {
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        double len = FileSize;
        int order = 0;
        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len /= 1024;
        }
        return $"{len:0.##} {sizes[order]}";
    }
    
    /// <summary>
    /// 获取图片尺寸字符串
    /// </summary>
    public string GetDimensions()
    {
        return $"{Width} × {Height}";
    }
    
    /// <summary>
    /// 获取分辨率字符串
    /// </summary>
    public string GetResolution()
    {
        return $"{HorizontalResolution:F0} × {VerticalResolution:F0} DPI";
    }
}