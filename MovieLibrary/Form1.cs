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
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (movieTextBox.TextLength > 0) { 
                try
                {
                string connection = "datasource=localhost;port=3306;username=movie;password=password";
                
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    MySqlCommand command = new MySqlCommand("INSERT into library.movies(name, year) values('" + movieTextBox.Text + "', 2006)", conn);
                    MySqlCommand check = new MySqlCommand("Select * from library.movies where name='" + movieTextBox.Text + "'", conn);
                    MySqlDataReader MyReader2;
                    
                        conn.Open();
                        MyReader2 = check.ExecuteReader();
                        if (!MyReader2.HasRows)
                        {
                        MyReader2.Close();
                            MyReader2 = command.ExecuteReader();
                            while (MyReader2.Read())
                            {

                            }
                            MessageBox.Show("Added to table");

                        }
                        else
                        {
                            MessageBox.Show("Already Exists");
                        }
                        conn.Close();
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            } else
            {
                MessageBox.Show("Field Cannot Be Empty!");
            }
        }
    }
}
