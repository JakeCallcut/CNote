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
            txtTitle.Text = "";
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
                txtTitle.Text = currentItem;
            }
            else
            {
                MessageBox.Show("The file for this note is missing", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string titlePath = @"..\Dependencies\notes\!Titles.txt";
            string newNotePath = @"..\Dependencies\notes\New Note.txt";
            StreamWriter sw;

            if (File.Exists(titlePath))
            {

                if (!File.Exists(newNotePath))
                {
                    sw = File.CreateText(newNotePath);
                    sw.Flush();
                    sw.Close();
                    using (sw = File.AppendText(titlePath))
                    {
                        sw.WriteLine("New Note");
                        lstNoteList.Items.Add("New Note");
                    }
                }
                else
                {
                    int i = 1;
                    bool created = false;
                    do
                    {
                        newNotePath = @"..\Dependencies\notes\New Note";
                        newNotePath = newNotePath + Convert.ToString(i) + ".txt";

                        if (!File.Exists(newNotePath))
                        {
                            sw = File.CreateText(newNotePath);
                            sw.Flush();
                            sw.Close();
                            created = true;
                            using (sw = File.AppendText(titlePath))
                            {
                                sw.WriteLine("New Note{0}", i);
                                lstNoteList.Items.Add("New Note" + i);
                            }
                        }
                        else
                        {
                            i++;
                        }
                    } while (created == false);
                }
            }
            else
            {
                MessageBox.Show("File !Titles.txt is missing", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string titlePath = @"..\Dependencies\notes\!Titles.txt";
            string currentItem = lstNoteList.SelectedItem.ToString();
            string path = @"..\Dependencies\notes\";
            path = path + currentItem + ".txt";

            string[] fileArray = File.ReadAllLines(titlePath);
            for (int i = 0; i < fileArray.Length; i++)
            {
                if ( fileArray[i] == currentItem)
                {
                    fileArray[i] = txtTitle.Text;
                    File.WriteAllLines(titlePath, fileArray);
                }
            }               

            File.WriteAllText(path, " ");
            string[] noteContents = rchNote.Lines;
            File.WriteAllLines(path, noteContents);

            string newPath = @"..\Dependencies\notes\";
            newPath = newPath + txtTitle.Text + ".txt";
            File.Move(path, newPath);

            lstNoteList.Items.Clear();
            if (File.Exists(titlePath))
            {
                using (StreamReader sr = File.OpenText(titlePath))
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
            string currentItem = lstNoteList.SelectedItem.ToString();
            var _delete = new InfoBox("Are you sure you want to delete " + currentItem);
            Program.purpose = "DELFILE";
            _delete.Show();
                                                        //last edit, doesnt wait fo ran answer
            if (Program.returned == "DEL")
            {
                rchNote.Clear();
                txtTitle.Text = "";

                string titlePath = @"..\Dependencies\notes\!Titles.txt";

                string[] fileArray = File.ReadAllLines(titlePath);
                int Index = Array.IndexOf(fileArray, currentItem);
                fileArray[Index] = "";
                /*
                for (int i = Index + 1; i < fileArray.Length; i++)      //move all items after Index back by one
                {
                    fileArray[i - 1] = fileArray[i];
                }

                */
                File.WriteAllLines(titlePath, fileArray);


                string path = @"..\Dependencies\notes\";
                path = path + currentItem + ".txt";
                File.Delete(path);
                Program.returned = "";
            }
            else
            {
                Program.returned = "";
                MessageBox.Show("it made it here");
            }
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
