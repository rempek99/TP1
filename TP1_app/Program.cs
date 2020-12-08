using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Serialization;
using SampleClasses;
using TP1.Logic;
using TP1.Model;

namespace TP1_app
{
class Program
    {
        bool filled = false;
        public static void FillWithSampleData(LibraryManager manager)
        {
            manager.AddNewReader("Jacek", "Kowal");
            manager.AddNewReader("Aneta", "Dzwon");
            manager.AddNewBookItem("Dziady", "Adam Mickiewicz");
            manager.RegisterCopies(0, 20, 10.20, "pln");
            manager.RegisterCopies(0, 1, 10.99, "pln");
            manager.RegisterBorrowing(1, 0);
            manager.RegisterPurchase(0, 0);
        }
        static void Main(string[] args)
        {
            
            bool filled_in = false;
            LibraryManager libraryManager = new LibraryManager(new DataRepository());
            CustomSerialization serializer = new CustomSerialization(typeof(Class1));
            Class3 c3 = new Class3(DateTime.Now, null);
            Class2 c2 = new Class2("content", c3);
            Class1 c1 = new Class1(20, c2);
            bool cont = true;
            string filename = "serialization.xml";
            string menu1 = "1) Serializacja XML\n2) Serializacja wlasna\n3) Deserializacja XML\n4) Deserializacja wlasna\n5) Manager Info\n6) SampleClass Info\n0) Koniec\n";
            string komunikat = "";
            string output = "";
            c3.refC1 = c1;
            char input = 'c';
            while(cont)
            {
                Stream stream;
                Console.Clear();
                output = komunikat + menu1 + "Wybor: ";
                komunikat = "";
                Console.WriteLine(output);
                input = Console.ReadKey().KeyChar;
                switch(input)
                {
                    case '1':
                        if(!filled_in)
                        {
                            Console.WriteLine("Wypelnic managera gotowymi danymi? [y/n]");
                            if (Console.ReadKey().KeyChar == 'y')
                            {
                                FillWithSampleData(libraryManager);
                                filled_in = true;
                            }
                        }
                        Console.WriteLine("Podaj nazwe pliku zapisu: ");
                        filename = Console.ReadLine();
                        MyXmlSerializer.CreateFile(typeof(LibraryManager), libraryManager, filename);
                        komunikat = "Zapisano do " + filename + '\n';
                        break;
                    case '2':
                        Console.WriteLine("Podaj nazwe pliku zapisu: ");
                        filename = Console.ReadLine();
                        //stream = File.Open(filename, FileMode.Create);
                        using (FileStream my_stream = File.Open(filename, FileMode.Create))
                        {
                            serializer.Serialize(my_stream, c1);
                        }
                        komunikat = "Zapisano do " + filename + '\n';
                        break;
                    case '3':
                        Console.WriteLine("Podaj nazwe pliku odczytu: ");
                        filename = Console.ReadLine();
                        libraryManager = (LibraryManager) MyXmlSerializer.ReadFile(typeof(LibraryManager), filename);
                        komunikat = "Odczytano z " + filename + '\n';
                        break;
                    case '4':
                        Console.WriteLine("Podaj nazwe pliku odczytu: ");
                        filename = Console.ReadLine();
                        //stream = File.Open(filename, FileMode.Open);
                        //stream.Position = 0;
                        using (FileStream my_stream = File.Open(filename, FileMode.Open))
                        {
                            c1 = (Class1)serializer.Deserialize(my_stream, true);
                        }
                            //stream.Dispose();
                        //stream.Close();
                        komunikat = "Odczytano z " + filename + '\n';
                        break;
                    case '5':
                        foreach (string s in libraryManager.GetInfo("events"))
                            komunikat += s + '\n';
                        komunikat += '\n';
                        break;
                    case '6':
                        komunikat = c1.ToString() + '\n';
                        break;
                    case '0':
                        cont = false;
                        break;
                }
            }

        }
    
    }
}
