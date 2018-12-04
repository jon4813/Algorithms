using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Lists
{
    public class SingleBoundList : IEnumerable<Item>
    {
        private readonly Item _bottom = new Item();
        private readonly Item _root = new Item();


        public SingleBoundList()
        {
            _bottom.Next = _root;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new SingleBoundEnumerator(_root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Item GetRoot()
        {
            return _root;
        }

        public Item AddLast(int value, Item next = null)
        {
            var item = new Item {Value = value};
            _bottom.Next.Next = item;
            _bottom.Next = item;
            if (next != null)
                item.Next = next;

            return item;
        }

        public Item AddFirst(int value)
        {
            var item = new Item {Next = _root.Next, Value = value};
            _root.Next = item;

            return item;
        }

        public void Print()
        {
            var next = _root.Next;
            while (next != null)
            {
                Console.Write($"-> {next.Value}");
                next = next.Next;
            }

            Console.WriteLine();
        }

        public void DeleteAfter(Item afterMe)
        {
            if (afterMe == null)
                return;
            if (afterMe.Next.Next == null)
            {
                afterMe.Next = null;
                _bottom.Next = afterMe;
            }

            if (afterMe.Next != null) afterMe.Next = afterMe.Next.Next;
        }

        public Item FindTheGreatest()
        {
            Item next;
            var biggest = next = _root.Next;
            while (next != null)
            {
                if (next.Value > biggest.Value)
                    biggest = next;
                next = next.Next;
            }

            return biggest;
        }
    }

    public class SingleBoundEnumerator : IEnumerator<Item>
    {
        private readonly Item _root;

        public SingleBoundEnumerator(Item root)
        {
            _root = root;
            Current = _root;
        }

        public bool MoveNext()
        {
            if (Current.Next == null)
                return false;
            Current = Current.Next;

            return true;
        }

        public void Reset()
        {
            Current = _root;
        }

        public Item Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Current = _root;
        }
    }

    public class Item
    {
        public int Value { get; set; }
        public Item Next { get; set; }
    }
}