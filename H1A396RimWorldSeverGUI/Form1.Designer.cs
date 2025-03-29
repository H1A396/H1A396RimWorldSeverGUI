namespace H1A396RimWorldSeverGUI
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnStartServer = new System.Windows.Forms.Button();
            this.BtnStopServer = new System.Windows.Forms.Button();
            this.BtnCrashTest = new System.Windows.Forms.Button();
            this.BtnCheckPortRelease = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnStartServer
            // 
            this.BtnStartServer.Location = new System.Drawing.Point(12, 12);
            this.BtnStartServer.Name = "BtnStartServer";
            this.BtnStartServer.Size = new System.Drawing.Size(75, 23);
            this.BtnStartServer.TabIndex = 0;
            this.BtnStartServer.Text = "启动服务";
            this.BtnStartServer.UseVisualStyleBackColor = true;
            this.BtnStartServer.Click += new System.EventHandler(this.BtnStartServer_Click);
            // 
            // BtnStopServer
            // 
            this.BtnStopServer.Location = new System.Drawing.Point(12, 41);
            this.BtnStopServer.Name = "BtnStopServer";
            this.BtnStopServer.Size = new System.Drawing.Size(75, 23);
            this.BtnStopServer.TabIndex = 1;
            this.BtnStopServer.Text = "停止服务";
            this.toolTip1.SetToolTip(this.BtnStopServer, "11");
            this.BtnStopServer.UseVisualStyleBackColor = true;
            this.BtnStopServer.Click += new System.EventHandler(this.BtnStopServer_Click);
            // 
            // BtnCrashTest
            // 
            this.BtnCrashTest.Location = new System.Drawing.Point(93, 12);
            this.BtnCrashTest.Name = "BtnCrashTest";
            this.BtnCrashTest.Size = new System.Drawing.Size(75, 23);
            this.BtnCrashTest.TabIndex = 2;
            this.BtnCrashTest.Text = "模拟崩溃";
            this.BtnCrashTest.UseVisualStyleBackColor = true;
            this.BtnCrashTest.Click += new System.EventHandler(this.BtnCrashTest_Click);
            // 
            // BtnCheckPortRelease
            // 
            this.BtnCheckPortRelease.Location = new System.Drawing.Point(93, 41);
            this.BtnCheckPortRelease.Name = "BtnCheckPortRelease";
            this.BtnCheckPortRelease.Size = new System.Drawing.Size(85, 23);
            this.BtnCheckPortRelease.TabIndex = 3;
            this.BtnCheckPortRelease.Text = "检查端口占用";
            this.toolTip1.SetToolTip(this.BtnCheckPortRelease, "延迟三秒后检查25555端口是否释放");
            this.BtnCheckPortRelease.UseVisualStyleBackColor = true;
            this.BtnCheckPortRelease.Click += new System.EventHandler(this.BtnCheckPortRelease_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 500;
            // 
            // rtbConsole
            // 
            this.rtbConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.rtbConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbConsole.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.rtbConsole.Location = new System.Drawing.Point(199, 12);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtbConsole.Size = new System.Drawing.Size(654, 370);
            this.rtbConsole.TabIndex = 4;
            this.rtbConsole.Text = "";
            // 
            // txtCommand
            // 
            this.txtCommand.Font = new System.Drawing.Font("JetBrains Mono", 9F);
            this.txtCommand.Location = new System.Drawing.Point(199, 388);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(573, 23);
            this.txtCommand.TabIndex = 5;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(778, 386);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "发送命令";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 474);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.rtbConsole);
            this.Controls.Add(this.BtnCheckPortRelease);
            this.Controls.Add(this.BtnCrashTest);
            this.Controls.Add(this.BtnStopServer);
            this.Controls.Add(this.BtnStartServer);
            this.Name = "Form1";
            this.Text = "RimWorldServerGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStartServer;
        private System.Windows.Forms.Button BtnStopServer;
        private System.Windows.Forms.Button BtnCrashTest;
        private System.Windows.Forms.Button BtnCheckPortRelease;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Button btnSend;
    }
}

