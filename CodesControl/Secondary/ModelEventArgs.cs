using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesControl.Secondary
{
    public class ModelEventArgs: EventArgs
    {
        private Object _item;

        public ModelEventArgs(Object item)
        {
            var _item = item;
        }

        public Object ChangedItem
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
            }
        }
    }
}
