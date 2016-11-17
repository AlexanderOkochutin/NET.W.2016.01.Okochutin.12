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
    public class GenericQueue<T> : IQueue<T>
    {
        /// <summary>
        /// data storage - circle buffer
        /// </summary>
        CircleBuffer<T> CircleArray;

        /// <summary>
        /// count of elemnts in queue 
        /// </summary>
        public int Count => CircleArray.Count;

        /// <summary>
        /// show queue is full or not
        /// </summary>
        private bool IsFull => CircleArray.IsFull;

        #region Constructors defenition

        /// <summary>
        /// default constructor
        /// </summary>
        public GenericQueue() : this(0) { }

        /// <summary>
        /// constructor base on input capacity
        /// </summary>
        /// <param name="capacity">input capacity</param>
        public GenericQueue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "capacity of Queue must be non-negative");
            }

            CircleArray = new CircleBuffer<T>(capacity);
        }

        /// <summary>
        /// constructor based on input IEnumerable data
        /// </summary>
        /// <param name="collection">input data</param>
        public GenericQueue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            CircleArray = new CircleBuffer<T>(collection.Count());
            foreach (T s in collection)
            {
                this.Enqueue(s);
            }
        }

        #endregion

        #region Iqueue implementation

        /// <summary>
        /// Add element to the tail of queue? if queue is full will resize queue
        /// </summary>
        /// <param name="item">input element</param>
        public void Enqueue(T item)
        {
            if (CircleArray.IsFull)
            {
                CircleArray.Resize();
            }

            CircleArray.PushTail(item);
        }
        
        /// <summary>
        /// get and remove element from head of queue
        /// </summary>
        /// <returns>head elemen of queue</returns>
        public T Dequeue() => CircleArray.PopHead();

        /// <summary>
        /// show without remove head element in queue
        /// </summary>
        /// <returns>head element in queue</returns>
        public T Peek() => CircleArray.PeekHead();

        #endregion

        #region Additional Functionality

        /// <summary>
        /// clear queue
        /// </summary>
        public void Clear() => CircleArray.Clear();

        #endregion

        #region IEnumerable<T> implementation

        public IEnumerator<T> GetEnumerator() => CircleArray.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => CircleArray.GetEnumerator();

        #endregion
    }
}
