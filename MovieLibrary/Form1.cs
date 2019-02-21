using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace MovieLibrary
{
    public partial class Form1 : Form
    {
        static databaseManager db;
        public Form1()
        {
            InitializeComponent();
            db = new databaseManager();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (movieTextBox.TextLength > 0)
            {
                if (db.addMovie(movieTextBox.Text))
                {
                    MessageBox.Show("Success");
                } else
                {
                    MessageBox.Show("Failure");
                }
            }
            else
            {
                MessageBox.Show("Field cannot be empty!");
            }
        }
    }
}
