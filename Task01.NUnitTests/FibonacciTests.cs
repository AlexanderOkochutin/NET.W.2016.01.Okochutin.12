using System;
using NUnit.Framework;
using Task01.Logic;
namespace Task01.NUnitTests
{
    [TestFixture]
    public class FibonacciTests
    {
      
        [TestCase(0,typeof(ArgumentOutOfRangeException))]
        [TestCase(-1,typeof(ArgumentOutOfRangeException))]
        [TestCase(93,typeof(OverflowException))]
        public void GetFirstN_Exception_Tests(int n,Type exceptionType)
        {
            Assert.Throws(exceptionType,()=>ForeachFibonacci(n));
        }

        public void ForeachFibonacci(int n)
        {
            foreach (var num in Fibonacci.GetFirstN(n))
            {
                
            }
        }

        [TestCase(1, new long[] {0})]
        [TestCase(2, new long[] { 0,1 })]
        [TestCase(5, new long[] { 0, 1 ,1,2,3})]
        [TestCase(10,new long[] { 0, 1 ,1,2,3,5,8,13,21,34})]
        public void GetFirstN_Tests(int n, long[] expected)
        {
            int i = 0;
            foreach (var num in Fibonacci.GetFirstN(n))
            {
                Assert.AreEqual(num,expected[i++]);
            }
        }

      
    }
}
