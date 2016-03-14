using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace CodesControl.View
{
    /// <summary>
    /// Логика взаимодействия для Control_View.xaml
    /// </summary>
    public partial class Control_View : UserControl
    {

        public Control_View()
        {
            InitializeComponent();
        }

        private void DifferentItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cont = sender as ListView;
            var item = cont.SelectedItem as ViewModel.ItemUserCodes_ViewModel;
            System.Console.WriteLine(item.Code);
        }
    }
}
