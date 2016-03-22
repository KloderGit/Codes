using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodesADONet;
using System.Data;

namespace CodesControl.Data
{
    public class PrepareStudents
    {
        MySql_SSH_Connection connection = new MySql_SSH_Connection();
        DataTable codesTable = new DataTable();
        DataTable userTable = new DataTable();

        public PrepareStudents()
        {
            codesTable = connection.GetCodes();
            userTable = connection.GetUsers();
        }

        private List<Model.Codes> codesList()
        {
            List<Model.Codes> codes = new List<Model.Codes>();

            foreach (DataRow row in codesTable.Rows)
            {
                var cod = new Model.Codes();

                cod.Id = (int)row[0];
                cod.Code = (string)row[1];
                cod.Active = (int)row[2] == 1 ? true : false;
                cod.UserId = (int)row[3];
                cod.EducationType = (string)row[4];

                try
                {
                    cod.ExpirationDate = DateTime.Parse(row[5].ToString());
                }
                catch (Exception e)
                {
                    cod.ExpirationDate = DateTime.MinValue;
                }

                cod.Restore();

                codes.Add(cod);
            }

            return codes;
        }

        private List<Model.Users> usersList()
        {
            List<Model.Users> codes = new List<Model.Users>();

            foreach (DataRow row in userTable.Rows)
            {
                Model.Users user = new Model.Users();

                user.Id = 



                cod.Restore();

                codes.Add(cod);
            }

            return codes;
        }
    }
}
private Int32 id;
private string name;
private string lastName;
private string parentName;
private string email;
private string login;
private string educationType;
private string phone;
private string code;
private string skype;