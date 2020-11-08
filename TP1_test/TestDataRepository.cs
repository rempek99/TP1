using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TP1.Model;

namespace TP1_test
{
    class TestDataRepository : IDataRepository
    {
        public Dictionary<int,string> bookItems;
        public List<string> readers;
        public List<string> copyInfos;
        public ObservableCollection<string> borrowings;
        public int key;

        public TestDataRepository()
        {
            key = 0;
            bookItems = new Dictionary<int, string>();
            readers = new List<string>();
            copyInfos = new List<string>();
            borrowings = new ObservableCollection<string>();
        }


        public void AddBookItem(string title, string author)
        {
            bookItems.Add(key, title + "," + author);
            key++;
        }

        public void AddBorrowing(int readerIndex, int copyInfoIndex)
        {
            borrowings.Add(readers[readerIndex] + ";" + copyInfos[copyInfoIndex]);
        }

        public void AddBorrowing(int readerIndex, int copyInfoIndex, DateTime startDate)
        {
            borrowings.Add(readers[readerIndex] + ";" + copyInfos[copyInfoIndex] + ";" + startDate.ToString()) ;
        }

        public void AddBorrowing(int readerIndex, int copyInfoIndex, DateTime startDate, DateTime endDate)
        {
            borrowings.Add(readers[readerIndex] + ";" + copyInfos[copyInfoIndex] + ";" + startDate.ToString() + ";" + endDate.ToString());
        }

        public void AddCopyInfo(int bookItemKey, int stock, double prize, string currency)
        {
            copyInfos.Add(bookItems[bookItemKey] + ";" + stock.ToString() + "," + prize.ToString() + "," + currency);
        }

        public void AddReader(string name, string lastname)
        {
            readers.Add(name + "," + lastname);
        }

        public bool BookExist(int bookItemKey)
        {
            throw new NotImplementedException();
        }

        public int FindBookItem(string title, string author)
        {
            foreach(KeyValuePair<int,string> element in bookItems)
            {
                if(element.Value.Contains(title + ";" + author))
                {
                    return element.Key;
                }
            }
            return -1;
        }

        public int FindBorrowing(int readerIndex, int copyInfoIndex, DateTime startDate)
        {
            int i = 0;
            foreach(string element in borrowings)
            {
                if(element.Contains(readers[readerIndex] + ";" + copyInfos[copyInfoIndex]))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public int FindExistedCopies(int bookItemKey, double prize, string currency)
        {
            int i = 0;
            foreach (string element in copyInfos)
            {
                if (element.Contains(bookItems[bookItemKey] + ";"))
                {
                    if(element.Contains(prize.ToString() + ";" + currency))
                        return i;
                }
                i++;
            }
            return -1;
        }

        public int FindReader(string name, string lastname)
        {
            int i = 0;
            foreach (string element in readers)
            {
                if (element.Contains(name + ";" + lastname))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public int GetBookItemsCount()
        {
            return bookItems.Count;
        }

        public int GetBorrowingsCount()
        {
            return borrowings.Count;
        }

        public int GetCopyInfoFromBorrowing(int borrowingIndex)
        {
            string copy = borrowings[borrowingIndex].Substring(borrowings[borrowingIndex].LastIndexOf(';') + 1);
            int i = 0;
            foreach(string element in copyInfos)
            {
                if (element.Contains(copy))
                    break;
                i++;    
            }
            return i;
        }

        public int GetCopyInfosCount()
        {
            return copyInfos.Count;
        }

        public int GetCopyInfoStock(int copyInfoIndex)
        {
            string tmp = copyInfos[copyInfoIndex];
            return Convert.ToInt32(tmp.Substring(tmp.LastIndexOf(';', ',')));
        }

        public List<string> GetInfo(string type)
        {
            return new List<string>();
        }

        public int GetKey()
        {
            return key;
        }

        public int GetReadersCount()
        {
            return readers.Count;
        }

        public void IncrementCopyInfoStock(int copyInfoIndex, int value)
        {
            string final = (GetCopyInfoStock(copyInfoIndex) + value).ToString();
            string tmp = copyInfos[copyInfoIndex];
            string left = tmp.Substring(tmp.LastIndexOf(';'));
           // string right = tmp.Substring(tmp.LastIndexOf(','),)
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
