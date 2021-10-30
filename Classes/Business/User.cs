using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace zlinz_3_k26.Classes.Business
{
    [DataContract]
    public class User : XmlStorage<User>
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int Permission { get; set; }

        public User()
        {
        }
        public override bool InitializeFromObject(User Object)
        {
            this.Login = Object.Login;
            this.Password = Object.Password;
            this.Permission = Object.Permission;

            return true;
        }

        public override string ToString()
        {
            return $"[Login={Login}|Password=???|Permission={Permission}]";
        }

    }
}
