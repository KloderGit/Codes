using System.ComponentModel;

namespace CodesControl.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler linkOnEvent = PropertyChanged;

            if (linkOnEvent != null)
            {
                linkOnEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
