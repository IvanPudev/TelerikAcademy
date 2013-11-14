using System;
using System.Linq;
using System.Collections.Generic;

namespace Task3WriteAllDirsAndGetFileSizes
{
    public class Folder
    {
        public string Name { get; private set; }
        public List<File> Files { get; private set; }
        public List<Folder> ChildFolders { get; private set; }

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public void AddFile(File file)
        {
            this.Files.Add(file);
        }

        public void AddSubFolder(Folder folder)
        {
            this.ChildFolders.Add(folder);
        }
    }
}
