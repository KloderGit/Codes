using System;
using Renci.SshNet;
using MySql.Data.MySqlClient;

namespace CodesADONet
{
    public class MySql_Shh_Connection
    {
        // Setup Credentials and Server Information
        ConnectionInfo ConnNfo = new ConnectionInfo("u10223.ssh.masterhost.ru", 22, "u10223", new AuthenticationMethod[]{ new PasswordAuthenticationMethod("u10223", "sted95nfabb") });

        public MySql_Shh_Connection()
        {
            // Execute a (SHELL) Command - prepare upload directory
            using (var sshclient = new SshClient(ConnNfo))
            {
                try
                {
                    sshclient.Connect();

                    var tunnel = new ForwardedPortLocal("127.0.0.1", 3306, "u10223.mysql.masterhost.ru", 3306);
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
            var p = new MySql_Connection("127.0.0.1", "u10223", "ption93r", "u10223", "3306");

            // var p = new MySql_Connection("217.16.28.213", "reader", "NtJzEqEmbt2", "fpa", "3306");
            p.GetData();
            p.CloseConnection();
        }

        

    }
}
