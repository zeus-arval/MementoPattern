using Memento.Common;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Memento
{
    public class Storage
    {
        public Memory Memory { get; private set; }
        public List<File> Files { get; private set; } = new();

        public Storage(double capacity, List<File> files)
        {
            double reservedMemory = 0.0d;
            Memory = new(capacity, reservedMemory);
            AddFiles(files, null);
        }

        public void AddFiles(List<File> files, HardDisk d)
        {
            int sleepTime = (d is SSD) ? 50 : 150;
            Console.WriteLine("Adding files.");
            foreach (File file in files)
            {
                _ = file ?? throw new Exception("File couldn't be null");
                if (!Memory.HasEnoughSpaceForTarget(file.Size)) break;
                Thread.Sleep(sleepTime);
                Console.WriteLine($"\tAdding [{file.Name}]");
                Files.Add(file);
                Memory.ReduceFreeSpace(file.Size);
            }
            Thread.Sleep(sleepTime * 2);
            Console.WriteLine("Files are added");
        }
        public void RemoveFiles()
        {
            Console.WriteLine("Removing files.");
            Files = new();
            Memory.FreeUpSpace();
            Console.WriteLine("Files are removed");
        }
    }
}