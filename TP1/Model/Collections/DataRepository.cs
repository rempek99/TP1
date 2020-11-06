using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP1.Model;

namespace TP1.Model
{
    public class DataRepository : IDataRepository
    {
        private DataContext dataContext;
        private int key;

        public DataRepository()
        {
            this.dataContext = new DataContext();
            this.key = 0;
        }

        public void AddBookItem(string title, string author)
        {
            dataContext.books.Add(key, new BookItem(title,author));
            key++;
        }

        public void AddReader(string name, string lastname, IProfiler profile)
        {
            dataContext.readers.Add(new Reader(name,lastname,profile));
        }

        public bool AddCopyInfo(BookItem bookItem, int stock, double prize, string currency)
        {
            CopyInfo newCopyInfo = new CopyInfo(bookItem, stock, prize, currency);
            if(dataContext.copyInfos.Contains(newCopyInfo))
            {
                return false;
            }
            dataContext.copyInfos.Add(newCopyInfo);
            return true;
        }
        public void AddBorrowing(Reader reader, CopyInfo copyInfo)
        {
            dataContext.borrowings.Add(new Borrowing(reader, copyInfo));
        }
        public void AddBorrowing(Reader reader, CopyInfo copyInfo, DateTime startDate)
        {
            dataContext.borrowings.Add(new Borrowing(reader, copyInfo, startDate));
        }
        public void AddBorrowing(Reader reader, CopyInfo copyInfo, DateTime startDate, DateTime endDate)
        {
            dataContext.borrowings.Add(new Borrowing(reader,copyInfo,startDate,endDate));
        }

        public bool RemoveBookItem(int key)
        {
            if(dataContext.books.ContainsKey(key))
            {
                dataContext.books.Remove(key);
                return true;
            }
            return false;            
        }

        public bool RemoveReader(Reader reader)
        {
            if (dataContext.readers.Contains(reader))
            {
                dataContext.readers.Remove(reader);
                return true;
            }
            return false;
        }

        public bool RemoveBorrowing(Borrowing borrowing)
        {
            if (dataContext.borrowings.Contains(borrowing))
            {
                dataContext.borrowings.Remove(borrowing);
                return true;
            }
            return false;
        }

        public bool RemoveCopyInfo(CopyInfo copyInfo)
        {
            if (dataContext.copyInfos.Contains(copyInfo))
            {
                dataContext.copyInfos.Remove(copyInfo);
                return true;
            }
            return false;
        }

        public bool UpdateReader(Reader reader, string name, string lastname)
        {
            if (!dataContext.readers.Contains(reader))
                return false;
            reader.name = name;
            reader.lastName = lastname;
            return true;
        }

        public bool UpdateBookItem(int key, string title, string author)
        {
            if (!dataContext.books.ContainsKey(key))
                return false;
            dataContext.books[key].author = author;
            dataContext.books[key].title = title;
            return true;
        }

        public bool UpdateBorrowing(Borrowing borrowing, Reader reader, CopyInfo copyInfo, DateTime startDate, DateTime endDate)
        {
            if (!dataContext.borrowings.Contains(borrowing))
                return false;
            borrowing.copyInfo = copyInfo;
            borrowing.reader = reader;
            borrowing.startDate = startDate;
            borrowing.endDate = endDate;
            return true;
        }

        public bool UpdateCopyInfo(CopyInfo copyInfo, BookItem bookItem, int stock, double prize, string currency)
        {

            if (!dataContext.copyInfos.Contains(copyInfo))
                return false;
            copyInfo.bookItem = bookItem;
            copyInfo.stock = stock;
            copyInfo.prize = prize;
            copyInfo.currency = currency;
            return true;
        }

        public Reader GetReader(int i)
        {
            if (dataContext.readers.Count() < i + 1)
                return null;
            return dataContext.readers[i];
        }

        public BookItem GetBookItem(int key)
        {
            return dataContext.books[key];
        }

        public Borrowing GetBorrowing(int i)
        {
            if (dataContext.borrowings.Count() < i + 1)
                return null;
            return dataContext.borrowings[i];
        }

        public CopyInfo GetCopyInfo(int i)
        {
            if (dataContext.copyInfos.Count() < i + 1)
                return null;
            return dataContext.copyInfos[i];
        }

        public int FindExistedCopies(int bookIndex, double prize, string currency)
        {
            CopyInfo newCopyInfo = new CopyInfo(dataContext.books[bookIndex], 0, prize, currency);
            for(int i =0; i < dataContext.copyInfos.Count();i++)
            {
                if (dataContext.copyInfos[i] == newCopyInfo)
                    return i;
            }
            return -1;
        }

        public void UpdateCopyInfoStock(CopyInfo copyInfo, int value)
        {
            copyInfo.stock += value;
        }
    }
}
