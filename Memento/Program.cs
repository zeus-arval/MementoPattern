using Memento.Common;
using System;
using System.Collections.Generic;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = 512.0d;
            Unix ubuntu = new("Ubuntu 18.04", capacity);
            ubuntu.PrintMemoryInfo();
            ubuntu.AddFiles(new() { 
                new Document("cppDocs.txt", 50.0, "Some boring text"), 
                new Image("dodgeChallenger.png", 250.0d, Array.Empty<byte>()), 
                new Document("pes.txt", 12.1d, "G9") 
            });
            ubuntu.PrintMemoryInfo();
            Storage backup = ubuntu.CreateBackup(capacity);

            HardDisk ssd = new SSD("SSD_M.2", backup);
            ubuntu.RemoveFiles();
            ubuntu.PrintMemoryInfo();
            ubuntu.ResetFromBackup(ssd.Storage);
        }
    }
}
