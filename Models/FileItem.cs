using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook_Laba4.Models
{
    public class FileItem
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
    }
    internal class myDirectory : FileItem
    {
    }
    internal class myFile : FileItem
    {
    }
    internal class myDisk : FileItem
    {
    }
}
