using System;
using System.Collections.Generic;
using System.Text;
using TP1;

namespace TP1_app
{
    public class DiscountCounter : IDiscountCounter
    {
        private float discountValue;

        public DiscountCounter(float discountValue)
        {
            this.discountValue = discountValue;
        }
        public float getDiscount()
        {
            return discountValue;
        }
    }
}
