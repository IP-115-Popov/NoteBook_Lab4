using Notebook_Laba4.ViewModels.Page;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reflection.Metadata;
using System.Text;

namespace Notebook_Laba4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object contentWindow;
        private NoteBookViewModel noteBookViewModel;
        private OpenFileViewModel openFileViewModel;     
        public MainWindowViewModel()
        {
            noteBookViewModel = new NoteBookViewModel();
            openFileViewModel = new OpenFileViewModel();
            contentWindow = noteBookViewModel;
            OpenFileButton = ReactiveCommand.Create(() =>
            {
                ContentWindow = openFileViewModel;
            });
            SaveFileButton = ReactiveCommand.Create(() =>
            {
                ContentWindow = openFileViewModel;
            });
        }
        public ReactiveCommand<Unit, Unit> OpenFileButton { get; set; }
        public ReactiveCommand<Unit, Unit> SaveFileButton { get; set; }
        public object ContentWindow
        {
            get => contentWindow; 
            set { this.RaiseAndSetIfChanged(ref contentWindow, value); }
        }

    }
}
