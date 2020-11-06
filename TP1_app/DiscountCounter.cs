using System;
using System.Collections.Generic;
using System.Text;
using TP1;
using TP1.Model;

namespace TP1_app
{
    public class DiscountCounter : IProfiler
    {
        private float discountValue;

        public DiscountCounter(float discountValue)
        {
            this.discountValue = discountValue;
        }
        public double GetDiscount()
        {
            throw new NotImplementedException();
        }
    }
}
