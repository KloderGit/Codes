﻿using System;
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
                ObjectChanged(new Secondary.ModelEventArgs(this.code));
                this.code = value;
            }
        }

        public bool Active
        {
            get { return this.active; }
            set
            {
                ObjectChanged(new Secondary.ModelEventArgs(this.active));
                this.active = value;
            }
        }

        public int UserId
        {
            get { return this.userId; }
            set
            {
                ObjectChanged(new Secondary.ModelEventArgs(this.userId));
                this.userId = value;
            }
        }

        public string EducationType
        {
            get { return this.educationType; }
            set
            {
                ObjectChanged(new Secondary.ModelEventArgs(this.educationType));
                this.educationType = value;
            }
        }

        public DateTime ExpirationDate
        {
            get { return this.expirationDate; }
            set
            {
                ObjectChanged(new Secondary.ModelEventArgs(this.expirationDate));
                this.expirationDate = value;
            }
        }

        public bool HasChanged { get { return this.buckupCodeValue == null; } }


        public object Clone()
        {
            return this.MemberwiseClone();
        }

        private void ObjectChanged(Secondary.ModelEventArgs e)
        {
            EventHandler onobjectChanged = OnObjectChanged;
            if (onobjectChanged != null) { onobjectChanged(this, e); }


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
        }
    }
}
