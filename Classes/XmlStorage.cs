using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using zlinz_3_k26.Interfaces;

namespace zlinz_3_k26.Classes
{
    public static class XmlStorageTypes
    {
        private static readonly List<Type> RegisteredTypes = new List<Type>();

        static XmlStorageTypes()
        {
            Register<object>();
            Register<Exception>();

            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (!type.IsGenericType)
                {
                    foreach (var attr in type.GetCustomAttributes())
                    {
                        if (attr.GetType() == typeof(DataContractAttribute))
                        {
                            XmlStorageTypes.Register(type);
                            break;
                        }
                    }
                }
            }
        }

        public static void Register(Type type)
        {
            if (!RegisteredTypes.Contains(type))
            {
                Console.WriteLine($"Zarejestrowano typ:{type.Name}");
                RegisteredTypes.Add(type);
            }
        }
        public static void Register<T>()
        {
            Register(typeof(T));
        }

        public static Type[] GetArray() => RegisteredTypes.ToArray();
    }

    [DataContract]
    public abstract class XmlStorage<T> : IXmlStorage where T : class
    {
        public virtual bool FromXml(Stream Stream)
        {
            DataContractSerializer oDeSerializer = new DataContractSerializer(typeof(T),XmlStorageTypes.GetArray());

            using var oReader = XmlDictionaryReader.CreateTextReader(Stream, new XmlDictionaryReaderQuotas());

            return InitializeFromObject((T)oDeSerializer.ReadObject(oReader, false));
        }

        public virtual MemoryStream ToXml()
        {
            using var oStream = new MemoryStream();

            DataContractSerializer oSerializer = new DataContractSerializer(typeof(T), XmlStorageTypes.GetArray());

            using var oWriter = XmlDictionaryWriter.CreateTextWriter(oStream, Encoding.UTF8);

            oSerializer.WriteObject(oWriter, this);

            return oStream;
        }

        public abstract bool InitializeFromObject(T Object);

    }
}
