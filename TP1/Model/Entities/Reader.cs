using System;
using System.Collections.Generic;
using System.Text;

namespace TP1.Model
{
    public class Reader //: Ccllient
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public Reader(string name, string lastName)
        {
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
    }
}
