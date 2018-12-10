using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using Algorithms.Lists;

namespace Algorithms
{
    public static class Sorting
    {
        //в сортировке вставками мы извлекаем из неотсортированной части массива любой элемент и вставляем его на своё место в отсортированной части,
        //мы ищем куда вставить очередной элемент
        public static void InsertionSort(int[] mas)
        {
            for (int i = 1; i < mas.Length; i++)
            {
                for (int j = i; j > 0 && mas[j] < mas[j - 1]; j--)
                {
                    Services.Swap(mas, j, j - 1);
                    Console.Write($"{i}: ");
                    Services.PrintArray(mas);
                }
            }
        }

        public static void BubbleSort(int[] mas)
        {
            for (var i = 0; i < mas.Length; i++)
            {
                for (var j = 0; j < mas.Length - 1; j++)
                {
                    if (mas[j] > mas[j + 1])
                    {
                        Services.Swap(mas, j, j + 1);
                        Console.Write($"{i}: ");
                        Services.PrintArray(mas);
                    }
                }
            }
        }
        //в сортировке выбором мы целенаправленно ищем максимальный элемент (или минимальный), которым дополняем отсортированную часть массива,
        //мы заранее уже знаем в какое место поставим, но при этом требуется найти элемент, этому месту соответствующий
        public static void SelectionSort(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                var k = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[k])
                    {
                        k = j;
                    }
                }

                Services.Swap(mas, i, k);
            }
        }

        public static void BlockSort(int[] mas)
        {
            var m = 10;
            var blockCount = mas.Length / m;

            CustomListItem[] blocks = new CustomListItem[blockCount];
            for (int i = 0; i < blockCount; i++)
            {
                blocks[i] = new CustomListItem();
            }

            for (var i = 0; i < mas.Length; i++)
            {
                int blockNo = (mas[i] / blockCount);

                CustomListItem item = new CustomListItem
                {
                    Value = mas[i],
                    Next = blocks[blockNo].Next
                };
                blocks[blockNo].Next = item;
            }

            PrintArrayOfList(blocks);

            for (int i = 0; i < blockCount; i++)
            {
                blocks[i] = SelectionSortList(blocks[i]);
            }

            PrintArrayOfList(blocks);

            var index = 0;
            for (int j = 0; j < blockCount; j++)
            {
                while (blocks[j].Next != null)
                {
                    mas[(j * m) + index] = blocks[j].Next.Value;
                    blocks[j] = blocks[j].Next;
                    index++;
                }

                index = 0;
            }

        }

        public static void PrintArrayOfList(CustomListItem[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                PrintList(mas[i]);
            }
        }

        //Сортировка подсчётом
        public static void CountSort(int[] mas)
        {
            int[] count = new int[mas.Max()+ 1];

            for (int i = 0; i < mas.Length; i++)
            {
                count[mas[i]]++;
            }

            var index = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    mas[index] = i;
                    index++;
                }
            }
        }

        public static void PyramidSort(int[] mas)
        {
            MakeHeap(mas);
            Console.Write("Heap: ");
            Services.PrintArray(mas);

            for (int i = mas.Length - 1; i >= 0; i--)
            {
                Services.Swap(mas, 0, i);
                var index = 0;
                var count = i;
                while (true)
                {
                    var child1 = 2 * index + 1;
                    var child2 = 2 * index + 2;

                    if (child1 >= count) child1 = index;
                    if (child2 >= count) child2 = index;

                    if ((mas[index] >= mas[child1]) && (mas[index] >= mas[child2]))
                        break;

                    var swapChild = mas[child1] > mas[child2] ? child1 : child2;

                    Services.Swap(mas, index, swapChild);

                    index = swapChild;
                }
            }
        }

        public static void MakeHeap(int[]mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                var index = i;
                while (index != 0)
                {
                    var parent = (index - 1) / 2;
                    if (mas[index] <= mas[parent])
                        break;

                    Services.Swap(mas, parent, index);
                    index = parent;
                }
            }
        }

        public static void MergeSort(int[] mas)
        {
            int[] buffer = new int[mas.Length];
            MergeSortInternal(mas, buffer, 0, mas.Length - 1);
        }

        private static void MergeSortInternal(int[] mas, int[] buffer, int start, int end)
        {
            if (start >= end)
                return;
            var middle = (start + end) / 2;
            MergeSortInternal(mas,buffer, start, middle);
            MergeSortInternal(mas, buffer, middle + 1, end);

            var index = start;
            var rightIndex = middle + 1;
            var bufferIndex = start;

            while (index <= middle && rightIndex <= end)
            {
                if (mas[index] <= mas[rightIndex])
                {
                    buffer[bufferIndex] = mas[index];
                    index++;
                }
                else
                {
                    buffer[bufferIndex] = mas[rightIndex];
                    rightIndex++;
                }
                bufferIndex++;
            }

            for (int i = index; i <= middle; i++)
            {
                buffer[bufferIndex] = mas[i];
                bufferIndex++;
            }

            for (int i = rightIndex; i <= end; i++)
            {
                buffer[bufferIndex] = mas[i];
                bufferIndex++;
            }

            for (int i = start; i <= end; i++)
            {
                mas[i] = buffer[i];
            }
        }


        public static void PrintList(CustomListItem root)
        {
            var tmp = root.Next;
            while (tmp != null)
            {
                Console.Write($"{tmp.Value} -> ");
                tmp = tmp.Next;
            }

            Console.WriteLine();
        }

        public static CustomListItem PrepareList(int length = 10, bool isRandom = false)
        {
            var root = new CustomListItem();
            var head = root;

            var r = new Random();

            for (int i = length - 1; i >= 0; i--)
            {
                var value = i;
                if (isRandom)
                    value = r.Next(length);
                head.Next = new CustomListItem() { Value = value };
                head = head.Next;
            }

            return root;
        }

        public class CustomListItem
        {
            public int Value { get; set; }
            public CustomListItem Next { get; set; }
        }

        public static CustomListItem SelectionSortList(CustomListItem root)
        {
            //указатель на посл элемент сортированной последовательности
            CustomListItem newRoot = new CustomListItem();

            while (root.Next != null)
            {
                var bestAfterMe = root;
                var bestValue = bestAfterMe.Next.Value;
                var afterMe = root.Next;
                while (afterMe.Next != null)
                {
                    if (afterMe.Next.Value > bestValue)
                    {
                        bestAfterMe = afterMe;
                        bestValue = afterMe.Next.Value;
                    }
                    afterMe = afterMe.Next;
                }

                var bestCell = bestAfterMe.Next;
                bestAfterMe.Next = bestCell.Next;

                bestCell.Next = newRoot.Next;
                newRoot.Next = bestCell;
            }

            return newRoot;
        }

        public static void QSort(int[] mas)
        {
            QSortInternal(mas, 0, mas.Length - 1);
        }

        private static void QSortInternal(int[] mas, int start, int end)
        {
            if (start >= end)
                return;

            var middle = Partition(mas, start, end);

            QSortInternal(mas, start, middle - 1);
            QSortInternal(mas, middle + 1, end);
        }

        private static int Partition(int[] mas, int start, int end)
        {
            int middle = (start + end) / 2;

            var pivot = mas[middle];
            while (start < end)
            {
                while (mas[start] < pivot)
                {
                    start++;
                }

                while (mas[end] > pivot)
                {
                    end--;
                }

                Services.Swap(mas, start, end);
                if (mas[start] < pivot)
                    start++;
                if (mas[end] > pivot)
                    end--;
            }

            return start;
        }

        #region Infrastructure
        

        #endregion
    }
}
