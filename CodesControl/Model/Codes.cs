using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesControl.Model
{
    public class Codes
    {
        private Int32 id;
        private string code;
        private bool active;
        private Int32 userId;
        private string educationType;
        private DateTime expirationDate;
        private Codes buckupCodeValue;

        public event EventHandler OnObjectChanged;
        public event Action OnHasBuckupChanged;

        public Int32 Id
        {
            get { return this.id; }
            set {
                ObjectChanged(new Secondary.ModelEventArgs(this.id));
                this.id = value;
            }
        }

        public string Code
        {
            get { return this.code; }
            set
            {
                this.code = value;
                ObjectChanged(new Secondary.ModelEventArgs(this.code));
            }
        }

        public bool Active
        {
            get { return this.active; }
            set
            {
                this.active = value;
                ObjectChanged(new Secondary.ModelEventArgs(this.active));
            }
        }

        public int UserId
        {
            get { return this.userId; }
            set
            {
                this.userId = value;
                ObjectChanged(new Secondary.ModelEventArgs(this.userId));
            }
        }

        public string EducationType
        {
            get { return this.educationType; }
            set
            {
                this.educationType = value;
                ObjectChanged(new Secondary.ModelEventArgs(this.educationType));
            }
        }

        public DateTime ExpirationDate
        {
            get { return this.expirationDate; }
            set
            {
                this.expirationDate = value;
                ObjectChanged(new Secondary.ModelEventArgs(this.expirationDate));
            }
        }

        public bool HasChanged { get { return this.buckupCodeValue != null; } }


        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Restore()
        {
            this.buckupCodeValue = null;
            HasBuckupChanged();
        }

        private void ObjectChanged(Secondary.ModelEventArgs e)
        {
            EventHandler onobjectChanged = OnObjectChanged;
            if ( onobjectChanged != null )
            {
                onobjectChanged(this, e);
            }

            if ( this.buckupCodeValue == null )
            {
                buckupCodeValue = this.Clone() as Codes;
                HasBuckupChanged();
            }
        }

        private void HasBuckupChanged()
        {
            Action hasChanged = OnHasBuckupChanged;
            if ( hasChanged != null ) { hasChanged(); }

            Console.WriteLine(" Изменено наличие бекапа в объекте Кода c ID - " + this.HasChanged);
        }
    }
}
