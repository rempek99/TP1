using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TP1.Model
{
    [DataContract]
    public class BookItem
    {
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string author { get; set; }

        public BookItem()
        {
        }

        public BookItem(string title, string author)
        {
            this.title = title;
            this.author = author;
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
    }
}
