using EstimationApp.ViewModels;
using System.Windows;

namespace EstimationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
            if (mainWindowViewModel.CloseAction == null)
                mainWindowViewModel.CloseAction = this.Close;
            InitializeComponent();
        }
    }
}
