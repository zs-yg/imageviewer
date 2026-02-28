namespace imageviewer;

static class Program
{
    /// <summary>
    ///  应用程序的主入口点。
    /// </summary>
    [STAThread]
    static void Main()
    {
        try
        {
            ApplicationConfiguration.Initialize();
            
            // 设置未处理异常处理程序
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
            Application.Run(new Forms.MainForm());
        }
        catch (Exception ex)
        {
            ShowErrorDialog("应用程序启动失败", ex);
        }
    }
    
    private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
        ShowErrorDialog("未处理的线程异常", e.Exception);
    }
    
    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception ex)
        {
            ShowErrorDialog("未处理的应用程序域异常", ex);
        }
    }
    
    private static void ShowErrorDialog(string title, Exception ex)
    {
        string errorMessage = $"{title}:\n\n{ex.Message}\n\n堆栈跟踪:\n{ex.StackTrace}";
        
        MessageBox.Show(errorMessage, "错误", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}