using Data;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Task3Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void QuerySyntaxTest()
        {
            List<Product> productsList = null;
            Assert.IsNull(productsList);
            productsList = QuerySyntax.GetProductsByName("Blade");
            Assert.IsNotNull(productsList);
            Assert.AreEqual("Blade", productsList[0].Name);
            productsList = QuerySyntax.GetProductsWithNRecentReviews(3);
            Assert.AreEqual(937, productsList[0].ProductID);
            Assert.AreEqual(798, productsList[1].ProductID);

            List<String> namesList = QuerySyntax.GetProductNamesByVendorName("Beaumont Bikes");
            Assert.AreEqual("Chainring Bolts", namesList[0]);
            Assert.AreEqual("Chainring Nut", namesList[1]);
            Assert.AreEqual("Chainring", namesList[2]);

            namesList = QuerySyntax.GetProductVendorByProductName("Chainring");
            Assert.AreEqual("Training Systems", namesList[0]);
            Assert.AreEqual("Beaumont Bikes", namesList[1]);
            Assert.AreEqual("Bike Satellite Inc.",namesList[2]);

            productsList = QuerySyntax.GetNRecentlyReviewedProducts(3);
            Assert.AreEqual(937, productsList[0].ProductID);
            Assert.AreEqual(798, productsList[1].ProductID);
            Assert.AreEqual(709, productsList[2].ProductID);

            productsList = QuerySyntax.GetNProductsFromCategory("Bikes", 2);
            Assert.AreEqual(775, productsList[0].ProductID);
            Assert.AreEqual(776, productsList[1].ProductID);

            int sum = QuerySyntax.GetTotalStandardCostByCategory(QuerySyntax.GetProductCategoryFromName("Bikes"));
            Assert.AreEqual(92092, sum);
        }
        [TestMethod]
        public void MethodSyntaxTest()
        {
            List<Product> productsList = null;
            Assert.IsNull(productsList);
            productsList = MethodSyntax.GetProductsByName("Blade");
            Assert.IsNotNull(productsList);
            Assert.AreEqual("Blade", productsList[0].Name);
            productsList = MethodSyntax.GetProductsWithNRecentReviews(3);
            Assert.AreEqual(937, productsList[0].ProductID);
            Assert.AreEqual(798, productsList[1].ProductID);

            List<String> namesList = MethodSyntax.GetProductNamesByVendorName("Beaumont Bikes");
            Assert.AreEqual("Chainring Bolts", namesList[0]);
            Assert.AreEqual("Chainring Nut", namesList[1]);
            Assert.AreEqual("Chainring", namesList[2]);

            namesList = MethodSyntax.GetProductVendorByProductName("Chainring");
            Assert.AreEqual("Training Systems", namesList[0]);
            Assert.AreEqual("Beaumont Bikes", namesList[1]);
            Assert.AreEqual("Bike Satellite Inc.", namesList[2]);

            productsList = MethodSyntax.GetNRecentlyReviewedProducts(3);
            Assert.AreEqual(937, productsList[0].ProductID);
            Assert.AreEqual(798, productsList[1].ProductID);
            Assert.AreEqual(709, productsList[2].ProductID);

            productsList = MethodSyntax.GetNProductsFromCategory("Bikes", 2);
            Assert.AreEqual(775, productsList[0].ProductID);
            Assert.AreEqual(776, productsList[1].ProductID);

            int sum = MethodSyntax.GetTotalStandardCostByCategory(MethodSyntax.GetProductCategoryFromName("Bikes"));
            Assert.AreEqual(92092, sum);
        }
        [TestMethod]
        public void ExtensionMethodsTestMethodSyntax()
        {
            List<Product> productsList = MethodSyntax.GetProductsByName("Grip").NullCategoryMS();
            foreach(Product product in productsList)
                Assert.IsNull(product.ProductSubcategory);
        }
        [TestMethod]
        public void ExtensionMethodsTestQuerySyntax()
        {
            List<Product> productsList = QuerySyntax.GetProductsByName("Grip").NullCategoryQS();
            foreach (Product product in productsList)
                Assert.IsNull(product.ProductSubcategory);
        }
        [TestMethod]
        public void ExtensionMethodsTestPaging()
        {
            List<Product> productsList = QuerySyntax.GetProductsByName("Thin").Page(3,0);
            Assert.AreEqual(3, productsList.Count);
            Assert.AreEqual(359, productsList[0].ProductID);
            Assert.AreEqual(360, productsList[1].ProductID);
            Assert.AreEqual(361, productsList[2].ProductID);
        }
        [TestMethod]
        public void ExtensionMethodsTestProductsString()
        {
            String str = QuerySyntax.GetProductsByName("Grip").ProductVendorString();
            Console.Write(str);
            Assert.AreEqual("LL Grip Tape-Gardner Touring Cycles\nLL Grip Tape-National Bike Association\nML Grip Tape-Gardner Touring Cycles\nML Grip Tape-National Bike Association\nHL Grip Tape-Morgan Bike Accessories", str);
        }
    }
}
