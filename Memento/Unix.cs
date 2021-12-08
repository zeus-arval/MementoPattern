using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Memento.Common;

namespace Memento
{
    public sealed class Unix
    {
        public string Name { get; private set; }
        public Memory Memory { get; private set; }
        public List<File> Files { get; private set; } = new();

        public Unix(string name, double capacity)
        {
            double defaultMemory = 200.0d;
            Name = name;
            Memory = new(capacity, defaultMemory);
            AddFiles(new() { new Document("RootDocs.txt", defaultMemory, "Some text")});
            Console.WriteLine("Ubuntu is configured\n");
        }

        public void AddFiles(List<File> files)
        {
            Console.WriteLine("Adding files.");
            foreach(File file in files)
            {
                _ = file ?? throw new Exception("File must contain any information");
                if (!Memory.HasEnoughSpaceForTarget(file.Size)) return;
                Files.Add(file);
                Thread.Sleep(100);
                Console.WriteLine($"\tAdding [{file.Name}]\tto /home/$USER/" + (file is Image ? "Pictures" : "Documents"));
                Memory.ReduceFreeSpace(file.Size);
            }
            Thread.Sleep(200);
            Console.WriteLine("All files are added");
        }
        public Storage CreateBackup(double capacity)
        {
            if (capacity <= 0.0d) throw new Exception("Memory capacity cannot be negative or zero");
            Console.WriteLine("Backup is created\n");
            return new(capacity, Files);
        }
        public void PrintMemoryInfo()
        {
            ConsoleColor color = ConsoleColor.Green;
            Console.ForegroundColor = color;
            Console.WriteLine("\n" + String.Concat(Enumerable.Repeat("-", 60)));
            Memory.PrintMemoryMessage(color, $"You have {Memory.FreeSpace} Kbytes free");
            Console.ForegroundColor = color;
            Console.WriteLine($"{Files.Count} files are in {Name}:");
            foreach(File file in Files)
            {
                file.PrintFileInfo(color);
            }
            Console.ForegroundColor = color;
            Console.WriteLine(String.Concat(Enumerable.Repeat("-", 60)) + "\n");
            Console.ResetColor();
        }
        public void ResetFromStorage(Storage storage)
        {
            Files = new();
            Memory.FreeUpSpace();

            foreach(File file in storage.Files)
            {
                _ = file ?? throw new Exception("File must contain any information");

                if (!Memory.HasEnoughSpaceForTarget(file.Size)) return;
                Files.Add(file);
                Memory.ReduceFreeSpace(file.Size);
            }
        }
        public void RemoveFiles()
        {
            Files.RemoveRange(1, Files.Count - 1);
            Memory.FreeUpSpace();
        }
    }
}
