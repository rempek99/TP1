using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace TP1.Model
{
    [DataContract]
    public class DataContext 
    {
        [DataMember]
        public List<Reader> readers = new List<Reader>();
        [DataMember]
        public Dictionary<int, BookItem> books = new Dictionary<int, BookItem>();
        [DataMember]
        public List<CopyInfo> copyInfos = new List<CopyInfo>();
        [DataMember]
        public ObservableCollection<Event> events = new ObservableCollection<Event>();

        public DataContext()
        {
        }
    }
}
