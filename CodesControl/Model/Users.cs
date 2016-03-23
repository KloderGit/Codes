using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesControl.Model
{
    public class Users
    {
        private Int32 id;
        private string name;
        private string lastName;
        private string parentName;
        private string email;
        private string login;
        //private string educationType;
        private string phone;
        private string code;
        private string skype;

        private Users buckupUserValue;
        public bool HasChanged { get { return this.buckupUserValue != null; } }

        public event EventHandler OnObjectChanged;
        public event Action OnHasBuckupChanged;

        public Int32 Id
        {
            get { return this.id; }
            set
            {
                objectChanged(new Secondary.ModelEventArgs(this.id));
                this.id = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                objectChanged(new Secondary.ModelEventArgs(this.name));
                this.name = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                objectChanged(new Secondary.ModelEventArgs(this.lastName));
                this.lastName = value;
            }
        }

        public string ParentName
        {
            get { return this.parentName; }
            set
            {
                objectChanged(new Secondary.ModelEventArgs(this.parentName));
                this.parentName = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                objectChanged(new Secondary.ModelEventArgs(this.email));
                this.email = value;
            }
        }

        public string Login
        {
            get { return this.login; }
            set
            {
                objectChanged(new Secondary.ModelEventArgs(this.login));
                this.login = value;
            }
        }

        //public string EducationType
        //{
        //    get { return this.educationType; }
        //    set
        //    {
        //        objectChanged(new Secondary.ModelEventArgs(this.educationType));
        //        this.educationType = value;
        //    }
        //}

        public string Phone
        {
            get { return this.phone; }
            set
            {
                objectChanged(new Secondary.ModelEventArgs(this.phone));
                this.phone = value;
            }
        }

        public string Code
        {
            get { return this.code; }
            set
            {
                objectChanged(new Secondary.ModelEventArgs(this.code));
                this.code = value;
            }
        }

        public string Skype
        {
            get { return this.skype; }
            set
            {
                objectChanged(new Secondary.ModelEventArgs(this.skype));
                this.skype = value;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Restore()
        {
            this.buckupUserValue = null;
            HasBuckupChanged();
        }

        private void objectChanged(Secondary.ModelEventArgs e)
        {
            EventHandler _onObjectChanged = OnObjectChanged;

            if (_onObjectChanged != null)
            {
                _onObjectChanged(this, e);
            }

            if (this.buckupUserValue == null)
            {
                buckupUserValue = this.Clone() as Users;
                HasBuckupChanged();
            }
        }

        private void HasBuckupChanged()
        {
            Action hasChanged = OnHasBuckupChanged;
            if (hasChanged != null) { hasChanged(); }
           // Console.WriteLine(" Изменено наличие бекапа в объекте Пользователь c ID - " + this.HasChanged);
        }
    }
}
