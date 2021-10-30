using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace zlinz_3_k26.Interfaces
{
    public interface IXmlStorage
    {
        bool FromXml(Stream Stream);
        MemoryStream ToXml();
    }
}
