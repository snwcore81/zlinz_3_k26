using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using zlinz_3_k26.Interfaces;

namespace zlinz_3_k26.Classes
{
    [DataContract]
    public abstract class XmlStorage<T> : IXmlStorage where T : class
    {
        public virtual bool FromXml(Stream Stream)
        {
            DataContractSerializer oDeSerializer = new DataContractSerializer(typeof(T));

            using var oReader = XmlDictionaryReader.CreateTextReader(Stream, new XmlDictionaryReaderQuotas());

            return InitializeFromObject((T)oDeSerializer.ReadObject(oReader, false));
        }

        public virtual MemoryStream ToXml()
        {
            using var oStream = new MemoryStream();

            DataContractSerializer oSerializer = new DataContractSerializer(typeof(T));

            using var oWriter = XmlDictionaryWriter.CreateTextWriter(oStream, Encoding.UTF8);

            oSerializer.WriteObject(oWriter, this);

            return oStream;
        }

        public abstract bool InitializeFromObject(T Object);

    }
}
