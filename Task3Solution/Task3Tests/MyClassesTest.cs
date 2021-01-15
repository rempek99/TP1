using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Task3;

namespace Task3Tests
{
    [TestClass]
    public class MyClassesTest
    {
        [TestMethod]
        public void GetNProductsFromCatTest()
        {
            List<MyProduct> list = MyMethods.GetNProductsFromCategory("Category1", 2);
            Assert.AreEqual("Product1", list[0].name);
            Assert.AreEqual("Product2", list[1].name);
        }

        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<String> names = MyMethods.GetProductNamesByVendorName("Vendor2");
            Assert.AreEqual("Product2", names[0]);
            Assert.AreEqual("Product3", names[1]);
        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            String name = MyMethods.GetProductVendorByProductName("Product5");
            Assert.AreEqual("Vendor3", name);
        }
    }
}
