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
            products = convertData(dataService.getAll(100));
          /*  products = new ObservableCollection<Product>();

            products.Add(new Product("Product1", "123", "Black", 20.99));
            products.Add(new Product("Product2", "222", "White", 2.99));*/
        }

        private ObservableCollection<Product> convertData(List<Dictionary<String,String>> data)
        {
            ObservableCollection<Product> converted = new ObservableCollection<Product>();
            foreach(Dictionary<String,String> currentProduct in data)
            {
                Product p = new Product(currentProduct["Name"], currentProduct["ProductNumber"], currentProduct["Color"], Double.Parse(currentProduct["StandardCost"]));
                converted.Add(p);
            }
            return converted;
        }
    }
}
