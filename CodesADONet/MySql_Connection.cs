using System;
using MySql.Data.MySqlClient;
using System.Data;

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

            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "PORT=" + _port + ";" + "Allow Zero Datetime=true;";

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


        public DataTable GetCodes()
        {
            var table = new DataTable();

            if (OpenConnection())
            {
                var CodesAdapter = new MySqlDataAdapter("Select id, code, status, user_id, type, exp_data From code_activation where user_id != 0", connection);

                CodesAdapter.Fill(table);

                CloseConnection();
            }

            return table;
        }

        public DataTable GetUser()
        {
            var table = new DataTable();

            if (OpenConnection())
            {
                var CodesAdapter = new MySqlDataAdapter("Select * From b_blog_post", connection);

                CodesAdapter.Fill(table);

                CloseConnection();
            }

            return table;
        }
    }
}
