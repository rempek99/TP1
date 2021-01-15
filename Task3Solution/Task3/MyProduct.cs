using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class MyProduct
    {
        public String name { get; set; }
        public MyVendor vendor { get; set; }
        public MyCategory category { get; set; }
        public double prize { get; set; }
    }

    public class MyVendor
    {
        public String name { get; set; }
    }
    public class MyCategory
    {
        public String name { get; set; }
    }
}
