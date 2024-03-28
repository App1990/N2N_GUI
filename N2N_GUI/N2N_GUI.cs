using System;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Windows.Forms;

namespace N2N_GUI
{
    public partial class N2N_GUI : Form
    {
        Process p;

        //// 导入Win32 API方法
        //[DllImport("kernel32.dll")]
        //private static extern bool GenerateConsoleCtrlEvent(int dwCtrlEvent, int dwProcessGroupId);

        //[DllImport("kernel32.dll")]
        //private static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate HandlerRoutine, bool Add);

        //// 定义委托类型
        //private delegate bool ConsoleCtrlDelegate(int CtrlType);

        #region-- N2N_GUI()
        public N2N_GUI()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            btn__start.Enabled = true;
            btn__abort.Enabled = false;

            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var fileFullName = Path.Combine(appDataPath, Application.ProductName, "profile.xml");

            var productDataPath = Path.Combine(appDataPath, Application.ProductName);
            if (!Directory.Exists(productDataPath)) Directory.CreateDirectory(productDataPath);

            // {select_index:0,server_list:[{server_ip:"106.15.40.169",server_port:10001,group:"WeGame",password:"p@ssw0rd",dhcp_mode:0,client_ip:10.0.0.101}]}
            // <SERVER_LIST><SERVER_ITEM REMOTE_IP="106.15.40.169" REMOTE_PORT="10001" GROUP="WeGame" PASSWORD="p@ssw0rd" ASSIGNED_IP="10.0.0.101" DHCP_MODE="0" IS_SELECTED="-1"></SERVER_ITEM></SERVER_LIST>

            if (File.Exists(fileFullName))
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(File.ReadAllText(fileFullName));

                var xmlNode = xmlDoc.SelectSingleNode("//SERVER_ITEM[@IS_SELECTED='-1']");
                if (xmlNode == null) return;

                txt__remote_ip.Text = xmlNode.SelectSingleNode("@REMOTE_IP").Value;
                txt__remote_port.Text = xmlNode.SelectSingleNode("@REMOTE_PORT").Value;

                txt__group.Text = xmlNode.SelectSingleNode("@GROUP").Value;
                txt__password.Text = xmlNode.SelectSingleNode("@PASSWORD").Value;
                txt__assigned_ip.Text = xmlNode.SelectSingleNode("@ASSIGNED_IP").Value;

                xmlNode = xmlNode.SelectSingleNode("@DHCP_MODE");
                bool blnDHCPMode = xmlNode != null && xmlNode.Value == "-1";

                txt__assigned_ip.Visible = blnDHCPMode;
                check__assigned_ip.Checked = blnDHCPMode;
            }
        }
        #endregion

        #region-- btn__restart_Click()
        private void btn__start_Click(object sender, EventArgs e)
        {
            _StartEdgeNode();
        }
        #endregion

        #region-- btn__abort_Click()
        private void btn__abort_Click(object sender, EventArgs e)
        {
            try
            {
                if (p != null)
                {
                    p.Kill();
                    p.Close();

                    //_SendCtrlC(p);
                }

                btn__start.Enabled = true;
                btn__abort.Enabled = false;
                txt__log.AppendText(string.Format("{0} Abort!\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                p?.Dispose();
            }
        }
        #endregion

        #region-- N2N_GUI_FormClosed()
        private void N2N_GUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (p != null && btn__abort.Enabled)
            {
                p.Kill();
                p.Close();
                p.Dispose();

                //_SendCtrlC(p);
            }
        }
        #endregion

        #region-- btn__restart_Click()
        private void btn__restart_Click(object sender, EventArgs e)
        {
            try
            {
                if (p != null)
                    _SendCtrlC(p);

                _StartEdgeNode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region-- _StartEdgeNode()
        private void _StartEdgeNode()
        {
            try
            {
                // 保存配置信息
                var remoteIP = txt__remote_ip.Text;
                var remotePort = txt__remote_port.Text;
                var remoteVersion = comboBox__version.Text;

                var group = txt__group.Text;
                var password = txt__password.Text;
                var assignedIp = txt__assigned_ip.Text;
                var assignedIPManually = check__assigned_ip.Checked ? "-1" : "0";
                var xml = string.Format("<SERVER_LIST><SERVER_ITEM REMOTE_IP=\"{0}\" REMOTE_PORT=\"{1}\" GROUP=\"{2}\" PASSWORD=\"{3}\" ASSIGNED_IP=\"{4}\" DHCP_MODE=\"{5}\" IS_SELECTED=\"-1\"></SERVER_ITEM></SERVER_LIST>"
                        , remoteIP, remotePort, group, password, assignedIp, assignedIPManually);

                var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var fileFullName = Path.Combine(appDataPath, Application.ProductName, "profile.xml");

                File.WriteAllText(fileFullName, xml);

                CheckForIllegalCrossThreadCalls = false;

                // 上次未释放的进程
                Process[] oldProcesses = Process.GetProcessesByName($"edge_{remoteVersion}");
                foreach (Process oldProcess in oldProcesses)
                {
                    oldProcess.Kill();
                    oldProcess.Close();
                    oldProcess.Dispose();

                    //_SendCtrlC(oldProcess);
                }

                p = new Process();
                p.StartInfo.FileName = $"edge_{remoteVersion}.exe";
                p.StartInfo.WorkingDirectory = Application.StartupPath;

                // 手动指定IP地址
                if (assignedIPManually == "-1")
                {
                    p.StartInfo.Arguments = $"-a {assignedIp} -c {group} -k {password} -l {remoteIP}:{remotePort}";
                }
                else
                {
                    // 采用DHCP动态分配IP
                    //var dhcp = remoteVersion == "v3" ? "10.10.0.0/16" : "0.0.0.0";
                    p.StartInfo.Arguments = $"-r -a dhcp:{remoteIP} -c {group} -k {password} -l {remoteIP}:{remotePort}";
                }

                p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口

                p.OutputDataReceived += new DataReceivedEventHandler(_OutputHandler);
                p.ErrorDataReceived += new DataReceivedEventHandler(_OutputHandler);

                p.Start();

                p.BeginOutputReadLine();
                p.BeginErrorReadLine();

                btn__abort.Enabled = true;
                btn__start.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region-- _OutputHandler()
        private void _OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            try
            {
                if (!string.IsNullOrEmpty(outLine.Data))
                {
                    txt__log.AppendText(outLine.Data + "\r\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region-- _SendCtrlC() 发送Ctrl+C方法
        static void _SendCtrlC(Process process)
        {
            if (process.HasExited) return;

            // 向进程的控制台发送CTRL+C信号
            //GenerateConsoleCtrlEvent(0, process.Id);

            //process.WaitForExit();
        }
        #endregion

        #region-- check__assigned_ip_CheckedChanged()
        private void check__assigned_ip_CheckedChanged(object sender, EventArgs e)
        {
            txt__assigned_ip.Visible = check__assigned_ip.Checked;
        }
        #endregion

        #region-- comboBox__version_SelectedIndexChanged()
        private void comboBox__version_SelectedIndexChanged(object sender, EventArgs e)
        {
            _StartEdgeNode();
        }
        #endregion
    }
}

