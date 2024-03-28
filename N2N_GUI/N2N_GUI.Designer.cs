using System.Drawing;
using System.Windows.Forms;

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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(N2N_GUI));
            groupBox1 = new GroupBox();
            comboBox__version = new ComboBox();
            label5 = new Label();
            txt__remote_port = new TextBox();
            label2 = new Label();
            txt__remote_ip = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            check__assigned_ip = new CheckBox();
            txt__assigned_ip = new TextBox();
            txt__password = new TextBox();
            label4 = new Label();
            txt__group = new TextBox();
            label3 = new Label();
            btn__start = new Button();
            btn__abort = new Button();
            txt__log = new TextBox();
            btn__restart = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox__version);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txt__remote_port);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txt__remote_ip);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(26, 28);
            groupBox1.Margin = new Padding(6, 7, 6, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(6, 7, 6, 7);
            groupBox1.Size = new Size(635, 233);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Supernode";
            // 
            // comboBox__version
            // 
            comboBox__version.DisplayMember = "3";
            comboBox__version.FormattingEnabled = true;
            comboBox__version.Items.AddRange(new object[] { "v1", "v2", "v3" });
            comboBox__version.Location = new Point(500, 131);
            comboBox__version.Name = "comboBox__version";
            comboBox__version.Size = new Size(100, 36);
            comboBox__version.TabIndex = 5;
            comboBox__version.Text = "V3";
            comboBox__version.SelectedIndexChanged += comboBox__version_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(500, 72);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(88, 28);
            label5.TabIndex = 4;
            label5.Text = "Version";
            // 
            // txt__remote_port
            // 
            txt__remote_port.Location = new Point(380, 133);
            txt__remote_port.Margin = new Padding(6, 7, 6, 7);
            txt__remote_port.Name = "txt__remote_port";
            txt__remote_port.Size = new Size(100, 34);
            txt__remote_port.TabIndex = 3;
            txt__remote_port.Text = "10001";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(380, 72);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(54, 28);
            label2.TabIndex = 2;
            label2.Text = "Port";
            // 
            // txt__remote_ip
            // 
            txt__remote_ip.Location = new Point(35, 133);
            txt__remote_ip.Margin = new Padding(6, 7, 6, 7);
            txt__remote_ip.Name = "txt__remote_ip";
            txt__remote_ip.Size = new Size(325, 34);
            txt__remote_ip.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 72);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(118, 28);
            label1.TabIndex = 0;
            label1.Text = "IP Address";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(check__assigned_ip);
            groupBox2.Controls.Add(txt__assigned_ip);
            groupBox2.Controls.Add(txt__password);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txt__group);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(706, 28);
            groupBox2.Margin = new Padding(6, 7, 6, 7);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(6, 7, 6, 7);
            groupBox2.Size = new Size(633, 233);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Edge(Local Settings)";
            // 
            // check__assigned_ip
            // 
            check__assigned_ip.AutoSize = true;
            check__assigned_ip.Location = new Point(59, 177);
            check__assigned_ip.Margin = new Padding(6, 7, 6, 7);
            check__assigned_ip.Name = "check__assigned_ip";
            check__assigned_ip.Size = new Size(136, 32);
            check__assigned_ip.TabIndex = 7;
            check__assigned_ip.Text = "Static IP ?";
            check__assigned_ip.UseVisualStyleBackColor = true;
            check__assigned_ip.CheckedChanged += check__assigned_ip_CheckedChanged;
            // 
            // txt__assigned_ip
            // 
            txt__assigned_ip.Location = new Point(264, 173);
            txt__assigned_ip.Margin = new Padding(6, 7, 6, 7);
            txt__assigned_ip.Name = "txt__assigned_ip";
            txt__assigned_ip.Size = new Size(307, 34);
            txt__assigned_ip.TabIndex = 8;
            txt__assigned_ip.Visible = false;
            // 
            // txt__password
            // 
            txt__password.Location = new Point(266, 110);
            txt__password.Margin = new Padding(6, 7, 6, 7);
            txt__password.Name = "txt__password";
            txt__password.PasswordChar = '*';
            txt__password.Size = new Size(305, 34);
            txt__password.TabIndex = 3;
            txt__password.Text = "p@ssw0rd";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 117);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(108, 28);
            label4.TabIndex = 2;
            label4.Text = "Password";
            // 
            // txt__group
            // 
            txt__group.Location = new Point(266, 47);
            txt__group.Margin = new Padding(6, 7, 6, 7);
            txt__group.Name = "txt__group";
            txt__group.Size = new Size(305, 34);
            txt__group.TabIndex = 1;
            txt__group.Text = "WeGame";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 54);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(75, 28);
            label3.TabIndex = 0;
            label3.Text = "Group";
            // 
            // btn__start
            // 
            btn__start.Location = new Point(769, 870);
            btn__start.Margin = new Padding(6, 7, 6, 7);
            btn__start.Name = "btn__start";
            btn__start.Size = new Size(162, 54);
            btn__start.TabIndex = 2;
            btn__start.Text = "Start";
            btn__start.UseVisualStyleBackColor = true;
            btn__start.Click += btn__start_Click;
            // 
            // btn__abort
            // 
            btn__abort.Location = new Point(973, 870);
            btn__abort.Margin = new Padding(6, 7, 6, 7);
            btn__abort.Name = "btn__abort";
            btn__abort.Size = new Size(162, 54);
            btn__abort.TabIndex = 3;
            btn__abort.Text = "Abort";
            btn__abort.UseVisualStyleBackColor = true;
            btn__abort.Click += btn__abort_Click;
            // 
            // txt__log
            // 
            txt__log.BackColor = SystemColors.ActiveCaptionText;
            txt__log.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt__log.ForeColor = Color.White;
            txt__log.Location = new Point(26, 275);
            txt__log.Margin = new Padding(6, 7, 6, 7);
            txt__log.Multiline = true;
            txt__log.Name = "txt__log";
            txt__log.ReadOnly = true;
            txt__log.ScrollBars = ScrollBars.Vertical;
            txt__log.Size = new Size(1308, 576);
            txt__log.TabIndex = 5;
            // 
            // btn__restart
            // 
            btn__restart.Location = new Point(1176, 870);
            btn__restart.Margin = new Padding(6, 7, 6, 7);
            btn__restart.Name = "btn__restart";
            btn__restart.Size = new Size(162, 54);
            btn__restart.TabIndex = 6;
            btn__restart.Text = "Restart";
            btn__restart.UseVisualStyleBackColor = true;
            btn__restart.Click += btn__restart_Click;
            // 
            // N2N_GUI
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1365, 952);
            Controls.Add(btn__restart);
            Controls.Add(txt__log);
            Controls.Add(btn__abort);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btn__start);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6, 7, 6, 7);
            Name = "N2N_GUI";
            Text = "N2N GUI";
            FormClosed += N2N_GUI_FormClosed;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txt__remote_ip;
        private Label label1;
        private TextBox txt__remote_port;
        private Label label2;
        private GroupBox groupBox2;
        private TextBox txt__group;
        private Label label3;
        private TextBox txt__password;
        private Label label4;
        private Button btn__start;
        private Button btn__abort;
        private TextBox txt__log;
        private Button btn__restart;
        private CheckBox check__assigned_ip;
        private TextBox txt__assigned_ip;
        private Label label5;
        private ComboBox comboBox__version;
    }
}

