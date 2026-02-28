namespace imageviewer.Utils;

/// <summary>
/// 文件操作工具类
/// </summary>
public static class FileHelper
{
    /// <summary>
    /// 获取目录中的所有图片文件
    /// </summary>
    public static string[] GetImageFiles(string directoryPath, string[] extensions)
    {
        if (!Directory.Exists(directoryPath))
        {
            return Array.Empty<string>();
        }

        try
        {
            var files = new List<string>();
            foreach (var extension in extensions)
            {
                files.AddRange(Directory.GetFiles(directoryPath, $"*{extension}", SearchOption.TopDirectoryOnly));
            }
            return files.OrderBy(f => f).ToArray();
        }
        catch (Exception)
        {
            return Array.Empty<string>();
        }
    }

    /// <summary>
    /// 获取目录中的所有图片文件（递归）
    /// </summary>
    public static string[] GetImageFilesRecursive(string directoryPath, string[] extensions)
    {
        if (!Directory.Exists(directoryPath))
        {
            return Array.Empty<string>();
        }

        try
        {
            var files = new List<string>();
            foreach (var extension in extensions)
            {
                files.AddRange(Directory.GetFiles(directoryPath, $"*{extension}", SearchOption.AllDirectories));
            }
            return files.OrderBy(f => f).ToArray();
        }
        catch (Exception)
        {
            return Array.Empty<string>();
        }
    }

    /// <summary>
    /// 获取文件的人类可读大小
    /// </summary>
    public static string GetHumanReadableFileSize(long fileSize)
    {
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        double len = fileSize;
        int order = 0;
        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len /= 1024;
        }
        return $"{len:0.##} {sizes[order]}";
    }

    /// <summary>
    /// 获取文件扩展名（不带点）
    /// </summary>
    public static string GetExtensionWithoutDot(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            return string.Empty;

        string extension = Path.GetExtension(filePath);
        if (string.IsNullOrEmpty(extension))
            return string.Empty;

        return extension.TrimStart('.');
    }

    /// <summary>
    /// 检查文件是否为图片
    /// </summary>
    public static bool IsImageFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            return false;

        string extension = Path.GetExtension(filePath).ToLowerInvariant();
        string[] imageExtensions = { ".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tiff", ".tif", ".ico", ".webp" };
        
        return imageExtensions.Contains(extension);
    }

    /// <summary>
    /// 安全地删除文件
    /// </summary>
    public static bool SafeDelete(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 安全地移动文件
    /// </summary>
    public static bool SafeMove(string sourceFilePath, string destFilePath)
    {
        try
        {
            if (File.Exists(sourceFilePath))
            {
                string destDirectory = Path.GetDirectoryName(destFilePath);
                if (!string.IsNullOrEmpty(destDirectory) && !Directory.Exists(destDirectory))
                {
                    Directory.CreateDirectory(destDirectory);
                }
                
                File.Move(sourceFilePath, destFilePath, true);
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 安全地复制文件
    /// </summary>
    public static bool SafeCopy(string sourceFilePath, string destFilePath)
    {
        try
        {
            if (File.Exists(sourceFilePath))
            {
                string destDirectory = Path.GetDirectoryName(destFilePath);
                if (!string.IsNullOrEmpty(destDirectory) && !Directory.Exists(destDirectory))
                {
                    Directory.CreateDirectory(destDirectory);
                }
                
                File.Copy(sourceFilePath, destFilePath, true);
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 获取文件的MIME类型
    /// </summary>
    public static string GetMimeType(string filePath)
    {
        string extension = Path.GetExtension(filePath).ToLowerInvariant();
        
        return extension switch
        {
            ".png" => "image/png",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".gif" => "image/gif",
            ".bmp" => "image/bmp",
            ".tiff" or ".tif" => "image/tiff",
            ".ico" => "image/x-icon",
            ".webp" => "image/webp",
            _ => "application/octet-stream"
        };
    }

    /// <summary>
    /// 创建目录（如果不存在）
    /// </summary>
    public static void EnsureDirectoryExists(string directoryPath)
    {
        if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }

    /// <summary>
    /// 获取目录中的子目录
    /// </summary>
    public static string[] GetSubdirectories(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            return Array.Empty<string>();
        }

        try
        {
            return Directory.GetDirectories(directoryPath);
        }
        catch
        {
            return Array.Empty<string>();
        }
    }

    /// <summary>
    /// 获取目录信息
    /// </summary>
    public static (int fileCount, long totalSize) GetDirectoryInfo(string directoryPath, string[] extensions)
    {
        if (!Directory.Exists(directoryPath))
        {
            return (0, 0);
        }

        try
        {
            var files = GetImageFilesRecursive(directoryPath, extensions);
            long totalSize = 0;
            
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                if (fileInfo.Exists)
                {
                    totalSize += fileInfo.Length;
                }
            }
            
            return (files.Length, totalSize);
        }
        catch
        {
            return (0, 0);
        }
    }
}