using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public enum Side
    {
        Left,
        Right
    }

    [Serializable]
    public class BinaryTree<T> : ICollection<T>, ICloneable where T : IComparable
    {
        [Serializable]
        public class Node
        {
            public T Data { get; set; }
            public Node? pLeft { get; set; }
            public Node? pRight { get; set; }

            public Node(T data)
            {
                Data = data;
                pLeft = null;
                pRight = null;
            }
        }

        public Node? root;
        public int Count { get; private set; }

        public readonly IComparer<T> comparer;

        public bool IsReadOnly => false;

        public BinaryTree(IComparer<T>? comparer = null)
        {
            Count = 0;
            root = null;
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public BinaryTree(IEnumerable<T> items, IComparer<T>? comparer = null) 
            : this(comparer)
        {
            Add(items);
        }

        public BinaryTree(BinaryTree<T> copyTree)
        {
            Count = copyTree.Count;
            comparer = copyTree.comparer;
            root = FullCopy(copyTree.root);
        }

        private Node? FullCopy(Node? item)
        {
            if (item == null)
                return null;

            Node copy = new Node(item.Data);
            copy.pLeft = FullCopy(item.pLeft);
            copy.pRight = FullCopy(item.pRight);

            return copy;
        }

        public virtual void Add(T item)
        {
            root = AddItem(root, item);
            Balance();
            Count++;
        }

        public virtual void Add(IEnumerable<T> collection)
        {
            foreach (var value in collection)
                Add(value);

            Balance();
        }

        private Node AddItem(Node? node, T item)
        {
            if (node == null)
                return new Node(item);

            else if (comparer.Compare(item, node.Data) == 0)
                throw new InvalidOperationException("Бинарное дерево не поддерживает добавление дубликатов данных.");

            else if (comparer.Compare(item, node.Data) < 0)
                node.pLeft = AddItem(node.pLeft, item);

            else if (comparer.Compare(item, node.Data) > 0)
                node.pRight = AddItem(node.pRight, item);

            return node;
        }

        public virtual void Clear()
        {
            Count = 0;
            root = null;
        }

        public bool Contains(T item)
        {
            return ContainsItem(root, item);
        }

        private bool ContainsItem(Node? node, T item)
        {
            if (node == null)
                return false;

            int comparisonResult = comparer.Compare(item, node.Data);

            if (comparisonResult == 0)
                return true;
            else if (comparisonResult < 0)
                return ContainsItem(node.pLeft, item);
            else
                return ContainsItem(node.pRight, item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            CopyToArray(root, array, arrayIndex);
        }

        private void CopyToArray(Node? node, T[] array, int index)
        {
            if (node != null)
            {
                CopyToArray(node.pLeft, array, index);
                array[index++] = node.Data;
                CopyToArray(node.pRight, array, index);
            }
        }
        public virtual bool Remove(T item)
        {
            int initialCount = Count;
            root = RemoveItem(root, item);
            return Count < initialCount;
        }

        private Node? RemoveItem(Node? node, T item)
        {
            if (node == null)
                return null;

            int comparisonResult = comparer.Compare(item, node.Data);  

            if (comparisonResult < 0)
                node.pLeft = RemoveItem(node.pLeft, item);

            else if (comparisonResult > 0)
                node.pRight = RemoveItem(node.pRight, item);

            else
            {
                if (node.pLeft == null)
                {
                    --Count;
                    return node.pRight;
                }

                else if (node.pRight == null)
                {
                    --Count;
                    return node.pLeft;
                }

                node.Data = GetMinValue(node.pRight);
                node.pRight = RemoveItem(node.pRight, node.Data);
            }
            return node;
        }

        public T? Find(T item)
        {
            Node? foundNode = FindNode(root, item);
            return foundNode != null ? foundNode.Data : default(T);
        }

        public Node? FindNode(Node? node, T item)
        {
            if (node == null || comparer.Compare(item, node.Data) == 0)
                return node;

            if (comparer.Compare(item, node.Data) < 0)
                return FindNode(node.pLeft, item);
            else
                return FindNode(node.pRight, item);
        }

        private T GetMinValue(Node node)
        {
            while (node.pLeft != null)
            {
                node = node.pLeft;
            }

            return node.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return LNR().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> LNR()
        {
            if (root != null)
            {
                Stack<Node> stack = new Stack<Node>();
                Node? current = root;

                while (stack.Count > 0 || current != null)
                {
                    while (current != null)
                    {
                        stack.Push(current);
                        current = current.pLeft;
                    }

                    current = stack.Pop();
                    yield return current.Data;

                    current = current.pRight;
                }
            }
        }

        public virtual void PrintTree()
        {
            PrintTree(root, 0);
        }

        private void PrintTree(Node? node, int level)
        {
            if (node == null)
                return;

            PrintTree(node.pLeft, level + 1);

            Console.WriteLine($"{new string(' ', level * 4)}{node.Data}");

            PrintTree(node.pRight, level + 1);
        }

        private string GetPrintTree(Node? startNode, string indent = "", Side? side = null, string row = "")
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";

                row = ($"{indent} [{nodeSide}]- {startNode.Data}\n");

                indent += new string(' ', 3);

                row += GetPrintTree(startNode.pLeft, indent, Side.Left, row);
                row += GetPrintTree(startNode.pRight, indent, Side.Right, row);

                return row;
            }
            return "";
        }

        public override string ToString() => Count == 0 ? "Дерево пустое" : GetPrintTree(root);

        public object Clone()
        {
            return new BinaryTree<T>(this);
        }

        public object ShallowCopy() => MemberwiseClone();

        #region Balance
        //Балансировка

        public void Balance()
        {
            root = BalanceNode(root);
        }

        private Node? BalanceNode(Node? node)
        {
            if (node == null)
                return null;

            node.pLeft = BalanceNode(node.pLeft);
            node.pRight = BalanceNode(node.pRight);

            int balanceFactor = GetBalanceFactor(node);


            if (balanceFactor > 1)
            {
                if (GetBalanceFactor(node.pLeft) >= 0)  
                {
                    return RotateRight(node); // левый левый поворт
                }
                else
                {
                    node.pLeft = RotateLeft(node.pLeft); // левый правый поворт
                    return RotateRight(node);
                }
            }
            else if (balanceFactor < -1)
            {
                if (GetBalanceFactor(node.pRight) <= 0)
                {
                    return RotateLeft(node); // правый правый
                }
                else
                {
                    node.pRight = RotateRight(node.pRight); // правый левый
                    return RotateLeft(node);
                }
            }

            return node;
        }

        private int GetHeight(Node? node)
        {
            if (node == null)
                return 0;
            return Math.Max(GetHeight(node.pLeft), GetHeight(node.pRight)) + 1;
        }

        private int GetBalanceFactor(Node? node)
        {
            if (node == null)
                return 0;
            return GetHeight(node.pLeft) - GetHeight(node.pRight);
        }

        private static Node? RotateRight(Node node)
        {
            var newRoot = node.pLeft;
            node.pLeft = newRoot.pRight;
            newRoot.pRight = node;
            return newRoot;
        }

        private static Node? RotateLeft(Node node)
        {
            var newRoot = node.pRight;
            node.pRight = newRoot.pLeft;
            newRoot.pLeft = node;
            return newRoot;
        }

        #endregion
    }
}
