using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H1A396RimWorldSeverGUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            // 设置全局异常处理（关键代码）
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => HandleGlobalException(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                HandleGlobalException(e.ExceptionObject as Exception);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());









        }



        // 全局异常处理方法
        private static void HandleGlobalException(Exception ex)
        {
            // 终止服务端进程（需访问Form1中的变量）
            if (Form1.IsServerRunning) // 需要修改Form1暴露状态（见下文）
            {
                Form1.GameServerProcess?.Kill();
            }

            // 记录错误日志（可选）
            MessageBox.Show($"程序崩溃: {ex?.Message}");
            Environment.Exit(1);
        }
    }
}
