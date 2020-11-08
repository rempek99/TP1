using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Text;
using TP1;
using TP1.Logic;
using TP1.Model;
using Xunit;

namespace TP1_test
{
    public class DataServiceTest
    {
        [Fact]
        public void MethodsTest()
        {
            DataService testService = new LibraryManager(new DataRepository(new XmlReader("path")));
            string title1 = "Dziady", title2 = "Wiersze",title3 = "Treny" , author1 = "Adam Mickiewicz", author2 = "Jan Brzechwa", author3 = "Jan Kochanowski";
            string name1 = "Jan", name2 = "Piotr", name3="Adam", lastName1 = "Kowalski", lastName2 = "Nowak", lastName3 = "Puszek";
            Assert.True(testService.AddNewBookItem(title1, author1));
            Assert.True(testService.AddNewBookItem(title2, author2));
            Assert.False(testService.AddNewBookItem(title2, author2));
            Assert.Equal(2, testService.GetInfo("bookItems").Count);
            Assert.True(testService.ChangeBookItemData(0, title3, author3));
            Assert.Contains(title3, testService.GetInfo("bookItems")[0]);
            Assert.Contains(author3, testService.GetInfo("bookItems")[0]);
            Assert.False(testService.ChangeBookItemData(3, title3, author3));

            Assert.True(testService.AddNewReader(name1, lastName1));
            Assert.True(testService.AddNewReader(name2, lastName2));
            Assert.False(testService.AddNewReader(name2, lastName2));
            Assert.Equal(2, testService.GetInfo("readers").Count);
            Assert.True(testService.ChangeReaderData(0, name3, lastName3));
            Assert.Contains(name3, testService.GetInfo("readers")[0]);
            Assert.Contains(lastName3,testService.GetInfo("readers")[0]);
            Assert.False(testService.ChangeReaderData(3, name3, lastName3));

            Random rnd = new Random();
            int quantity = rnd.Next(1,256);
            double prize = rnd.NextDouble() * quantity;
            string currency = "PLN";
            Assert.True(testService.RegisterCopies(0, quantity, prize, currency));
            quantity = rnd.Next(1, 256);
            prize = rnd.NextDouble() * quantity;
            currency = "USD";
            Assert.True(testService.RegisterCopies(1, quantity, prize, currency));
            Assert.True(testService.RegisterCopies(1, quantity, prize, currency));
            Assert.Equal(2, testService.GetInfo("copyInfos").Count);
            Assert.Contains((quantity * 2).ToString(), testService.GetInfo("copyInfos")[1]);
            quantity = rnd.Next(1, 256);
            prize = rnd.NextDouble() * quantity;
            currency = "EUR";
            Assert.True(testService.ChangeCopiesData(0, 1, quantity, prize, currency));
            Assert.Contains(title2, testService.GetInfo("copyInfos")[0]);
            Assert.Contains(author2, testService.GetInfo("copyInfos")[0]);
            Assert.Contains(quantity.ToString(), testService.GetInfo("copyInfos")[0]);
            Assert.Contains(prize.ToString("0.00"), testService.GetInfo("copyInfos")[0]);
            Assert.Contains(currency.ToString(), testService.GetInfo("copyInfos")[0]);
            Assert.False(testService.ChangeCopiesData(3, 1, quantity, prize, currency));

            DateTime date1 = new DateTime(1995, 1, 1);
            date1 = date1.AddDays(rnd.Next(200, 1000));
            Assert.True(testService.RegisterBorrowing(0, 0));
            Assert.True(testService.RegisterBorrowing(1, 1, date1));
            date1 = date1.AddDays(rnd.Next(200, 1000));
            DateTime date2 = date1.AddDays(rnd.Next(1, 100));
            Assert.True(testService.RegisterBorrowing(0, 1, date1, date2));
            Assert.False(testService.RegisterBorrowing(2, 0));
            Assert.False(testService.RegisterBorrowing(0, 2,date1));
            Assert.False(testService.RegisterBorrowing(2, 0));
            Assert.False(testService.RegisterBorrowing(2, 2,date1,date2));
            // date 1 < date2
            Assert.False(testService.RegisterBorrowing(0, 0, date2, date1));
            Assert.Equal(3, testService.GetInfo("borrowings").Count);
            Assert.True(testService.SetReturned(0));
            Assert.False(testService.SetReturned(0));

            Assert.True(testService.RemoveReader(0));
            Assert.True(testService.RemoveReader(0));
            Assert.False(testService.RemoveReader(0));
            Assert.False(testService.ChangeReaderData(0, name3, lastName3));
            Assert.True(testService.RemoveBookItem(0));
            Assert.True(testService.RemoveBookItem(1));
            Assert.False(testService.RemoveBookItem(0));
            Assert.False(testService.ChangeBookItemData(1, title3, author3));
            Assert.True(testService.RetractCopies(1));
            int tmp = rnd.Next(1, quantity);
            Assert.True(testService.RetractCopies(0, tmp));
            Assert.Equal(quantity - tmp, testService.GetQuantity(0));
            Assert.False(testService.ChangeCopiesData(1, 1, quantity, prize, currency));
        }
    }
}
