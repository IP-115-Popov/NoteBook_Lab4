using Avalonia.Controls;
using Avalonia.Interactivity;
using Notebook_Laba4.ViewModels;
using Notebook_Laba4.ViewModels.Page;
using System;
using System.IO;

namespace Notebook_Laba4.Views.Page
{
    public partial class OpenFileView : UserControl
    {
        public OpenFileView()
        {
            InitializeComponent();
        }
        public void TappDir(object sender, RoutedEventArgs args)
        {
            if (DataContext is OpenFileViewModel openFileViewModel)
            {
                openFileViewModel.TappDir.Execute().Subscribe();
            }
        }
    }
}
