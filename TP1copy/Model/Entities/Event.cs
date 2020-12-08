using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TP1copy.Model
{
    [Serializable()]
    public abstract class Event : ISerializable
    {
        public Guid id { get; set; }
        public Reader reader { get; set; }
        public CopyInfo copyInfo { get; set; }
        public DateTime eventDate { get; set; }
        public DateTime endDate { get; set; }

        protected Event()
        {
            id = Guid.NewGuid();
        }

        public Event(Reader reader, CopyInfo copyInfo)
        {
            id = Guid.NewGuid();
            this.reader = reader;
            this.copyInfo = copyInfo;
            this.eventDate = DateTime.Now;
        }
        public Event(Reader reader, CopyInfo copyInfo, DateTime eventDate)
        {
            id = Guid.NewGuid();
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", id);
            info.AddValue("reader", reader);
            info.AddValue("copyInfo", copyInfo);
            info.AddValue("eventDate", eventDate);
            info.AddValue("endDate", endDate);
        }
        public Event(SerializationInfo info, StreamingContext context)
        {
            id = (Guid)info.GetValue("id", typeof(Guid));
            reader = (Reader)info.GetValue("reader", typeof(Reader));
            copyInfo = (CopyInfo)info.GetValue("copyInfo", typeof(CopyInfo));
            eventDate = (DateTime)info.GetValue("eventDate", typeof(DateTime));
            endDate = (DateTime)info.GetValue("endDate", typeof(DateTime));
        }
    }

}
