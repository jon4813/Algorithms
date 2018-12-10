using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    static class Trees
    {
        /// <summary>
        /// Прямой порядок
        /// </summary>
        /// <param name="root"></param>
        public static void TraversePreorder<T>(TreeNode<T> root) where T : IComparable<T>
        {
            Console.Write($"{root.Value} ->");
            if (root.LeftChild != null) TraversePreorder(root.LeftChild);
            if (root.RightChild != null) TraversePreorder(root.RightChild);
        }

        /// <summary>
        /// Симметричный порядок
        /// </summary>
        /// <param name="root"></param>
        public static void TraverseInorder<T>(TreeNode<T> root) where T : IComparable<T>
        {
            if (root.LeftChild != null) TraverseInorder(root.LeftChild);
            Console.Write($"{root.Value} ->");
            if (root.RightChild != null) TraverseInorder(root.RightChild);
        }

        /// <summary>
        /// Обратный порядок
        /// </summary>
        /// <param name="root"></param>
        public static void TraversePostorder<T>(TreeNode<T> root) where T : IComparable<T>
        {
            if (root.LeftChild != null) TraversePostorder(root.LeftChild);
            if (root.RightChild != null) TraversePostorder(root.RightChild);
            Console.Write($"{root.Value} ->");
        }

        /// <summary>
        /// Обход в ширину
        /// </summary>
        /// <param name="root"></param>
        public static void TraverseDepthFirst<T>(TreeNode<T> root) where T : IComparable<T>
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.Write($"{node.Value} ->");

                if (node.LeftChild != null) queue.Enqueue(node.LeftChild);
                if (node.RightChild != null) queue.Enqueue(node.RightChild);
            }
        }
    }

    public static class TreeServices
    {
        public static TreeNode<string> PrepareTree()
        {
            TreeNode<string> nodeD = new TreeNode<string> { Value = "D" };
            TreeNode<string> nodeB = new TreeNode<string> { Value = "B" };
            TreeNode<string> nodeE = new TreeNode<string> { Value = "E" };
            TreeNode<string> nodeA = new TreeNode<string> { Value = "A" };
            TreeNode<string> nodeC = new TreeNode<string> { Value = "C" };

            nodeD.LeftChild = nodeB;
            nodeD.RightChild = nodeE;

            nodeB.LeftChild = nodeA;
            nodeB.RightChild = nodeC;

            return nodeD;
        }
    }

    public class TreeNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightChild { get; set; }

        public static void DeleteNode(T value, TreeNode<T> root)
        {
            var (previous, current) = FindPrevious(value, root, null);

            if (previous == null && current == null)
                return;

            // терминальный узел (лист)
            if (current.LeftChild == null && current.RightChild == null)
            {
                DeleteNode(previous, current, null);
                return;
            }

            //если у текущего узла только один потомок
            if (current.RightChild == null && current.LeftChild != null)
            {
                DeleteNode(previous, current, current.LeftChild);
                return;
            }
            if (current.RightChild != null && current.LeftChild == null)
            {
                DeleteNode(previous, current, current.RightChild);
                return;
            }

            if (current.LeftChild.RightChild == null)
            {
                current.LeftChild.RightChild = current.RightChild;
                DeleteNode(previous, current, current.LeftChild);
                return;
            }

            var (mostRightPrev, mostRight) = FindMostRight(current.LeftChild, previous);

            if (mostRight.LeftChild == null)
            {
                mostRightPrev.RightChild = null;

                if (previous.LeftChild == mostRight)
                    previous.LeftChild = mostRight;
                else
                    previous.RightChild = mostRight;

                mostRight.LeftChild = current.LeftChild;
                mostRight.RightChild = current.RightChild;

            }
            else
            {
                mostRightPrev.RightChild = mostRight.LeftChild;
                if (previous.LeftChild == current)
                    previous.LeftChild = mostRight;
                else
                    previous.RightChild = mostRight;

                mostRight.LeftChild = current.LeftChild;
                mostRight.RightChild = current.RightChild;
            }
        }

        private static (TreeNode<T> previous, TreeNode<T> current) FindMostRight(TreeNode<T> current, TreeNode<T> previous)
        {
            if (current.RightChild == null)
                return (previous, current);

            return FindMostRight(current.RightChild, current);
        }

        private static void DeleteNode(TreeNode<T> previous, TreeNode<T> current, TreeNode<T> forReplace)
        {
            if (previous.LeftChild == current)
                previous.LeftChild = forReplace;
            else
                previous.RightChild = forReplace;
        }

        //public static (TreeNode<T> previous, TreeNode<T> current)? FindMostRight(T key, TreeNode<T> root, TreeNode<T> previous)
        //{
        //    if (root.RightChild == null)
        //    {
        //        if (previous.LeftChild == null)
        //            return (previous, root);
        //    }
        //}

        public static (TreeNode<T> previous, TreeNode<T> current) FindPrevious(T key, TreeNode<T> root, TreeNode<T> previous)
        {
            if (root == null)
                return (previous: null, current: null);
            if (key.CompareTo(root.Value) == 0) return (previous, root);

            if (key.CompareTo(root.Value) < 0)
            {
                return FindPrevious(key, root.LeftChild, root);
            }
            return FindPrevious(key, root.RightChild, root);
        }


        public TreeNode<T> Find(T key)
        {
            if (key.CompareTo(Value) == 0) return this;

            if (key.CompareTo(Value) < 0)
            {
                return LeftChild?.Find(key);
            }
            return RightChild?.Find(key);
        }

        public void AddNode(T value)
        {
            if (Value.CompareTo(value) > 0)
            {
                if (LeftChild == null) LeftChild = new TreeNode<T> { Value = value };
                else
                    LeftChild.AddNode(value);
            }
            else
            {
                if (RightChild == null) RightChild = new TreeNode<T> { Value = value };
                else RightChild.AddNode(value);
            }
        }
    }
}
