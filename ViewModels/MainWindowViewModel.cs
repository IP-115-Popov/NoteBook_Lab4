using Notebook_Laba4.ViewModels.Page;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace Notebook_Laba4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string? mainText = "Hello"; 
        private object contentWindow;
        private NoteBookViewModel noteBookViewModel;
       // private OpenFileViewModel openFileViewModel;     
        public MainWindowViewModel()
        {    
            contentWindow = noteBookViewModel = new NoteBookViewModel(mainText);
            OpenFileButton = ReactiveCommand.Create(() =>
            {
                OpenFileViewModel openFileViewModel = new OpenFileViewModel("Open");
                ContentWindow = openFileViewModel;


                openFileViewModel.TappDir.Subscribe(
                        returnedSrt =>
                        {
                            ContentWindow = new NoteBookViewModel(returnedSrt);
                        }
                    );
 
            });
            SaveFileButton = ReactiveCommand.Create(() =>
            {
                ContentWindow = new OpenFileViewModel("Save");
            });
            ExitFileButton = ReactiveCommand.Create(() =>
            {
                ContentWindow = new NoteBookViewModel(mainText);
            });
        }
        public ReactiveCommand<Unit, Unit> OpenFileButton { get; set; }
        public ReactiveCommand<Unit, Unit> SaveFileButton { get; set; }
        public ReactiveCommand<Unit, Unit> ExitFileButton { get; set; }
        public object ContentWindow
        {
            get => contentWindow; 
            set { this.RaiseAndSetIfChanged(ref contentWindow, value); }
        }

    }
}
