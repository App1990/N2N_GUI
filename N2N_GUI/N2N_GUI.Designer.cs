namespace N2N_GUI
{
    partial class N2N_GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(N2N_GUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt__remote_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt__remote_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.check__assigned_ip = new System.Windows.Forms.CheckBox();
            this.txt__assigned_ip = new System.Windows.Forms.TextBox();
            this.txt__password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt__group = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn__start = new System.Windows.Forms.Button();
            this.btn__abort = new System.Windows.Forms.Button();
            this.txt__log = new System.Windows.Forms.TextBox();
            this.btn__restart = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt__remote_port);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt__remote_ip);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supernode";
            // 
            // txt__remote_port
            // 
            this.txt__remote_port.Location = new System.Drawing.Point(214, 57);
            this.txt__remote_port.Name = "txt__remote_port";
            this.txt__remote_port.Size = new System.Drawing.Size(53, 21);
            this.txt__remote_port.TabIndex = 3;
            this.txt__remote_port.Text = "10001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // txt__remote_ip
            // 
            this.txt__remote_ip.Location = new System.Drawing.Point(16, 57);
            this.txt__remote_ip.Name = "txt__remote_ip";
            this.txt__remote_ip.Size = new System.Drawing.Size(151, 21);
            this.txt__remote_ip.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.check__assigned_ip);
            this.groupBox2.Controls.Add(this.txt__assigned_ip);
            this.groupBox2.Controls.Add(this.txt__password);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt__group);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(326, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edge(Local Settings)";
            // 
            // check__assigned_ip
            // 
            this.check__assigned_ip.AutoSize = true;
            this.check__assigned_ip.Location = new System.Drawing.Point(27, 76);
            this.check__assigned_ip.Name = "check__assigned_ip";
            this.check__assigned_ip.Size = new System.Drawing.Size(90, 16);
            this.check__assigned_ip.TabIndex = 7;
            this.check__assigned_ip.Text = "Static IP ?";
            this.check__assigned_ip.UseVisualStyleBackColor = true;
            this.check__assigned_ip.CheckedChanged += new System.EventHandler(this.check__assigned_ip_CheckedChanged);
            // 
            // txt__assigned_ip
            // 
            this.txt__assigned_ip.Location = new System.Drawing.Point(122, 74);
            this.txt__assigned_ip.Name = "txt__assigned_ip";
            this.txt__assigned_ip.Size = new System.Drawing.Size(144, 21);
            this.txt__assigned_ip.TabIndex = 8;
            this.txt__assigned_ip.Visible = false;
            // 
            // txt__password
            // 
            this.txt__password.Location = new System.Drawing.Point(123, 47);
            this.txt__password.Name = "txt__password";
            this.txt__password.PasswordChar = '*';
            this.txt__password.Size = new System.Drawing.Size(143, 21);
            this.txt__password.TabIndex = 3;
            this.txt__password.Text = "p@ssw0rd";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password";
            // 
            // txt__group
            // 
            this.txt__group.Location = new System.Drawing.Point(123, 20);
            this.txt__group.Name = "txt__group";
            this.txt__group.Size = new System.Drawing.Size(143, 21);
            this.txt__group.TabIndex = 1;
            this.txt__group.Text = "WeGame";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Group";
            // 
            // btn__start
            // 
            this.btn__start.Location = new System.Drawing.Point(355, 373);
            this.btn__start.Name = "btn__start";
            this.btn__start.Size = new System.Drawing.Size(75, 23);
            this.btn__start.TabIndex = 2;
            this.btn__start.Text = "Start";
            this.btn__start.UseVisualStyleBackColor = true;
            this.btn__start.Click += new System.EventHandler(this.btn__start_Click);
            // 
            // btn__abort
            // 
            this.btn__abort.Location = new System.Drawing.Point(449, 373);
            this.btn__abort.Name = "btn__abort";
            this.btn__abort.Size = new System.Drawing.Size(75, 23);
            this.btn__abort.TabIndex = 3;
            this.btn__abort.Text = "Abort";
            this.btn__abort.UseVisualStyleBackColor = true;
            this.btn__abort.Click += new System.EventHandler(this.btn__abort_Click);
            // 
            // txt__log
            // 
            this.txt__log.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt__log.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt__log.ForeColor = System.Drawing.Color.White;
            this.txt__log.Location = new System.Drawing.Point(12, 118);
            this.txt__log.Multiline = true;
            this.txt__log.Name = "txt__log";
            this.txt__log.ReadOnly = true;
            this.txt__log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt__log.Size = new System.Drawing.Size(606, 249);
            this.txt__log.TabIndex = 5;
            // 
            // btn__restart
            // 
            this.btn__restart.Location = new System.Drawing.Point(543, 373);
            this.btn__restart.Name = "btn__restart";
            this.btn__restart.Size = new System.Drawing.Size(75, 23);
            this.btn__restart.TabIndex = 6;
            this.btn__restart.Text = "Restart";
            this.btn__restart.UseVisualStyleBackColor = true;
            this.btn__restart.Click += new System.EventHandler(this.btn__restart_Click);
            // 
            // N2N_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 408);
            this.Controls.Add(this.btn__restart);
            this.Controls.Add(this.txt__log);
            this.Controls.Add(this.btn__abort);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn__start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "N2N_GUI";
            this.Text = "N2N GUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.N2N_GUI_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt__remote_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt__remote_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt__group;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt__password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn__start;
        private System.Windows.Forms.Button btn__abort;
        private System.Windows.Forms.TextBox txt__log;
        private System.Windows.Forms.Button btn__restart;
        private System.Windows.Forms.CheckBox check__assigned_ip;
        private System.Windows.Forms.TextBox txt__assigned_ip;
    }
}

