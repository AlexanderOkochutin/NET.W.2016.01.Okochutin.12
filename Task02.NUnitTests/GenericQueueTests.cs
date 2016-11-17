using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task02.Logic;

namespace Task02.NUnitTests
{
    [TestFixture]
    public class GenericQueueTests<T>
    {

        [TestCase(5,new int[] {1,2,3,4,5})]
        [TestCase(10, new int[] { 1, 2, 3, 4, 5 })]
        public void Constructor_Capacity_Test(int capacity, int[] expected)
        {
            GenericQueue<int> test = new GenericQueue<int>(capacity);
            for (int i = 1; i <= 5; i++)
            {
                test.Enqueue(i);
            }
            CollectionAssert.AreEqual(test.ToArray(),expected);
        }


        [TestCase(new int[] {1,2,3,4,5})]
        public void Constructor_Collection_Tests(int[] expected )
        {
            List<int> test = new List<int>() {1,2,3,4,5};
            GenericQueue<int> testQueue = new GenericQueue<int>(test);
            CollectionAssert.AreEqual(testQueue.ToArray(),expected);
        }


        [TestCase(new int[] {1,2,3,4,5,6,7,8,9,10})]
        public void Enqueue_And_Dequeue_Tests(int[] data1)
        {
            GenericQueue<int> test1 = new GenericQueue<int>(data1);
            test1.Dequeue();
            test1.Dequeue();
            GenericQueue<int> test2 = new GenericQueue<int>(10);
            for (int i = 3; i <= 10; i++)
            {
                test2.Enqueue(i);
            }
            CollectionAssert.AreEqual(test1,test2);
        }
    }
}
