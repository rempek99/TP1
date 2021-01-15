using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class ExtensionMethods
    {
        private static DataClasses1DataContext dataContext = new DataClasses1DataContext();
        public static List<Product> NullCategoryQS(this List<Product> products)
        {
            IEnumerable<Product> list = from product in products
                                          where product.ProductSubcategory == null
                                          select product;
            return list.ToList();
        }
        public static List<Product> NullCategoryMS(this List<Product> products)
        {
            IEnumerable<Product> list = products.Where<Product>(product => product.ProductSubcategory == null);
            return list.ToList();
        }
        public static List<Product> Page(this List<Product> products, int pageSize, int pageNo)
        {
            return products.Skip(pageNo * pageSize).Take(pageSize).ToList();
        }
        public static String ProductVendorString(this List<Product> products)
        {
            var query = from product in products
                        from productVendor in dataContext.ProductVendor
                        where product.ProductID == productVendor.ProductID
                        select new {pName =  productVendor.Product.Name, vName =  productVendor.Vendor.Name };
            return string.Join("\n", query.Select(x => $"{x.pName}-{x.vName}").ToArray());
        }
    }
}
