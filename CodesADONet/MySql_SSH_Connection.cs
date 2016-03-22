using System;
using Renci.SshNet;
using MySql.Data.MySqlClient;
using System.Data;

namespace CodesADONet
{
    public class MySql_SSH_Connection
    {
        // Setup Credentials and Server Information
        ConnectionInfo ConnNfo = new ConnectionInfo("u432805.ssh.masterhost.ru", 22, "u432805", new AuthenticationMethod[]{ new PasswordAuthenticationMethod("u432805", "re2tionoush") });
        ForwardedPortLocal tunnel = new ForwardedPortLocal("127.0.0.1", 3306, "u432805.mysql.masterhost.ru", 3306);
        SshClient sshclient;
        MySql_Connection mysql;

        delegate DataTable submitAction();

        public MySql_SSH_Connection()
        {
            mysql = new MySql_Connection("127.0.0.1", "u432805", "s-2Vi-oUs5yl", "u432805", "3306");
        }


        public DataTable GetCodes()
        {
            submitAction getCodeFunction = mysql.GetCodes;
            return ExecuteMysql(getCodeFunction);
        }

        public DataTable GetUsers()
        {
            submitAction getUserFunction = mysql.GetUser;
            return ExecuteMysql(getUserFunction);
        }


        private DataTable ExecuteMysql(submitAction _execute)
        {
            DataTable table = new DataTable();

            using (sshclient = new SshClient(ConnNfo))
            {

                try
                {
                    sshclient.Connect();
                    sshclient.AddForwardedPort(tunnel);
                    tunnel.Start();
                    Console.WriteLine("SSH установлено, тунель открыт");

                    table = _execute();
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
