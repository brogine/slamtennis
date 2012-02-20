using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Slam
{
    partial class FrmAcerca : Form
    {
        public FrmAcerca()
        {
            InitializeComponent();
                       
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
