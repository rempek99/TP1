using System;
using System.Runtime.Serialization;

namespace SampleClasses
{
    public class Class1 : ISerializable
    {
        public Guid id { get; set; }
        public int contentInt { get; set; }
        public Class2 refC2 { get; set; }

        public Class1()
        {
            this.id = Guid.NewGuid();
        }

        public Class1(int contentInt, Class2 refC2)
        {
            this.id = Guid.NewGuid();
            this.contentInt = contentInt;
            this.refC2 = refC2;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", id);
            info.AddValue("contentInt", contentInt);
            info.AddValue("refC2", refC2);
        }
        public override string ToString()
        {
            return this.GetType() + "{id=" + id + ", contentInt=" + contentInt + ", refC2=\n" + refC2.ToString() + '}';
        }
    }
}
