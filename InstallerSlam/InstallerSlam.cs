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
            try
            {
                base.Commit(savedState);
                Form1 frmb = new Form1();
                if (frmb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmb.Dispose();                    
                }

            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ah ocurrido un error en la instalacion error devuelto: " + ex.Message, "Instalacion de Slam Tenis", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                base.Rollback(savedState);
            }
        }
    }
}
