using System;
using System.Collections.Generic;

namespace Logic
{
    public interface IDataService
    {
        void addProduct(string name, string productNumber, string color, double standardCost, short safetyStockLevel);
        void removeProduct(String name);
        Dictionary<String,String> getProduct(String name);
        List<Dictionary<String, String>> getAll(int pageSize);
    }
}
