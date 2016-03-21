using System;
using Renci.SshNet;
using MySql.Data.MySqlClient;

namespace CodesADONet
{
    public class MySql_SSH_Connection
    {
        // Setup Credentials and Server Information
        ConnectionInfo ConnNfo = new ConnectionInfo("u432805.ssh.masterhost.ru", 22, "u432805", new AuthenticationMethod[]{ new PasswordAuthenticationMethod("u432805", "re2tionoush") });

        public MySql_SSH_Connection()
        {
            // Execute a (SHELL) Command - prepare upload directory
            using (var sshclient = new SshClient(ConnNfo))
            {
                try
                {
                    sshclient.Connect();

                    // var tunnel = new ForwardedPortLocal("127.0.0.1", 3306, "u10223.mysql.masterhost.ru", 3306);

                    var tunnel = new ForwardedPortLocal("127.0.0.1", 3306, "u432805.mysql.masterhost.ru", 3306);

                    sshclient.AddForwardedPort(tunnel);
                    tunnel.Start();

                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!");

                    readTable();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }

        }


        public void readTable()
        {
            //var p = new MySql_Connection("127.0.0.1", "u10223", "ption93r", "u10223", "3306");

            // var p = new MySql_Connection("217.16.28.213", "reader", "NtJzEqEmbt2", "fpa", "3306");

            var p = new MySql_Connection("127.0.0.1", "u432805", "s-2Vi-oUs5yl", "u432805", "3306");

            p.OpenConnection();
            //p.GetData();
            p.CloseConnection();
        }

        

    }
}
