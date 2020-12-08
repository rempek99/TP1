using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TP1copy.Model
{
    [Serializable()]
    public class CopyInfo :ISerializable
    {
        public Guid id { get; set; }
        public BookItem bookItem { get; set; }
        public int stock { get; set; }
        public double prize { get; set; }
        public string currency { get; set; } 

        public CopyInfo()
        {
            id = Guid.NewGuid();
        }

        public CopyInfo(BookItem bookItem, int stock, double prize, string currency)
        {
            this.bookItem = bookItem;
            this.stock = stock;
            this.prize = prize;
            this.currency = currency;
            id = Guid.NewGuid();
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("bookItem", bookItem);
            info.AddValue("stock", stock);
            info.AddValue("prize", prize);
            info.AddValue("currency", currency);
            info.AddValue("id", id);
        }
        public CopyInfo(SerializationInfo info, StreamingContext context)
        {
            bookItem = (BookItem)info.GetValue("bookItem", typeof(BookItem));
            stock = (int)info.GetValue("stock", typeof(int));
            prize = (double)info.GetValue("prize", typeof(double));
            currency = (string)info.GetValue("currency", typeof(string));
            id = (Guid)info.GetValue("id", typeof(Guid));
        }
    }

}
