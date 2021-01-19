using System;

namespace Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public String Name { get; set; }
        public String ProductNumber { get; set; }
        public String Color{ get; set; }
        public Double StandardCost { get; set; }
        public short SafetyStockLevel { get; set; }

        public Product(int productID, string name, string productNumber, string color, double standardCost, short safetyStockLevel)
        {
            this.ProductID = productID;
            this.Name = name;
            this.ProductNumber = productNumber;
            this.Color = color;
            this.SafetyStockLevel = safetyStockLevel;
            StandardCost = standardCost;
        }
    }
}
