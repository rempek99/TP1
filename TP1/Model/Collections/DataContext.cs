using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TP1.Model
{
    public class DataContext
    {
        public List<Reader> readers = new List<Reader>();
        public Dictionary<int, BookItem> books = new Dictionary<int, BookItem>();
        public ObservableCollection<Event> events = new ObservableCollection<Event>();
        public List<CopyInfo> copyInfos = new List<CopyInfo>();

        public DataContext()
        {
        }
    }
}
