using System;
using System.Collections.Generic;
using System.Text;

namespace TP1.Logic
{
    public class Profile : IProfiler
    {
        double discountValue;
        public static readonly Profile young = new Profile("young");
        public static readonly Profile standard = new Profile("standard");
        public double GetDiscount()
        {
            return discountValue;
        }
        protected Profile(string type)
        {
            if (type == "young")
            {
                discountValue = 0.5;
            }
            if (type == "standard")
            {
                discountValue = 0.0;
            }
        }
    }
}
