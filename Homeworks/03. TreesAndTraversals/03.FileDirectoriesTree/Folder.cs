using System.Collections.Generic;

namespace _03.FileDirectoriesTree
{
    public class Folder
    {
        private ICollection<File> files;
        private ICollection<Folder> subFolders;

        public Folder(string name)
        {
            this.Name = name;
            this.files = new List<File>();
            this.subFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public ICollection<File> Files
        {
            get { return this.files; }
            set { this.files = value; }
        }

        public ICollection<Folder> SubFolders
        {
            get { return this.subFolders; }
            set { this.subFolders = value; }
        }

        public override string ToString()
        {
            return this.Name;
        }

        private long size = 0;

        public long GetSizeOfAll()
        {
            if (this.SubFolders.Count == 0)
            {
                foreach (var file in this.Files)
                {
                    size += file.Size;
                }

                return size;
            }

            foreach (var file in this.Files)
            {
                size += file.Size;
            }

            foreach (var folder in this.SubFolders)
            {
                this.size += folder.GetSizeOfAll();
            }

            return this.size;
        }
    }
}
