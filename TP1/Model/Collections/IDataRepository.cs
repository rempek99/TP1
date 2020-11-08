using System;
using System.Collections.Generic;

namespace TP1.Model
{
    public interface IDataRepository
    {

        // READER
        void AddReader(string name, string lastname);
        int FindReader(string name, string lastname);
        void RemoveReader(int readerIndex);
        void UpdateReader(int readerIndex, string name, string lastname);
        int GetReadersCount();

        // BOOK ITEM
        void AddBookItem(string title, string author);
        int FindBookItem(string title, string author);
        void RemoveBookItem(int key);
        void UpdateBookItem(int key, string title, string author);
        bool BookExist(int bookItemKey);
        int GetBookItemsCount();

        // EVENT
        void AddBorrowing(int readerIndex, int copyInfoIndex);
        void AddBorrowing(int readerIndex, int copyInfoIndex, DateTime startDate);
        void AddBorrowing(int readerIndex, int copyInfoIndex, DateTime startDate, DateTime endDate);
        void AddPurchase(int readerIndex, int copyInfoIndex);
        void AddPurchase(int readerIndex, int copyInfoIndex, DateTime startDate);
        bool IsBorrowing(int eventIndex);
        void SetBorrowingEndDate(int borrowingIndex, DateTime endDate);
        bool IsBorrowingReturned(int borrowingIndex);
        int FindEvent(int readerIndex, int copyInfoIndex, DateTime startDate);
        int GetEventsCount();

        // COPY INFO
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