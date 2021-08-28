using System;
using System.Collections.Generic;

namespace SelectionSort
{
    /// <summary>
    /// Selection sort is a sorting algorithm that selects the smallest 
    /// element from an unsorted list in each iteration and places that 
    /// element at the beginning of the unsorted list.
    /// O(n^2)
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var arr = new List<int> { 5, 3, 6, 2, 10 };
            Console.WriteLine("Array: "+ string.Join(" ", arr));
            Console.WriteLine("Sorted array: " + string.Join(" ", SelectionSort(arr)));
        }

        private static int[] SelectionSort(List<int> arr)
        {
            var newArr = new int[arr.Count];
            for (int i = 0; i < newArr.Length; i++)
            {
                var low = FindLow(arr);
                newArr[i] = arr[low];
                arr.RemoveAt(low);
            }
            return newArr;
        }

        private static int FindLow(List<int> arr)
        {
            var low = arr[0];
            var lowIndex = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] < low)
                {
                    low = arr[i];
                    lowIndex = i;
                }
            }
            return lowIndex;
        }
    }
}
