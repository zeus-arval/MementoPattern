using System;

namespace Memento.Common
{
    public abstract class File
    {
        public string Name { get; private protected set; }
        public double Size { get; private protected set; }

        protected File(string name, double size)
            => (Name, Size) = (name, size);

        public void PrintFileInfo(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"\t\t{Name}\t[{Size} Kbytes]");
        }
    }
}
