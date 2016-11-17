using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Logic
{
    /// <summary>
    /// structure of data circle buffer
    /// </summary>
    /// <typeparam name="T">type of elements in buffer</typeparam>
    public class CircleBuffer<T> : IEnumerable<T>
    {
        #region property and const defenitions
        /// <summary>
        /// sz array for data
        /// </summary>
        private T[] Data {  get; set; }
        
        /// <summary>
        ///index of head-element 
        /// </summary>
        private int Head { get; set; }

        /// <summary>
        /// index of tail-element
        /// </summary>
        private int Tail { get; set; }

        /// <summary>
        /// count of elements in array
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// length of array
        /// </summary>
        public int Length => Data.Length;
        
        /// <summary>
        /// show array is full or not
        /// </summary>
        public bool IsFull => Count == Data.Length;

        /// <summary>
        /// default length of array for dafault constructor
        /// </summary>
        public const int defaultCapacity = 4;

        #endregion


        #region Constructors defenitions

        public CircleBuffer() { }

        public CircleBuffer(int capacity)
        {
            if (capacity == 0)
            {
                capacity = defaultCapacity;
            }

            Data = new T[capacity];
            Head = Tail = Count = 0;
        }

        #endregion

        #region Add and Get methods

        /// <summary>
        /// add element to tail positiopn
        /// </summary>
        /// <param name="s">input element</param>
        public void PushTail(T s)
        {
            if (Count < Data.Length && Equals(Data[Tail],default(T)))
            {
                Count++;
            }

            Data[Tail] = s;
            Tail = (++Tail) % Data.Length;
        }

        /// <summary>
        /// Get and remove element from head position
        /// </summary>
        /// <returns>element on head position</returns>
        public T PopHead()
        {

            if (Count == 0)
            {
                throw new InvalidOperationException("array is empty");
            }

            T removed = Data[Head];
            Data[Head] = default(T);
            Head = (++Head) % Data.Length;
            Count--;
            return removed;
        }

        /// <summary>
        /// show element on head position without remove
        /// </summary>
        /// <returns>element on head position</returns>
        public T PeekHead()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("queue is empty");
            }
            return Data[Head];
        }

        /// <summary>
        /// Add element to head position 
        /// </summary>
        /// <param name="s">input element</param>
        public void PushHead(T s)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// get and remove element on tail position
        /// </summary>
        /// <returns>element on tail position</returns>
        public T PopTail()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Show element without remove on tail position
        /// </summary>
        /// <returns>element on tail position</returns>
        public T PeekTail()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Additional functionality

        /// <summary>
        /// resize and copy data in new array
        /// </summary>
        /// <param name="scaleFactor"> grow factor of array</param>
        public void Resize(int scaleFactor = 2)
        {
            int newCount = Data.Length * scaleFactor;
            T[] buffer = this.ToArray();
            Array.Resize(ref buffer, newCount);
            Data = buffer;
            Head = 0;
            Tail = Count;
        }

        /// <summary>
        /// clear array and reset all pointers
        /// </summary>
        public void Clear()
        {
            Data = new T[Data.Length];
            Head = Tail = Count = 0;
        }

        /// <summary>
        /// indexator to the right access to the circle array
        /// </summary>
        /// <param name="index">index start count from head</param>
        /// <returns>element on this position</returns>
        public T this[int index] => Data[(Head + index) % Data.Length];

        #endregion

        #region IEnumerable implementation


        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator<T>(this);
        }
        #endregion

        /// <summary>
        /// Custom Enumerator for circle buffer
        /// </summary>
        private struct Enumerator<T> : IEnumerator<T>
        {
            private readonly CircleBuffer<T> queue;
            private int index;
            T CurrentElem;

            internal Enumerator(CircleBuffer<T> q)
            {
                queue = q;
                index = -1;
                CurrentElem = default(T);
            }

            public void Dispose()
            {
              
            }

            public bool MoveNext()
            {
                if (index == -2)
                {
                    return false;
                }

                index++;
                if (index == queue.Count)
                {
                    CurrentElem = default(T);
                    index = -2;
                    return false;

                }

                CurrentElem = queue[index];
                return true;
            }

            public T Current
            {
                get
                {
                    if (index < 0)
                    {
                        throw new InvalidOperationException();
                    }

                    return CurrentElem;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (index < 0)
                    {
                        throw new InvalidOperationException();
                    }

                    return CurrentElem;
                }
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }

    
}
