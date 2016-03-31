using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CustomQueueTask3
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private T[] container;
        private int topRef = -1;
        private int defaultCapacity = 10;
        public int Count {
            get { return topRef + 1; }
        }
        public int Capacity { get; private set; }
        public CustomQueue(T[] arr)
        {
            if (ReferenceEquals(arr, null))
                throw new NullReferenceException();
            container = new T[arr.Length];
            this.Capacity = container.Length;
            arr.CopyTo(container, 0);
        }
        public CustomQueue()
        {
            container = new T[defaultCapacity];
            Capacity = container.Length;
        }
        public void Enqueue(T item)
        {
            if (ReferenceEquals(item, null))
                throw new NullReferenceException();
            if(Capacity == topRef+1)
            {
                Array.Resize<T>(ref container, Capacity * 2);
                Capacity = container.Length;
            }
            container[++topRef] = item;
        }
        public T Dequeue()
        {
            if(topRef == -1)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T item = container[0];
            ArrayShifting(container);
            topRef--;
            return item;
        }
        public T Peek()
        {
            if(topRef == -1)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return container[0];
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomIterator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        private struct CustomIterator : IEnumerator<T>
        {
            private readonly CustomQueue<T> queue;
            private int currentIndex;

            public CustomIterator(CustomQueue<T> queue)
            {
                if (ReferenceEquals(queue, null))
                    throw new NullReferenceException();
                this.queue = queue;
                currentIndex = -1;
            }
            public T Current
            {
                get
                {
                    if(currentIndex == -1 || currentIndex == queue.topRef + 1)
                    {
                        throw new InvalidOperationException();
                    }
                    return queue.container[currentIndex];
                }
            }
            object IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }
            public void Reset()
            {
                currentIndex = -1;
            }
            public bool MoveNext()
            {
                return ++currentIndex <= queue.topRef;
            }
            public void Dispose() { }
        }
        private void ArrayShifting(T[] array)
        {
            if (ReferenceEquals(array, null))
                throw new NullReferenceException();
            for(int i = 0;i<topRef;i++)
            {
                array[i] = array[i + 1];
            }
        }
    }
}
