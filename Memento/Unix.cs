using System;
using System.Collections.Generic;

namespace Memento
{
    public sealed class Unix
    {
        public Memory Memory { get; set; }
        public List<IFile> Files { get; set; } = new();

        public Unix(double capacity, List<IFile> files)
        {
            Files = files;
            Memory = new(capacity);
        }

        public void AddFiles(List<IFile> files)
        {
            foreach(IFile file in files)
            {
                _ = file ?? throw new Exception("File must contain any information");
                if (!Memory.HasEnoughSpace(file.Size)) return;
                Files.Add(file);
                Memory.ReduceFreeSpace(file.Size);
            }
            Console.WriteLine("All files are added");
        }
        public Storage CreateBackup(double capacity)
        {
            if (capacity <= 0.0d) throw new Exception("Memory capacity cannot be negative or zero");
            return new(capacity, Files);
        }
        public void ResetFromBackup(Storage storage)
        {
            Files = new();
            Memory.FreeUpSpace();

            foreach(IFile file in storage.Files)
            {
                _ = file ?? throw new Exception("File must contain any information");

                if (!Memory.HasEnoughSpace(file.Size)) return;
                Files.Add(file);
                Memory.ReduceFreeSpace(file.Size);
            }
        }
    }
}
