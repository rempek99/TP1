using System;
using System.Collections.Generic;
using System.Text;

namespace TP1
{
    public class BookItem
    {
        private string title, author;

        public BookItem(string title, string author)
        {
            this.title = title;
            this.author = author;
        }

        public override string ToString()
        {
            return title + ", " + author;
        }
    }
}
