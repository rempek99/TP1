using System;
using System.Collections.Generic;
using System.Text;

namespace TP1copy.Model
{
    public interface IDataReaderFromFile
    {
        List<string> readData(string key1, string key2);
    }
}
