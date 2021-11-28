using System;
using System.Collections.Generic;

namespace Memento
{
    public class Storage
    {
        public Memory Memory { get; set; }
        public List<IFile> Files { get; set; } = new();

        public Storage(double capacity, List<IFile> files)
        {
            Memory = new(capacity);
            AddFiles(files);
        }

        public void AddFiles(List<IFile> files)
        {
            foreach(IFile file in files)
            {
                _ = file ?? throw new Exception("File couldn't be null");
                if (!Memory.HasEnoughSpace(file.Size)) break;
                Files.Add(file);
                Memory.ReduceFreeSpace(file.Size);
            }
        }
        public void RemoveFiles()
        {
            Files = new();
            Memory.FreeUpSpace();
        }
    }
}