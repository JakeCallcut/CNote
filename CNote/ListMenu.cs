using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace CNote
{
    public partial class ListMenu : Form
    {
        public ListMenu()
        {
            InitializeComponent();
        }

        public void LoadLists()
        {
            lstListList.Items.Clear();
            string titlePath = @"..\Dependencies\lists\!Titles.txt";
            if (File.Exists(titlePath))
            {
                using (StreamReader sr = File.OpenText(titlePath))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        lstListList.Items.Add(s);
                    }
                }
            }
            else
            {
                MessageBox.Show("File !Titles.txt is missing", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void ListMenu_Activated(object sender, EventArgs e)
        {
            LoadLists();
        }
    }
}
