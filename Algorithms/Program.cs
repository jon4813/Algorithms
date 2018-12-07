using System;
using System.Collections;
using Algorithms.Lists;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            AddTreeNodeTest();
            Console.ReadLine();
        }


        #region Trees

        static void AddTreeNodeTest()
        {
            TreeNode<string> root = new TreeNode<string> {Value = "C"};
            root.AddNode("B");
            root.AddNode("A");
            root.AddNode("D");
            root.AddNode("E");

            Trees.TraverseInorder(root);
        }

        static void TraversePreorderTest()
        {
            TreeNode<string> root = TreeServices.PrepareTree();
            Console.WriteLine("Прямой");
            Trees.TraversePreorder(root);
            Console.WriteLine();
            Console.WriteLine("Симметричный");
            Trees.TraverseInorder(root);
            Console.WriteLine();
            Console.WriteLine("Обратный");
            Trees.TraversePostorder(root);

            Console.WriteLine();
            Console.WriteLine("Обход в ширину");
            Trees.TraverseDepthFirst(root);
        }
#endregion

        #region Search
        static void BinarySearchTest()
        {
            Search.BinarySearchRecursive(Services.PrepareArray(50), 45);
            Search.InterpollarSearch(Services.PrepareArray(50),45);
            Search.BinarySearch(Services.PrepareArray(50), 45);
        }

        #endregion

        #region Sort
        static void BlockSortTest()
        {
            var mas = Services.PrepareArray(100);
            Services.Shuffle(mas);

            Services.PrintArray(mas);
            Sorting.BlockSort(mas);

            Services.PrintArray(mas);
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
            var mas = Services.PrepareRandomArray(20, 100);
            Services.Shuffle(mas);

            Services.PrintArray(mas);
            Sorting.CountSort(mas);

            Services.PrintArray(mas);
        }

        static void PyramidSortTest()
        {
            var mas = Services.PrepareArray(10);
            Services.Shuffle(mas);

            Services.PrintArray(mas);
            Sorting.PyramidSort(mas);

            Services.PrintArray(mas);
        }

        static void MergeSortTest()
        {
            var mas = Services.PrepareArray(10);
            Services.Shuffle(mas);

            Services.PrintArray(mas);
            Sorting.MergeSort(mas);

            Services.PrintArray(mas);
        }

        static void QSortTest()
        {
            var mas = Services.PrepareArray(10);
            Services.Shuffle(mas);

            Services.PrintArray(mas);
            Sorting.QSort(mas);

            Services.PrintArray(mas);
        }

        static void SortingTest()
        {
            var length = 10;
            var mas = Services.PrepareArray(length);
            Services.Shuffle(mas);
            Services.PrintArray(mas);
            Console.WriteLine("SelectionSort");
            Sorting.SelectionSort(mas);
            Services.PrintArray(mas);
        }

        #endregion

        #region Lists
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

#endregion

    }
}
