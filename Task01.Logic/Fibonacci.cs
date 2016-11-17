using System;
using System.Collections.Generic;

namespace Task01.Logic
{
    public static class Fibonacci
    {
        /// <summary>
        /// Iterator for get first N numbers in Fibonacci sequence
        /// </summary>
        /// <param name="n">how many numbers will be calculate</param>
        /// <returns>return next fibonacci number in sequence on each iteration</returns>
        /// <exception cref="ArgumentOutOfRangeException">throw when input n less or equal zero</exception>
        /// <exception cref="OverflowException">throws when you want to calculate more than 92 fibonacci number</exception>
        public static IEnumerable<long> GetFirstN(int n)
        {
            if(n <= 0) throw new ArgumentOutOfRangeException(nameof(n));
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
