using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;

namespace Serialization
{
    public class MyFormatter : Formatter
    {
        private String output = "";
        public override ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }

        public MyFormatter()
        {
            Binder = new MyBinder();
            Context = new StreamingContext();
        }

        public override object Deserialize(Stream serializationStream)
        {
            object obj = null;
            Type objType = null;
            String streamContent = "";
            Dictionary<long, object> objects = new Dictionary<long, object>();
            long tempID = 0;
            long mainID = -1;
            using (StreamReader sr = new StreamReader(serializationStream))
            {
                streamContent = sr.ReadToEnd();
            }
            String [] lines = streamContent.Split('\n');
            foreach(String line in lines)
            {
                if (line.Length == 0)
                    break;
                if (line[0] == '#') // ClassType mark
                {
                    String[] parted = line.Substring(1).Split(';');
                    objType = Binder.BindToType(parted[0], parted[1]);
                    obj = Activator.CreateInstance(objType); // Creating an instance of readed Type                    
                }
                else if (line.Equals("}"))
                    objects.Add(tempID, obj);
                else if (line.Contains(";"))
                {
                    String[] TypeKeyValue = line.Split(';');
                    if (TypeKeyValue[1].Equals("#id"))
                    {
                        Type idType = Type.GetType(TypeKeyValue[0]);
                        tempID = (long)Convert.ChangeType(TypeKeyValue[2], idType, CultureInfo.InvariantCulture);
                        if (mainID < 0)
                            mainID = tempID;
                    }
                    else if (TypeKeyValue[2].Contains("ref"))
                    {
                        //Console.WriteLine("REFERENCJA");
                    }
                    else
                    {
                        Type propertyType = Type.GetType(TypeKeyValue[0]);
                        PropertyInfo propertyInfo = objType.GetProperty(TypeKeyValue[1]);
                        propertyInfo.SetValue(obj, Convert.ChangeType(TypeKeyValue[2], propertyType, CultureInfo.InvariantCulture));
                    }
                }
            }
            AssignReferences(objects, lines);

            return objects[mainID];
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            if (graph is ISerializable data)
            {
                SerializationInfo sInfo = new SerializationInfo(graph.GetType(), new FormatterConverter());
                data.GetObjectData(sInfo, Context);
                Binder.BindToName(sInfo.ObjectType, out string assemblyName, out string typeName);
                output += '#' + assemblyName  + ";" + typeName + "\n{\n";
                long id = m_idGenerator.GetId(graph, out bool firstTime);
                output += id.GetType() +";#id;" + id + '\n';
                foreach (SerializationEntry property in sInfo)
                {
                    WriteMember(property.Name, property.Value);
                    output += '\n';
                }
                output += "}\n";
            }
            while (m_objectQueue.Count != 0)
            {
                Serialize(null, m_objectQueue.Dequeue());
            }
            if (serializationStream != null)
            {
                using (StreamWriter sw = new StreamWriter(serializationStream))
                {
                    sw.Write(output);
                }
            }
        }

        public void AssignReferences(Dictionary<long,object> objects, String[] lines)
        {
            object operationObject = null;
            Type objType = null;
            Type idType = null;
            foreach (String line in lines)
            {
                if (line.Length == 0)
                    break;
                if (line[0] == '#') // ClassType mark
                {
                    String[] parted = line.Substring(1).Split(';');
                    objType = Binder.BindToType(parted[0], parted[1]);       
                }
                if (line.Contains("#id"))
                {
                    String[] TypeKeyValue = line.Split(';');
                    if(idType == null)
                        idType = Type.GetType(TypeKeyValue[0]);
                    operationObject = objects[(long)Convert.ChangeType(TypeKeyValue[2], idType, CultureInfo.InvariantCulture)];
                }
                if (line.Contains(";ref{"))
                {
                    String[] TypeKeyValue = line.Split(';');
                    String pureIdStr = TypeKeyValue[2].Trim(new Char[] { 'r', 'e', 'f', '{', '}' });
                    PropertyInfo propertyInfo = objType.GetProperty(TypeKeyValue[1]);
                    propertyInfo.SetValue(operationObject, objects[(long)Convert.ChangeType(pureIdStr, idType, CultureInfo.InvariantCulture)]);
                }
            }
        }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            output += val.GetType() + ";" + name + ";" + val.ToString("u",CultureInfo.InvariantCulture);
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            output += val.GetType() + ";" + name + ";" + val.ToString(CultureInfo.InvariantCulture);
        }

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (memberType.Equals(typeof(String)))
            {
                output += memberType + ";" + name + ";" + obj.ToString();
            }
            else
            {
                output += memberType + ";" + name + ";ref{" + m_idGenerator.GetId(obj, out bool firstTime).ToString() + '}';
                if (firstTime)
                {
                    m_objectQueue.Enqueue(obj);
                }
            }   
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }
    }
}
