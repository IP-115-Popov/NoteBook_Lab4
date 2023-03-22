using Avalonia.Controls;
using Notebook_Laba4.ViewModels;

namespace Notebook_Laba4.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
