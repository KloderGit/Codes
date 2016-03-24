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

        private void AviableItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            searchField.Focus();
        }

        private void CodesTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            searchField.Focus();
        }
    }
}
