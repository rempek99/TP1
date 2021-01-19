using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Threading;
using ViewModel;

namespace Task4Tests
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void SimpleTest()
        {
            Product product = new Product(1, "test", "testNo", "testColor", 1.0, 10);
            Assert.IsNotNull(product);
            DataContext dc = new DataContext(new TestDataService());
            Assert.IsNotNull(dc);
            Assert.AreEqual("added", dc.addProduct(product));
            Assert.AreEqual("removed", dc.removeProduct("test"));
            Assert.AreEqual("updated", dc.updateProduct(product));
        }
    }
}
