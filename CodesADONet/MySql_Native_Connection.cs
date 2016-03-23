using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace CodesADONet
{
    public class MySql_Native_Connection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string connectionString;
        private string port;

        public MySql_Native_Connection(string _server, string _user, string _pass, string _db, string _port)
        {
            server = _server;
            database = _db;
            uid = _user;
            password = _pass;
            port = _port;

            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "PORT=" + _port + ";" + "Allow Zero Datetime=true;";

      //      connection = new MySqlConnection(connectionString);
        }


        //open connection to database
        public bool OpenConnection(MySqlConnection connection)
        {
            try
            {
                connection.Open();
                 Console.WriteLine("MySQL - Соединение установлено!!!");
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
                    default:
                        Console.WriteLine(ex.Message);
                        break;

                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection(MySqlConnection connection)
        {
            try
            {
                connection.Close();
                Console.WriteLine("MySQL - Соединение закрыто!!!");
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

            using (var connection = new MySqlConnection(connectionString))
            {
                if (OpenConnection(connection))
                {
                    var CodesAdapter = new MySqlDataAdapter("Select id, code, status, user_id, type, exp_data From code_activation where user_id != 0", connection);

                    CodesAdapter.Fill(table);

                    CloseConnection(connection);
                }
            }

            return table;
        }

        public DataTable GetUser()
        {
            var table = new DataTable();

            string sql = "SELECT " +
                               "b_user.ID, " +
                               "b_user. NAME, " +
                               "b_user.LAST_NAME, " +
                               "b_user.SECOND_NAME, " +
                               "b_user.EMAIL, " +
                               "b_user.LOGIN, " +
                               "b_user.PERSONAL_PHONE, " +
                               "b_uts_user.UF_CARDNUMBER, " +
                               "b_uts_user.UF_SKYPE " +
                          "from b_user " +
                          "LEFT JOIN b_uts_user on b_uts_user.VALUE_ID = b_user.ID " +
                          "WHERE(b_uts_user.UF_CARDNUMBER is not NULL) AND(b_uts_user.UF_CARDNUMBER != 'empty')";

            using (var connection = new MySqlConnection(connectionString))
            {
                if (OpenConnection(connection))
                {
                    var CodesAdapter = new MySqlDataAdapter(sql, connection);

                    CodesAdapter.Fill(table);

                    CloseConnection(connection);
                }

            }

            return table;
        }
    }
}
