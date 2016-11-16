using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02.Logic;

namespace Task02.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            GenericQueue<string> test = new GenericQueue<string>();
            for (int i = 0; i < 15; i++)
            {
                test.Enqueue(i.ToString());
            }
            for (int i = 0; i < 8; i++)
            {
                test.Dequeue();
            }

            for (int i = 16; i < 30; i++)
            {
                test.Enqueue(i.ToString());
            }

            foreach (var i in test)
            {
                Console.WriteLine(i);
            }
           
            Console.ReadLine();
        }
    }
}
