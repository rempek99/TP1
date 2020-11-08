using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1;
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
            Console.WriteLine("Imiona czytelnikow zapisane w pliku: ");
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
            foreach (string info in libraryManager.GetInfo("events"))
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
            libraryManager.RegisterBorrowing(1, 0);
            libraryManager.RegisterPurchase(0, 0);
            foreach (string info in libraryManager.GetInfo("copyInfos"))
                Console.WriteLine(info);
            foreach (string info in libraryManager.GetInfo("events"))
                Console.WriteLine(info);
            Console.ReadLine();
            libraryManager.SetReturned(1);
            if (libraryManager.SetReturned(1) == false)
                Console.WriteLine("DZIALA");
            foreach (string info in libraryManager.GetInfo("events"))
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
            foreach (string info in libraryManager.GetInfo("events"))
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
            foreach (string info in libraryManager.GetInfo("events"))
                Console.WriteLine(info);
            libraryManager.SetReturned(0);
            Console.WriteLine("ZWROT KSIAZKI KAROLINY");
            foreach (string info in libraryManager.GetInfo("events"))
                Console.WriteLine(info);
            Console.ReadLine();
        }
    }
}
