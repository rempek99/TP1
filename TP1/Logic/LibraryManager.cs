using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using TP1.Model;

namespace TP1.Logic
{
/*    [XmlRootAttribute("PurchaseOrder", Namespace = "http://www.cpandl.com",
IsNullable = false)]*/
    public class LibraryManager : DataService
    {
        public LibraryManager() : base()
        {
        }
        public LibraryManager(DataRepository dataRepository) : base(dataRepository)
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
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
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
            catch (Exception ex)
            {
                if(ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
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
                if (!dataRepository.BookExist(bookKey))
                    return false;
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
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
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
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
                    return false;
            }
            return true;
        }
        public override bool ChangeCopiesData(int copiesIndex, int bookItemKey, int quantity, double prize, string currency)
        {
            try
            {
                dataRepository.UpdateCopyInfo(copiesIndex, bookItemKey, quantity, prize, currency);
            }
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
                    return false;
            }
            return true;
        }
        public override int GetQuantity(int copiesIndex)
        {
            return dataRepository.GetCopyInfoStock(copiesIndex);
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
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
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
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
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
                if (startDate > endDate)
                    return false;
                dataRepository.AddBorrowing(readerIndex, copyIndex,startDate,endDate);
            }
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
                    return false;
            }
            return true;
        }
        public override bool SetReturned(int borrowingIndex)
        {
            try
            {
                if (!dataRepository.IsBorrowing(borrowingIndex))
                    return false;
                if (dataRepository.IsBorrowingReturned(borrowingIndex))
                    return false;
                dataRepository.SetBorrowingEndDate(borrowingIndex, DateTime.Now);
                dataRepository.IncrementCopyInfoStock(
                    dataRepository.GetCopyInfoFromBorrowing(borrowingIndex), 1);
            }
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
                    return false;
            }
            return true;
        }
        public override bool RegisterPurchase(int readerIndex, int copyIndex)
        {
            try
            {
                if (dataRepository.GetCopyInfoStock(copyIndex) == 0)
                    return false;
                dataRepository.AddPurchase(readerIndex, copyIndex);
                dataRepository.IncrementCopyInfoStock(copyIndex, -1);
            }
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
                    return false;
            }
            return true;
        }
        public override bool RegisterPurchase(int readerIndex, int copyIndex, DateTime startDate)
        {
            try
            {
                if (dataRepository.GetCopyInfoStock(copyIndex) == 0)
                    return false;
                dataRepository.AddPurchase(readerIndex, copyIndex,startDate);
                dataRepository.IncrementCopyInfoStock(copyIndex, -1);
            }
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException || ex is ArgumentOutOfRangeException)
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
