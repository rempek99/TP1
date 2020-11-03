using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1;
namespace TP1_app
{
    class Program
    {
        static void Main(string[] args)
        {
            IDiscountCounter normalClient = new DiscountCounter(0.0f);
            IDiscountCounter youngClient = new DiscountCounter(0.5f);
            IClient k1 = new Reader("Jan", "Kowalski", 990214291, normalClient);
            IClient ky1 = new Reader("Jasiu", "Kowalski", 040214291, youngClient);
            CopyInfo cp = new CopyInfo(1, new BookItem("Dziady", "Mickiewicz"), new Prize(24.10f, 0.23f, "pln"));

            Borrow b1 = new Borrow(1, ky1, cp);
            Console.WriteLine(b1.ToString());
            Console.ReadLine();
            b1.setReturned();
            Console.ReadLine();
        }
    }
}
