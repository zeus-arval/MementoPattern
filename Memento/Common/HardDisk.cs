using System;
using System.Collections.Generic;

namespace Memento.Common
{
    public class HardDisk
    {
        public string Name { get; private protected set; }
        public Storage Storage { get; private protected set; }

        public HardDisk(string name, Storage storage)
        {
            (Name, Storage) = (name, storage);
        }

        public void AddFiles(List<File> files)
        {
            Storage.AddFiles(files, this);
        }

        public void RemoveFiles()
        {
            Storage.RemoveFiles();
        }
    }
}