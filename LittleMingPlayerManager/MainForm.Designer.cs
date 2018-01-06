namespace LittleMingPlayerManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPlayTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTimeList = new System.Windows.Forms.ComboBox();
            this.btnDeleteTime = new System.Windows.Forms.Button();
            this.btnAddTime = new System.Windows.Forms.Button();
            this.picTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveConfigure = new System.Windows.Forms.Button();
            this.cbRomte = new System.Windows.Forms.CheckBox();
            this.btnSelectFloder = new System.Windows.Forms.Button();
            this.txtRemoteUrl = new System.Windows.Forms.TextBox();
            this.txtFileFormat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIPAdress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFloder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnUnstall = new System.Windows.Forms.Button();
            this.btnServiceState = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPlayTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboTimeList);
            this.groupBox1.Controls.Add(this.btnDeleteTime);
            this.groupBox1.Controls.Add(this.btnAddTime);
            this.groupBox1.Controls.Add(this.picTime);
            this.groupBox1.Location = new System.Drawing.Point(59, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 424);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "每日计划播放时间";
            // 
            // txtPlayTime
            // 
            this.txtPlayTime.Location = new System.Drawing.Point(219, 291);
            this.txtPlayTime.Name = "txtPlayTime";
            this.txtPlayTime.Size = new System.Drawing.Size(100, 31);
            this.txtPlayTime.TabIndex = 5;
            this.txtPlayTime.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "停止时间（分）：";
            // 
            // cboTimeList
            // 
            this.cboTimeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboTimeList.Location = new System.Drawing.Point(6, 30);
            this.cboTimeList.Name = "cboTimeList";
            this.cboTimeList.Size = new System.Drawing.Size(316, 256);
            this.cboTimeList.TabIndex = 3;
            // 
            // btnDeleteTime
            // 
            this.btnDeleteTime.Location = new System.Drawing.Point(6, 378);
            this.btnDeleteTime.Name = "btnDeleteTime";
            this.btnDeleteTime.Size = new System.Drawing.Size(110, 40);
            this.btnDeleteTime.TabIndex = 1;
            this.btnDeleteTime.Text = "删除时间";
            this.btnDeleteTime.UseVisualStyleBackColor = true;
            this.btnDeleteTime.Click += new System.EventHandler(this.btnDeleteTime_Click);
            // 
            // btnAddTime
            // 
            this.btnAddTime.Location = new System.Drawing.Point(212, 378);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(110, 40);
            this.btnAddTime.TabIndex = 1;
            this.btnAddTime.Text = "添加时间";
            this.btnAddTime.UseVisualStyleBackColor = true;
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // picTime
            // 
            this.picTime.CustomFormat = "HH:mm";
            this.picTime.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.picTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.picTime.Location = new System.Drawing.Point(97, 329);
            this.picTime.Name = "picTime";
            this.picTime.ShowUpDown = true;
            this.picTime.Size = new System.Drawing.Size(120, 31);
            this.picTime.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveConfigure);
            this.groupBox2.Controls.Add(this.cbRomte);
            this.groupBox2.Controls.Add(this.btnSelectFloder);
            this.groupBox2.Controls.Add(this.txtRemoteUrl);
            this.groupBox2.Controls.Add(this.txtFileFormat);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtIPAdress);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFloder);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(457, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1006, 492);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "详细配置";
            // 
            // btnSaveConfigure
            // 
            this.btnSaveConfigure.Location = new System.Drawing.Point(775, 378);
            this.btnSaveConfigure.Name = "btnSaveConfigure";
            this.btnSaveConfigure.Size = new System.Drawing.Size(152, 40);
            this.btnSaveConfigure.TabIndex = 13;
            this.btnSaveConfigure.Text = "保存配置";
            this.btnSaveConfigure.UseVisualStyleBackColor = true;
            this.btnSaveConfigure.Click += new System.EventHandler(this.btnSaveConfigure_Click);
            // 
            // cbRomte
            // 
            this.cbRomte.AutoSize = true;
            this.cbRomte.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbRomte.Location = new System.Drawing.Point(4, 236);
            this.cbRomte.Name = "cbRomte";
            this.cbRomte.Size = new System.Drawing.Size(170, 29);
            this.cbRomte.TabIndex = 4;
            this.cbRomte.Text = "启用远程控制";
            this.cbRomte.UseVisualStyleBackColor = true;
            // 
            // btnSelectFloder
            // 
            this.btnSelectFloder.Location = new System.Drawing.Point(852, 25);
            this.btnSelectFloder.Name = "btnSelectFloder";
            this.btnSelectFloder.Size = new System.Drawing.Size(87, 41);
            this.btnSelectFloder.TabIndex = 12;
            this.btnSelectFloder.Text = "选择";
            this.btnSelectFloder.UseVisualStyleBackColor = true;
            this.btnSelectFloder.Click += new System.EventHandler(this.btnSelectFloder_Click);
            // 
            // txtRemoteUrl
            // 
            this.txtRemoteUrl.Location = new System.Drawing.Point(193, 236);
            this.txtRemoteUrl.Name = "txtRemoteUrl";
            this.txtRemoteUrl.Size = new System.Drawing.Size(739, 31);
            this.txtRemoteUrl.TabIndex = 11;
            // 
            // txtFileFormat
            // 
            this.txtFileFormat.Location = new System.Drawing.Point(129, 186);
            this.txtFileFormat.Name = "txtFileFormat";
            this.txtFileFormat.Size = new System.Drawing.Size(804, 31);
            this.txtFileFormat.TabIndex = 11;
            this.txtFileFormat.Text = "*.mp3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "文件格式";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(129, 128);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(804, 31);
            this.txtPort.TabIndex = 11;
            this.txtPort.Text = "9898";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "内网端口";
            // 
            // txtIPAdress
            // 
            this.txtIPAdress.Location = new System.Drawing.Point(129, 81);
            this.txtIPAdress.Name = "txtIPAdress";
            this.txtIPAdress.Size = new System.Drawing.Size(804, 31);
            this.txtIPAdress.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "内网地址";
            // 
            // txtFloder
            // 
            this.txtFloder.Location = new System.Drawing.Point(129, 30);
            this.txtFloder.Name = "txtFloder";
            this.txtFloder.Size = new System.Drawing.Size(716, 31);
            this.txtFloder.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "音乐文件夹";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInstall);
            this.groupBox3.Controls.Add(this.btnUnstall);
            this.groupBox3.Controls.Add(this.btnServiceState);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(87, 582);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1313, 234);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "状态";
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(1149, 172);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(156, 49);
            this.btnInstall.TabIndex = 2;
            this.btnInstall.Text = "保存并运行";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnUnstall
            // 
            this.btnUnstall.Location = new System.Drawing.Point(8, 179);
            this.btnUnstall.Name = "btnUnstall";
            this.btnUnstall.Size = new System.Drawing.Size(155, 43);
            this.btnUnstall.TabIndex = 1;
            this.btnUnstall.Text = "卸载";
            this.btnUnstall.UseVisualStyleBackColor = true;
            this.btnUnstall.Click += new System.EventHandler(this.btnUnstall_Click);
            // 
            // btnServiceState
            // 
            this.btnServiceState.Location = new System.Drawing.Point(167, 38);
            this.btnServiceState.Name = "btnServiceState";
            this.btnServiceState.Size = new System.Drawing.Size(451, 43);
            this.btnServiceState.TabIndex = 1;
            this.btnServiceState.Text = "未安装";
            this.btnServiceState.UseVisualStyleBackColor = true;
            this.btnServiceState.Click += new System.EventHandler(this.btnServiceState_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "服务状态";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1574, 866);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "播放器管理";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker picTime;
        private System.Windows.Forms.ComboBox cboTimeList;
        private System.Windows.Forms.Button btnAddTime;
        private System.Windows.Forms.TextBox txtPlayTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSelectFloder;
        private System.Windows.Forms.TextBox txtRemoteUrl;
        private System.Windows.Forms.TextBox txtFileFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIPAdress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFloder;
        private System.Windows.Forms.CheckBox cbRomte;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnServiceState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveConfigure;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnDeleteTime;
        private System.Windows.Forms.Button btnUnstall;
    }
}