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
        public int ResponseCode { get; private set; }

        [DataMember]
        public string ResponseString { get; private set; }

        public ResponseObject()
        {
            ResponseCode = -1;
            ResponseString = "Brak odpowiedzi";
        }

        public ResponseObject(int ResponseCode, string ResponseString)
        {
            this.ResponseCode = ResponseCode;
            this.ResponseString = ResponseString;
        }

        public override string ToString()
        {
            return $"[ResponseString={ResponseString}|ResponseCode={ResponseCode}]";
        }
    }
}
