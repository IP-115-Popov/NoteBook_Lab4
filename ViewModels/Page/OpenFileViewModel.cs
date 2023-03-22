using Notebook_Laba4.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook_Laba4.ViewModels.Page
{
    internal class OpenFileViewModel : ViewModelBase
    {
        private string? textButton;
        public ObservableCollection<FileItem> Dir { get; set; } = new ObservableCollection<FileItem>();
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
            string[] dirs = Directory.GetFiles("C:\\Users\\79130\\Desktop\\VM\\Notebook_Laba4");
            foreach (string dir in dirs)
            {
                if (File.Exists(dir))
                {
                    Dir.Add(new FileItem() { ImagePath = "Assets/pic/filefile.png", Name = "file"});
                }
            }
        }
        public string? TextButton
        {
            get => textButton;
            set { this.RaiseAndSetIfChanged(ref textButton, value); }
        }
    }
}
