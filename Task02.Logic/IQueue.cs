using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Logic
{
    /// <summary>
    /// Interface for custom generic queue(FIFO)
    /// </summary>
    /// <typeparam name="T">parameter of type</typeparam>
    public interface IQueue<T> : IEnumerable<T>
    {
        /// <summary>
        /// put element into  tail of queue
        /// </summary>
        /// <param name="s"></param>
        void Enqueue(T s);

        /// <summary>
        /// take element from Head of queue
        /// </summary>
        /// <returns>first element</returns>
        T Dequeue();

        /// <summary>
        /// show element in Head of queue
        /// </summary>
        /// <returns>first element</returns>
        T Peek();
    }
}
