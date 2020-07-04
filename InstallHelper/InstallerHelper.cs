using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstallHelper
{
    [RunInstaller(true)]
    public partial class InstallerHelper : Installer
    {
        public InstallerHelper()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            string pathValue = $@"{Context.Parameters["rootPath"].Replace("/", "")}bin\";

            SysEnv.SetPath(pathValue);
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);

            string pathValue = $@"{Context.Parameters["rootPath"].Replace("/", "")}bin\";

            SysEnv.RemovePath(pathValue);
        }
    }
}
