using System;
using System.Collections.Generic;
using System.Text;

namespace TP1.Model
{
    public interface IDataRepository
    {
        Reader GetReader(int i);
        void AddReader(string name, string lastname, IProfiler profile);
        bool RemoveReader(Reader reader);
        bool UpdateReader(Reader reader, string name, string lastname);

        BookItem GetBookItem(int key);
        void AddBookItem(string title, string author);
        bool RemoveBookItem(int key);
        bool UpdateBookItem(int key, string title, string author);

        Borrowing GetBorrowing(int i);
        void AddBorrowing(Reader reader, CopyInfo copyInfo, DateTime startDate, DateTime endDate);
        void AddBorrowing(Reader reader, CopyInfo copyInfo);
        void AddBorrowing(Reader reader, CopyInfo copyInfo, DateTime startDate);
        bool RemoveBorrowing(Borrowing borrowing);
        bool UpdateBorrowing(Borrowing borrowing, Reader reader, CopyInfo copyInfo, DateTime startDate, DateTime endDate);

        CopyInfo GetCopyInfo(int i);
        bool AddCopyInfo(BookItem bookItem, int stock, double prize, string currency);
        bool RemoveCopyInfo(CopyInfo copyInfo);
        bool UpdateCopyInfo(CopyInfo copyInfo, BookItem bookItem, int stock,double prize,string currency);
        void UpdateCopyInfoStock(CopyInfo copyInfo, int value);
        int FindExistedCopies(int bookIndex, double prize, string currency);
    }
}