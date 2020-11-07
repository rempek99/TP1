using System;
using System.Collections.Generic;
using System.Text;
using TP1.Model;

namespace TP1_test
{
    class TestDataRepository : IDataRepository
    {
        public void AddBookItem(string title, string author)
        {
            throw new NotImplementedException();
        }

        public void AddBorrowing(int readerIndex, int copyInfoIndex)
        {
            throw new NotImplementedException();
        }

        public void AddBorrowing(int readerIndex, int copyInfoIndex, DateTime startDate)
        {
            throw new NotImplementedException();
        }

        public void AddBorrowing(int readerIndex, int copyInfoIndex, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void AddCopyInfo(int bookItemKey, int stock, double prize, string currency)
        {
            throw new NotImplementedException();
        }

        public void AddReader(string name, string lastname)
        {
            throw new NotImplementedException();
        }

        public int FindBookItem(string title, string author)
        {
            throw new NotImplementedException();
        }

        public int FindBorrowing(int readerIndex, int copyInfoIndex, DateTime startDate)
        {
            throw new NotImplementedException();
        }

        public int FindExistedCopies(int bookItemKey, double prize, string currency)
        {
            throw new NotImplementedException();
        }

        public int FindReader(string name, string lastname)
        {
            throw new NotImplementedException();
        }

        public int GetBookItemsCount()
        {
            throw new NotImplementedException();
        }

        public int GetBorrowingsCount()
        {
            throw new NotImplementedException();
        }

        public int GetCopyInfoFromBorrowing(int borrowingIndex)
        {
            throw new NotImplementedException();
        }

        public int GetCopyInfosCount()
        {
            throw new NotImplementedException();
        }

        public int GetCopyInfoStock(int copyInfoIndex)
        {
            throw new NotImplementedException();
        }

        public List<string> GetInfo(string type)
        {
            throw new NotImplementedException();
        }

        public int GetKey()
        {
            throw new NotImplementedException();
        }

        public int GetReadersCount()
        {
            throw new NotImplementedException();
        }

        public void IncrementCopyInfoStock(int copyInfoIndex, int value)
        {
            throw new NotImplementedException();
        }

        public bool IsBorrowingReturned(int borrowingIndex)
        {
            throw new NotImplementedException();
        }

        public void LoadDataFromFile()
        {
            throw new NotImplementedException();
        }

        public void RemoveBookItem(int key)
        {
            throw new NotImplementedException();
        }

        public void RemoveCopyInfo(int copyInfoIndex)
        {
            throw new NotImplementedException();
        }

        public void RemoveReader(int readerIndex)
        {
            throw new NotImplementedException();
        }

        public void SetBorrowingEndDate(int borrowingIndex, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateBookItem(int key, string title, string author)
        {
            throw new NotImplementedException();
        }

        public void UpdateCopyInfo(int copyInfoIndex, int bookItemKey, int stock, double prize, string currency)
        {
            throw new NotImplementedException();
        }

        public void UpdateReader(int readerIndex, string name, string lastname)
        {
            throw new NotImplementedException();
        }
    }
}
