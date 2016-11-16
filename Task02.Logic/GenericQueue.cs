using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Logic
{


    public class GenericQueue<T> : IQueue<T>
    {
        CircleBuffer<T> CircleArray;

        public int Count => CircleArray.Count;

        public bool IsFull => CircleArray.IsFull;

        #region Constructors defenition

        public GenericQueue() : this(0) { }

        public GenericQueue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "capacity of Queue must be non-negative");
            }

            CircleArray = new CircleBuffer<T>(capacity);
        }

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

        public void Enqueue(T item)
        {
            if (CircleArray.IsFull)
            {
                CircleArray.Resize();
            }

            CircleArray.PushTail(item);
        }

        public T Dequeue() => CircleArray.PopHead();

        public T Peek() => CircleArray.PeekHead();

        #endregion

        #region Additional Functionality

        public void Clear() => CircleArray.Clear();

        #endregion

        #region IEnumerable<string> implementation

        public IEnumerator<T> GetEnumerator() => CircleArray.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => CircleArray.GetEnumerator();

        #endregion
    }
}
