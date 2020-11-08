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
            return bookItem.ToString() + "; (" + stock.ToString() + "); " + prize.ToString("0.00") + currency;
        }

        public override bool Equals(object obj)
        {
            return obj is CopyInfo info &&
                   EqualityComparer<BookItem>.Default.Equals(bookItem, info.bookItem) &&
                   stock == info.stock &&
                   prize == info.prize &&
                   currency == info.currency;
        }
        public override int GetHashCode()
        {
            int hashCode = -1595896239;
            hashCode = hashCode * -1521134295 + EqualityComparer<BookItem>.Default.GetHashCode(bookItem);
            hashCode = hashCode * -1521134295 + stock.GetHashCode();
            hashCode = hashCode * -1521134295 + prize.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(currency);
            return hashCode;
        }
    }

}
