using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TP1copy.Model
{
    [Serializable()]
    public class DataRepository : IDataRepository, ISerializable
    {
        public Guid id { get; set; }
        public DataContext dataContext { get; set; }
        public int key{ get; set; }
    private IDataReaderFromFile dataReader { get;  set; }

        public DataRepository()
        {
            id = Guid.NewGuid();
            this.dataContext = new DataContext();
            this.key = 0;
        }

        public DataRepository(IDataReaderFromFile dataReader)
        {
            id = Guid.NewGuid();
            this.dataReader = dataReader;
            this.dataContext = new DataContext();
            this.key = 0;
        }

        // READER
        public void AddReader(string name, string lastname)
        {
            dataContext.readers.Add(new Reader(name,lastname));
        }
        public int FindReader(string name, string lastname)
        {
            int i = 0;
            Reader pattern = new Reader(name, lastname);
            foreach(Reader reader in dataContext.readers)
            {
                if (reader.Equals(pattern))
                    return i;
                i++;
            }
            return -1;
        }
        public void RemoveReader(int readerIndex)
        {
           /* if (dataContext.readers.Contains(reader))
            {*/
                dataContext.readers.Remove(dataContext.readers[readerIndex]);
               /* return true;
            }
            return false;*/
        }
        public void UpdateReader(int readerIndex, string name, string lastname)
        {
            /*if (!dataContext.readers.Contains(reader))
                return false;*/
            dataContext.readers[readerIndex].name = name;
            dataContext.readers[readerIndex].lastName = lastname;
           /* return true;*/
        }
        public int GetReadersCount()
        {
            return dataContext.readers.Count();
        }

        // BOOK ITEM
        public void AddBookItem(string title, string author)
        {
            dataContext.books.Add(key, new BookItem(title,author));
            key++;
        }
        public int FindBookItem(string title, string author)
        {
            BookItem pattern = new BookItem(title, author);
            int key = -1;
            foreach(BookItem element in dataContext.books.Values)
            {
                if (element.Equals(pattern))
                {
                    key = dataContext.books.FirstOrDefault(x => x.Value.Equals(pattern)).Key;
                    return key;
                }
            }
            return key;
        }
        public void RemoveBookItem(int key)
        {
                dataContext.books.Remove(key);       
        }
        public void UpdateBookItem(int key, string title, string author)
        {
       /*     if (!dataContext.books.ContainsKey(key))
                return false;*/
            dataContext.books[key].author = author;
            dataContext.books[key].title = title;
           /* return true;*/
        }
        public int GetBookItemsCount()
        {
            return dataContext.books.Count();
        }
        public bool BookExist(int bookItemKey)
        {
            if (dataContext.books.ContainsKey(bookItemKey))
                return true;
            return false;
        }

        // EVENT
        public void AddBorrowing(int readerIndex, int copyInfoIndex)
        {
            dataContext.events.Add(new Borrowing(dataContext.readers[readerIndex], dataContext.copyInfos[copyInfoIndex]));
        }
        public void AddBorrowing(int readerIndex, int copyInfoIndex, DateTime startDate)
        {
            dataContext.events.Add(new Borrowing(dataContext.readers[readerIndex], dataContext.copyInfos[copyInfoIndex], startDate));
        }
        public void AddBorrowing(int readerIndex, int copyInfoIndex, DateTime startDate, DateTime endDate)
        {
            dataContext.events.Add(new Borrowing(dataContext.readers[readerIndex], dataContext.copyInfos[copyInfoIndex], startDate,endDate));
        }
        public void SetBorrowingEndDate(int borrowingIndex, DateTime endDate)
        {
           /* if (!dataContext.borrowings.Contains(borrowing))
                return false;*/
            dataContext.events[borrowingIndex].endDate = endDate;
           /* return true;*/
        }
        public bool IsBorrowingReturned(int borrowingIndex)
        {
            if (dataContext.events[borrowingIndex].endDate == new DateTime(0))
                return false;
            return true;
        }
        public int FindEvent(int readerIndex, int copyInfoIndex, DateTime startDate)
        {
            int i = 0;
            Borrowing pattern = new Borrowing(dataContext.readers[readerIndex], dataContext.copyInfos[copyInfoIndex], startDate);
            foreach (Borrowing borrowing in dataContext.events)
            {
                if (borrowing.Equals(pattern))
                    return i;
                i++;
            }
            return -1;
        }
        public int GetEventsCount()
        {
            return dataContext.events.Count();
        }
        public void AddPurchase(int readerIndex, int copyInfoIndex)
        {
            dataContext.events.Add(new Purchase(dataContext.readers[readerIndex], dataContext.copyInfos[copyInfoIndex]));
        }
        public void AddPurchase(int readerIndex, int copyInfoIndex, DateTime eventDate)
        {
            dataContext.events.Add(new Purchase(dataContext.readers[readerIndex], dataContext.copyInfos[copyInfoIndex],eventDate));
        }
        public bool IsBorrowing(int eventIndex)
        {
            return dataContext.events[eventIndex].GetType().Name == "Borrowing";
        }

        // COPY INFO
        public void AddCopyInfo(int bookItemKey, int stock, double prize, string currency)
        {
          /*  CopyInfo newCopyInfo = new CopyInfo(bookItem, stock, prize, currency);
            if (dataContext.copyInfos.Contains(newCopyInfo))
            {
                return false;
            }*/
            dataContext.copyInfos.Add(new CopyInfo(dataContext.books[bookItemKey], stock, prize, currency));
          //  return true;
        }
        public void RemoveCopyInfo(int copyInfoIndex)
        {
            /*if (dataContext.copyInfos.Contains(copyInfo))
            {*/
                dataContext.copyInfos.Remove(dataContext.copyInfos[copyInfoIndex]);
           /*     return true;
            }
            return false;*/
        }
        public void UpdateCopyInfo(int copyInfoIndex, int bookItemKey, int stock, double prize, string currency)
        {
/*
            if (!dataContext.copyInfos.Contains(copyInfo))
                return false;*/
            dataContext.copyInfos[copyInfoIndex].bookItem = dataContext.books[bookItemKey];
            dataContext.copyInfos[copyInfoIndex].stock = stock;
            dataContext.copyInfos[copyInfoIndex].prize = prize;
            dataContext.copyInfos[copyInfoIndex].currency = currency;
        /*    return true;*/
        }
        public void IncrementCopyInfoStock(int copyInfoIndex, int value)
        {
            dataContext.copyInfos[copyInfoIndex].stock += value;
        }
        public int FindExistedCopies(int bookItemKey, double prize, string currency)
        {
            CopyInfo newCopyInfo = new CopyInfo(dataContext.books[bookItemKey], 0, prize, currency);
            for(int i =0; i < dataContext.copyInfos.Count();i++)
            {
                if (dataContext.copyInfos[i].bookItem == newCopyInfo.bookItem
                    && dataContext.copyInfos[i].prize == newCopyInfo.prize
                    && dataContext.copyInfos[i].currency == newCopyInfo.currency
                    )
                    return i;
            }
            return -1;
        }
        public int GetCopyInfosCount()
        {
            return dataContext.copyInfos.Count();
        }
        public int GetCopyInfoStock(int copyInfoIndex)
        {
            return dataContext.copyInfos[copyInfoIndex].stock;
        }
        public int GetCopyInfoFromBorrowing(int borrowingIndex)
        {
            CopyInfo pattern = dataContext.events[borrowingIndex].copyInfo;
            int i = 0;
            foreach(CopyInfo element in dataContext.copyInfos)
            {
                if (element == pattern)
                    break;
                i++;
            }
            return i;
        }

        public List<string> GetInfo(string type)
        {
            List<string> output = new List<string>();
            int i = 0;
            switch (type)
            { 
                case "readers":
                    {
                        foreach (object element in dataContext.readers)
                        {
                            output.Add(i +") " + element.ToString());
                            i++;
                        }
                        break;
                    }
                case "bookItems":
                    {
                        foreach (object element in dataContext.books)
                        {
                            output.Add(element.ToString());
                            i++;
                        }
                        break;
                    }
                case "copyInfos":
                    {
                        foreach (object element in dataContext.copyInfos)
                        {
                            output.Add(i + ") " + element.ToString());
                            i++;
                        }
                        break;
                    }
                case "events":
                    {
                        foreach (object element in dataContext.events)
                        {
                            output.Add(i + ") " + element.ToString());
                            i++;
                        }
                        break;
                    }
                default:
                    {
                        output.Add("! Unrecognized type !");
                        break;
                    }
            }
            return output;
        }
        public void LoadDataFromFile()
        {
            List<string> a = dataReader.readData("reader", "name");
            List<string> b = dataReader.readData("reader", "lastName");
            for(int i = 0; i < a.Count();i++)
                AddReader(a[i],b[i]);
            a = dataReader.readData("book", "title");
            b = dataReader.readData("book", "author");
            for (int i = 0; i < a.Count(); i++)
                AddBookItem(a[i], b[i]);
            a = dataReader.readData("copyInfo", "bookItemKey");
            b = dataReader.readData("copyInfo", "stock");
            List<string> c = dataReader.readData("copyInfo", "prize");
            List<string> d = dataReader.readData("copyInfo", "currency");
            for (int i = 0; i < a.Count(); i++)
                AddCopyInfo(Convert.ToInt32(a[i]), Convert.ToInt32(b[i]), Convert.ToDouble(c[i]),d[i]);
            a = dataReader.readData("borrowing", "readerIndex");
            b = dataReader.readData("borrowing", "copyInfoIndex");
            c = dataReader.readData("borrowing", "startDate");
            d = dataReader.readData("borrowing", "endDate");
            for (int i = 0; i < a.Count(); i++)
            {
                if (d[i].Length == 0)
                {
                    d[i] = new DateTime(0).ToString();
                }
                AddBorrowing(Convert.ToInt32(a[i]), Convert.ToInt32(b[i]), Convert.ToDateTime(c[i]), Convert.ToDateTime(d[i]));
            }
            a = dataReader.readData("purchase", "readerIndex");
            b = dataReader.readData("purchase", "copyInfoIndex");
            c = dataReader.readData("purchase", "startDate");
            for (int i = 0; i < a.Count(); i++)
            {
                if (d[i].Length == 0)
                {
                    d[i] = new DateTime(0).ToString();
                }
                AddPurchase(Convert.ToInt32(a[i]), Convert.ToInt32(b[i]), Convert.ToDateTime(c[i]));
            }
        }

        public int GetKey()
        {
            return key;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", id);
            info.AddValue("dataContext", dataContext);
            info.AddValue("key", key);
        }
    }
}
