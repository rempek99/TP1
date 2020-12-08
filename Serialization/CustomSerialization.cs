using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Serialization
{
    public class CustomSerialization : IFormatter
    {
       private ISerializable sObj;
        private int insideObj = 0;
        private Type type;
        private Type savedType;
        public List<Type> knownTypes { get; set; }
        private List<String> knownIDs;
        private List<object> collectedItems;
        bool isInsideColleciton = false;
        string line;
        StreamReader reader;
        Dictionary<Guid, object> references;
        public CustomSerialization(Type type)
        {
            this.type = type;
            this.savedType = type;
            collectedItems = new List<object>();
            knownIDs = new List<string>();
            knownTypes = new List<Type>();
            references = new Dictionary<Guid, object>();
        }
        public string getID(ISerializable obj, Type type)
        {
            List<PropertyInfo> pInfo =  type.GetProperties().ToList();
            foreach(PropertyInfo p in pInfo)
            {
                if (p.Name == "id")
                    return p.GetValue(obj).ToString();
            }
            return "0";
        }
        public ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Deserialize(Stream serializationStream)
        {
            Object obj;
            Console.WriteLine(line);
            try
            {
                obj = Activator.CreateInstance(type);
            }
            catch(System.MissingMethodException ex)
            {
                foreach(Type tmp in knownTypes)
                {
                    if (line.Equals(tmp.FullName))
                    {
                        type = tmp;
                        break;
                    }
                }
                obj = Activator.CreateInstance(type);
            }
            
            if(reader == null)
                reader = new StreamReader(serializationStream);
            
               // obj_type = Type.GetType(reader.ReadLine());
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    Console.WriteLine(line);
                if (line == savedType.FullName)
                    line = reader.ReadLine();
                else
                {
                    switch (line)
                    {
                        case "{":
                            insideObj++;
                            break;
                        case "}":
                            insideObj--;
                            PropertyInfo proper = type.GetProperty("id");
                            if(!references.ContainsKey((Guid)proper.GetValue(obj)))
                                references.Add((Guid)proper.GetValue(obj), obj);
                            return obj;
                        case "[":
                            isInsideColleciton = true;
                            break;
                        case "]":
                            isInsideColleciton = false;
                            obj = assignCollectedItems(obj);
                            return obj;
                            break;
                        default:
                            if(isInsideColleciton && line.Contains('.'))
                            {
                                PropertyInfo prop = type.GetProperty("Item");
                                Type tmp = type;
                                type = prop.PropertyType;
                                isInsideColleciton = false;
                                collectedItems.Add(Deserialize(serializationStream));
                                isInsideColleciton = true;
                                type = tmp;
                            }
                            else if (line.Contains('>'))
                            {
                                string[] keyValue = line.Split('>');
                                PropertyInfo pi = type.GetProperty(keyValue[0]);
                                if (pi != null)
                                {
                                    Type tmp = type;
                                    type = pi.PropertyType;
                                    pi.SetValue(obj,Deserialize(serializationStream));
                                    type = tmp;
                                }
                            }
                            else if (line.Contains('='))
                            {
                                string[] keyValue = line.Split('=');
                                PropertyInfo pi = type.GetProperty(keyValue[0]);
                                if (pi != null)
                                {
                                    if(keyValue[1].Length > 3 && keyValue[1].Substring(0,3) == "ref" )
                                    {
                                        try
                                        {
                                            pi.SetValue(obj, references[getReferenceID(keyValue[1])]);
                                        }
                                        catch (System.Collections.Generic.KeyNotFoundException)
                                        {
                                            type.ToString();
                                            references.ToString();
                                            pi.SetValue(obj, null);
                                        }
                                    }
                                    else if (keyValue[0] == "id")
                                        pi.SetValue(obj, Guid.Parse(keyValue[1]), null);
                                    else
                                    {
                                        writeProperty(pi, obj, keyValue[1]);
                                        //pi.SetValue(obj, keyValue[1], null);
                                    }
                                }

                            }
                            break;
                    }
                }
            }
            return obj;
        }
        public void AssignReferences(Stream serializationStream, object obj)
        {
            if (reader == null)
                reader = new StreamReader(serializationStream);

            // obj_type = Type.GetType(reader.ReadLine());
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                Console.WriteLine(line);
                if (line == savedType.FullName)
                    line = reader.ReadLine();
                else
                {
                    switch (line)
                    {
                        case "{":
                            insideObj++;
                            break;
                        case "}":
                            insideObj--;
                            break;
                        default:
                            if (line.Contains('>'))
                            {
                                string[] keyValue = line.Split('>');
                                PropertyInfo pi = type.GetProperty(keyValue[0]);
                                if (pi != null)
                                {
                                    Type tmp = type;
                                    type = pi.PropertyType;
                                    AssignReferences(serializationStream,pi.GetValue(obj));
                                    type = tmp;
                                }
                            }
                            else if (line.Contains('='))
                            {
                                string[] keyValue = line.Split('=');
                                PropertyInfo pi = type.GetProperty(keyValue[0]);
                                if (pi != null)
                                {
                                    if (keyValue[1].Length > 3 && keyValue[1].Substring(0, 3) == "ref")
                                    {
                                        try
                                        {
                                            if (pi.GetValue(obj) == null)
                                                pi.SetValue(obj, references[getReferenceID(keyValue[1])]);
                                        }
                                        catch (System.Collections.Generic.KeyNotFoundException)
                                        {
                                            type.ToString();
                                            references.ToString();
                                            pi.SetValue(obj, null);
                                        }
                                    }

                                }
                            }
                            break;
                    }
                }
            }
        }
        public object Deserialize(Stream serializationStream, bool circularReferences)
        {
            object _obj = Deserialize(serializationStream);
            if (circularReferences)
            {
                //setup all 
                serializationStream.Position = 0;
                AssignReferences(serializationStream, _obj);
            }
            return _obj;
        }
        public void writeProperty(PropertyInfo pi, object obj, string value)
        {

            switch (pi.PropertyType.Name)
            {
               case "Int32":
                    pi.SetValue(obj, Int32.Parse(value), null);
                    break;
                case "String":
                    pi.SetValue(obj, value, null);
                    break;
                case "Double":
                    pi.SetValue(obj, Double.Parse(value), null);
                    break;
                case "DateTime":
                    pi.SetValue(obj, DateTime.Parse(value), null);
                    break;
                default:
                    break;
            }
        }
        public Guid getReferenceID(String value)
        {
            return Guid.Parse(value.Substring(4,36));
        }
        public object assignCollectedItems(object _obj)
        {
            object result = null;
            if(type.Name.Contains("List"))
            {
                Type elements_type = collectedItems[0].GetType();
                IList tmp =(IList) _obj;
                tmp.Add(collectedItems);
                collectedItems.Clear();
                Convert.ChangeType(tmp, type);
                result = tmp;
                return tmp;
            }
            switch (type.Name)
            {
                case "List":
                    break;
                default:
                    break;
            }

            return result;
        }
        public void Serialize(Stream serializationStream, object graph)
        {
            SerializationInfo sInfo = new SerializationInfo(type,new MyConverter());
            StreamingContext sContext = new StreamingContext();
            sObj = (ISerializable)graph;
            sObj.GetObjectData(sInfo, sContext);
            List<PropertyInfo> propertyInfos = sInfo.ObjectType.GetProperties().ToList();
            StreamWriter writer = new StreamWriter(serializationStream);
            StreamReader reader;
            writer.WriteLine(graph.GetType());
            writer.WriteLine('{');
            Type savedType = type;
            Type savedType2 = type;
            
            foreach (PropertyInfo pi in propertyInfos)
            {
                if (sInfo.GetValue(pi.Name, pi.PropertyType) is ICollection)
                {
                    writer.WriteLine(pi.Name + '>' + pi.PropertyType);
                    writer.WriteLine('[');
                    writer.Flush();
                    if (sInfo.GetValue(pi.Name, pi.PropertyType) is IDictionary)
                    {
                        IDictionary dictionary = (IDictionary)sInfo.GetValue(pi.Name, pi.PropertyType);
                        IEnumerator keyEnumerator = dictionary.Keys.GetEnumerator();
                        for (int i = 0; i < dictionary.Count; i++)
                        {
                            keyEnumerator.MoveNext();
                            writer.WriteLine(String.Format("{0}={1}", keyEnumerator.Current, " = " + dictionary[keyEnumerator.Current]));

                            // valueEnumerator.MoveNext();
                        }
                    }
                    else
                    {
                        ICollection collection = (ICollection)sInfo.GetValue(pi.Name, pi.PropertyType);
                        foreach (object obj in collection)
                        {
                            type = obj.GetType();
                            Serialize(serializationStream, obj);
                        }
                        type = savedType;
                    }
                    writer.WriteLine(']');
                }
                else if (sInfo.GetValue(pi.Name, pi.PropertyType) is ISerializable)
                {
                    if (pi.PropertyType == typeof(DateTime))
                        writer.WriteLine(String.Format("{0}={1}", pi.Name, sInfo.GetValue(pi.Name, pi.PropertyType)));
                    else 
                    {
                        sObj = (ISerializable)sInfo.GetValue(pi.Name, pi.PropertyType);
                        if (knownIDs.Contains(getID(sObj, pi.PropertyType)))
                        {
                            writer.WriteLine(String.Format("{0}={1}", pi.Name, "ref{" + getID(sObj, pi.PropertyType) + '}'));
                        }
                        else
                        {
                            type = pi.PropertyType;
                            writer.Write(pi.Name + '>');
                            writer.Flush();
                            Serialize(serializationStream, sInfo.GetValue(pi.Name, pi.PropertyType));
                            type = savedType;
                        }
                    }
                }
                else
                {
                    if (pi.Name == "id")
                        knownIDs.Add(sInfo.GetValue(pi.Name, pi.PropertyType).ToString());
                    writer.WriteLine(String.Format("{0}={1}", pi.Name, sInfo.GetValue(pi.Name, pi.PropertyType)));
                }
                
            }
            writer.WriteLine('}');
            writer.Flush();
        }


    }
   
    public class MyConverter : IFormatterConverter
    {
        public object Convert(object value, Type type)
        {
            throw new NotImplementedException();
        }

        public object Convert(object value, TypeCode typeCode)
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(object value)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(object value)
        {
            throw new NotImplementedException();
        }

        public char ToChar(object value)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(object value)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(object value)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(object value)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(object value)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(object value)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(object value)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(object value)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(object value)
        {
            throw new NotImplementedException();
        }

        public string ToString(object value)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(object value)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(object value)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(object value)
        {
            throw new NotImplementedException();
        }
    }
}
