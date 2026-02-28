using System.Drawing;
using imageviewer.Models;

namespace imageviewer.ImageHandlers;

/// <summary>
/// 图片处理接口
/// 定义图片处理的基本操作
/// </summary>
public interface IImageHandler
{
    /// <summary>
    /// 获取支持的图片格式扩展名
    /// </summary>
    string[] SupportedExtensions { get; }
    
    /// <summary>
    /// 检查文件是否可以被此处理器处理
    /// </summary>
    bool CanHandle(string filePath);
    
    /// <summary>
    /// 加载图片
    /// </summary>
    Image LoadImage(string filePath);
    
    /// <summary>
    /// 获取图片信息
    /// </summary>
    ImageInfo GetImageInfo(string filePath);
    
    /// <summary>
    /// 保存图片
    /// </summary>
    void SaveImage(Image image, string filePath);
}