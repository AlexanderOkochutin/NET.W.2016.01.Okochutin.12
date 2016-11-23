using System;
using System.Collections;
using System.Collections.Generic;

namespace Task03.Logic
{
    /// <summary>
    /// custom generic set
    /// </summary>
    /// <typeparam name="T">class which implement IComparable interface</typeparam>
    public class Set<T> : IEnumerable<T> where T : class, IEquatable<T>
    {
        private readonly List<T> data = new List<T>();
        public int Count => data.Count;

        /// <summary>
        /// default constructor
        /// </summary>
        public Set()
        {
        }

        /// <summary>
        /// constructor based on collection
        /// </summary>
        /// <param name="items">input collection</param>
        public Set(IEnumerable<T> items)
        {
            AddRange(items);
        }

        /// <summary>
        /// method for adding element in set
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="InvalidOperationException">when element already exist in set</exception>
        public void Add(T item)
        {
            if (Contains(item))
            {
                throw new InvalidOperationException("item already in set");
            }
            data.Add(item);
        }

        /// <summary>
        /// add some elements in set
        /// </summary>
        /// <param name="items"></param>
        /// <exception cref="InvalidOperationException">when one of input elements already exist in set</exception>
        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }

        /// <summary>
        /// remove element from set
        /// </summary>
        /// <param name="item">removable element</param>
        /// <returns>true in case when element was in set and false when no such element in set</returns>
        public bool Remove(T item)
        {
            return data.Remove(item);
        }

        /// <summary>
        /// method which help to know element in set or not
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true in case when elem already exist in set and false in other case</returns>
        public bool Contains(T item)
        {
            return data.Contains(item);
        }

        /// <summary>
        /// union of sets
        /// </summary>
        /// <param name="other"></param>
        /// <returns>new set (result of union of two sets)</returns>
        public Set<T> Union(Set<T> other)
        {
            Set<T> result = new Set<T>(data);
            foreach (T item in other)
            {
                if (!Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        /// <summary>
        /// intersection of two sets
        /// </summary>
        /// <param name="other"></param>
        /// <returns>new set (result of intersection of two sets)</returns>
        public Set<T> Intersection(Set<T> other)
        {
            Set<T> result = new Set<T>();
            foreach (T item in this)
            {
                if (other.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        /// <summary>
        /// difference of teo sets
        /// </summary>
        /// <param name="other"></param>
        /// <returns>new set (result of difference of two sets)</returns>
        public Set<T> Difference(Set<T> other)
        {
            Set<T> result = new Set<T>(this);
            foreach (T item in other)
            {
                result.Remove(item);
            }
            return result;
        }

        /// <summary>
        /// symmetrical difference of two sets
        /// </summary>
        /// <param name="other"></param>
        /// <returns>return new set(result of symmetrical difference of two sets)</returns>
        public Set<T> SymmetricalDifference(Set<T> other)
        {
            Set<T> union = Union(other);
            Set<T> intersection = Intersection(other);
            return union.Difference(intersection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}
