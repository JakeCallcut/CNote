using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNote
{
    public partial class InfoBox : Form
    {
        public InfoBox(string _text)
        {
            InitializeComponent();
            this.lblText.Text = _text;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (Program.purpose == "EXIT")
            {
                Application.Exit();
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (Program.purpose == "EXIT")
            {
                this.Close();
            }
        }
    }
}
