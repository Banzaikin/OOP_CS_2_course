using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab_OOP_12
{
    public enum Side
    {
        LeftSide,
        RightSide
    }
    public class Node<T> 
        where T : IComparable, ICloneable
    {
        public Node(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }
        public override string ToString() => Data.ToString();
    }
    public class BinarySearchTree<T> : ICollection<T>, IEnumerable<T>, ICloneable
       where T : IComparable, ICloneable
    {
        public Node<T> RootNode { get; set; }
        //пустая коллекция 
        //пустая коллекция с емкостью capacity (для дерева емкость не имеет особого значения, т.к. зависит от специфики добавления)
        public BinarySearchTree(int capacity)
        {
            RootNode = null;
        }
        //коллекция, которая инициализируется элементами и емкостью коллекции
        public BinarySearchTree(IEnumerable<T> collection)
        {
            RootNode = null;
            AddRange(collection);
        }
        public BinarySearchTree(IComparer<T>? comparer)
        {
            this.Comparer = comparer ?? Comparer<T>.Default;
        }
        public BinarySearchTree() : this(Comparer<T>.Default)
        {
            RootNode = null;
        }
        public BinarySearchTree(BinarySearchTree<T> tree) : this(tree.Comparer)
        {
            if (tree.Count != 0)
            {
                this.RootNode = CloneNode(tree.RootNode);
                this.Count = tree.Count;
            }
        }
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public IComparer<T> Comparer { get; private set; }
        public virtual void Add(T data)
        {
            RootNode = Add(RootNode, data);
            Count++;
        }
        public virtual void AddRange(IEnumerable<T> collection)
        {
            foreach (var value in collection)
                Add(value);
        }
        public Node<T> Add(Node<T> currentNode, T data)
        {
            if (currentNode == null)
                return new Node<T>(data);
            try 
            {
                int result = Comparer.Compare(currentNode.Data, data);

                if (result == 0)
                    throw new Exception("Бинарное дерево не содержит дубликатов данных.");
                else if (result < 0)
                    currentNode.Left = Add(currentNode.Left, data);
                else if (result > 0)
                    currentNode.Right = Add(currentNode.Right, data);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}. Элемент не был добавлен в дерево!");
            }
            return currentNode;
        }

        public virtual bool Remove(T value)
        {
            Node<T> OrigRoot = RootNode;
            RootNode = RemoveRec(RootNode, value);
            return Equals(OrigRoot.Data, RootNode.Data);
        }

        private Node<T> RemoveRec(Node<T> node, T value)
        {
            if (node == null) return node;

            int comparison = Comparer.Compare(node.Data, value);
            if (comparison < 0)
            {
                node.Left = RemoveRec(node.Left, value);
            }
            else if (comparison > 0)
            {
                node.Right = RemoveRec(node.Right, value);
            }
            else
            {
                // Узел с одним потомком или без потомков
                if (node.Left == null)
                {
                    Count--;
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    Count--;
                    return node.Left;
                }
                // Узел с двумя потомками: получение наименьшего значения в правом поддереве
                node.Data = MinValue(node.Right);

                // Удаление наименьшего узла в правом поддереве
                node.Right = RemoveRec(node.Right, node.Data);
            }
            return node;
        }

        public T MinValue(Node<T> node)
        {
            T minValue = node.Data;
            while (node.Left != null)
            {
                minValue = node.Left.Data;
                node = node.Left;
            }
            return minValue;
        }
        public T Find(T item)
        {
            var itemNode = FindNode(item, RootNode);
            if (itemNode != null)
                return itemNode.Data;
            return default;
        }
        public Node<T> FindNode(T data, Node<T> startWithNode = null)
        {
            if (startWithNode == null)
                return null;
            int result = data.CompareTo(startWithNode.Data);
            if (result == 0)
                return startWithNode;
            else if (result < 0)
                return FindNode(data, startWithNode.Left);
            else
                return FindNode(data, startWithNode.Right);
        }
        public void Clear()
        {
            RootNode = null;
            Count = 0;
        }
        public object Clone()
        {
            return (object)new BinarySearchTree<T>(this);
        }
        public object ShallowCopy()
        {
            return (object)this.MemberwiseClone();
            //Метод MemberwiseClone создает неглубокую копию, создавая новый объект,
            // а затем копируя нестатические поля текущего объекта в новый объект 
        }

        private Node<T>? CloneNode(Node<T>? node)
        {
            if (node == null)
                return null;
            var clonedNode = new Node<T>((T)node.Data.Clone())
            {
                Left = CloneNode(node.Left),
                Right = CloneNode(node.Right)
            };
            return clonedNode;
        }
        public void PrintTree()
        {
            PrintTree(RootNode);
        }
        private void PrintTree(Node<T> startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.LeftSide ? "R" : "L";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");
                indent += new string(' ', 3);
                //рекурсивный вызов для левой и правой веток
                PrintTree(startNode.Left, indent, Side.LeftSide);
                PrintTree(startNode.Right, indent, Side.RightSide);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder(RootNode).GetEnumerator();
        }
        private IEnumerable<T> InOrder(Node<T>? node)
        {
            if (node != null)
            {
                foreach (var item in InOrder(node.Left))
                {
                    yield return item;
                }

                yield return node.Data;

                foreach (var item in InOrder(node.Right))
                {
                    yield return item;
                }
            }
        }
        public bool Contains(T item)
        {
            return !(FindNode(item, RootNode) is null);
        }
        public void CopyTo(T[]? array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Недостаточное пространство в целевом массиве.");
            }

            foreach (var value in this)
                array[arrayIndex++] = value;
        }
    }
}
