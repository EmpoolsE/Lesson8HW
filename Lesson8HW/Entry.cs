using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson8HW
{
    class Entry
    {
        private bool loged = false;
        private User user;
        
        public string Register(string login, string password)
        {
            if (!Regex.Match(login, "^[a-zA-Z0-9.-]{3,}@[a-z]{3,}[.]{1}[a-z]{2,}").Success || UserInfo.UserExist(login))
            {
                return "User exist try other login";
            }
            user = new User() { Login = login, Password = password };
            UserInfo.SaveUserInfo(user);
            return "registered";
        }
        public string SignIn(string login, string password)
        {
            if (!UserInfo.UserExist(login))
            {
                return "Wrong Login!";
            }
            user = UserInfo.GetUserInfo(login);
            loged = true;
            return "Welcome";
        }

        public List<Note> GetNotes()
        {
            return new List<Note>();
        }
        public Note GetNote(DateTime date)
        {
            return new Note();
        }
        
        public string SaveNote(string text)
        {
            return "saved";
        }
    }
}
