using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var testList = new List<int?>(10);
            testList.Add(7);
            testList.Add(6);
            testList.Add(5);
            testList.Add(4);
            testList.Add(3);
            testList.Add(2);
            testList.Add(1);

            Console.WriteLine("initial list:");
            testList.PrintList();
            
            testList.BuildMaxHeap();
            Console.WriteLine("after max heapifying:");
            testList.Add(8);
            testList.MaxHeapify(0);
            Console.WriteLine("after heapifying of 8");
            testList.PrintList();

            testList.BuildMinHeap();
            Console.WriteLine("after min heapifying:");
            testList.PrintList();
            
            testList.PrintList();
            Console.WriteLine(testList.DeleteTop());
            Console.WriteLine("after delete top:");
            testList.PrintList();
        }
    }
}