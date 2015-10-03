using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace coInventory.Mini
{
    public partial class frmXemBaoCao : Form
    {
        public frmXemBaoCao()
        {
            InitializeComponent();
        }

        private void frmXemBaoCao_Load(object sender, EventArgs e)
        {
           lblLink.Text= ConfigurationManager.AppSettings["LinkBaoCao"];
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(lblLink.Text);
            Close();
        }
    }
}
