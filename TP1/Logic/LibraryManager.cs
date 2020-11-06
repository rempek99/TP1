using System;
using System.Collections.Generic;
using System.Text;
using TP1.Model;

namespace TP1.Logic
{
    public class LibraryManager : DataService
    {
        public override void AddNewBookItem(string title, string author)
        {
            dataRepository.AddBookItem(title, author);
        }

        public override void AddNewReader(string name, string lastName, IProfiler profile)
        {
            dataRepository.AddReader(name, lastName, profile);
        }

        public override void ChangeBookItemData(int bookKey, string title, string author)
        {
            dataRepository.UpdateBookItem(bookKey, title, author);
        }

        public override void ChangeReaderData(int readerIndex, string name, string lastName)
        {
            dataRepository.UpdateReader(dataRepository.GetReader(readerIndex), name, lastName);
        }

        public override bool RegisterBorrowing(int readerIndex, int copyIndex)
        {
            if (dataRepository.GetCopyInfo(copyIndex).stock == 0)
                return false;
            dataRepository.AddBorrowing(dataRepository.GetReader(readerIndex), dataRepository.GetCopyInfo(copyIndex));
            return true;
        }

        public override bool RegisterBorrowing(int readerIndex, int copyIndex, DateTime startDate)
        {
            if (dataRepository.GetCopyInfo(copyIndex).stock == 0)
                return false;
            dataRepository.AddBorrowing(dataRepository.GetReader(readerIndex), dataRepository.GetCopyInfo(copyIndex),startDate);
            return true;
        }

        public override bool RegisterBorrowing(int readerIndex, int copyIndex, DateTime startDate, DateTime endDate)
        {
            if (dataRepository.GetCopyInfo(copyIndex).stock == 0)
                return false;
            dataRepository.AddBorrowing(dataRepository.GetReader(readerIndex), dataRepository.GetCopyInfo(copyIndex),startDate,endDate);
            return true;
        }

        public override void RegisterCopies(int bookIndex, int quantity, double prize, string currency)
        {
            int i = dataRepository.FindExistedCopies(bookIndex, prize, currency);
            if (i >= 0)
            {
                dataRepository.UpdateCopyInfoStock(dataRepository.GetCopyInfo(i), quantity);
            }
            else
            {
                dataRepository.AddCopyInfo(dataRepository.GetBookItem(bookIndex), quantity, prize, currency);
            }
        }

        public override void RemoveBookItem(int bookKey)
        {
            if(dataRepository.RemoveBookItem(bookKey))
        }

        public override void RemoveReader(int readerIndex)
        {
            throw new NotImplementedException();
        }

        public override void RetractCopies(int copiesIndex)
        {
            throw new NotImplementedException();
        }

        public override void RetractCopies(int copiesIndex, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
