using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class QuerySyntax : IDisposable
    {
        private static AdventureWorksDataContext dataContext = new AdventureWorksDataContext();

        public static void AddProduct(Product product)
        { 
            dataContext.Product.InsertOnSubmit(product);
            try
            {
                dataContext.SubmitChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static List<Product> GetAllProducts(int n)
        {
            IEnumerable<Product> products = from product in dataContext.Product
                                            orderby product.ProductID
                                            select product;
            if (n < 0)
                return products.ToList();
            return products.Take(n).ToList();
        }
        public static List<Product> GetProductsByName(string namePart)
        {
            IEnumerable<Product> products = from product in dataContext.Product
                                            where product.Name.Contains(namePart)
                                            orderby product.ProductID
                                            select product;
            return products.ToList();
        }
        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            IEnumerable<String> productNames = from pv in dataContext.ProductVendor
                                               where pv.Vendor.Name == vendorName
                                               select pv.Product.Name;
            return productNames.ToList();
        }
        // ! In this db one product can be assigned to more than 1 vendor
        public static List<string> GetProductVendorByProductName(string productName)
        {
            IEnumerable<String> vendorName = from pv in dataContext.ProductVendor
                                             where pv.Product.Name == productName
                                             select pv.Vendor.Name;
            return vendorName.ToList();
        }
        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            IEnumerable<Product> products = from pr in dataContext.ProductReview
                                            orderby pr.ReviewDate descending
                                            select pr.Product;
            return products.Take(howManyReviews).Distinct().ToList();
        }
        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            IEnumerable<Product> products = from pr in dataContext.ProductReview
                                            orderby pr.ReviewDate descending
                                            select pr.Product;
            return products.Distinct().Take(howManyProducts).ToList();
        }
        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            IEnumerable<Product> products = from product in dataContext.Product
                                            where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                            orderby product.Name
                                            select product;
            return products.Take(n).ToList();
        }
        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            IEnumerable<Decimal> standardCosts = from product in dataContext.Product
                                            where product.ProductSubcategory.ProductCategory.ProductCategoryID.Equals(category.ProductCategoryID)
                                            select product.StandardCost;
            return Decimal.ToInt32(standardCosts.Sum());
        }
        public static ProductCategory GetProductCategoryFromName(String categoryName)
        {
            IEnumerable<ProductCategory> categories = from category in dataContext.ProductCategory
                                                      where category.Name.Equals(categoryName)
                                                      select category;
            return categories.First();
        }

        public void Dispose()
        {
            dataContext.Dispose();
        }
    }
}
