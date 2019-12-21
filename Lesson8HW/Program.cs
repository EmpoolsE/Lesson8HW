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
                        entry.Register(login, password);
                        break;
                    case 1:
                        entry.SignIn(login, password);
                        break;
                    default:
                        Console.WriteLine("wrong chose");
                        break;
                }
            }
        }
    }
}
