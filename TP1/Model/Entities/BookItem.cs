using System;
using System.Collections.Generic;
using System.Text;

namespace TP1.Model
{
    public class BookItem
    {
        public string title { get; set; }
        public string author { get; set; }

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
            return "\"" + title + "\"" + ", " + author;
        }
    }
}
