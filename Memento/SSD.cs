using System;
using System.Collections.Generic;

namespace Memento
{
    public class SSD : IHardDisk
    {
        public string Name { get; set; }
        public Storage Storage { get; set; }

        public SSD(string name, Storage storage)
        {
            (Name, Storage) = (name, storage);
        }

        public void AddFiles(List<IFile> files)
        {
            Storage.AddFiles(files);
        }

        public void RemmoveFiles()
        {
            Storage.RemoveFiles();
        }
    }
}