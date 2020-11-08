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
            
            XmlReader x = new XmlReader("data.xml");
            List<string> tmp = x.readData("reader","name");
            Console.WriteLine(new DateTime(0));
            foreach (string info in tmp)
                Console.WriteLine(info);

            LibraryManager libraryManager = new LibraryManager(new DataRepository(x));
            libraryManager.LoadFileData();
            foreach (string info in libraryManager.GetInfo("readers"))
                Console.WriteLine(info);
            foreach (string info in libraryManager.GetInfo("bookItems"))
                Console.WriteLine(info);
            foreach (string info in libraryManager.GetInfo("copyInfos"))
                Console.WriteLine(info);
            foreach (string info in libraryManager.GetInfo("borrowings"))
                Console.WriteLine(info);
            Console.ReadLine();
            libraryManager.AddNewReader("Jacek", "Kowal");
            libraryManager.AddNewReader("Aneta", "Dzwon");
            libraryManager.AddNewBookItem("Dziady", "Adam Mickiewicz");
            libraryManager.RegisterCopies(0, 20, 10.20, "pln");
            foreach (string info in libraryManager.GetInfo("copyInfos"))
                Console.WriteLine(info);
            libraryManager.RegisterCopies(0, 1, 10.99, "pln");
            foreach (string info in libraryManager.GetInfo("copyInfos"))
                Console.WriteLine(info);
            libraryManager.RegisterBorrowing(0, 0);
            libraryManager.RegisterBorrowing(1, 0);
            foreach (string info in libraryManager.GetInfo("copyInfos"))
                Console.WriteLine(info);
            foreach (string info in libraryManager.GetInfo("borrowings"))
                Console.WriteLine(info);
            Console.ReadLine();
            libraryManager.SetReturned(1);
            if (libraryManager.SetReturned(1) == false)
                Console.WriteLine("DZIALA");
            foreach (string info in libraryManager.GetInfo("borrowings"))
                Console.WriteLine(info);
            foreach (string info in libraryManager.GetInfo("copyInfos"))
                Console.WriteLine(info);
            Console.ReadLine();
            Console.WriteLine("PRZED USUNIECIEM");
            foreach (string info in libraryManager.GetInfo("readers"))
                Console.WriteLine(info);
            foreach (string info in libraryManager.GetInfo("bookItems"))
                Console.WriteLine(info);
            foreach (string info in libraryManager.GetInfo("copyInfos"))
                Console.WriteLine(info);
            foreach (string info in libraryManager.GetInfo("borrowings"))
                Console.WriteLine(info);
            libraryManager.RemoveReader(2);
            libraryManager.RemoveBookItem(0);
            libraryManager.RetractCopies(1);
            Console.WriteLine("USUNIETO KAROLINE i DZIADY");
            foreach (string info in libraryManager.GetInfo("readers"))
                Console.WriteLine(info);
            foreach (string info in libraryManager.GetInfo("bookItems"))
                Console.WriteLine(info);
            foreach (string info in libraryManager.GetInfo("copyInfos"))
                Console.WriteLine(info);
            foreach (string info in libraryManager.GetInfo("borrowings"))
                Console.WriteLine(info);
            libraryManager.SetReturned(0);
            Console.WriteLine("ZWROT KSIAZKI KAROLINY");
            foreach (string info in libraryManager.GetInfo("borrowings"))
                Console.WriteLine(info);
            Console.ReadLine();
            /* Reader k1 = new Reader("Jan", "Kowalski", Profile.standard);
            IDataRepository dataRepository = new DataRepository();
            dataRepository.AddReader(k1);
            dataRepository.AddReader(k1);
            CopyInfo cp = new CopyInfo(new BookItem("Dziady", "Mickiewicz"),3 , 24.10f, "pln");
            CopyInfo cp2 = new CopyInfo(new BookItem("Dziady", "Mickiewicz"), 33, 24.10f, "pln");
            Console.WriteLine(cp == cp2);
              dataRepository.AddBorrowing(new Borrowing(k1, cp));
            
            dataRepository.UpdateReader(0, "Andrzej", "Nowak");
            Console.WriteLine();
            Console.ReadLine();

             IDiscountCounter normalReader = new DiscountCounter(0.0f);
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
