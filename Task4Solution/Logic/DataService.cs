using Data;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class DataService : IDataService
    {
        public void addProduct(string name, string productNumber, string color, double StandardCost)
        {
            throw new NotImplementedException();
        }

        public List<Dictionary<string, string>> getAll(int pageSize)
        {
            List<Product> products = QuerySyntax.GetAllProducts(pageSize);
            List<Dictionary<string, string>> outputData = new List<Dictionary<string, string>>();
            foreach (Product p in products)
            {
                Dictionary<String, String> currentProductData = new Dictionary<string, string>();
                currentProductData.Add("Name", p.Name);
                currentProductData.Add("ProductNumber", p.ProductNumber);
                currentProductData.Add("Color", p.Color);
                currentProductData.Add("StandardCost", p.StandardCost.ToString());
                outputData.Add(currentProductData);
            }
            return outputData;
        }

        public Dictionary<string, string> getProduct(string name)
        {
            throw new NotImplementedException();
        }

        public void removeProduct(string name)
        {
            throw new NotImplementedException();
        }
    }
}
