using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesControl.Model
{
    public class EducationType
    {
        public string Title {get; set;}
        public int Count {get; set;}

        public EducationType(string _key, int _count)
        {
            this.Title = _key;
            this.Count = _count;
        }
    }
}
