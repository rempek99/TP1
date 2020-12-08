using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace TP1copy.Model
{
    [Serializable()]
    public class DataContext : ISerializable
    {
        public Guid id { get; set; }
        public List<Reader> readers { get; set; } = new List<Reader>();
        public Dictionary<int, BookItem> books { get; set; } = new Dictionary<int, BookItem>();
        public List<CopyInfo> copyInfos { get; set; } = new List<CopyInfo>();
        public ObservableCollection<Event> events { get; set; } = new ObservableCollection<Event>();

        public DataContext()
        {
            id = Guid.NewGuid();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", id);
            info.AddValue("readers", readers);
            info.AddValue("books", books);
            info.AddValue("copyInfos", copyInfos);
            info.AddValue("events", events);
        }
        public DataContext(SerializationInfo info, StreamingContext context)
        {
            readers = (List<Reader>)info.GetValue("readers", typeof(List<Reader>));
            books = (Dictionary<int, BookItem>)info.GetValue("books", typeof(Dictionary<int, BookItem>));
            copyInfos = (List<CopyInfo>)info.GetValue("copyInfos", typeof(List<CopyInfo>));
            events = (ObservableCollection<Event>)info.GetValue("events", typeof(ObservableCollection<Event>));
        }
    }
}
