using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manegment_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnViewBooks_Click(object sender, EventArgs e)
        {
            MessageBox.Show("View Books Form Opened");
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Book Form Opened");
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Issue Book Form Opened");
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Return Book Form Opened");
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Student Form Opened");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
