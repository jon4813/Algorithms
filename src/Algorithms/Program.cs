using System;
using System.Collections;
using Algorithms.Lists;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            GameAnimals game = new GameAnimals();
            game.GameStart();
            Console.ReadLine();
        }

        static void BlockSortTest()
        {
            var mas = Sorting.PrepareArray(100);
            Sorting.Shuffle(mas);

            Sorting.PrintArray(mas);
            Sorting.BlockSort(mas);

            Sorting.PrintArray(mas);
        }

        static void SelectionSortListTest()
        {
            var root = Sorting.PrepareList();
            Sorting.PrintList(root);

            var orderedRoot = Sorting.SelectionSortList(root);
            Sorting.PrintList(orderedRoot);
        }

        static void CountSortTest()
        {
            var mas = Sorting.PrepareRandomArray(20, 100);
            Sorting.Shuffle(mas);

            Sorting.PrintArray(mas);
            Sorting.CountSort(mas);

            Sorting.PrintArray(mas);
        }

        static void PyramidSortTest()
        {
            var mas = Sorting.PrepareArray(10);
            Sorting.Shuffle(mas);

            Sorting.PrintArray(mas);
            Sorting.PyramidSort(mas);

            Sorting.PrintArray(mas);
        }

        static void MergeSortTest()
        {
            var mas = Sorting.PrepareArray(10);
            Sorting.Shuffle(mas);

            Sorting.PrintArray(mas);
            Sorting.MergeSort(mas);

            Sorting.PrintArray(mas);
        }

        static void QSortTest()
        {
            var mas = Sorting.PrepareArray(10);
            Sorting.Shuffle(mas);

            Sorting.PrintArray(mas);
            Sorting.QSort(mas);

            Sorting.PrintArray(mas);
        }

        static void RabbitTurtle()
        {
            SingleBoundList list = new SingleBoundList();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            var item = list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);
            list.AddLast(8, item);

            RabbitAndTurtle rt = new RabbitAndTurtle(list.GetRoot());
            var c = rt.FindCicleItem();

            Console.WriteLine(c.Value);
        }

        static void SingleBoundList()
        {
            SingleBoundList list = new SingleBoundList();
            Item last = null;
            for (int i = 0; i < 10; i++)
            {
                if (i == 8)
                    last = list.AddLast(i);
                else
                    list.AddLast(i);
            }

            list.Print();

            list.AddFirst(100);

            list.Print();

            list.DeleteAfter(last);
            list.Print();

            Console.WriteLine($"Gratest: {list.FindTheGreatest().Value}");

        }

        static void SortingTest()
        {
            var length = 10;
            var mas = Sorting.PrepareArray(length);
            Sorting.Shuffle(mas);
            Sorting.PrintArray(mas);
            Console.WriteLine("SelectionSort");
            Sorting.SelectionSort(mas);
            Sorting.PrintArray(mas);
        }


    }
}
