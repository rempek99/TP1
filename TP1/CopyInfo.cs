using System;
using System.Collections.Generic;
using System.Text;
using TP1;

public struct Prize
{
    public Prize(float brutto, float vat, string currency)
    {
        this.brutto = brutto;
        this.vat = vat;
        this.currency = currency;
    }
    override public string ToString()
    {
        return brutto.ToString("0.00") + currency + " (vat" + (vat*100).ToString() + "%)";
    }
    float brutto;
    float vat;
    string currency;
}

namespace TP1
{
    public class CopyInfo
    {
        int id;
        BookItem book;
        Prize prize;

        public CopyInfo(int id, BookItem book, Prize prize)
        {
            this.id = id;
            this.book = book;
            this.prize = prize;
        }
        override public string ToString()
        {
            return id + ") " + book.ToString() + ", " + prize.ToString();
        }
    }
}
