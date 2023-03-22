using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Notebook_Laba4.ViewModels.Page
{
    internal class NoteBookViewModel : ViewModelBase
    {
        public string textTextBox;
        public NoteBookViewModel(string myText = "")
        {
            TextTextBox = myText;
        }
        
        public string TextTextBox
        {
            get => textTextBox;
            set => this.RaiseAndSetIfChanged(ref textTextBox, value); 
        }
    }
}
