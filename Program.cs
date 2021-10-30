using System;
using System.IO;
using System.Text;
using zlinz_3_k26.Classes;
using zlinz_3_k26.Classes.Business;

namespace zlinz_3_k26
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlString = @"<User xmlns=""http://schemas.datacontract.org/2004/07/zlinz_3_k26.Classes.Business"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><Login>jacek</Login><Password>12jacek34</Password><Permission>1</Permission><Response><ResponseCode>100</ResponseCode><ResponseString>Udało się zalogować</ResponseString></Response></User>";


            User user = new User();
            
            user.FromXml(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            Console.WriteLine(user);

            /*
            User obj = new User
            {
                Login = "jacek",
                Password = "12jacek34",
                Permission = 1
            };

            Console.WriteLine(Encoding.UTF8.GetString(obj.ToXml().ToArray()));
            */
        }
    }
}
