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
            lstNote.Items.Clear();
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
                        lstNote.Items.Add(s);
                    }
                }
            }
            else
            {
                MessageBox.Show("The file for this note is missing", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void NotesMenu_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

    }
}
