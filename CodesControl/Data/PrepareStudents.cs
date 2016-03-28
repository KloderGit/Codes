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
        MySql_SSH_Connection connection = MySql_SSH_Connection.SshConnection;
        DataTable codesTable = new DataTable();
        DataTable userTable = new DataTable();

        public PrepareStudents()
        {
            codesTable = connection.GetCodes();
            userTable = connection.GetUsers();
            connection.UpdateCode(9243, DateTime.Now);

            connection = null;

        }

        private List<Model.Codes> codesList()
        {
            List<Model.Codes> codes = new List<Model.Codes>();

            foreach (DataRow row in codesTable.Rows)
            {
                var cod = new Model.Codes();

                cod.Id = String.IsNullOrEmpty(row[0].ToString()) ? 0 : (int)row[0];
                cod.Code = String.IsNullOrEmpty(row[1].ToString()) ? "" : (string)row[1];
                cod.Active = (int)row[2] == 1 ? true : false;
                cod.UserId = String.IsNullOrEmpty(row[3].ToString()) ? 0 : (int)row[3];
                cod.EducationType = String.IsNullOrEmpty(row[4].ToString()) ? "" : (string)row[4];

                try
                {
                    cod.ExpirationDate = DateTime.Parse(row[5].ToString());
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.WriteLine(row[5].ToString());
                    cod.ExpirationDate = DateTime.MinValue;
                    Console.WriteLine(cod.ExpirationDate);

                }

                cod.Restore();

                codes.Add(cod);
            }

            return codes;
        }

        private List<Model.Users> usersList()
        {
            List<Model.Users> users = new List<Model.Users>();

            foreach (DataRow row in userTable.Rows)
            {
                Model.Users user = new Model.Users();

                user.Id = String.IsNullOrEmpty(row[0].ToString()) ? 0 : (int)row[0];
                user.Name = String.IsNullOrEmpty(row[1].ToString()) ? "" : (string)row[1];
                user.LastName = String.IsNullOrEmpty(row[2].ToString()) ? "" : (string)row[2];
                user.ParentName = String.IsNullOrEmpty(row[3].ToString()) ? "" : (string)row[3];
                user.Email = String.IsNullOrEmpty(row[4].ToString()) ? "" : (string)row[4];
                user.Login = String.IsNullOrEmpty(row[5].ToString()) ? "" : (string)row[5];
                user.Phone = String.IsNullOrEmpty(row[6].ToString()) ? "" : (string)row[6];
                user.Code = String.IsNullOrEmpty(row[7].ToString()) ? "" : (string)row[7];
                user.Skype = String.IsNullOrEmpty(row[8].ToString()) ? "" : (string)row[8];
                user.Restore();

                users.Add(user);
            }

            return users;
        }

        public List<ViewModel.Student_ViewModel> GetStudents()
        {
            List<ViewModel.Student_ViewModel> students = new List<ViewModel.Student_ViewModel>();

            var codes = codesList();
            var users = usersList();

            foreach (var codeItem in codes)
            {
                
                Model.Users user = users.FirstOrDefault(p => p.Code == codeItem.Code);

                if (user != null)
                {
                    var student = new ViewModel.Student_ViewModel(user, codeItem);

                    students.Add(student);
                }
            }

            return students;
        }
    }
}