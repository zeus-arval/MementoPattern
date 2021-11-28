using System;

namespace Memento
{
    public class Memory
    {
        private readonly double _capacity;
        public MemoryStatus MemoryStatus { get; set; } = new(null);
        public double FreeSpace { get; set; }
        public Memory(double capacity)
        {
            (_capacity, FreeSpace) = (capacity, capacity);
        }
        public void ReduceFreeSpace(double size)
        {
            if (size <= 0) throw new Exception("Size cannot be negative or zero");
            if (FreeSpace < size)
            {
                MemoryStatus.AddErrorMessage("There is not enough space on the disk to.");
                return;
            }
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
            FreeSpace = _capacity;
            MemoryStatus.AddErrorMessage(null);
        }
    }
}
