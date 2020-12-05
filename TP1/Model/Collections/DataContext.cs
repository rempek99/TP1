using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace TP1.Model
{
    public class DataContext
    {
        public List<Reader> readers = new List<Reader>();
        public Dictionary<int, BookItem> books = new Dictionary<int, BookItem>();
        public List<CopyInfo> copyInfos = new List<CopyInfo>();
        public ObservableCollection<Event> events = new ObservableCollection<Event>();

        public DataContext()
        {
        }
    }
}
