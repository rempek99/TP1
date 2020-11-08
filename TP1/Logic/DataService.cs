using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TP1.Model;

namespace TP1.Logic
{
    public abstract class DataService
    {

        protected IDataRepository dataRepository;

        protected DataService(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        //READER
        public abstract bool AddNewReader(string name, string lastName);
        public abstract bool RemoveReader(int readerIndex);
        public abstract bool ChangeReaderData(int readerIndex, string name, string lastName);

        //BOOK ITEM
        public abstract bool AddNewBookItem(string title, string author);
        public abstract bool RemoveBookItem(int bookIndex);
        public abstract bool ChangeBookItemData(int bookKey, string title, string author);
        
        //COPIES
        public abstract bool RegisterCopies(int bookKey, int quantity, double prize, string currency);
        public abstract bool RetractCopies(int copiesIndex);
        public abstract bool RetractCopies(int copiesIndex, int quantity);
        public abstract bool ChangeCopiesData(int copiesIndex, int bookItemKey, int quantity, double prize, string currency);
        public abstract int GetQuantity(int copiesIndex);
        
        //BORROWING
        public abstract bool RegisterBorrowing(int readerIndex, int copyIndex);
        public abstract bool RegisterBorrowing(int readerIndex, int copyIndex, DateTime startDate);
        public abstract bool RegisterBorrowing(int readerIndex, int copyIndex, DateTime startDate, DateTime endDate);
        public abstract bool SetReturned(int borrowingIndex);


        public abstract List<string> GetInfo(string type);
        public abstract void LoadFileData();
    }
}
