using System;
using System.Collections.Generic;
using System.Text;

namespace TP1
{
    public class Borrow
    {
        int id;
        IClient client;
        CopyInfo book;
        DateTime startDate, endDate;

        public Borrow(int id, IClient client, CopyInfo book, DateTime startDate, DateTime endDate)
        {
            this.id = id;
            this.client = client;
            this.book = book;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public Borrow(int id, IClient client, CopyInfo book, DateTime startDate)
        {
            this.id = id;
            this.client = client;
            this.book = book;
            this.startDate = startDate;
        }

        public Borrow(int id, IClient client, CopyInfo book)
        {
            this.id = id;
            this.client = client;
            this.book = book;
            this.startDate = DateTime.Now;
        }

        public void setReturned()
        {
            this.endDate = DateTime.Now;
        }

        public override string ToString()
        {
            return id + ") " + client.ToString() + book.ToString() + startDate;   
        }
    }
}
