using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Task02.Logic
{

    /// <summary>
    /// custom generic queue
    /// </summary>
    /// <typeparam name="T">type off elements in queue</typeparam>
    public class GenericQueue<T> : IEnumerable<T>
    {
        #region properties and fields

        /// <summary>
        /// sz array for data
        /// </summary>
        private T[] Data { get; set; }

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
        private int Count { get; set; }

        /// <summary>
        /// length of array
        /// </summary>
        private int Length => Data.Length;

        /// <summary>
        /// show array is full or not
        /// </summary>
        public bool IsFull => Count == Data.Length;

        private const int defaultCapacity = 4;

        #endregion

        #region Constructors defenition

        /// <summary>
        /// default constructor
        /// </summary>
        public GenericQueue() : this(0) { }

        /// <summary>
        /// constructor base on input capacity
        /// </summary>
        /// <param name="capacity">input capacity</param>
        public GenericQueue(int capacity = defaultCapacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity), "capacity of Queue must be non-negative");

            Data = new T[capacity];
            Head = Tail = Count = 0;
        }

        /// <summary>
        /// constructor based on input IEnumerable data
        /// </summary>
        /// <param name="collection">input data</param>
        public GenericQueue(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            Data = new T[collection.Count()];
            Head = Tail = Count = 0;
            foreach (T s in collection)
            {
                this.Enqueue(s);
            }
        }

        #endregion

        #region Queue methods 

        /// <summary>
        /// Add element to the tail of queue? if queue is full will resize queue
        /// </summary>
        /// <param name="item">input element</param>
        public void Enqueue(T item)
        {
            if (IsFull) Resize();

            if (Count < Data.Length && Equals(Data[Tail], default(T))) Count++;

            Data[Tail] = item;
            Tail = (++Tail) % Data.Length;
        }

        /// <summary>
        /// get and remove element from head of queue
        /// </summary>
        /// <returns>head elemen of queue</returns>
        public T Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException("array is empty");

            T removed = Data[Head];
            Data[Head] = default(T);
            Head = (++Head) % Data.Length;
            Count--;
            return removed;
        }

        /// <summary>
        /// show without remove head element in queue
        /// </summary>
        /// <returns>head element in queue</returns>
        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException("queue is empty");
            return Data[Head];
        }

        #endregion

        #region Additional Functionality

        /// <summary>
        /// clear queue
        /// </summary>
        public void Clear()
        {
            Data = new T[Data.Length];
            Head = Tail = Count = 0;
        }
        
        /// <summary>
        /// Resize data storage
        /// </summary>
        /// <param name="scaleFactor">scale factor for resize</param>
        private void Resize(int scaleFactor = 2)
        {
            int newCount = Data.Length * scaleFactor;
            T[] buffer = this.ToArray();
            Array.Resize(ref buffer, newCount);
            Data = buffer;
            Head = 0;
            Tail = Count;
        }

        /// <summary>
        /// indexator for work with circle buffer, start count from head
        /// </summary>
        /// <param name="index"> index from head</param>
        /// <returns>element on index position</returns>
        private T this[int index] => Data[(Head + index) % Data.Length];

        #endregion

        #region IEnumerable<T> implementation

        public IEnumerator<T> GetEnumerator() => new Enumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator() => new Enumerator<T>(this);

        #endregion

        /// <summary>
        /// custom enumerator for queue
        /// </summary>
        private struct Enumerator<T> : IEnumerator<T>
        {
            private readonly GenericQueue<T> queue;
            private int index;
            private T CurrentElem;

            internal Enumerator(GenericQueue<T> q)
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
