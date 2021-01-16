using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Product
    {
        public String Name { get; set; }
        public String ProductNumber { get; set; }
        public String Color{ get; set; }
        public Double StandardCost { get; set; }

        public Product(string name, string productNumber, string color, double standardCost)
        {
            this.Name = name;
            this.ProductNumber = productNumber;
            this.Color = color;
            StandardCost = standardCost;
        }
    }
}
