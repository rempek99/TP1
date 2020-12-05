using System;
using System.Runtime.Serialization;

namespace TP1.Model
{
    [DataContract]
    public class Purchase : Event
    {
        public Purchase() : base()
        { }
        public Purchase(Reader reader, CopyInfo copyInfo) : base(reader, copyInfo)
        {
        }

        public Purchase(Reader reader, CopyInfo copyInfo, DateTime eventDate) : base(reader, copyInfo, eventDate)
        {
        }

        public override double GetPrize()
        {
            return copyInfo.prize;
        }
    }
}
