using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodesADONet;
using System.Data;

namespace CodesControl.Data
{
    public class UpdateCode
    {
        MySql_SSH_Connection connection = MySql_SSH_Connection.SshConnection;

        public UpdateCode( Model.Codes _code )
        {
            connection.UpdateCode(_code.Id, _code.ExpirationDate);
        }
    }
}
