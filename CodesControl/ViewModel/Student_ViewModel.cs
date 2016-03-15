using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodesControl.Model;

namespace CodesControl.ViewModel
{
    public class Student_ViewModel: ViewModelBase
    {
        private Users user;
        private Codes code;

        //Поля для чтения
        public Int32 UserId { get { return user.Id; } }
        public string UserName { get { return user.Name; } }
        public string UserLastName { get { return user.LastName; } }
        public string UserParentName { get { return user.ParentName; } }
        public string UserEmail { get { return user.Email; } }
        public string UserLogin { get { return user.Login; } }
        public string UserPhone { get { return user.Phone; } }
        public string UserSkype { get { return user.Skype; } }
        public Int32 CodeId { get { return code.Id; } }
        public bool CodeActive { get { return code.Active; } }



        // Поля для изменения
        public string EducationType
        {
            get { return code.EducationType; }
            set
            {
                if (value != code.EducationType )
                {
                    user.EducationType = value;
                    code.EducationType = value;
                    OnPropertyChanged("EducationType");
                }
            }
        }

        public string Code
        {
            get { return code.Code; }
            set
            {
                if (value != code.Code)
                {
                    user.Code = value;
                    code.Code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        public DateTime CodeExpirationDate
        {
            get  { return code.ExpirationDate;  }
            set
            {
                if (value != code.ExpirationDate)
                {
                    code.ExpirationDate = value;
                    OnPropertyChanged("CodeExpirationDate");
                }
            }
        }

        // Коструктор
        public Student_ViewModel(Users _user, Codes _code)
        {
            this.user = _user;
            this.code = _code;
        }




    }
}
