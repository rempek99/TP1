using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TP1copy.Model
{
    [Serializable()]
    public class BookItem :ISerializable
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string author { get; set; }

        public BookItem()
        {
            id = Guid.NewGuid();
        }

        public BookItem(string title, string author)
        {
            this.title = title;
            this.author = author;
            id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            return obj is BookItem item &&
                   title == item.title &&
                   author == item.author;
        }

        public override string ToString()
        {
            return  "\"" + title + "\"" + ", " + author;
        }

        public override int GetHashCode()
        {
            int hashCode = 1709028807;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(author);
            return hashCode;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("title", title);
            info.AddValue("author", author);
            info.AddValue("id", id);
        }
        public BookItem(SerializationInfo info, StreamingContext context)
        {
            title = (string)info.GetValue("title", typeof(string));
            author = (string)info.GetValue("author", typeof(string));
            id = (Guid)info.GetValue("id", typeof(Guid));
        }
    }
}
