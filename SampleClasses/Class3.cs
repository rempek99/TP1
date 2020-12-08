using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SampleClasses
{
    public class Class3 : ISerializable
    {
        public Guid id { get; set; }
        public DateTime contentDate { get; set; }
        public Class1 refC1 { get; set; }

        public Class3()
        {
            this.id = Guid.NewGuid();
        }

        public Class3(DateTime contentDate, Class1 refC1)
        {
            this.id = Guid.NewGuid();
            this.contentDate = contentDate;
            this.refC1 = refC1;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", id);
            info.AddValue("contentDate", contentDate);
            info.AddValue("refC1", refC1);
        }
        public override string ToString()
        {
            return this.GetType() + "{id=" + id + ", contentDate=" + contentDate + ", refC1=" + refC1.GetType() + '}';
        }
    }
}
