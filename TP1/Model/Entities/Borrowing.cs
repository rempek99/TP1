using System;
using System.Collections.Generic;
using System.Text;

namespace TP1.Model
{
    public class Borrowing
    {
        public Reader reader { get; set; }
        public CopyInfo copyInfo { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public Borrowing(Reader reader, CopyInfo copyInfo, DateTime startDate, DateTime endDate)
        {
            this.reader = reader;
            this.copyInfo = copyInfo;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public Borrowing(Reader reader, CopyInfo copyInfo, DateTime startDate)
        {
            this.reader = reader;
            this.copyInfo = copyInfo;
            this.startDate = startDate;
        }

        public Borrowing(Reader reader, CopyInfo copyInfo)
        { 
            this.reader = reader;
            this.copyInfo = copyInfo;
            this.startDate = DateTime.Now;
        }

        public void setReturned()
        {
            this.endDate = DateTime.Now;
        }

        public override string ToString()
        {
            return reader.ToString() + "; " + copyInfo.ToString() + "; " + startDate;   
        }
    }
}
