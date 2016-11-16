using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.Logic
{
    public class Fibonacci
    {
        /// <summary>
        /// Iterator for get first N numbers in Fibonacci sequence
        /// </summary>
        /// <param name="n">how many numbers will be calculate</param>
        /// <returns>return next fibonacci number in sequence on each iteration</returns>
        public static IEnumerable<long> GetFirstN(int n)
        {
            long a = 1;
            long b = 0;
            long c = 0;
            checked
            {
                for (int i = 0; i < n; i++)
                {
                    yield return c;
                    c = a + b;
                    a = b;
                    b = c;
                }
            }
        } 
    }
}
