using Avalonia.Controls.Shapes;
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
            string[] myFiles = Directory.GetFiles("C:\\Users\\79130\\Desktop\\VM\\Notebook_Laba4");
            string[] myDirs = Directory.GetDirectories("C:\\Users\\79130\\Desktop\\VM\\Notebook_Laba4");
            foreach (string mydir in myDirs)
            {
                Dir.Add(new FileItem() { ImagePath = "Assets/pic/closedir.png", Name = System.IO.Path.GetFileName(mydir)});
            }

            foreach (string f in myFiles)
            {
                if (File.Exists(f))
                {
                    //FileInfo fileInf = new FileInfo(f);
                    Dir.Add(new FileItem() { ImagePath = "Assets/pic/filefile.png", Name = System.IO.Path.GetFileName(f)});
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
