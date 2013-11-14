using System;
using System.Linq;

namespace Task3WriteAllDirsAndGetFileSizes
{
    public class File
    {
        public string Name { get; private set; }
        public long Size { get; private set; }

        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }
    }
}
