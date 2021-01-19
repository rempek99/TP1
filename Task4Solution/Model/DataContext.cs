using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logic;

namespace Model
{
    public class DataContext
    {
        public IDataService dataService { get; set; }
        public ObservableCollection<Product> products { get; set; }

        public DataContext()
        {
            this.dataService = new DataService();
            products = convertData(dataService.getAll(-1));
        }
        public DataContext(IDataService dataService)
        {
            this.dataService = dataService;
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

        public void setDataService(object obj)
        {
            this.dataService = (IDataService) obj;
        }

        public string addProduct(Product product)
        {
            string message = dataService.addProduct(product.Name, product.ProductNumber, product.Color, product.StandardCost, product.SafetyStockLevel);
            products = convertData(dataService.getAll(-1));
            return message;
        }
        public string removeProduct(String name)
        {
            string message = dataService.removeProduct(name);
            products = convertData(dataService.getAll(-1));
            return message;
        }
        public string updateProduct(Product product)
        {
            string message = "";
            try
            {
                message = dataService.updateProduct(product.ProductID, product.Name, product.ProductNumber, product.Color, product.StandardCost, product.SafetyStockLevel);
                products = convertData(dataService.getAll(-1));
            }
            catch (NullReferenceException)
            {
                return "Firstly add product";
            }
            return message;
        }
    }
}
