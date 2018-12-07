using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class Search
    {
        public static void BinarySearch(int[] mas, int val)
        {
            int min = 0;
            int max = mas.Length - 1;
            int delpth = 0;
            while (min <= max)
            {
                delpth++;
                int mid = (min + max) / 2;
                if (mid > val)
                    max = mid - 1;
                else if (mid < val)
                    min = mid + 1;
                else
                {
                    Console.WriteLine($"Found! Delpth: {delpth} ");
                    break;
                }
            }
        }

        public static void BinarySearchRecursive(int[] mas, int val)
        {
            int delpth = 0;
            BinarySearchRecursiveInternal(mas, 0, mas.Length - 1, val,ref  delpth);
        }
        private static void BinarySearchRecursiveInternal(int[] mas, int min, int max, int val, ref int delpth)
        {                        
            delpth++;
            int mid = (min + max) / 2;
            if (mid > val)            
                max = mid - 1;                            
            else if (mid < val)
                min = mid + 1;
            else
            {
                Console.WriteLine($"Found! Delpth: {delpth} ");
                return;
            }

            BinarySearchRecursiveInternal(mas, min, max, val, ref delpth);
        }

        public static void InterpollarSearch(int[] mas, int val)
        {
            int min = 0;
            int max = mas.Length - 1;
            int delpth = 0;
            while (min <= max)
            {
                delpth++;
                int mid = min + (max - min) * (val - mas[min]) / (mas[max] - mas[min]);

                if (mas[mid] == val)
                {
                    Console.WriteLine($"Found! Delpth: {delpth} ");
                    break;
                }

                if (mid > val)
                    max = mid - 1;
                else
                    min = mid + 1;
            }
        }
    }
}
