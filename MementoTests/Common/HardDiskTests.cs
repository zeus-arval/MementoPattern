using Memento;
using Memento.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MementoTests.Common
{
    [TestClass]
    public class HardDiskTests
    {
        private HardDisk disk = new(null, null);

        [TestInitialize]
        public void Initialize()
        {
            string name = "ubuntu 16.04";
            double capacity = 200.0d;
            Storage storage = new(capacity, new());
            disk = new HardDisk(name , storage);
        }

        [TestMethod]
        public void AddFilesTest()
        {
            int filesAmount = disk.Storage.Files.Count;
            Assert.AreEqual(0, filesAmount);

            disk.AddFiles(new() { new Document("test.txt", 100.0d, "Just for test") });
            filesAmount = disk.Storage.Files.Count;
            Assert.AreEqual(1, filesAmount);

        }
        [TestMethod]
        public void RemoveFilesTest()
        {
            disk.AddFiles(new() { new Document("test.txt", 100.0d, "Just for test") });
            int filesAmount = disk.Storage.Files.Count;
            Assert.AreEqual(1, filesAmount);

            disk.RemoveFiles();
            filesAmount = disk.Storage.Files.Count;
            Assert.AreEqual(0, filesAmount);
        }
    }
}
