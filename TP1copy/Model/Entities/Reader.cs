using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TP1copy.Model
{
    [Serializable()]
    public class Reader : ISerializable
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; } 

        public Reader()
        {
            id = Guid.NewGuid();
        }

        public Reader(string name, string lastName)
        {
            id = Guid.NewGuid();
            this.name = name;
            this.lastName = lastName;
        }


        override public string ToString()
        {
            return name + " " + lastName ;
        }

        public override bool Equals(object obj)
        {
            return obj is Reader reader &&
                   name == reader.name &&
                   lastName == reader.lastName;
        }
        public override int GetHashCode()
        {
            int hashCode = -714586200;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(lastName);
            return hashCode;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        { 
            info.AddValue("name", name);
            info.AddValue("lastName", lastName);
            info.AddValue("id",id);
        }
        public Reader(SerializationInfo info, StreamingContext context)
        {
            name = (string)info.GetValue("name", typeof(string));
            lastName = (string)info.GetValue("lastname", typeof(string));
            id = (Guid)info.GetValue("id", typeof(Guid));
        }
    }
}
