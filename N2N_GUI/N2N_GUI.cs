using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace N2N_GUI
{
    public partial class N2N_GUI : Form
    {
        Process p;

        public N2N_GUI()
        {
            InitializeComponent();

            btn__start.Enabled = true;
            btn__abort.Enabled = false;
            string strFileFullName = Path.Combine(Application.StartupPath, "N2N_GUI.ini");

            //<CONFIG_DATA><N2N_GUI_SETUP REMOTE_IP="106.15.40.169" REMOTE_PORT="10001" GROUP="WeGame" PASSWORD="p@ssw0rd" ASSIGNED_IP="10.0.0.101"></N2N_GUI_SETUP></CONFIG_DATA>

            if (File.Exists(strFileFullName))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(File.ReadAllText(strFileFullName));

                txt__remote_ip.Text = xmlDoc.SelectSingleNode("//@REMOTE_IP").Value;
                txt__remote_port.Text = xmlDoc.SelectSingleNode("//@REMOTE_PORT").Value;

                txt__group.Text = xmlDoc.SelectSingleNode("//@GROUP").Value;
                txt__password.Text = xmlDoc.SelectSingleNode("//@PASSWORD").Value;
                txt__assigned_ip.Text = xmlDoc.SelectSingleNode("//@ASSIGNED_IP").Value;
            }
        }

        private void btn__start_Click(object sender, EventArgs e)
        {
            try
            {
                // 保存配置信息
                string strRemoteIP = txt__remote_ip.Text;
                string strRemotePort = txt__remote_port.Text;

                string strGroup = txt__group.Text;
                string strPassword = txt__password.Text;
                string strAssignedIp = txt__assigned_ip.Text;
                string strXml = string.Format("<CONFIG_DATA><N2N_GUI_SETUP REMOTE_IP=\"{0}\" REMOTE_PORT=\"{1}\" GROUP=\"{2}\" PASSWORD=\"{3}\" ASSIGNED_IP=\"{4}\"></N2N_GUI_SETUP></CONFIG_DATA>"
                        , strRemoteIP, strRemotePort, strGroup, strPassword, strAssignedIp);

                string strFileFullName = Path.Combine(Application.StartupPath, "N2N_GUI.ini");
                File.WriteAllText(strFileFullName, strXml);

                CheckForIllegalCrossThreadCalls = false;

                // 上次未释放的进程
                Process[] oldProcesses = Process.GetProcessesByName("edge_v2");
                foreach (Process oldProcess in oldProcesses)
                {
                    oldProcess.Kill();
                    oldProcess.Close();
                    oldProcess.Dispose();
                }

                p = new Process();

                p.StartInfo.FileName = "edge_v2.exe";
                p.StartInfo.WorkingDirectory = Application.StartupPath;
                p.StartInfo.Arguments = string.Format("-a {0} -c {1} -k {2} -l {3}:{4}", strAssignedIp, strGroup, strPassword, strRemoteIP, strRemotePort);//传递的参数

                p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);

                p.Start();
                p.BeginOutputReadLine();

                btn__abort.Enabled = true;
                btn__start.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            try
            {
                if (!String.IsNullOrEmpty(outLine.Data))
                {
                    lst__log.Items.Add(outLine.Data);
                    lst__log.TopIndex = lst__log.Items.Count - lst__log.Height / lst__log.ItemHeight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn__abort_Click(object sender, EventArgs e)
        {
            try
            {
                if (p != null)
                {
                    p.Kill();
                    p.Close();
                }

                btn__start.Enabled = true;
                btn__abort.Enabled = false;
                lst__log.Items.Add(string.Format("{0} Abort!", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (p != null) p.Dispose();
            }
        }

        private void N2N_GUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (p != null && btn__abort.Enabled)
            {
                p.Kill();
                p.Close();
                p.Dispose();
            }
        }
    }
}
