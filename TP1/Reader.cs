using System;
using System.Collections.Generic;
using System.Text;

namespace TP1
{
    public class Reader : IClient
    {
        private string name, lastName;
        private int personalID;
        private IDiscountCounter discounter;

        public Reader(string name, string lastName, int personalID, IDiscountCounter discounter)
        {
            this.name = name;
            this.lastName = lastName;
            this.personalID = personalID;
            this.discounter = discounter;
        }

        public float GetDiscount()
        {
            return discounter.getDiscount();
        }

        override public string ToString()
        {
            return name + " " + lastName + ", " + personalID.ToString();
        }
    }
}
