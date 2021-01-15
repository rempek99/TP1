using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class MethodSyntax
    {
        private static DataClasses1DataContext dataContext = new DataClasses1DataContext();
        public static List<Product> GetProductsByName(string namePart)
        {
            IEnumerable<Product> products = dataContext.Product.Where<Product>(product => product.Name.Contains(namePart)).OrderBy<Product, Int32>(product => product.ProductID);
            return products.ToList();
        }
        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            IEnumerable<String> productNames = dataContext.ProductVendor.Where<ProductVendor>(productVendor => productVendor.Vendor.Name.Equals(vendorName)).Select<ProductVendor,String>(productVendor => productVendor.Product.Name);
            return productNames.ToList();
        }
        // ! In this db one product can be assigned to more than 1 vendor
        public static List<String> GetProductVendorByProductName(string productName)
        {
            IEnumerable<String> vendorName = dataContext.ProductVendor.Where<ProductVendor>(productVendor => productVendor.Product.Name.Equals(productName)).Select<ProductVendor, String>(productVendor => productVendor.Vendor.Name);
            return vendorName.ToList();
        }
        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            IEnumerable<Product> products = dataContext.ProductReview.OrderByDescending<ProductReview, DateTime>(productReview => productReview.ReviewDate).Select<ProductReview, Product>(productReview => productReview.Product);
            return products.Take(howManyReviews).Distinct().ToList();
        }
        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            IEnumerable<Product> products = dataContext.ProductReview.OrderByDescending<ProductReview, DateTime>(productReview => productReview.ReviewDate).Select<ProductReview, Product>(productReview => productReview.Product);
            return products.Distinct().Take(howManyProducts).ToList();
        }
        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            IEnumerable<Product> products = dataContext.Product.Where<Product>(product => product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)).OrderBy<Product,String>(product => product.Name);
            return products.Take(n).ToList();
        }
        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            IEnumerable<Decimal> standardCosts = dataContext.Product.Where<Product>(product => product.ProductSubcategory.ProductCategory.ProductCategoryID.Equals(category.ProductCategoryID)).Select<Product,Decimal>(product => product.StandardCost);
            return Decimal.ToInt32(standardCosts.Sum());
        }
        public static ProductCategory GetProductCategoryFromName(String categoryName)
        {
            IEnumerable<ProductCategory> categories = dataContext.ProductCategory.Where<ProductCategory>(productCategory => productCategory.Name.Equals(categoryName));
            return categories.First();
        }
    }
}
