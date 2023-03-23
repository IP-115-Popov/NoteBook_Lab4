using Notebook_Laba4.ViewModels.Page;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace Notebook_Laba4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string? mainText; 
        private object contentWindow;
        private NoteBookViewModel noteBookViewModel;
       // private OpenFileViewModel openFileViewModel;     
        public MainWindowViewModel()
        {    
            contentWindow = noteBookViewModel = new NoteBookViewModel();
            OpenFileButton = ReactiveCommand.Create(() =>
            {
                OpenFileViewModel openFileViewModel = new OpenFileViewModel("Open");
                ContentWindow = openFileViewModel;

                openFileViewModel.TappDir.Subscribe(
                        returnedSrt =>
                        {
                            ContentWindow = new NoteBookViewModel();
                            MainText = returnedSrt;
                        }
                    );
 
            });
            SaveFileButton = ReactiveCommand.Create(() =>
            {
                OpenFileViewModel openFileViewModel = new OpenFileViewModel("Save");
                ContentWindow = openFileViewModel;
                //TappDir вернёт путь к фаилу для сохранения
                openFileViewModel.TappDir.Subscribe(
                    returnedSrt => 
                    {
                        using (StreamWriter writer = new StreamWriter(returnedSrt, false))
                        {
                            writer.Write(MainText);
                        }
                    }
                );
            });
            ExitFileButton = ReactiveCommand.Create(() =>
            {
                ContentWindow = new NoteBookViewModel();
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
        private string? MainText
        {
            get => mainText;
            set { this.RaiseAndSetIfChanged(ref mainText, value); }
        }

    }
}
