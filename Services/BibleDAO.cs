using FirstPageTry.Models;
using MySql.Data.MySqlClient;

namespace FirstPageTry.Services
{
    public class BibleDAO : IBibleDataService
    {
        //database connection string
        //string connectionString = @"datasource='localhost';port=3306;username=root;password=root;database=bible";
        //string connectionString = @"datasource='awseb-e-hk3mcbp9xc-stack-awsebrdsdatabase-hfimodqiuoha.co2unanndvzy.us-west-1.rds.amazonaws.com';port=3306;username=username;password=password;database=bible";
        //string connectionString = @"datasource='awseb-e-ncv74eszgr-stack-awsebrdsdatabase-erz8lbsf3my8.co2unanndvzy.us-west-1.rds.amazonaws.com';port=3306;username=username;password=password;database=bible";
        string connectionString = @"datasource='awseb-e-ayiu7aumsz-stack-awsebrdsdatabase-vwipaihhpug9.co2unanndvzy.us-west-1.rds.amazonaws.com';port=3306;username=username;password=password;database=bible";

        public List<BibleModel> AllVerses()
        {
            //assume nothing is found
            List<BibleModel> foundVerses = new List<BibleModel>();

            //uses prepared statements for security
            string MySqlStatement = "SELECT * FROM t_kjv limit 100";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(MySqlStatement, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundVerses.Add(new BibleModel((int)reader[0], (int)reader[1], (int)reader[2], (int)reader[3],
                            (string)reader[4]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundVerses;
        }

        public BibleModel GetVerseById(int v)
        {
            BibleModel foundVerses = null;

            //uses prepared statements for security @username @password are defined below
            string MySqlStatement = "SELECT * FROM t_kjv WHERE v = @v";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(MySqlStatement, connection);

                //define the values of the two placeholders in the sqlStatement string
                command.Parameters.AddWithValue("@v", v);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundVerses = (new BibleModel((int)reader[0], (int)reader[1], (int)reader[2], (int)reader[3],
                            (string)reader[4]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundVerses;
        }

        public List<BibleModel> SearchVerses(string searchTerm, string testament = "")
        {

            //assume nothing is found
            List<BibleModel> foundVerses = new List<BibleModel>();

            //uses prepared statements for security
            string MySqlStatement = "";

            if (testament == "OT")
            {
                MySqlStatement = "SELECT * FROM t_kjv WHERE t LIKE @t AND b < 40";
            }
            else if (testament == "NT")
            {
                MySqlStatement = "SELECT * FROM t_kjv WHERE t LIKE @t AND b >= 40";
            }
            else
            {
                MySqlStatement = "SELECT * FROM t_kjv WHERE t LIKE @t";
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(MySqlStatement, connection);

                //define the values of the two placeholderse in the MySqlStatement string
                command.Parameters.AddWithValue("@t", '%' + searchTerm + '%');

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundVerses.Add(new BibleModel((int)reader[0], (int)reader[1], (int)reader[2], (int)reader[3],
                            (string)reader[4]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
            }
            return foundVerses;
        }
    }
}
