using System;

namespace Memento
{
    public class Memory
    {
        private readonly double _capacity;
        private readonly double _defaultMemory;
        public MemoryStatus MemoryStatus { get; private set; } = new(null);
        public double FreeSpace { get; private set; }
        public Memory(double capacity, double defaultMemory)
            => (_capacity, _defaultMemory, FreeSpace) = (capacity, defaultMemory, capacity - defaultMemory);
        
        public void ReduceFreeSpace(double size)
        {
            if (!MemoryStatus.HasFreeSpace) MemoryStatus.PrintError(); //TODO check if code dublicates
            if (size <= 0) throw new Exception("Size cannot be negative or zero");
            bool freeSpaceIsEnough = size < FreeSpace;
            FreeSpace -= freeSpaceIsEnough ? size : 0.0d;
            MemoryStatus.AddErrorMessage(freeSpaceIsEnough ? null : "Memory is full");
        }
        public bool HasEnoughSpaceForTarget(double targetSize)
        {
            if (!MemoryStatus.HasFreeSpace) MemoryStatus.PrintError();
            bool hasEnoughSpace = FreeSpace >= targetSize;
            MemoryStatus.AddErrorMessage(hasEnoughSpace ? null : "Not enough memory to complete this operation");
            return hasEnoughSpace;
        }
        public void FreeUpSpace()
        {
            FreeSpace = _capacity - _defaultMemory;
            MemoryStatus.AddErrorMessage(null);
            PrintMemoryMessage(ConsoleColor.Yellow, "Space is cleared");
        }
        public void PrintMemoryMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"\n{message}\n");
            Console.ResetColor();
        }
    }
}
