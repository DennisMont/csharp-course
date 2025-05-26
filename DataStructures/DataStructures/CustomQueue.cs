using System.Collections;

namespace DataStructures
{
    // FIFO
    public class CustomQueue<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node? Next { get; set; } = null!;

            public Node(T value)
            {
                Value = value;
            }
        }

        private Node? _head;
        private Node? _tail;
        public int Count => _count;
        private int _count = 0;

        public void Enqueue(T item)
        {
            var newNode = new Node(item);

            if (_head == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                _tail!.Next = newNode;
                _tail = newNode;
            }
            
            _count++;
        }

        public T Dequeue()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T FirstItem = _head.Value;
            _head = _head.Next;
            _count--;

            return FirstItem;
        }

        public T Peek()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _head.Value;
        }

        public bool IsEmpty() => _count == 0;

        public T[] ToArray()
        {
            T[] array = new T[_count];
            int indexArray = 0;

            while (!IsEmpty())
            {
                array[indexArray] = Dequeue();
                indexArray++;
            }

            return array;
        }
    }
}
