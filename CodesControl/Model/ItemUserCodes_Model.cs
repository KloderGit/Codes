using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesControl.Model
{
    public class ItemUserCodes_Model
    {
        public Guid id { get; private set; }
        public Users User { get; set; }
        public Codes Code { get; set; }

        private Users buckupUserValue;
        private Codes buckupCodeValue;

        public bool buckupAviable
        {
            get { return buckupUserValue != null || buckupCodeValue != null; }
        }

        //  Конструктор
        public ItemUserCodes_Model(Users user, Codes code)
        {
            this.id = new Guid();
            this.User = user;
            this.Code = code;
        }

        public void selfBuckup()
        {
            if (this.buckupUserValue == null)
            {
                buckupUserValue = (Model.Users)this.User.Clone();
            }

            if (this.buckupCodeValue == null)
            {
                buckupCodeValue = (Model.Codes)this.Code.Clone();
            }
        }
    }
}
