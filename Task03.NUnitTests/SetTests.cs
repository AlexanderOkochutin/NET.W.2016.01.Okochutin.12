using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task03.Logic;


namespace Task03.NUnitTests
{   
    [TestFixture]
    public class SetTests
    {
        [TestCase()]
        public void Constructor_tests()
        {
            string[] data = new string[] {"1", "2", "3", "4", "5"};
            Set<string> test = new Set<string>(data);
            Set<string> test2 = new Set<string>();
            test2.Add("1");
            test2.AddRange(new string[] {"2","3","4","5"});
            CollectionAssert.AreEqual(test,test2);
        }

        [TestCase()]
        public void Remove_Tests()
        {
            string[] data1 = new string[] { "1", "2", "3", "4", "5" };
            string[] data2 = new string[] { "1", "2", "3", "4" };
            Set<string> test1 = new Set<string>(data1);
            Set<string> test2 = new Set<string>(data2);
            test1.Remove("5");
            CollectionAssert.AreEqual(test1,test2);
        }

        [TestCase()]
        public void Union_tests()
        {
            string[] data1 = new string[] { "1", "2", "3", "4", "5" };
            string[] data2 = new string[] {"4","5","6","7" };
            string[] expectedData = new string[] { "1", "2", "3", "4", "5", "6", "7" };
            Set<string> test1 = new Set<string>(data1);
            Set<string> test2 = new Set<string>(data2);
            Set<string> expected = new Set<string>(expectedData);
            test1 = test1.Union(test2);
            CollectionAssert.AreEqual(test1,expected);
        }

        [TestCase()]
        public void Intersection_tests()
        {
            string[] data1 = new string[] { "1", "2", "3", "4", "5" };
            string[] data2 = new string[] { "4", "5", "6", "7" };
            string[] expectedData = new string[] { "4","5" };
            Set<string> test1 = new Set<string>(data1);
            Set<string> test2 = new Set<string>(data2);
            Set<string> expected = new Set<string>(expectedData);
            test1 = test1.Intersection(test2);
            CollectionAssert.AreEqual(test1, expected);
        }

        [TestCase()]
        public void Difference_tests()
        {
            string[] data1 = new string[] { "1", "2", "3", "4", "5" };
            string[] data2 = new string[] { "4", "5", "6", "7" };
            string[] expectedData = new string[] { "1", "2", "3" };
            Set<string> test1 = new Set<string>(data1);
            Set<string> test2 = new Set<string>(data2);
            Set<string> expected = new Set<string>(expectedData);
            test1 = test1.Difference(test2);
            CollectionAssert.AreEqual(test1, expected);
        }

        [TestCase()]
        public void SymDifference_tests()
        {
            string[] data1 = new string[] { "1", "2", "3", "4", "5" };
            string[] data2 = new string[] { "4", "5", "6", "7" };
            string[] expectedData = new string[] { "1","2","3","6","7"};
            Set<string> test1 = new Set<string>(data1);
            Set<string> test2 = new Set<string>(data2);
            Set<string> expected = new Set<string>(expectedData);
            test1 = test1.SymmetricalDifference(test2);
            CollectionAssert.AreEqual(test1, expected);
        }
    }
}
