using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace zlinz_3_k26.Classes.Business
{
    [DataContract]
    public class ResponseObject
    {
        [DataMember]
        public int ResponseCode { get; set; }

        [DataMember]
        public string ResponseString { get; set; }

        public ResponseObject()
        {
            ResponseCode = -1;
            ResponseString = "Brak odpowiedzi";
        }

        public override string ToString()
        {
            return $"[ResponseString={ResponseString}|ResponseCode={ResponseCode}]";
        }
    }
}
