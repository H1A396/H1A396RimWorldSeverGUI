using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; // 用于Process类
using System.IO;          // 用于流操作
using System.Net.Sockets;


///4654
namespace H1A396RimWorldSeverGUI
{
    public partial class Form1: Form
    {
        //进程管理相关
        private Process gameServerProcess; // 新增的进程对象
        private bool isServerRunning = false; // 新增状态标记，服务端是否运行的布尔变量
        private readonly StringBuilder _outputBuffer = new StringBuilder(); // 输出缓冲
        private System.Timers.Timer _outputTimer; // 输出刷新定时器



        // 新增静态属性（供Program.cs访问）
        public static bool IsServerRunning => ((Form1)Application.OpenForms["Form1"])?.isServerRunning ?? false;
        public static Process GameServerProcess => ((Form1)Application.OpenForms["Form1"])?.gameServerProcess;

        private const int ServerPort = 25555; // 替换为你的实际端口号
        // 或者从配置文件读取（推荐）



        private Process _serverProcess; // 服务端进程对象
        
        





        private void AppendLog(string text)
        {
            if (string.IsNullOrEmpty(text)) return;

            // 使用 Invoke 确保线程安全
            if (rtbConsole.InvokeRequired)
            {
                rtbConsole.Invoke(new Action<string>(AppendLog), text);
            }
            else
            {
                rtbConsole.AppendText($"{DateTime.Now:HH:mm:ss} - {text}\n");
                rtbConsole.SelectionStart = rtbConsole.TextLength;
                rtbConsole.ScrollToCaret(); // 自动滚动到底部
            }
        }


        public Form1()//初始化组件
        {
            InitializeComponent();
        }



        //启动服务按钮，
        private void BtnStartServer_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("按钮已点击！");//弹出窗口显示消息
            try
            {
                // 配置进程启动参数
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "GameServer.exe",    // 程序名称（确保路径正确）
                    UseShellExecute = false,         // 必须为false才能重定向流
                    RedirectStandardInput = true,    // 允许发送输入命令
                    RedirectStandardOutput = true,   // 捕获标准输出
                    RedirectStandardError = true,    // 捕获错误输出
                    CreateNoWindow = true,           // 不显示控制台窗口
                    WorkingDirectory = Application.StartupPath, // 设置工作目录（可选）
                    StandardOutputEncoding = Encoding.UTF8, // 指定编码（与服务端输出一致）
                    StandardErrorEncoding = Encoding.UTF8
                };

                // 创建进程对象
                gameServerProcess = new Process { StartInfo = startInfo };
                gameServerProcess.StartInfo = startInfo;

                // 绑定输出事件
                gameServerProcess.OutputDataReceived += (s, args) => AppendLog($"[输出] {args.Data}");
                gameServerProcess.ErrorDataReceived += (s, args) => AppendLog($"[错误] {args.Data}");


                // 启动进程
                gameServerProcess.Start();

                // 开始异步读取输出
                gameServerProcess.BeginOutputReadLine();
                gameServerProcess.BeginErrorReadLine();


                isServerRunning = true; // 新增状态标记
                // 更新按钮状态（后续会优化）
                BtnStartServer.Enabled = false;
                BtnStopServer.Enabled = true;
                MessageBox.Show("服务端已启动！");
            }
            catch (Exception ex)
            {
                AppendLog($"启动失败: {ex.Message}");
            }
        }




        // 当窗口即将关闭时，会自动触发这个方法
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // 如果服务器正在运行 并且 进程对象存在
            if (isServerRunning && gameServerProcess != null)
            {
                // 第一步：尝试友好地关闭
                try
                {
                    // 向服务器控制台输入"quit"命令（就像你在cmd里手动输入quit一样）
                    gameServerProcess.StandardInput.WriteLine("quit");
                    AppendLog("已发送quit退出命令"); // 在日志中记录这个操作

                    // 等待最多3秒，看服务器是否能自己退出
                    gameServerProcess.WaitForExit(3000);
                }
                catch // 如果上面任何一步出错（比如进程突然崩溃）
                {
                    // 这里不做处理，直接跳过（继续执行后续代码）
                }

                // 第二步：强制终止（如果3秒后还没退出）
                if (!gameServerProcess.HasExited) // 检查进程是否还在运行
                {
                    gameServerProcess.Kill();      // 强制杀死进程（类似任务管理器结束进程）
                    gameServerProcess.Dispose();   // 释放相关资源
                    AppendLog("服务端已强制终止"); // 记录强制终止日志
                }

            }

            base.OnFormClosing(e);
        }




        //停止服务按钮，关闭服务端
        private void BtnStopServer_Click(object sender, EventArgs e)
        {
            if (isServerRunning && gameServerProcess != null)
            {
                gameServerProcess.StandardInput.WriteLine("quit");
                gameServerProcess.WaitForExit(1000);

                if (!gameServerProcess.HasExited)
                {
                    gameServerProcess.Kill();
                }

                gameServerProcess.Dispose();
                isServerRunning = false;
                BtnStartServer.Enabled = true;
                AppendLog("服务端已正常停止");
            }

        }




        //进行一次模拟崩溃测试的按钮
        private void BtnCrashTest_Click(object sender, EventArgs e)
        {
            // 人为触发一个异常
            throw new InvalidOperationException("这是一个模拟崩溃测试！");
        }





        //检查端口是否释放的方法
        private async void CheckPortReleased()
        {
            await Task.Delay(3000); // 等待3秒
            try
            {
                using (var portChecker = new System.Net.Sockets.TcpClient())
                {
                    // 尝试连接目标端口
                    portChecker.Connect("127.0.0.1", ServerPort);

                    // 如果连接成功，说明端口仍被占用
                    AppendLog($"警告：端口 {ServerPort} 未释放！");
                }
            }
            catch (SocketException ex) when (ex.SocketErrorCode == SocketError.ConnectionRefused)
            {
                // 连接被拒绝（正常情况，端口已释放）
                AppendLog($"端口 {ServerPort} 已释放");
            }
            catch (Exception ex)
            {
                AppendLog($"端口检查失败: {ex.Message}");
            }
        }

        

        //检查端口是否释放按钮
        private void BtnCheckPortRelease_Click(object sender, EventArgs e)
        {
            CheckPortReleased(); // 新增检查
        }
    }
}
