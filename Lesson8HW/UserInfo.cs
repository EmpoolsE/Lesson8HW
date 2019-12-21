using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson8HW
{
    public static class UserInfo
    {

        public static bool UserExist(string login)
        {
            var path = @"Users\"+Regex.Replace(login, "@[a-zA-Z0-9.-]+[.]{1}[a-z]{2,}", "")+".dat";
            return File.Exists(path);
        }
        public static User GetUserInfo(string login)
        {
            return null;
        }
        public static bool SaveUserInfo(User user)
        {
            try
            {
                FileStream stream = File.Create(@"Users\" + Regex.Replace(user.Login, "@[a-zA-Z0-9.-]+[.]{1}[a-z]{2,}", "") + ".dat");
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, user);
                stream.Close();
                return true;
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
