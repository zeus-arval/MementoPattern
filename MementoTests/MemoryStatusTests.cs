using Memento;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoTests
{
    [TestClass]
    public class MemoryStatusTests
    {
        private MemoryStatus status = new(null);

        [TestInitialize]
        public void Initialize()
        {
            status = new(null);
        }

        [TestMethod]
        public void AddErrorMessageTest()
        {
            string message = "Test Error Message";
            Assert.AreEqual(null, status.ErrorMessage);
            Assert.AreEqual(true, status.HasFreeSpace);

            status.AddErrorMessage(message);

            Assert.AreEqual(message, status.ErrorMessage);
            Assert.AreEqual(false, status.HasFreeSpace);
        }
    }
}
