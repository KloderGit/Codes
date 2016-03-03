using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesControl.Model
{
    public class Codes
    {
        public Int32 Id { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public Int32 UserId { get; set; }
        public string EducationType { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
