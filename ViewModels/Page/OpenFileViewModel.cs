﻿using Avalonia.Controls;
using Avalonia.Controls.Shapes;
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
    internal class OpenFileViewModel : ViewModelBase
    {
        private string path = "C:\\Users\\79130\\Desktop\\VM\\Notebook_Laba4";
        private string? textButton;
        public FileItem selectedDir;
        public ObservableCollection<FileItem> Dir { get; set; } = new ObservableCollection<FileItem>();
        public FileItem SelectedDir 
        {
            get => selectedDir;
            set => this.RaiseAndSetIfChanged(ref selectedDir, value);
        }
       // public string? flag = null;
        public OpenFileViewModel(string? flag)
        {
            TappDir = ReactiveCommand.Create(() => {
                if (SelectedDir.Name == "..")
                {
                    path = Directory.GetParent(path).ToString();
                }
                else if(System.IO.Path.GetExtension(path) == ".txt")
                {
                    if (TextButton == "Open")
                    {
                        using (StreamReader reader = new StreamReader(path))
                        {
                            string text = reader.ReadToEnd();

                            //NoteBookViewModel();
                        }
                    }
                    else if (TextButton == "Save")
                    {
                        using (StreamWriter writer = new StreamWriter(path, false))
                        {
                            writer.Write("CFHXC");
                        }
                    }
                }
                else
                {
                    path = SelectedDir.FullName;
                }
                
                UpdateDir();
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
        public ReactiveCommand<Unit, Unit> TappDir { get; set; }
        private void UpdateDir()
        {
            Dir.Clear();
            Dir.Add(new FileItem() { FullName = "Null", ImagePath = "Assets/pic/opendir.png", Name = ".."});
            string[] myFiles = Directory.GetFiles(path);
            string[] myDirs = Directory.GetDirectories(path);
            foreach (string mydir in myDirs)
            {
                Dir.Add(new FileItem() { FullName = mydir, ImagePath = "Assets/pic/closedir.png", Name = System.IO.Path.GetFileName(mydir) });
            }
            foreach (string f in myFiles)
            {
                if (File.Exists(f))
                {
                    Dir.Add(new FileItem() { FullName = f, ImagePath = "Assets/pic/filefile.png", Name = System.IO.Path.GetFileName(f) });
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
