using System;
using TP1.Model;
using Xunit;

namespace TP1_test
{
    public class EntitiesTest
    {
        [Fact]
        public void ReaderTest()
        {
            string name1 = "Jan", lastName1 = "Kowalski";
            Reader tester = new Reader(name1, lastName1);
            Reader testerCopy = new Reader(name1, lastName1);
            Assert.Contains(name1, tester.ToString());
            Assert.True(tester.Equals(testerCopy));
        }
        [Fact]
        public void BookItemTest()
        {
            string title1 = "Dziady", author1 = "Adam Mickiewicz";
            BookItem tester = new BookItem(title1, author1);
            BookItem testerCopy = new BookItem(title1, author1);
            Assert.Contains(title1, tester.ToString());
            Assert.True(tester.Equals(testerCopy));
        }
        [Fact]
        public void CopyInfoTest()
        {
            Random rnd = new Random();
            string title1 = "Dziady", author1 = "Adam Mickiewicz", currency1 = "PLN";
            int stock1 = rnd.Next(int.MaxValue);
            double prize1 = rnd.NextDouble() * stock1;
            BookItem testBook = new BookItem(title1, author1);
            CopyInfo testCopy = new CopyInfo(testBook, stock1, prize1, currency1);
            CopyInfo testCopyOfCopy = new CopyInfo(testBook, stock1, prize1, currency1);
            Assert.Contains(title1, testCopy.ToString());
            Assert.True(testCopy.Equals(testCopyOfCopy));
        }
        [Fact]
        public void BorrowingTest()
        {
            Random rnd = new Random();
            string title1 = "Dziady", author1 = "Adam Mickiewicz", currency1 = "PLN";
            string name1 = "Jan", lastName1 = "Kowalski";
            int stock1 = rnd.Next(int.MaxValue);
            double prize1 = rnd.NextDouble() * stock1;
            Reader tester = new Reader(name1, lastName1);
            BookItem testBook = new BookItem(title1, author1);
            CopyInfo testCopy = new CopyInfo(testBook, stock1, prize1, currency1);
            Borrowing testBorrowing = new Borrowing(tester, testCopy);
            Assert.Contains(title1, testBorrowing.ToString());
            Assert.Contains(name1, testBorrowing.ToString());
            DateTime date1 = new DateTime(2015, 1, 1);
            date1 = date1.AddDays(rnd.Next(200, 2000));
            DateTime date2 = date1.AddDays(rnd.Next(1, 200));
            testBorrowing = new Borrowing(tester, testCopy,date1);
            Assert.Contains(date1.ToString(), testBorrowing.ToString());
            testBorrowing = new Borrowing(tester, testCopy, date1,date2);
            Borrowing testBorrowingCopy = new Borrowing(tester, testCopy, date1,date2);
            Assert.True(testBorrowing.Equals(testBorrowingCopy));
        }
    }
        public class DataRepositoryTest
    {

        [Fact]
        public void ReaderOperations()
        {
            IDataReaderFromFile fileReader = null;
            IDataRepository repo = new DataRepository(fileReader);
            string name1 = "Jan", name2 = "Piotr", lastName1 = "Kowalski", lastName2 = "Nowak";
            repo.AddReader(name1, lastName1);
            Assert.Equal(0, repo.FindReader(name1, lastName1));
            repo.UpdateReader(0, name2, lastName2);
            Assert.Equal(0, repo.FindReader(name2, lastName2));
            repo.RemoveReader(0);
            Assert.Equal(0, repo.GetReadersCount());
            Random rnd = new Random();
            int tmp = rnd.Next(2, 256);
            for (int i = 0; i < tmp; i++)
                repo.AddReader("Test" + i.ToString(), "Sample");
            Assert.Equal(tmp, repo.GetReadersCount());
            tmp = rnd.Next(tmp - 1);
            Assert.Equal(tmp, repo.FindReader("Test" + tmp.ToString(), "Sample"));
        }

