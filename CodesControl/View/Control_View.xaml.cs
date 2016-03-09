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
            var requestCulture = System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU");
            System.Threading.Thread.CurrentThread.CurrentCulture = requestCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = requestCulture;

        }
    }
}
