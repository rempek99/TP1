using System;
using System.Runtime.Serialization;
using System.Xml;

namespace Serialization
{
    public class MyXmlSerializer
    {
        
    static public void CreateManagerFile(Type objectType, Object myObject, String filename)
    {
        // STANDARD VERSION
        /* XmlSerializer serializer = new XmlSerializer(typeof(LibraryManager));
         TextWriter writer = new StreamWriter(filename);
         serializer.Serialize(writer, manager);
         writer.Close();*/

        // DATA CONTRACT SERIALIZER
/*
        dataContractSerializerSettings.KnownTypes = new Type[] { typeof(Borrowing), typeof(Purchase)};*/
        DataContractSerializer serializer = new DataContractSerializer(objectType, null, 0x7FFF, false, true, null);
        XmlWriter writer = XmlWriter.Create(filename);
        serializer.WriteObject(writer, myObject);
        writer.Close();
    }
        static public Object ReadManagerFile(Type objectType, String filename)
        {
            DataContractSerializer serializer = new DataContractSerializer(objectType, null, 0x7FFF, false, true, null);
            XmlReader writer = XmlReader.Create(filename);
            Object tmp = serializer.ReadObject(writer);
            writer.Close();
            return tmp;
        }
}
}
