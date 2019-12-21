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
        public bool Logged { get {
                return loged;
            } }
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
            if (user.Password == password)
            {
                loged = true;
                return "Welcome";
            }
            else
            {
                loged = false;
                user = null;
                return "Wrong password";
            }
            
        }

        public List<Note> GetNotes()
        {
            if (loged)
            {
                return user.notes;
            }
            else
            {
                Console.WriteLine("Must be logged");
                return null;
            }
            
        }
        public Note GetNote(DateTime date)
        {
            if (loged)
            {
                return user.notes.Single(s => s.Date == date);
            }
            else
            {
                Console.WriteLine("Must be logged");
                return null;
            }
            
        }
        
        public string SaveNote(string text)
        {
            if (loged)
            {
                user.SaveNote(new Note() { Date = DateTime.Now, NoteText = text});
                return "Saved";
            }
            else
            {
                return "Must be logged";
            }
        }
    }
}
