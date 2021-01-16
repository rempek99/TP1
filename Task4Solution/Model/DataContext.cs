using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logic;

namespace Model
{
    public class DataContext
    {
        public IDataService dataService;
        public ObservableCollection<Product> products { get; set; }

        public DataContext()
        {
            this.dataService = new DataService();
            products = convertData(dataService.getAll(-1));
        }

        private ObservableCollection<Product> convertData(List<Dictionary<String,String>> data)
        {
            ObservableCollection<Product> converted = new ObservableCollection<Product>();
            foreach(Dictionary<String,String> currentProduct in data)
            {
                Product p = new Product(Int32.Parse(currentProduct["ProductID"]), currentProduct["Name"], currentProduct["ProductNumber"], currentProduct["Color"], Double.Parse(currentProduct["StandardCost"]), short.Parse(currentProduct["SafetyStockLevel"]));
                converted.Add(p);
            }
            return converted;
        }
        public void addProduct(Product product)
        {
            dataService.addProduct(product.Name, product.ProductNumber, product.Color, product.StandardCost, product.SafetyStockLevel);
            products = convertData(dataService.getAll(-1));
        }
    }
}