        [Fact]
        public void BookItemOperations()
        {
            IDataReaderFromFile reader = null;
            IDataRepository repo = new DataRepository(reader);
            string title1 = "Dziady", title2 = "Wiersze", author1 = "Adam Mickiewicz", author2 = "Jan Brzechwa";
            repo.AddBookItem(title1, author1);
            Assert.Equal(repo.GetKey() - 1, repo.FindBookItem(title1, author1));
            repo.UpdateBookItem(repo.GetKey() - 1, title2, author2);
            Assert.Equal(repo.GetKey() - 1, repo.FindBookItem(title2, author2));
            Assert.True(repo.BookExist(repo.GetKey() - 1));
            repo.RemoveBookItem(repo.GetKey() - 1);
            Assert.False(repo.BookExist(repo.GetKey() - 1));
            Assert.Equal(0, repo.GetBookItemsCount());
            Random rnd = new Random();
            int tmp = rnd.Next(2, 256);
            int startKey = repo.GetKey();
            for (int i = 0; i < tmp; i++)
                repo.AddBookItem("Test" + i.ToString(), "Sample");
            Assert.Equal(tmp, repo.GetBookItemsCount());
            tmp = rnd.Next(tmp - 1);
            Assert.Equal(tmp + startKey, repo.FindBookItem("Test" + tmp.ToString(), "Sample"));
        }
        [Fact]
        public void CopyInfoOperations()
        {
            IDataReaderFromFile reader = null;
            IDataRepository repo = new DataRepository(reader);
            Random rnd = new Random();
            string title1 = "Dziady", title2 = "Wiersze", author1 = "Adam Mickiewicz", author2 = "Jan Brzechwa";
            int stock = rnd.Next(1, 128);
            double prize = rnd.NextDouble() * 30;
            string currency = "USD";
            repo.AddBookItem(title1, author1);
            repo.AddBookItem(title2, author2);
            Assert.Equal(2, repo.GetBookItemsCount());
            int bookKey = repo.GetKey() - rnd.Next(1, 2);
            repo.AddCopyInfo(bookKey, stock, prize, currency);
            Assert.Equal(0, repo.FindExistedCopies(bookKey, prize, currency));
            stock = rnd.Next(1, 128);
            prize = rnd.NextDouble() * 30;
            currency = "PLN";
            bookKey = repo.GetKey() - rnd.Next(1, 2);
            repo.UpdateCopyInfo(0, bookKey, stock, prize, currency);
            Assert.Equal(0, repo.FindExistedCopies(bookKey, prize, currency));
            int tmp = repo.GetCopyInfoStock(0);
            int tmp2 = rnd.Next(100);
            repo.IncrementCopyInfoStock(0, tmp2);
            Assert.Equal(tmp + tmp2, repo.GetCopyInfoStock(0));
            repo.RemoveCopyInfo(0);
            Assert.Equal(0, repo.GetCopyInfosCount());
            Assert.Equal(2, repo.GetBookItemsCount());
        }
        [Fact]
        public void BorrowingOperations()
        {
            IDataReaderFromFile reader = null;
            IDataRepository repo = new DataRepository(reader);
            Random rnd = new Random();
            string title1 = "Dziady", title2 = "Wiersze", author1 = "Adam Mickiewicz", author2 = "Jan Brzechwa";
            string name1 = "Jan", name2 = "Piotr", lastName1 = "Kowalski", lastName2 = "Nowak";
            repo.AddReader(name1, lastName1);
            repo.AddReader(name2, lastName2);
            int stock = rnd.Next(1, 128);
            double prize = rnd.NextDouble() * 30;
            string currency = "USD";
            repo.AddBookItem(title1, author1);
            repo.AddBookItem(title2, author2);
            int bookKey = repo.GetKey() - rnd.Next(1, 2);
            repo.AddCopyInfo(bookKey, stock, prize, currency);
            stock = rnd.Next(1, 128);
            prize = rnd.NextDouble() * 30;
            currency = "PLN";
            bookKey = repo.GetKey() - rnd.Next(1, 2);
            repo.AddCopyInfo(bookKey, stock, prize, currency);
            Assert.Equal(2, repo.GetReadersCount());
            Assert.Equal(2, repo.GetBookItemsCount());
            Assert.Equal(2, repo.GetCopyInfosCount());
            int tmp1 = rnd.Next(1, repo.GetReadersCount());
            int tmp2 = rnd.Next(1, repo.GetCopyInfosCount());
            repo.AddBorrowing(tmp1, tmp2);
            Assert.Equal(tmp2, repo.GetCopyInfoFromBorrowing(0));
            Assert.NotEmpty(repo.GetInfo("borrowings")[0]);
            tmp1 = rnd.Next(1, repo.GetReadersCount());
            tmp2 = rnd.Next(1, repo.GetCopyInfosCount());
            DateTime date1 = new DateTime(1995, 1, 1);
            date1 = date1.AddDays(rnd.Next(200,1000));
            repo.AddBorrowing(tmp1, tmp2, date1);
            Assert.Equal(1, repo.FindBorrowing(tmp1, tmp2, date1));
            tmp1 = rnd.Next(1, repo.GetReadersCount());
            tmp2 = rnd.Next(1, repo.GetCopyInfosCount());
            date1.AddDays(rnd.Next(200, 1000));
            DateTime date2 = date1.AddDays(rnd.Next(1, 100));
            repo.AddBorrowing(tmp1, tmp2, date1,date2);
            Assert.False(repo.IsBorrowingReturned(1));
            repo.SetBorrowingEndDate(1, DateTime.Now);
            Assert.True(repo.IsBorrowingReturned(1));
            Assert.Equal(3, repo.GetBorrowingsCount());
            
        }
    }
}
