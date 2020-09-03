using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoRentalStore;

namespace UnitTestsForVideoRentalStore
{
    [TestClass]
    public class ConnectionDB
    {
        [TestMethod]
        public void CheckDatabaseConnection_ConnectionOpen_True()
        {
            ManageLoginRegister mlr = new ManageLoginRegister();
            bool assertionValue = mlr.CheckDatabaseConnection();
            Assert.IsTrue(assertionValue);

        }
    }
}
