using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class Services
    {
        public static void Shuffle(int[] mas)
        {
            var random = new Random(1);
            for (int i = 0; i < mas.Length; i++)
            {
                var tmpInd = random.Next(mas.Length);
                Swap(mas, i, tmpInd);
            }
        }

        public static void Swap(int[] mas, int i, int j)
        {
            var tmp = mas[i];
            mas[i] = mas[j];
            mas[j] = tmp;
        }

        public static int[] PrepareArray(int length)
        {
            int[] mas = new int[length];

            for (int i = 0; i < length; i++)
            {
                mas[i] = i;
            }

            return mas;
        }

        public static int[] PrepareRandomArray(int length, int max)
        {
            int[] mas = new int[length];
            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                mas[i] = random.Next(max);
            }

            return mas;
        }

        public static void PrintArray(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write($"{mas[i]},");
            }

            Console.WriteLine();
        }
    }
}
