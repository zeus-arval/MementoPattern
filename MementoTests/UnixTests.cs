using Memento;
using Memento.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MementoTests
{
    [TestClass]
    public class UnixTests
    {
        private Unix unix = new(string.Empty, double.MinValue);

        [TestInitialize]
        public void Initialize()
        {
            string name = "TestUbuntu";
            double capacity = 256.0d;
            unix = new(name, capacity);
        }

        [TestMethod]
        public void AddFilesTest()
        {
            Assert.AreEqual(0, unix.Files.Count);
            List<File> files = new List<File> { new Image("birthday.png", 24.0d, Array.Empty<byte>()) };
            unix.AddFiles(files);
            Assert.AreEqual(1, unix.Files.Count);
        }

        [TestMethod]
        public void CreateBackupTest()
        {
            double capacity = 128.0d;
            unix.AddFiles(new List<File> { new Document("importantDoc.txt", 48.0d, "Important content...") });
            Assert.AreEqual(1, unix.Files.Count);

            Storage storage = unix.CreateBackup(capacity);
            CollectionAssert.AreEqual(storage.Files, unix.Files);
        }

        [TestMethod]
        public void ResetFromBackupTest()
        {
            Storage backup = new(128.0d, new List<File> { new Image("Sea.png", 56.0d, Array.Empty<byte>()) });
            Assert.AreEqual(0, unix.Files.Count);

            unix.ResetFromStorage(backup);
            CollectionAssert.AreEqual(backup.Files, unix.Files);
        }

        [TestMethod]
        public void RemoveFilesTest()
        {
            unix.AddFiles(new() { new Document("RootDocs.txt", 56.0d, "Some text") });
            unix.AddFiles(new() { new Document("docs.txt", 23.0d, "Some text")});
            Assert.AreEqual(2, unix.Files.Count);

            unix.RemoveFiles();
            Assert.AreEqual(1, unix.Files.Count);
        }
    }
}
