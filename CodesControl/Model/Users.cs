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
        private string educationType;
        private string phone;
        private string code;
        private string skype;

        public event EventHandler OnObjectChanged;

        public Int32 Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                objectChanged(new Secondary.ModelEventArgs(this.id));
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                objectChanged(new Secondary.ModelEventArgs(this.name));
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                this.lastName = value;
                objectChanged(new Secondary.ModelEventArgs(this.lastName));
            }
        }

        public string ParentName
        {
            get { return this.parentName; }
            set
            {
                this.parentName = value;
                objectChanged(new Secondary.ModelEventArgs(this.parentName));
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                this.email = value;
                objectChanged(new Secondary.ModelEventArgs(this.email));
            }
        }

        public string Login
        {
            get { return this.login; }
            set
            {
                this.login = value;
                objectChanged(new Secondary.ModelEventArgs(this.login));
            }
        }

        public string EducationType
        {
            get { return this.educationType; }
            set
            {
                this.educationType = value;
                objectChanged(new Secondary.ModelEventArgs(this.educationType));
            }
        }

        public string Phone
        {
            get { return this.phone; }
            set
            {
                this.phone = value;
                objectChanged(new Secondary.ModelEventArgs(this.phone));
            }
        }

        public string Code
        {
            get { return this.code; }
            set
            {
                this.code = value;
                objectChanged(new Secondary.ModelEventArgs(this.code));
            }
        }

        public string Skype
        {
            get { return this.skype; }
            set
            {
                this.skype = value;
                objectChanged(new Secondary.ModelEventArgs(this.skype));
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        private void objectChanged(Secondary.ModelEventArgs e)
        {
            EventHandler _onObjectChanged = OnObjectChanged;

            if (_onObjectChanged != null)
                _onObjectChanged(this, e);
        }
    }
}
