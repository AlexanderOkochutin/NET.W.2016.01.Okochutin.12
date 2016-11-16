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
        public int Count { get; private set; }
        public int Length => Data.Length;
        public bool IsFull => Count == Data.Length;
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

        public void PushTail(T s)
        {/*
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }*/
            if (Count < Data.Length && Equals(Data[Tail],default(T)))
            {
                Count++;
            }

            Data[Tail] = s;
            Tail = (++Tail) % Data.Length;
        }

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

        public T PeekHead()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("queue is empty");
            }
            return Data[Head];
        }

        public void PushHead(T s)
        {
            throw new NotImplementedException();
        }

        public T PopTail()
        {
            throw new NotImplementedException();
        }

        public T PeekTail()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Additional functionality

        public void Resize(int scaleFactor = 2)
        {
            int newCount = Data.Length * scaleFactor;
            T[] buffer = this.ToArray();
            Array.Resize(ref buffer, newCount);
            Data = buffer;
            Head = 0;
            Tail = Count;
        }

        public void Clear()
        {
            Data = new T[Data.Length];
            Head = Tail = Count = 0;
        }

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
                //throw new NotImplementedException();
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
