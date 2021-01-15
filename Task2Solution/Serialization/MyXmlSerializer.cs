using System;
using System.Runtime.Serialization;
using System.Xml;

namespace Serialization
{
    public class MyXmlSerializer
    {
        
    static public void CreateFile(Type objectType, Object myObject, String filename)
    {
       
        // DATA CONTRACT SERIALIZER

        DataContractSerializer serializer = new DataContractSerializer(objectType, null, 0x7FFF, false, true, null);
            using (XmlWriter writer = XmlWriter.Create(filename, new XmlWriterSettings() { Indent = true }))
            {
                // !uncomment to enable style.css!
               // writer.WriteProcessingInstruction("xml-stylesheet", "type=\"text/css\" href=\"style.css\"");
                serializer.WriteObject(writer, myObject);
            }
        //writer.Close();
    }
        static public Object ReadFile(Type objectType, String filename)
        {
            DataContractSerializer serializer = new DataContractSerializer(objectType, null, 0x7FFF, false, true, null);
            XmlReader writer = XmlReader.Create(filename);
            Object tmp = serializer.ReadObject(writer);
            writer.Close();
            return tmp;
        }
}
}
