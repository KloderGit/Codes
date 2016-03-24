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
        SshClient sshclient;
        ForwardedPortLocal tunnel;
        MySql_Native_Connection mysql;

        delegate DataTable submitAction();

        public MySql_SSH_Connection()
        {
           mysql = new MySql_Native_Connection("127.0.0.1", "u432805", "s-2Vi-oUs5yl", "u432805", "3306");
           sshclient = new SshClient(connectionInfoSSH);
            sshclient.Connect();
            Console.WriteLine("SSH установлено");
            tunnel = new ForwardedPortLocal("127.0.0.1", 3306, "u432805.mysql.masterhost.ru", 3306);
            sshclient.AddForwardedPort(tunnel);
            tunnel.Start();
            Console.WriteLine("Тунель открыт");
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
            return _execute();
        }

    }
}
