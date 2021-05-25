using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incassator
{
    class BinaryTree
    {
        private BinaryTreeNode _head;
        private int _count;
        public void add(int value)
        {
            if (_head == null)
            {
                _head = new BinaryTreeNode(value);
            }
            // Случай 2: Дерево не пустое => 
            // ищем правильное место для вставки.
            else
            {
                addTo(_head, value);
            }

            _count++;
        }

        private void addTo(BinaryTreeNode node, int value)
        {
            // Случай 1: Вставляемое значение меньше значения узла
            if (value < node.Value)
            {
                if (node.Left == null)
                    node.Left = new BinaryTreeNode(value);
                else
                    addTo(node.Left, value);
            }
            // Случай 2: Вставляемое значение больше или равно значению узла.
            else
            {
                if (node.Right == null)
                    node.Right = new BinaryTreeNode(value);
                else
                    addTo(node.Right, value);
            }
        }

        public int findMin()
        {
            int result = -1;
            BinaryTreeNode current = _head;
            while (current != null)
            {
                result = current.Value;
                current = current.Left;
            }
            return result;
        }

        public bool remove(int value)
        {
            BinaryTreeNode current, parent;
            current = findWithParent(value, out parent);

            if (current == null)
            {
                return false;
            }

            _count--;

            // Случай 1: Если нет детей справа, левый ребенок встает на место удаляемого.
            if (current.Right == null)
            {
                if (parent == null)
                {
                    _head = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // Если значение родителя больше текущего,
                        // левый ребенок текущего узла становится левым ребенком родителя.
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    { // Если значение родителя меньше текущего, // левый ребенок текущего узла становится правым ребенком родителя. 
                        parent.Right = current.Left;
                    }
                }
            }
            // Случай 2: Если у правого ребенка нет детей слева // то он занимает место удаляемого узла. 
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null)
                {
                    _head = current.Right;
                } else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // Если значение родителя больше текущего,
                        // правый ребенок текущего узла становится левым ребенком родителя.
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    { // Если значение родителя меньше текущего, // правый ребенок текущего узла становится правым ребенком родителя. 
                        parent.Right = current.Right; 
                    } 
                } 
            } 
            // Случай 3: Если у правого ребенка есть дети слева, крайний левый ребенок // из правого поддерева заменяет удаляемый узел. 
            else { 
                // Найдем крайний левый узел. 
                BinaryTreeNode leftmost = current.Right.Left; 
                BinaryTreeNode leftmostParent = current.Right; 
                while (leftmost.Left != null) 
                { 
                    leftmostParent = leftmost; 
                    leftmost = leftmost.Left; 
                } 
                // Левое поддерево родителя становится правым поддеревом крайнего левого узла. 
                leftmostParent.Left = leftmost.Right; 
                // Левый и правый ребенок текущего узла становится левым и правым ребенком крайнего левого. 
                leftmost.Left = current.Left; 
                leftmost.Right = current.Right;
                if (parent == null)
                {
                    _head = leftmost;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        // Если значение родителя больше текущего,
                        // крайний левый узел становится левым ребенком родителя.
                        parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        // Если значение родителя меньше текущего,
                        // крайний левый узел становится правым ребенком родителя.
                        parent.Right = leftmost;
                    }
                }

            }
            return true;
        }
        private BinaryTreeNode findWithParent(int value, out BinaryTreeNode parent)
        {
            BinaryTreeNode current = _head;
            parent = null;
            while (current != null)
            {
                int result = current.CompareTo(value);
                if (result > 0)
                {
                    // Если искомое значение меньше, идем налево.
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // Если искомое значение больше, идем направо.
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    // Если равны, то останавливаемся
                    break;
                }
            }

            return current;
        }
    }

    class BinaryTreeNode : IComparable<int>
    {
        public BinaryTreeNode(int value)
        {
            Value = value;
        }

        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        public int Value { get; private set; }

        /// 
        /// Сравнивает текущий узел с данным.
        /// 
        /// Сравнение производится по полю Value.
        /// Метод возвращает 1, если значение текущего узла больше,
        /// чем переданного методу, -1, если меньше и 0, если они равны

        public int CompareTo(int other)
        {
            return Value.CompareTo(other);
        }

        public override string ToString()
        {
            return Convert.ToString(Value);
        }
    }
}
