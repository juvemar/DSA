﻿namespace _03.FileDirectoriesTree
{
    public class File
    {
        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name { get; set; }

        public long Size { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
