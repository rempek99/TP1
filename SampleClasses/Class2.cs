using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SampleClasses
{
    public class Class2 : ISerializable
    {
       // public Guid id { get; set; }
        public string contentString { get; set; }
        public Class3 refC3 { get; set; }

        public Class2()
        {
            //this.id = Guid.NewGuid();
        }

        public Class2(string contentString, Class3 refC3)
        {
           // this.id = Guid.NewGuid();
            this.contentString = contentString;
            this.refC3 = refC3;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //info.AddValue("id", id);
            info.AddValue("contentString", contentString);
            info.AddValue("refC3", refC3);
        }
        public override string ToString()
        {
            return this.GetType() + "{contentString=" + contentString + ", refC3=\n" + refC3.ToString() + '}';
        }
    }
}
