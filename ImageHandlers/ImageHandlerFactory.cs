namespace imageviewer.ImageHandlers;

/// <summary>
/// 图片处理器工厂
/// 根据文件扩展名创建相应的图片处理器
/// </summary>
public static class ImageHandlerFactory
{
    private static readonly Dictionary<string, IImageHandler> _handlers = new Dictionary<string, IImageHandler>(StringComparer.OrdinalIgnoreCase);
    
    static ImageHandlerFactory()
    {
        // 注册所有可用的图片处理器
        RegisterHandler(new PngHandler());
        // 未来可以在这里注册其他处理器，如JpegHandler等
    }
    
    /// <summary>
    /// 注册图片处理器
    /// </summary>
    public static void RegisterHandler(IImageHandler handler)
    {
        if (handler == null)
            throw new ArgumentNullException(nameof(handler));
        
        foreach (var extension in handler.SupportedExtensions)
        {
            _handlers[extension] = handler;
        }
    }
    
    /// <summary>
    /// 根据文件路径获取合适的图片处理器
    /// </summary>
    public static IImageHandler? GetHandler(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            return null;
        
        string extension = Path.GetExtension(filePath);
        if (string.IsNullOrEmpty(extension))
            return null;
        
        if (_handlers.TryGetValue(extension, out var handler))
        {
            return handler;
        }
        
        return null;
    }
    
    /// <summary>
    /// 检查文件是否被支持
    /// </summary>
    public static bool IsSupported(string filePath)
    {
        return GetHandler(filePath) != null;
    }
    
    /// <summary>
    /// 获取所有支持的扩展名
    /// </summary>
    public static string[] GetAllSupportedExtensions()
    {
        return _handlers.Keys.ToArray();
    }
    
    /// <summary>
    /// 获取所有支持的图片过滤器字符串（用于OpenFileDialog）
    /// </summary>
    public static string GetSupportedFilters()
    {
        var extensionsByType = _handlers
            .GroupBy(kvp => kvp.Value.GetType().Name.Replace("Handler", ""))
            .Select(g => $"{g.Key}文件 ({string.Join(", ", g.Select(kvp => $"*{kvp.Key}"))})|{string.Join(";", g.Select(kvp => $"*{kvp.Key}"))}")
            .ToList();
        
        extensionsByType.Add("所有支持的文件|" + string.Join(";", _handlers.Keys.Select(ext => $"*{ext}")));
        extensionsByType.Add("所有文件 (*.*)|*.*");
        
        return string.Join("|", extensionsByType);
    }
    
    /// <summary>
    /// 获取所有已注册的处理器
    /// </summary>
    public static IEnumerable<IImageHandler> GetAllHandlers()
    {
        return _handlers.Values.Distinct();
    }
}