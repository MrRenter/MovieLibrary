using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLibrary
{
    class databaseManager
    {
        static MySqlConnection conn;

        public databaseManager()
        {
            conn = new MySqlConnection("datasource=localhost;port=3306;username=movie;password=password"); //TODO move to a settings file
        }

        public Boolean addMovie(string movieName)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("INSERT into library.movies(name, year) values('" + movieName + "', 2006)", conn); //Sql injection here
                MySqlDataReader reader;

                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                }
                return true; //Success

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean checkIfMovieExist(string movieName)
        {
            try
            {
                MySqlCommand check = new MySqlCommand("Select * from library.movies where name='" + movieName + "'", conn); //SQL injection here
                MySqlDataReader reader;

                conn.Open(); //maybe using?
                reader = check.ExecuteReader();

                if (reader.HasRows)
                {
                    return true; //Movie already exists
                } else
                {
                    return false; //Found no results
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
