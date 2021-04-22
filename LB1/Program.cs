using System;
using System.Collections.Generic;


namespace LB1
{

    // Tasks:
    // Outputing list
    // Creating list
    // Adding element to the list
    // Removing element from the list
    // List`s size
    // Searching elements in the list
    // Is list empty?
    // Union lists

    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    // LinkedList
    public class LinkedList<T> where T : IComparable
    {
        Node<T> head; // First element
        Node<T> last; // Last element
        int count;  // Amount of elements in the list

        // Add last
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (head == null)
                head = node;
            else
                last.Next = node;
            last = node;
            count++;
        }
        // Add sorted
        public void AddSorted(T data)
        {
            Node<T> node = new Node<T>(data);
            if (head == null)
            {
                head = node;
                count++;
            }
            else
            {
                Node<T> current = head;
                Node<T> prev = null;
                while (current != null)
                {
                    if (Comparer<T>.Default.Compare(current.Data, data) == 1)
                    {
                        if (prev == null)
                        {
                            node.Next = head;
                            head = node;
                            count++;
                        }
                        else
                        {
                            node.Next = prev.Next;
                            prev.Next = node;
                            count++;
                        }
                        break;
                    }
                    if (current.Next == null)
                    {
                        current.Next = new Node<T>(data);
                        count++;
                        break;
                    }
                    prev = current;
                    current = current.Next;
                }
            }
        }
        // Output of the list
        public void PrintList()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        // Remove the element
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // If node in the middle or in the end
                    if (previous != null)
                    {
                        // Remove node current, now previous refers not on current - on current.Next
                        previous.Next = current.Next;
                        // If current.Next isn't installed, so node is last, change variable last
                        if (current.Next == null)
                            last = previous;
                    }
                    else
                    {
                        // If the first element is removing than reinstall the "head"
                        head = head.Next;
                        // If after removing list is empty, reset "last"
                        if (head == null)
                            last = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        // Counting list`s size
        public int Count { get { return count; } }
        public bool isEmpty()
        {
            return (count == 0);
        }
        // If the list contains element
        public bool Contains(T data)    
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        // Union
        public LinkedList<T> Union(LinkedList<T> A)
        {
            LinkedList<T> list = new LinkedList<T>();
            Node<T> current = A.head;
            while (current != null)
            {
                if (!list.Contains(current.Data))
                    list.AddSorted(current.Data);
                current = current.Next;
            }
            current = head;
            while (current != null)
            {
                if (!list.Contains(current.Data))
                    list.AddSorted(current.Data);
                current = current.Next;
            }
            return list;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> link = new LinkedList<string>();

            Console.WriteLine("Sorted word-elements of the list:");
            // Adding some elements
            link.AddSorted("Alex");
            link.AddSorted("Djek");
            link.AddSorted("Bob");
            link.AddSorted("Doug");
            link.PrintList();
            Console.WriteLine();

            // Creating the list
            var list = new LinkedList<int>();

            Console.WriteLine("Sorted number-elements of the list:");
            // Adding an element to the list
            list.AddSorted(2);
            list.AddSorted(1);
            list.AddSorted(3);
            list.AddSorted(4);
            list.AddSorted(5);

            // Deleting an element from the list
            list.Remove(4);

            // Output of the list
            list.PrintList();

            // Search by list
            int snum = 5;
            Console.WriteLine("\nList contains number '" + snum + "'? - " + list.Contains(5));
            
            // Size of the list
            int num = list.Count;
            Console.WriteLine("\nSize of the list = " + num);

            // Union
            Console.WriteLine("\nUnion:");
            var list1 = new LinkedList<int>();
            list1.AddSorted(1);
            list1.AddSorted(2);
            list1.AddSorted(3);
            list1.AddSorted(4);                
            LinkedList<int> linkedList2 = list.Union(list1);
            linkedList2.PrintList();
            
            // Output if list is empty or not
            Console.WriteLine("\nThe list is empty? - " + list.isEmpty());
        }
    }
}