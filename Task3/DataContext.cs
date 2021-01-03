using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class DataContext
    {
        public List<MyProduct> Products { get; set; }
        public List<MyCategory> Categories { get; set; }
        public List<MyVendor> Vendors { get; set; }
        public DataContext() 
        {
            Products = new List<MyProduct>();
            Categories = new List<MyCategory>();
            Vendors = new List<MyVendor>();

            // Sample Data
            MyVendor v1 = new MyVendor();
            v1.name = "Vendor1";
            MyVendor v2 = new MyVendor();
            v2.name = "Vendor2";
            MyVendor v3 = new MyVendor();
            v3.name = "Vendor3";
            Vendors.Add(v1);
            Vendors.Add(v2);
            Vendors.Add(v3);
            MyCategory c1 = new MyCategory();
            c1.name = "Category1";
            MyCategory c2 = new MyCategory();
            c2.name = "Category2";
            MyCategory c3 = new MyCategory();
            c3.name = "Category3";
            Categories.Add(c1);
            Categories.Add(c2);
            Categories.Add(c3);
            MyProduct p1 = new MyProduct
            {
                name = "Product1",
                vendor = v1,
                category = c1,
                prize = 20.12
            };
            MyProduct p2 = new MyProduct
            {
                name = "Product2",
                vendor = v2,
                category = c1,
                prize = 1.59
            };
            MyProduct p3 = new MyProduct
            {
                name = "Product3",
                vendor = v2,
                category = c2,
                prize = 51.21
            };
            MyProduct p4 = new MyProduct
            {
                name = "Product4",
                vendor = v3,
                category = c1,
                prize = 0.99
            };
            MyProduct p5 = new MyProduct
            {
                name = "Product5",
                vendor = v3,
                category = c3,
                prize = 100.55
            };
            Products.Add(p1);
            Products.Add(p2);
            Products.Add(p3);
            Products.Add(p4);
            Products.Add(p5);
        }
    }
}
