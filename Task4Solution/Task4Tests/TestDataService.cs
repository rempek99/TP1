using Logic;
using System;
using System.Collections.Generic;

namespace Task4Tests
{
    public class TestDataService : IDataService
    {

        public string addProduct(string name, string productNumber, string color, double standardCost, short safetyStockLevel)
        {
            return "added";
        }

        public List<Dictionary<string, string>> getAll(int pageSize)
        {
            List < Dictionary<string, string>> test = new List<Dictionary<string, string>>();
            Dictionary<String, String> currentProductData = new Dictionary<string, string>();
            currentProductData.Add("ProductID", "1");
            currentProductData.Add("Name", "test");
            currentProductData.Add("ProductNumber", "test");
            currentProductData.Add("Color", "test");
            currentProductData.Add("StandardCost", "1.0");
            currentProductData.Add("SafetyStockLevel", "10");
            test.Add(currentProductData);
            return test;
        }

        public Dictionary<string, string> getProduct(string name)
        {
            return new Dictionary<string, string>();
        }

        public string removeProduct(string name)
        {
            return "removed";
        }

        public string updateProduct(int productID, string name, string productNumber, string color, double standardCost, short safetyStockLevel)
        {
            return "updated";
        }
    }
}