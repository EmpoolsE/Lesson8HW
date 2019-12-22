using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8HW
{
    class Program
    {
        static void Main(string[] args)
        {
            Entry entry = new Entry();
            Console.WriteLine("Welcome chose what to do");
            while(entry.Logged == false)
            {
                Console.WriteLine("Register = 0, SignIn = 1");
                var answer = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter login");
                var login = Console.ReadLine();
                Console.WriteLine("enter password");
                var password = Console.ReadLine();
                switch (answer)
                {
                    case 0:
                        Console.WriteLine(entry.Register(login, password));
                        break;
                    case 1:
                        Console.WriteLine(entry.SignIn(login, password));
                        break;
                    default:
                        Console.WriteLine("wrong chose");
                        break;
                }
            }
            Console.WriteLine("Today is {0} \nLets write note", DateTime.Now);
            string noteText = "";
            while (true)
            {
                string wordLine = Console.ReadLine();
                if(wordLine == "quit")
                {
                    if (noteText != "")
                    {
                        entry.SaveNote(noteText);
                    }
                    break;
                }
                if (wordLine == "data")
                {
                    if (noteText != "")
                    {
                        entry.SaveNote(noteText);
                    }
                    Console.WriteLine("Your List of notes");
                    foreach (var note in entry.GetNotes())
                    {
                        Console.WriteLine(note.Date+"\n");
                    }
                    Console.WriteLine("Enter date to view note text or data to view list or quit to exit");
                    ShowNote(entry);
                    break;
                }
                noteText += wordLine + "\n";
            }
            
            
            
        }
        public static void ShowNote(Entry entry)
        {
            while (true)
            {
                string option = Console.ReadLine();
                switch (option)
                {
                    case "data":
                        foreach (var note in entry.GetNotes())
                        {
                            Console.WriteLine(note.Date + "\n");
                        }
                        break;
                    case "exit":
                        break;
                    default:
                        DateTime date = Convert.ToDateTime(option);
                        Note findednote = entry.GetNote(date);
                        Console.WriteLine("{0}\n{1}", findednote.Date, findednote.NoteText);
                        break;
                }
            }
        }
    }
}
