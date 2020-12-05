using System;
using System.Collections.Generic;
using System.Linq;
using Serialization;
using TP1;
using TP1.Logic;
using TP1.Model;

namespace TP1_app
{
    public class Person
    {
        public string name { get; set; }
        public Person friend;
        public Pet pet;
    }
    public class Pet
    {
        public string race { get; set; }
    }
    public class Group
    {
        public List<Pet> pets;
        public List<Person> people;
        public Group()
        {
            pets = new List<Pet>();
            people = new List<Person>();
        }
        public void add(Person p)
        {
            people.Add(p);
        }
        public void addPet(Pet p)
        {
            pets.Add(p);
        }
    }

class Program
    {
       
        static void Main(string[] args)
        {

            //Event evt = new Borrowing(new Reader("Adam", "Jakis"), new CopyInfo(new BookItem("Ksiazka", "Autor"), 200, 10.40, "PLN"));

            Group group = new Group();
            Person p1 = new Person(), p2 = new Person();
            Pet pet1 = new Pet(), pet2 = new Pet();
            p1.name = "Adam";
            p2.name = "Joasia";
            pet1.race = "Jamnik";
            pet2.race = "Buldog";
            group.addPet(pet1);
            group.addPet(pet2);
            group.add(p1);
            group.add(p2);
            p1.pet = group.pets[0];
            p1.friend = group.people[1];

            MyXmlSerializer2.Write(typeof(Group), group, "test.xml");
            //Group group2 = (Group)MyXmlSerializer.ReadManagerFile(typeof(Group), "test.xml");
            //Console.WriteLine(group2.ToString());

            /*        
                    DataRepository dataRepository = new DataRepository();
                    dataRepository.AddBookItem("jeden", "pierwszy");
                    dataRepository.AddBookItem("dwa", "drugi");
                    dataRepository.AddCopyInfo(0, 100, 20.01, "PLN");
                    dataRepository.AddReader("Jacek", "Stachursky");
                    dataRepository.AddBorrowing(0, 0);
                    MyXmlSerializer.CreateManagerFile(typeof(DataRepository), dataRepository, "plik.xml");
                    DataRepository dataRepository1 = (DataRepository) MyXmlSerializer.ReadManagerFile(typeof(DataRepository), "plik.xml");
                    Console.WriteLine(dataRepository1.ToString());
        */

           /* MyXmlReader x = new MyXmlReader("data.xml");
            List<string> tmp = x.readData("reader", "name");
            Console.WriteLine("Imiona czytelnikow zapisane w pliku: ");
            foreach (string info in tmp)
                Console.WriteLine(info);

            LibraryManager libraryManager = new LibraryManager(new DataRepository(x));
            libraryManager.LoadFileData();
            libraryManager.AddNewReader("Jacek", "Kowal");
            libraryManager.AddNewReader("Aneta", "Dzwon");
            libraryManager.AddNewBookItem("Dziady", "Adam Mickiewicz");
            libraryManager.RegisterCopies(0, 20, 10.20, "pln");
            libraryManager.RegisterCopies(0, 1, 10.99, "pln");
            libraryManager.RegisterBorrowing(1, 0);
            libraryManager.RegisterPurchase(0, 0);
            foreach (string borrowing in libraryManager.GetInfo("events"))
                Console.WriteLine(borrowing);
            Console.ReadLine();
            MyXmlSerializer.CreateManagerFile(typeof(LibraryManager), libraryManager, "plik.xml");

            LibraryManager managerBackup = (LibraryManager)MyXmlSerializer.ReadManagerFile(typeof(LibraryManager), "plik.xml");
            Console.WriteLine("ORIGINAL:");
            Console.WriteLine(libraryManager.dataRepository.dataContext.copyInfos.First().bookItem.ToString());
            libraryManager.dataRepository.dataContext.books.Values.Last().author = "zamianka";
            Console.WriteLine(libraryManager.dataRepository.dataContext.copyInfos.First().bookItem.ToString());
            //Console.WriteLine(libraryManager.dataRepository.dataContext.books.Values.Last().ToString());
            Console.WriteLine("Backup:");
            Console.WriteLine(managerBackup.dataRepository.dataContext.copyInfos.First().bookItem.ToString());
            managerBackup.dataRepository.dataContext.books.Values.Last().author = "zamianka";
            Console.WriteLine(managerBackup.dataRepository.dataContext.copyInfos.First().bookItem.ToString());
            foreach (String evt in managerBackup.GetInfo("events"))
            {
                libraryManager.GetInfo("events");
                Console.WriteLine(evt);
            }*/
        }
    }
}
