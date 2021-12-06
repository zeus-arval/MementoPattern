using Memento;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MementoTests
{
    [TestClass]
    public class MemoryTests
    {
        private Memory memory = new(default, default);
        
        [TestInitialize]
        public void Initialize()
        {
            double capacity = 128.0d;
            double defaultMemory = 0.0d;
            memory = new(capacity, defaultMemory);
        }

        [TestMethod]
        public void TestReduceFreeSpace()
        {
            double size = 100.0;
            double freeSpace = memory.FreeSpace - size;
            memory.ReduceFreeSpace(size);

            Assert.AreEqual(freeSpace, memory.FreeSpace);
            Assert.AreEqual(null, memory.MemoryStatus.ErrorMessage);

            memory.ReduceFreeSpace(size);
            Assert.AreEqual(freeSpace, memory.FreeSpace);
            Assert.AreEqual("Memory is full", memory.MemoryStatus.ErrorMessage);
        }

        [TestMethod]
        public void TestHasEnoughSpace()
        {
            double targetSize = 150.0d;
            memory.HasEnoughSpaceForTarget(targetSize);
            Assert.AreEqual("Not enough memory to complete this operation", memory.MemoryStatus.ErrorMessage);

            targetSize -= 50.0d;
            memory.HasEnoughSpaceForTarget(targetSize);
            Assert.AreEqual(null, memory.MemoryStatus.ErrorMessage);
        }

        [TestMethod]
        public void TestFreeUpSpace()
        {
            memory.ReduceFreeSpace(100);
            Assert.AreNotEqual(128.0d, memory.FreeSpace);

            memory.FreeUpSpace();
            Assert.AreEqual(128.0d, memory.FreeSpace);
        }
    }
}
