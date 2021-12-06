using Memento;
using Memento.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoTests
{
    [TestClass]
    public class StorageTests
    {
        private Storage storage = new(0.0d, new List<File>());

        [TestInitialize]
        public void Initialize()
        {
            double capacity = 128.0d;
            storage = new(capacity, new List<File>());
        }

        [TestMethod]
        public void AddFilesTest()
        {
            double documentSize = 23.0d;
            double memoryFreeSpace = storage.Memory.FreeSpace;
            List<File> files = new List<File> { new Document("docs.txt", documentSize, "Content") };
            Assert.AreEqual(0, storage.Files.Count());

            storage.AddFiles(files, null);
            double expectedFreeSpace = memoryFreeSpace - documentSize;
            Assert.AreEqual(1, storage.Files.Count());
            Assert.AreEqual(expectedFreeSpace, storage.Memory.FreeSpace);
        }

        [TestMethod]
        public void RemoveFilesTest()
        {
            double documentSize = 108.0d;
            double memoryFreeSpace = storage.Memory.FreeSpace;
            List<File> files = new List<File> { new Document("docs.txt", documentSize, "Content") };
            storage.AddFiles(files, null);
            Assert.AreEqual(1, storage.Files.Count());

            storage.RemoveFiles();
            Assert.AreEqual(0, storage.Files.Count());
            Assert.AreEqual(memoryFreeSpace, storage.Memory.FreeSpace);
        }
    }
}
