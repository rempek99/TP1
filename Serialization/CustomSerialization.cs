using System;
using System.IO;

namespace Serialization
{
    public class CustomSerialization
    {
        static public void CreateFile(Object myObject, String filename)
        {
            MyFormatter serializer = new MyFormatter();
            Stream stream = File.Open(filename, FileMode.Create);
            serializer.Serialize(stream, myObject);
            stream.Close();
        }
        static public Object ReadFile(String filename)
        {
            MyFormatter serializer = new MyFormatter();
            Stream stream = File.Open(filename, FileMode.Open);
            object objCopy = serializer.Deserialize(stream);
            stream.Close();
            return objCopy;
        }
    }
}
