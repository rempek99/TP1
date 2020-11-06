using System;
using System.Collections.Generic;
using System.Text;

namespace TP1.Model
{
    public class Reader //: Ccllient
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public IProfiler profiler;
        public Reader(string name, string lastName, IProfiler discounter)
        {
            this.name = name;
            this.lastName = lastName;
            this.profiler = discounter;
        }

        public double GetDiscount()
        {
            return profiler.GetDiscount();
        }

        override public string ToString()
        {
            return name + " " + lastName + " (" + profiler +")";
        }

        public override bool Equals(object obj)
        {
            return obj is Reader reader &&
                   name == reader.name &&
                   lastName == reader.lastName &&
                   EqualityComparer<IProfiler>.Default.Equals(profiler, reader.profiler);
        }
    }
}
