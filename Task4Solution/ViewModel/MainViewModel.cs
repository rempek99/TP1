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
        private string m_CurrentMessage;
        

        public MainViewModel()
        {
            m_dataContext = new DataContext();
            m_Products = m_dataContext.products;
            m_CurrentProduct = m_Products[0];
          //  EditedProduct = CurrentProduct;
            m_CurrentMessage = "Welcome";
            AddSampleProduct = new MyCommand(() => {CurrentMessage = m_dataContext.addProduct(new Product(99, "test", "333-92", "Red", 20.12, 200)); Products = m_dataContext.products; });
            RemoveSampleProduct = new MyCommand(() => { CurrentMessage = m_dataContext.removeProduct("test"); Products = m_dataContext.products; });
            UpdateSampleProduct = new MyCommand(() => { CurrentMessage = m_dataContext.updateProduct(CurrentProduct); Products = m_dataContext.products; });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Product EditedProduct
        {
            get => m_CurrentProduct;
        }

        public ObservableCollection<Product> Products
        {
            get => m_Products;
            set
            {
                m_Products = value;
                onPropertChanged(nameof(Products));
            }
        }
        public Product CurrentProduct
        {
            get => m_CurrentProduct;
            set
            {
                m_CurrentProduct = value;
                onPropertChanged(nameof(CurrentProduct));
            }
        }
        public string CurrentMessage
        {
            get => m_CurrentMessage;
            set
            {
                m_CurrentMessage = value;
                onPropertChanged(nameof(CurrentMessage));
            }
        }
        public MyCommand AddSampleProduct
        {
            get; private set;
        }
        public MyCommand RemoveSampleProduct
        {
            get; private set;
        }
        public MyCommand UpdateSampleProduct
        {
            get; private set;
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

       private void onPropertChanged(string propertName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertName));
            }
        }
    }
}
