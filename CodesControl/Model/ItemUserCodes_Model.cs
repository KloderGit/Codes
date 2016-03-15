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
            user.OnObjectChanged += new EventHandler(object_property_changed);

            this.Code = code;
            code.OnObjectChanged += new EventHandler(object_property_changed);
        }

        private void object_property_changed( object sender, EventArgs e )
        {
            if ( !this.buckupAviable )
            {
                if ( sender is Users ) { buckupUserValue = this.User; Console.WriteLine("Изменен - " + this.User); }
                if ( sender is Codes ) { buckupCodeValue = this.Code; Console.WriteLine("Изменен - " + this.Code); }
            }
        }
    }
}
