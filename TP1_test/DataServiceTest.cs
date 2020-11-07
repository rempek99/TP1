using System;
using System.Collections.Generic;
using System.Text;
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
            string title1 = "Dziady", title2 = "Wiersze", author1 = "Adam Mickiewicz", author2 = "Jan Brzechwa";
            testService.AddNewBookItem(title1, author1);
        }
    }
}
