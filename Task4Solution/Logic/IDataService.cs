using System;
using System.Collections.Generic;

namespace Logic
{
    public interface IDataService
    {
        void addProduct(String name, String productNumber, String color, double StandardCost);
        void removeProduct(String name);
        Dictionary<String,String> getProduct(String name);
        List<Dictionary<String, String>> getAll(int pageSize);
    }
}
