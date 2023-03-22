using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook_Laba4.ViewModels.Page
{
    internal class OpenFileViewModel : ViewModelBase
    {
        private string? textButton;
        public OpenFileViewModel(string flag)
        {
            if (flag == "Open")
            {
                TextButton = "Open";
            }
            else if (flag == "Save")
            {
                TextButton = "Save";
            }
        }
        public string? TextButton
        {
            get => textButton;
            set { this.RaiseAndSetIfChanged(ref textButton, value); }
        }
    }
}
