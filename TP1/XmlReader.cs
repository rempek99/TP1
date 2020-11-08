using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using TP1.Model;

namespace TP1
{
    public class XmlReader : IDataReaderFromFile
    {
        public string filePath { get; set; }

        public XmlReader(string filePath)
        {
            this.filePath = filePath;
        }

        public List<string> readData(string key1, string key2)
        {
            List<string> output = new List<string>();
            XmlTextReader reader = new XmlTextReader(filePath);
            bool Key1Found = false;
            bool Key2Found = false;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        if(reader.Name.ToString() == key1)
                            Key1Found = true;
                        if (reader.Name.ToString() == key2 && Key1Found)
                            Key2Found = true;
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        if (Key2Found && Key1Found)
                        {
                            output.Add(reader.Value);
                            Key2Found = false;
                            Key1Found = false;
                        }
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        if (Key1Found && !Key2Found && reader.Name == key1)
                        {
                            output.Add("");
                            Key2Found = false;
                            Key1Found = false;
                        }  
                        break;
                }
                Console.WriteLine(".");
            }

            /*while (docReader.Read())
            {
                if(docReader.Name == key1 && docReader.NodeType == XmlNodeType.Element)
                {
                    Console.WriteLine(docReader.Name);
                    while(docReader.Read())
                    {
                        if (docReader.Name == key2 && docReader.NodeType == XmlNodeType.Text)
                        {
                            Console.WriteLine(docReader.Name, " ", docReader.Value);
                            break;
                        }
                    }

                }
            }*/
            return output;
        }
    }
}
