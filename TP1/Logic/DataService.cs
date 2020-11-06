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
        public abstract void AddNewReader(string name, string lastName,IProfiler profile);
        public abstract void RemoveReader(int readerIndex);
        public abstract void ChangeReaderData(int readerIndex, string name, string lastName);
        public abstract void AddNewBookItem(string title, string author);
        public abstract void RemoveBookItem(int bookIndex);
        public abstract void ChangeBookItemData(int bookKey, string title, string author);
        public abstract void RegisterCopies(int bookIndex, int quantity, double prize, string currency);
        public abstract void RetractCopies(int copiesIndex);
        public abstract void RetractCopies(int copiesIndex, int quantity);
        public abstract bool RegisterBorrowing(int readerIndex, int copyIndex);
        public abstract bool RegisterBorrowing(int readerIndex, int copyIndex, DateTime startDate);
        public abstract bool RegisterBorrowing(int readerIndex, int copyIndex, DateTime startDate, DateTime endDate);
    }
}
