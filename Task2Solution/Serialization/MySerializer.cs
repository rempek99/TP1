using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    public class MySerializer
    {
        public static void Write(Type type,Object obj, String filename)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            TextWriter textWriter = new StreamWriter(filename);
            serializer.Serialize(textWriter, obj);
            textWriter.Close();
        }
    }
}
