using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;

namespace CodesControl.Clsses.Collection
{
    public class ObserverableNotifyCollection<T> : ObservableCollection<T>
    {
        public void AddItem(T _item)
        {
            this.Add(_item);

            if (_item is ViewModel.ItemUserCodes_ViewModel)
            {
                var it = _item as ViewModel.ItemUserCodes_ViewModel;
               // it.ObjectPropertyChanged += selfRefresh;
            }

            Console.WriteLine("Добавлен элемент");
        }

        private void selfRefresh()
        {
            Console.WriteLine("Событие при изменении объекта");
            base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
