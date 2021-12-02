using System;

namespace Memento
{
    public class Memory
    {
        private readonly double _capacity;
        private readonly double _defaultMemory;
        public MemoryStatus MemoryStatus { get; set; } = new(null);
        public double FreeSpace { get; set; }
        public Memory(double capacity, double defaultMemory)
        {
            (_capacity, _defaultMemory, FreeSpace) = (capacity, defaultMemory, capacity - defaultMemory);
        }
        public void ReduceFreeSpace(double size)
        {
            if (size <= 0) throw new Exception("Size cannot be negative or zero");
            FreeSpace -= size;
            MemoryStatus.AddErrorMessage(FreeSpace > 0 ? null : "Memory is full");
        }
        public bool HasEnoughSpace(double targetSize)
        {
            bool hasEnoughSpace = FreeSpace >= targetSize;
            MemoryStatus.AddErrorMessage(hasEnoughSpace ? null : "Not enough memory to complete this operation");
            return hasEnoughSpace;
        }
        public void FreeUpSpace()
        {
            FreeSpace = _capacity - _defaultMemory;
            MemoryStatus.AddErrorMessage(null);
            Console.WriteLine("Space is cleared");
        }
        public void PrintFreeMemory(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"You have {FreeSpace} Kbytes free");
            Console.ResetColor();
        }
    }
}
