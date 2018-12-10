using System;
using Generics = System.Collections.Generic;

namespace Algorithms
{
    public class TwoTreeTrees<T> where T : struct, IComparable<T>
    {
        public void CreateTree(int count)
        {
            for (int i = 0; i < count; i++)
            {

            }
        }

        public void AddNode(TwoTreeNode<T> root, T value)
        {

            if (!root.Values[0].HasValue)
            {
                root.Values[0] = value;
            }

            if (root.Values[0].HasValue && !root.Values[1].HasValue)
            {
                if (value.CompareTo(root.Values[0].Value) < 0)
                {
                    AddNode(root.LeftNode, value);
                }
                else
                {
                    AddNode(root.RightNode, value);
                }
            }

            if (root.Values[0].HasValue && root.Values[1].HasValue)
            {

            }

            if (!root.Values[0].HasValue)
            {
                root.Values[0] = value;
                return;
            }

            if (value.CompareTo(root.Values[0].Value) >= 0)
            {

            }

            for (int i = 0; i < root.Values.Length; i++)
            {                
            }
        }
    }

    public class TwoTreeNode<T> where T : struct, IComparable<T>
    {
        public TwoTreeNode<T> LeftNode { get; set; }
        public TwoTreeNode<T> MiddleNode { get; set; }
        public TwoTreeNode<T> RightNode { get; set; }
        public TwoTreeNode<T> ParentNode { get; set; }
        public T?[] Values { get; } = new T?[2];
    }
}