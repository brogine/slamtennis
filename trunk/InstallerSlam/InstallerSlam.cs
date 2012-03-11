using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace InstallerSlam
{
    [RunInstaller(true)]
    public partial class InstallerSlam : Installer
    {
        public InstallerSlam()
        {
            InitializeComponent();
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
            Form1 frmb = new Form1();
            frmb.ShowDialog();
            frmb.Dispose();
        }
    }
}
