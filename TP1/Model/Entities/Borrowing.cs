using System;

namespace TP1.Model
{
    public class Borrowing : Event
    {

        public Borrowing(Reader reader, CopyInfo copyInfo, DateTime eventDate, DateTime endDate) :base(reader,copyInfo,eventDate)
        {
            this.endDate = endDate;
        }

        public Borrowing(Reader reader, CopyInfo copyInfo, DateTime eventDate) :base(reader,copyInfo,eventDate)
        {
        }

        public Borrowing(Reader reader, CopyInfo copyInfo) : base(reader,copyInfo)
        {
        }

        public void setReturned()
        {
            this.endDate = DateTime.Now;
        }

        public override string ToString()
        {
            string output = base.ToString();
            if (endDate != new DateTime(0))
                output += "; " + endDate;
            return output;
        }

        public override double GetPrize()
        {
            return copyInfo.prize * 0.2;
        }

    }
}
