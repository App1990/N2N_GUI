using System;
using System.Text;
using System.Linq;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace InstallHelper
{
    public static class SysEnv
    {
        #region-- GetSysEnvironmentByName() 获取注册表中的环境变量
        /// <summary>
        /// 获取系统环境变量
        /// </summary>
        public static string GetSysEnvironmentByName(string name)
        {
            try
            {
                return OpenSysEnvironment().GetValue(name).ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        #endregion

        #region-- OpenSysEnvironment() 打开系统环境变量注册表
        /// <summary>
        /// 打开系统环境变量注册表
        /// </summary>
        public static RegistryKey OpenSysEnvironment()
        {
            RegistryKey regKey = null;
            try
            {
                regKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);

                regKey = regKey.OpenSubKey(@"SYSTEM\ControlSet001\Control\Session Manager\Environment", true);

                return regKey;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                //if (regKey != null)
                //{
                //    regKey.Close();
                //    regKey.Dispose();
                //}
            }
        }
        #endregion

        #region-- SetSysEnvironment() 设置系统环境变量
        /// <summary>
        /// 设置系统环境变量
        /// </summary>
        public static void SetSysEnvironment(string name, string strValue)
        {
            OpenSysEnvironment().SetValue(name, strValue);
        }
        #endregion

        #region-- CheckSysEnvironmentExist() 检测系统环境变量是否存在
        /// <summary>
        /// 检测系统环境变量是否存在
        /// </summary>
        public static bool CheckSysEnvironmentExist(string name)
        {
            return !string.IsNullOrEmpty(GetSysEnvironmentByName(name));
        }
        #endregion

        #region-- SetPath() 系统环境变量PATH添加路径
        /// <summary>
        /// 系统环境变量PATH添加值
        /// </summary>
        public static void SetPath(string value, bool first = false)
        {
            string pathList = GetSysEnvironmentByName("Path");

            if (string.IsNullOrEmpty(pathList)) return;

            string[] list = pathList.Split(';');
            if (list.Contains(value)) return;

            string[] newList = new string[] { value };

            SetSysEnvironment("Path", string.Join(";", (first? newList.Concat(list): list.Concat(newList)).ToArray()));
        }
        #endregion

        #region-- RemovePath() 系统环境变量PATH移除路径
        /// <summary>
        /// 系统环境变量PATH移除路径
        /// </summary>
        public static void RemovePath(string value)
        {
            string pathList = GetSysEnvironmentByName("Path");

            if (string.IsNullOrEmpty(pathList)) return;

            List<string> list = pathList.Split(';').ToList();
            list.Remove(value);
            SetSysEnvironment("Path", string.Join(";", list));
        }
        #endregion
    }

    //Kernel32.DLL内有SetEnvironmentVariable函数用于设置系统环境变量
    //C#调用要用DllImport，代码封装如下：
    class SetSysEnvironmentVariable
    {
        [DllImport("Kernel32.DLL ", SetLastError = true)]
        public static extern bool SetEnvironmentVariable(string lpName, string lpValue);

        public static void SetPath(string pathValue, bool before = false)
        {
            string pathList = SysEnv.GetSysEnvironmentByName("Path");

            if (string.IsNullOrEmpty(pathList)) return;

            string[] list = pathList.Split(';');
            if (list.Contains(pathValue)) return;

            string[] newList = new string[] { pathValue };

            if (before)
                newList.Concat(list);
            else
                list.Concat(newList);

            SetEnvironmentVariable("Path", string.Join(";", list));
        }
    }
}
