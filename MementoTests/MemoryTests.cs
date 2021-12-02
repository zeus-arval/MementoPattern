using Memento;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MementoTests
{
    [TestClass]
    public class MemoryTests
    {
        [TestInitialize]
        public void Initialize()
        {
            MemoryStatus status = new(null);
            double capacity = 128.0d;
            double defaultMemory = 0.0d;
            Memory memory = new(capacity, defaultMemory);
        }

        [TestMethod]
        public void TestReduceFreeSpace()
        {
            double size = 100.0;

        }
    }
}
