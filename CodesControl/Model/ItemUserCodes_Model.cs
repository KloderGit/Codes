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

        public ItemUserCodes_Model(Users user, Codes code)
        {
            this.id = new Guid();
            this.User = user;
            this.Code = code;
        }
    }
}
