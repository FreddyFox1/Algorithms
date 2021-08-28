using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{
    /// <summary>
    /// Binary Search is a searching algorithm for finding an element's position in a sorted array.
    /// In this approach, the element is always searched in the middle of a portion of an array.
    /// O(log2N)!
    /// Works only with sorted list
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var myList = new List<int> { 1, 3, 5, 7, 9 };
            Console.WriteLine(BinarySearch(myList, 3)); // => 1 index of number
            Console.WriteLine(BinarySearch(myList, -1)); // => null
            Console.WriteLine(BinarySearch(myList, 9)); // => 4 index of number
            Console.WriteLine(BinarySearch(myList, 5)); // => 2 index of number
        }

        private static int? BinarySearch(IList<int> list, int item)
        {
            var low = 0;
            var high = list.Count() - 1;

            while (low <= high)
            {
                var mid = (low + high) / 2;
                var guess = list[mid];
                
                if (guess == item) return mid;
                
                if (guess > item)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return null;
        }
    }
}
