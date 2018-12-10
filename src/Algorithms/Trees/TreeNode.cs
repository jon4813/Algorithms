using System;

namespace Algorithms
{
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
