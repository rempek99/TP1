using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TP1.Model
{
    [DataContract, KnownType(typeof(Borrowing)),KnownType(typeof(Purchase))]

    public abstract class Event
    {
        [DataMember]
        public Reader reader { get; set; }
        [DataMember]
        public CopyInfo copyInfo { get; set; }
        [DataMember]
        public DateTime eventDate { get; set; }
        [DataMember]
        public DateTime endDate { get; set; }

        protected Event()
        {
        }

        public Event(Reader reader, CopyInfo copyInfo)
        {
            this.reader = reader;
            this.copyInfo = copyInfo;
            this.eventDate = DateTime.Now;
        }
        public Event(Reader reader, CopyInfo copyInfo, DateTime eventDate)
        {
            this.reader = reader;
            this.copyInfo = copyInfo;
            this.eventDate = eventDate;
        }
        public override string ToString()
        {
            string output = this.GetType().Name + "; " + reader.ToString() + "; " +
                copyInfo.bookItem.ToString() + "; " + GetPrize().ToString("0.00") + copyInfo.currency+ "; " + eventDate;
            return output;
        }

     
        public abstract double GetPrize();

        public override int GetHashCode()
        {
            int hashCode = 762025183;
            hashCode = hashCode * -1521134295 + EqualityComparer<Reader>.Default.GetHashCode(reader);
            hashCode = hashCode * -1521134295 + EqualityComparer<CopyInfo>.Default.GetHashCode(copyInfo);
            hashCode = hashCode * -1521134295 + eventDate.GetHashCode();
            hashCode = hashCode * -1521134295 + endDate.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   EqualityComparer<Reader>.Default.Equals(reader, @event.reader) &&
                   EqualityComparer<CopyInfo>.Default.Equals(copyInfo, @event.copyInfo) &&
                   eventDate == @event.eventDate &&
                   endDate == @event.endDate;
        }
    }

}
