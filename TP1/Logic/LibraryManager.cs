using System;
using System.Collections.Generic;
using System.Text;
using TP1.Model;

namespace TP1.Logic
{
    public class LibraryManager : DataService
    {
        public LibraryManager(IDataRepository dataRepository) : base(dataRepository)
        {
        }

        // READER
        public override bool AddNewReader(string name, string lastName)
        {
            if (dataRepository.FindReader(name, lastName) >= 0)
                return false;

            dataRepository.AddReader(name, lastName);
            return true;
        }
        public override bool RemoveReader(int readerIndex)
        {
            try 
            {
                dataRepository.RemoveReader(readerIndex);
            }
            catch(IndexOutOfRangeException)
            {
                return false;
            }
            return true;
        }
        public override bool ChangeReaderData(int readerIndex, string name, string lastName)
        {
            try
            {
                dataRepository.UpdateReader(readerIndex, name, lastName);
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return true;
        }
        
        // BOOK ITEM
        public override bool AddNewBookItem(string title, string author)
        {
            if (dataRepository.FindBookItem(title, author) >= 0)
                return false;
            dataRepository.AddBookItem(title, author);
            return true; 
        }
        public override bool RemoveBookItem(int bookKey)
        {
            try
            {
                dataRepository.RemoveBookItem(bookKey);
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
            return true;
        }
        public override bool ChangeBookItemData(int bookKey, string title, string author)
        { 
            try
            {
                dataRepository.UpdateBookItem(bookKey, title, author);
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
            return true;
        }

        // COPIES
        public override bool RegisterCopies(int bookKey, int quantity, double prize, string currency)
        {
            int i = -1;
            try
            {
                i = dataRepository.FindExistedCopies(bookKey, prize, currency);
            }
            catch(KeyNotFoundException)
            {
                return false;
            }
            if (i >= 0)
                dataRepository.IncrementCopyInfoStock(i, quantity);
            else
                dataRepository.AddCopyInfo(bookKey, quantity, prize, currency);
            return true;
        }
        public override bool RetractCopies(int copiesIndex)
        {
            try
            {
                dataRepository.RemoveCopyInfo(copiesIndex);
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return true;
        }
        public override bool RetractCopies(int copiesIndex, int quantity)
        {
            try
            {
                dataRepository.IncrementCopyInfoStock(copiesIndex,-quantity);
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return true;
        }
        public override bool ChangeCopiesData(int copiesIndex, int bookItemKey, int stock, double prize, string currency)
        {
            try
            {
                dataRepository.UpdateCopyInfo(copiesIndex, bookItemKey, stock, prize, currency);
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return true;
        }

        // BORROWING
        public override bool RegisterBorrowing(int readerIndex, int copyIndex)
        {
            try
            {
                if (dataRepository.GetCopyInfoStock(copyIndex) == 0)
                    return false;
                dataRepository.AddBorrowing(readerIndex, copyIndex);
                dataRepository.IncrementCopyInfoStock(copyIndex, -1);
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return true;
        }

        public override bool RegisterBorrowing(int readerIndex, int copyIndex, DateTime startDate)
        {
            try
            {
                if (dataRepository.GetCopyInfoStock(copyIndex) == 0)
                    return false;
                dataRepository.AddBorrowing(readerIndex, copyIndex,startDate);
                dataRepository.IncrementCopyInfoStock(copyIndex, -1);
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return true;
        }

        public override bool RegisterBorrowing(int readerIndex, int copyIndex, DateTime startDate, DateTime endDate)
        {
            try
            {
                if (dataRepository.GetCopyInfoStock(copyIndex) == 0)
                    return false;
                dataRepository.AddBorrowing(readerIndex, copyIndex,startDate,endDate);
                dataRepository.IncrementCopyInfoStock(copyIndex, -1);
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return true;
        }
        public override bool SetReturned(int borrowingIndex)
        {
            try
            {
                if (dataRepository.IsBorrowingReturned(borrowingIndex))
                    return false;
                dataRepository.SetBorrowingEndDate(borrowingIndex, DateTime.Now);
                dataRepository.IncrementCopyInfoStock(
                    dataRepository.GetCopyInfoFromBorrowing(borrowingIndex), 1);
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return true;
        }

        public override List<string> GetInfo(string type)
        {
            return dataRepository.GetInfo(type);
        }

        public override void LoadFileData()
        {
            dataRepository.LoadDataFromFile();
        }
    }
}
