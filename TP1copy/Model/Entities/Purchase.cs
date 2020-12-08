using System;
using System.Runtime.Serialization;

namespace TP1copy.Model
{
    [Serializable()]
    public class Purchase : Event, ISerializable
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
