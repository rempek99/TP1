using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleClasses;
using Serialization;
using System;
using System.IO;
using System.Linq;
using TP1.Logic;
using TP1.Model;

namespace TestSerialization
{
    [TestClass]
    public class Serialization
    {
        [TestMethod]
        public void Test1()
        {
            CustomSerialization serializer = new CustomSerialization(typeof(Class1));
            Class3 c3 = new Class3(DateTime.Now, null);
            Class2 c2 = new Class2("content", c3);
            Class1 c1 = new Class1(20, c2);
            c3.refC1 = c1;
            Stream stream = File.Open("sample.dat", FileMode.Create);
            serializer.Serialize(stream, c1);
            stream.Close();
            stream = File.Open("sample.dat", FileMode.Open);
            Class1 c1Copy = (Class1)serializer.Deserialize(stream, true);
            stream.Close();
            c2.contentString = "zmiana";
            Assert.IsNotNull(c1Copy.refC2);
            Assert.IsNotNull(c1Copy.refC2.refC3);
            Assert.AreEqual(c1, c1.refC2.refC3.refC1);
            c1Copy.contentInt = 10;
            Assert.AreEqual(10, c1Copy.contentInt);
            Assert.AreEqual(10, c1Copy.refC2.refC3.refC1.contentInt);
        }
        [TestMethod]
        public void Test2()
        {
            LibraryManager libraryManager = new LibraryManager(new DataRepository());
            libraryManager.AddNewReader("Jacek", "Kowal");
            libraryManager.AddNewReader("Aneta", "Dzwon");
            libraryManager.AddNewBookItem("Dziady", "Adam Mickiewicz");
            libraryManager.RegisterCopies(0, 20, 10.20, "pln");
            libraryManager.RegisterCopies(0, 1, 10.99, "pln");
            libraryManager.RegisterBorrowing(1, 0);
            libraryManager.RegisterPurchase(0, 0);
            MyXmlSerializer.CreateFile(typeof(LibraryManager), libraryManager, "serialization.xml");
            LibraryManager managerBackup = (LibraryManager)MyXmlSerializer.ReadFile(typeof(LibraryManager), "serialization.xml");
            libraryManager.dataRepository.dataContext.books.Values.Last().author = "zmiana";
            Assert.AreEqual("zmiana", libraryManager.dataRepository.dataContext.copyInfos.First().bookItem.author);
            managerBackup.dataRepository.dataContext.books.Values.Last().author = "zmiana";
            Assert.AreEqual("zmiana", managerBackup.dataRepository.dataContext.copyInfos.First().bookItem.author);
        }
    }
}
