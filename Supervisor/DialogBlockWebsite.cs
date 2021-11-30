using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisor
{
    public partial class DialogBlockWebsite : Form
    {
        public DialogBlockWebsite(string type, string web = null)
        {
            InitializeComponent();

            lbMessage.Text = "";
            Name = type;
            if (web != null)
                tbWeb.Text = web;
        }

        #region Properties
        public string Website { get; set; }
        #endregion

        #region Event
        private void tbWeb_KeyDown(object sender, KeyEventArgs e)
        {
            if (((int)e.KeyCode) == 13)
            {
                btnOK.PerformClick();
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbWeb.Text) && FormatNameWebsite(tbWeb.Text))
            {
                try
                {
                    Uri uri = new Uri(tbWeb.Text);
                    Website = uri.Host;
                }
                catch (Exception)
                {
                    Website = tbWeb.Text;
                    Website = Website.Substring(0, 4) == "www." ? Website.Substring(4) : Website;
                }
                
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion


        #region Method
        private bool FormatNameWebsite(string web)
        {
            if (!web.Contains('.'))
            {
                lbMessage.Text = "Wrong website format.";
                return false;
            }

            lbMessage.Text = "";
            return true;
        }
        #endregion
    }
}
