using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TP1.Model
{
    public class DataContext
    {
        public List<Reader> readers = new List<Reader>();
        public Dictionary<int, BookItem> books = new Dictionary<int, BookItem>();
        public ObservableCollection<Borrowing> borrowings = new ObservableCollection<Borrowing>();
        public List<CopyInfo> copyInfos = new List<CopyInfo>();

        public DataContext()
        {
        }
    }
}
