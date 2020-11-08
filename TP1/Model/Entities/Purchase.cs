using System;
using System.Collections.Generic;
using System.Text;

namespace TP1.Model
{
    public class Purchase : Event
    {
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
