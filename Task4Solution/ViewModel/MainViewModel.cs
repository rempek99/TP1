using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DataContext m_dataContext;
        private ObservableCollection<Product> m_Products;
        private Product m_CurrentProduct;

        public MainViewModel()
        {
            m_dataContext = new DataContext();
            m_Products = m_dataContext.products;
            m_CurrentProduct = m_Products[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Product> Products
        {
            get => m_Products;
            set
            {
                m_Products = value;
                onPropertyChanged(nameof(Products));
            }
        }
        public Product CurrentProduct
        {
            get => m_CurrentProduct;
            set
            {
                m_CurrentProduct = value;
                onPropertyChanged(nameof(CurrentProduct));
            }
        }


        public DataContext dataContext
        {
            get => m_dataContext;
            set
            {
                m_dataContext = value;
                Products = new ObservableCollection<Product>(value.products);
            }
        }

       private void onPropertyChanged(string propertName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertName));
            }
        }
    }
}
