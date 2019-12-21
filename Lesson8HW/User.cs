using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8HW
{
    [Serializable]
    public class User
    {
        private string password;
        public string Login { get; set; }
        public string Password { get; set; }

        public List<Note> notes = new List<Note>();
        public void SaveNote(Note note)
        {
            notes.Add(note);

        }
    }
}
