using System;
using System.Collections.Generic;
using System.Text;

namespace TP1.Model
{
    public interface IDataRepository
    {

        // READER
        // Reader GetReader(int i);
        void AddReader(string name, string lastname);
        int FindReader(string name, string lastname);
        void RemoveReader(int readerIndex);
        void UpdateReader(int readerIndex, string name, string lastname);
        int GetReadersCount();

        // BOOK ITEM
        // BookItem GetBookItem(int key);
        void AddBookItem(string title, string author);
        int FindBookItem(string title, string author);
        void RemoveBookItem(int key);
        void UpdateBookItem(int key, string title, string author);
        int GetBookItemsCount();

        // BORROWING
        // Borrowing GetBorrowing(int i);
        void AddBorrowing(int readerIndex, int copyInfoIndex);
        void AddBorrowing(int readerIndex, int copyInfoIndex, DateTime startDate);
        void AddBorrowing(int readerIndex, int copyInfoIndex, DateTime startDate, DateTime endDate);
        // void RemoveBorrowing(int borrowingIndex); //Borrowing are saved 4ever
        void SetBorrowingEndDate(int borrowingIndex, DateTime endDate);
        bool IsBorrowingReturned(int borrowingIndex);
        int FindBorrowing(int readerIndex, int copyInfoIndex, DateTime startDate);
        int GetBorrowingsCount();

        // COPY INFO
        // CopyInfo GetCopyInfo(int i);
        void AddCopyInfo(int bookItemKey, int stock, double prize, string currency);
        void RemoveCopyInfo(int copyInfoIndex);
        void UpdateCopyInfo(int copyInfoIndex, int bookItemKey, int stock,double prize,string currency);
        void IncrementCopyInfoStock(int copyInfoIndex, int value);
        int FindExistedCopies(int bookItemKey, double prize, string currency);
        int GetCopyInfosCount();
        int GetCopyInfoStock(int copyInfoIndex);
        int GetCopyInfoFromBorrowing(int borrowingIndex);

        List<string> GetInfo(string type);
        void LoadDataFromFile();
        int GetKey();
    }
}