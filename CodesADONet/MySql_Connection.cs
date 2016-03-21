using System;
using MySql.Data.MySqlClient;

namespace CodesADONet
{
    public class MySql_Connection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string connectionString;
        private string port;

        //  Конструктор
        public MySql_Connection(string _server, string _user, string _pass, string _db, string _port )
        {
            server = _server;
            database = _db;
            uid = _user;
            password = _pass;
            port = _port;

            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Соединение установлено!!!");
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                Console.WriteLine("Соединение закрыто!!!");
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void GetData()
        {
            if (OpenConnection())
            {
                var cmd = new MySqlCommand("Select * From se_usergroup", connection);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(dr.GetString(1));
                    }
                }

            }

        }
    }
}
