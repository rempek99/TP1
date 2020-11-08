using System;
using System.Collections.Generic;
using System.Text;
using TP1.Logic;
using TP1.Model;
using TP1;
using Xunit;

namespace TP1_test
{
    public class DataReaderFromFileTest
    {
        [Fact]
        public void XMLReaderTest()
        {
            // Data.xml file contains info about 3 readers, 2 bookItems, 2 copyInfos, 2 borrowings and 2 puchaces
            DataService library = new LibraryManager(new DataRepository(new XmlReader("data.xml")));
            Assert.Empty(library.GetInfo("readers"));
            library.LoadFileData();
            Assert.NotEmpty(library.GetInfo("readers"));
            Assert.Equal(3, library.GetInfo("readers").Count);
            Assert.Equal(2, library.GetInfo("bookItems").Count);
            Assert.Equal(2, library.GetInfo("copyInfos").Count);
            Assert.Equal(4, library.GetInfo("events").Count);
            
        }
    }
}
