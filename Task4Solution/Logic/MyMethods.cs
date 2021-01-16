using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class MyMethods 
    {
        private static DataContext dataContext = new DataContext();
        public static List<MyProduct> GetNProductsFromCategory(string categoryName, int n)
        {
            IEnumerable<MyProduct> products = dataContext.Products.Where<MyProduct>(product => product.category.name.Equals(categoryName)).OrderBy<MyProduct,String>(product => product.name);
            return products.Take(n).ToList();
        }
        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            IEnumerable<String> productNames = from p in dataContext.Products
                                               where p.vendor.name == vendorName
                                               select p.name;
            return productNames.ToList();
        }
        public static String GetProductVendorByProductName(string productName)
        {
            IEnumerable<String> vendorName = dataContext.Products.Where<MyProduct>(product => product.name.Equals(productName)).Select<MyProduct, String>(product => product.vendor.name);
            return vendorName.First();
        }
    }
}
