using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using System.IO;

namespace CNote
{
    public partial class NotesMenu : Form
    {
        public NotesMenu()
        {
            InitializeComponent();
        }

        private void NotesMenu_Activated(object sender, EventArgs e)
        {
            lstNoteList.Items.Clear();
            string path = @"..\Dependencies\notes\!Titles.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        lstNoteList.Items.Add(s);
                    }
                }
            }
            else
            {
                MessageBox.Show("File !Titles.txt is missing", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstNoteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            rchNote.Text = "";
            string currentItem = lstNoteList.SelectedItem.ToString();
            string path = @"..\Dependencies\notes\";
            path = path + currentItem + ".txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        rchNote.Text += Environment.NewLine + s;
                    }
                }
                lblTitle.Text = currentItem;
            }
            else
            {
                MessageBox.Show("The file for this note is missing", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }//

        private void NotesMenu_Load(object sender, EventArgs e)
        {
        }//

        private void rchNote_TextChanged(object sender, EventArgs e)
        {

        }//

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(56, 135, 94);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(71, 170, 119);
        }


        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(56, 135, 94);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(71, 170, 119);
        }
    }
}
