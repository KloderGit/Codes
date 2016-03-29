using System.Windows;

namespace CodesUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CodesControl.View.Control_View codes = new CodesControl.View.Control_View
            {
                DataContext = new CodesControl.ViewModel.Control_ViewModel(),
                Margin = new Thickness(10, 10,10 ,10)
            };

            Root.Children.Add(codes);
        }
    }
}
