using System;
using System.Collections.Generic;

namespace Logic
{
    public interface IDataService
    {
        string addProduct(string name, string productNumber, string color, double standardCost, short safetyStockLevel);
        string removeProduct(String name);
        string updateProduct(int productID, string name, string productNumber, string color, double standardCost, short safetyStockLevel);
        Dictionary<String,String> getProduct(String name);
        List<Dictionary<String, String>> getAll(int pageSize);
    }
}
