using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3
{
    public class List<T> : IComparer<T>
    {
        public int Compare(T a, T b)
        {
            return Comparer.Default.Compare(a, b);
        }
        
        private readonly int _capacity;
        private T[] _array;
        public int Size { get; set; } 

        public List(int n)
        {
            _capacity = n;
            _array = new T[_capacity];
        }

        public bool Add(T item)
        {
            if (IsFull())
            {
                return false;
            }
            _array[Size++] = item;
            return true;
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public bool IsFull()
        {
            return _capacity == Size;
        }
        
        public void PrintList()
        {
            for (var i = 0; i < Size; i++)
            {
                Console.Write(_array[i] + " ");
            }
            Console.WriteLine();
        }

        public void HeapSort()
        {
            int initSize = Size;
            BuildMaxHeap();
            for (int i = Size - 1; i >= 0; i--)
            {
                Swap(0, i);
                Size--;
                MaxHeapify(0);
            }

            Size = initSize;
        }
        
        // 13
        public T DeleteTop()
        {
            _array[0] = _array[--Size];
            MaxHeapify(0);
            ++Size;
            for (int i = Size - 2; i >= 0; i--)
            {
                _array[i + 1] = _array[i];
            }
            _array[0] = default(T);
            
            return _array[1];
        }
        
        public void BuildMaxHeap()
        {
            for (int i = (Size - 1) / 2; i >= 0; i--)
            {
                MaxHeapify(i);
            }
        }

        public void MaxHeapify(int node)
        {
            int largest = node;
            int left = node * 2 + 1;
            int right = node * 2 + 2;
            
            // left > node
            if (left < Size && Compare(_array[left], _array[largest]) > 0)
            {
                largest = left;
            }
            
            // right > node
            if (right < Size && Compare(_array[right], _array[largest]) > 0)
            {
                largest = right;
            }
            
            // If smallest is not parent 
            if (largest != node)
            { 
                Swap(node, largest); 

                // Recursively heapify the affected sub-tree 
                MaxHeapify(largest); 
            }
        }
        
        public void BuildMinHeap()
        {
            for (int i = (Size - 2) / 2; i >= 0; i--)
            {
                MinHeapify(i);
            }
        }
        
        private void MinHeapify(int node)
        {
            int smallest = node;
            int left = 2 * node + 1;
            int right = 2 * node + 2;
            
            // left < node
            if (left < Size && Compare(_array[left], _array[smallest]) < 0)
            {
                smallest = left;
            }
            
            // right < node
            if (right < Size && Compare(_array[right], _array[smallest]) < 0)
            {
                smallest = right;
            }
            
            // If smallest is not parent 
            if (smallest != node)
            { 
                Swap(node, smallest); 

                // Recursively heapify the affected sub-tree
                MinHeapify(smallest);
            }
        }

        private void Swap(int i1, int i2)
        {
            T temp = _array[i1];
            _array[i1] = _array[i2];
            _array[i2] = temp;
        }
    }
}