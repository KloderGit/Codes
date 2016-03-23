using System;
using Renci.SshNet;
using MySql.Data.MySqlClient;
using System.Data;

namespace CodesADONet
{
    public class MySql_SSH_Connection
    {
        // Setup Credentials and Server Information
        ConnectionInfo connectionInfoSSH = new ConnectionInfo("u432805.ssh.masterhost.ru", 22, "u432805", new AuthenticationMethod[]{ new PasswordAuthenticationMethod("u432805", "re2tionoush") });

        // MySql_Native_Connection mysql;

        delegate DataTable submitAction();

        public MySql_SSH_Connection()
        {
           // mysql = new MySql_Native_Connection("127.0.0.1", "u432805", "s-2Vi-oUs5yl", "u432805", "3306");
        }


        public DataTable GetCodes()
        {
            submitAction getCodeFunction = new MySql_Native_Connection("127.0.0.1", "u432805", "s-2Vi-oUs5yl", "u432805", "3306").GetCodes;
            return ExecuteMysql(getCodeFunction);
        }

        public DataTable GetUsers()
        {
            submitAction getUserFunction = new MySql_Native_Connection("127.0.0.1", "u432805", "s-2Vi-oUs5yl", "u432805", "3306").GetUser;
            return ExecuteMysql(getUserFunction);
        }


        private DataTable ExecuteMysql(submitAction _execute)
        {
            DataTable table = new DataTable();

            using (var sshclient = new SshClient(connectionInfoSSH))
            {

                try
                {
                    sshclient.Connect();
                    Console.WriteLine("SSH установлено");

                    using (var tunnel = new ForwardedPortLocal("127.0.0.1", 3306, "u432805.mysql.masterhost.ru", 3306))
                    {
                        sshclient.AddForwardedPort(tunnel);
                        tunnel.Start();
                        Console.WriteLine("Тунель открыт");

                        table = _execute();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

                return table;
        }

    }
}
