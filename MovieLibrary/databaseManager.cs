using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    class databaseManager
    {
        static MySqlConnection conn;

        public databaseManager()
        {
            conn = new MySqlConnection("datasource=localhost;port=3306;username=movie;password=password"); //TODO move to a settings file
        }

        public Boolean addMovie(string MovieName)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("INSERT into library.movies(name, year) values('" + MovieName + "', 2006)", conn);
                MySqlCommand check = new MySqlCommand("Select * from library.movies where name='" + MovieName + "'", conn);
                MySqlDataReader reader;

                conn.Open();
                reader = check.ExecuteReader();
                if (!reader.HasRows)
                {
                    reader.Close();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                    }
                    return true; //Success
                }
            }
            catch (Exception)
            {

                throw;
            } finally
            {
                conn.Close();
            }
            return false;
        }
    }
}
