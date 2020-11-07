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

       /* public void setReturned()
        {
            this.endDate = DateTime.Now;
        }*/

        public override string ToString()
        {
            string output = reader.ToString() + "; " + copyInfo+ "; " + startDate;
            if (endDate != new DateTime(0))
                output += "; " + endDate;
            return output;
        }

        public override bool Equals(object obj)
        {
            return obj is Borrowing borrowing &&
                   EqualityComparer<Reader>.Default.Equals(reader, borrowing.reader) &&
                   EqualityComparer<CopyInfo>.Default.Equals(copyInfo, borrowing.copyInfo) &&
                   startDate == borrowing.startDate &&
                   endDate == borrowing.endDate;
        }
    }
}
