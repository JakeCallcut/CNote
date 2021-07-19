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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Program.purpose = "EXIT";
            InfoBox _info = new InfoBox("Are you sure?");
            _info.Text = "Quit CNote?";
            _info.Show();
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            NotesMenu _notes = new NotesMenu();
            _notes.Show();
            this.Hide();
        }
    }
}
