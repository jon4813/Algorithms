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
}
