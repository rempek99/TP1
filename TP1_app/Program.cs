using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1.Logic;
using TP1.Model;
namespace TP1_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader k1 = new Reader("Jan", "Kowalski", Profile.standard);
            IDataRepository dataRepository = new DataRepository();
          /*  dataRepository.AddReader(k1);
            dataRepository.AddReader(k1);*/
            CopyInfo cp = new CopyInfo(new BookItem("Dziady", "Mickiewicz"),3 , 24.10f, "pln");
            CopyInfo cp2 = new CopyInfo(new BookItem("Dziady", "Mickiewicz"), 33, 24.10f, "pln");
            Console.WriteLine(cp == cp2);
            /*     dataRepository.AddBorrowing(new Borrowing(k1, cp));*/
            Console.WriteLine(dataRepository.GetBorrowing(0).ToString());
            dataRepository.UpdateReader(dataRepository.GetReader(0), "Andrzej", "Nowak");
            Console.WriteLine(dataRepository.GetBorrowing(0).ToString());
            Console.ReadLine();

            /* IDiscountCounter normalReader = new DiscountCounter(0.0f);
             IDiscountCounter youngReader = new DiscountCounter(0.5f);
             IReader k1 = new Reader("Jan", "Kowalski", 990214291, normalReader);
             IReader ky1 = new Reader("Jasiu", "Kowalski", 040214291, youngReader);
             CopyInfo cp = new CopyInfo(1, new BookItem("Dziady", "Mickiewicz"), new Prize(24.10f, 0.23f, "pln"));

             Borrow b1 = new Borrow(1, ky1, cp);
             Console.WriteLine(b1.ToString());
             Console.ReadLine();
             b1.setReturned();
             Console.ReadLine();*/
        }
    }
}
