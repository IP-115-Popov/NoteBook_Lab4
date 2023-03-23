using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using DynamicData.Tests;
using Microsoft.VisualBasic;
using Notebook_Laba4.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Notebook_Laba4.ViewModels.Page
{
    public class OpenFileViewModel : ViewModelBase
    {
        private string findFile;
        private string path = "C:\\Users\\79130\\Desktop\\VM\\Notebook_Laba4";
        private string? textButton;
        public FileItem selectedDir;
        public ObservableCollection<FileItem> Dir { get; set; } = new ObservableCollection<FileItem>();
        public FileItem SelectedDir 
        {
            get => selectedDir;
            set
            { 
                this.RaiseAndSetIfChanged(ref selectedDir, value);
                FindFile = SelectedDir.NameItem;
            }
        }

        public OpenFileViewModel(string? flag)
        {
                TappDir = ReactiveCommand.Create<Unit, string>((str) =>
                {                  
                    if (SelectedDir.NameItem == "..")
                    {
                        path = Directory.GetParent(path).ToString();
                        UpdateDir();
                    }
                    else
                    {
                        //включаем в путь выбраный элемент
                        path = SelectedDir.FullName;
                        string testa = System.IO.Path.GetExtension(path);
                        if (testa == ".txt")
                        {
                            if (TextButton == "Open")
                            {
                                using (StreamReader reader = new StreamReader(path))
                                {
                                    return reader.ReadToEnd();
                                }
                            }
                            else if (TextButton == "Save")
                            {
                                //возврашяем путь к фаилу
                                return path;
                            }
                        }
                        else
                        {
                            //выбраный элемент эта папка которую мы уже включити в путь 
                            //перехзагружаемся в выбраной папке
                            UpdateDir();
                        }
                    }                   
                    return "";
            });
            if (flag == "Open")
            {
                TextButton = "Open";
            }
            else if (flag == "Save")
            {
                TextButton = "Save";
            }
            UpdateDir();
        }
        public ReactiveCommand<Unit, string> SaveOrOpen { get; set; }
        public ReactiveCommand<Unit, string> TappDir { get; set; }
        private void UpdateDir()
        {
            Dir.Clear();
            Dir.Add(new FileItem() { FullName = "Null", ImagePath = "Assets/pic/opendir.png", NameItem = ".."});
            string[] myFiles = Directory.GetFiles(path);
            string[] myDirs = Directory.GetDirectories(path);
            foreach (string mydir in myDirs)
            {
                Dir.Add(new FileItem() { FullName = mydir, ImagePath = "Assets/pic/closedir.png", NameItem = System.IO.Path.GetFileName(mydir) });
            }
            foreach (string f in myFiles)
            {
                if (File.Exists(f))
                {
                    Dir.Add(new FileItem() { FullName = f, ImagePath = "Assets/pic/filefile.png", NameItem = System.IO.Path.GetFileName(f) });
                }
            }
        }
        public string? TextButton
        {
            get => textButton;
            set { this.RaiseAndSetIfChanged(ref textButton, value); }
        }
        private string FindFile
        {
            get => findFile;
            set { this.RaiseAndSetIfChanged(ref findFile, value); }
        }
    }
}
