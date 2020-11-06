using System;
using System.Collections.Generic;
using System.Text;
using TP1;



namespace TP1.Model
{
    public class CopyInfo
    {
        public BookItem bookItem { get; set; }
        public int stock { get; set; }
        public double prize { get; set; }
        public string currency { get; set; }

        public CopyInfo(BookItem bookItem, int stock, double prize, string currency)
        {
            this.bookItem = bookItem;
            this.stock = stock;
            this.prize = prize;
            this.currency = currency;
        }

        override public string ToString()
        {
            return bookItem.ToString() + "; (" + stock.ToString() + "); " + prize.ToString() + currency;
        }

        public override bool Equals(object obj)
        {
            return obj is CopyInfo info &&
                   EqualityComparer<BookItem>.Default.Equals(bookItem, info.bookItem) &&
                   prize == info.prize &&
                   currency == info.currency;
        }
    }

}
