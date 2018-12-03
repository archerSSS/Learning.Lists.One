using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                    return node;
                node = node.next;
            }
            return null;
        }

        public bool Remove(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node.next != null && node.prev != null)
                    {
                        node = node.prev;
                        node.next = node.next.next;
                        node.next.prev = node;
                        return true;
                    }
                    else
                    {
                        if (node == head)
                        {
                            if (head.next == tail) tail.prev = null;
                            head = head.next;
                            //return true;
                        }
                        if (node == tail)
                        {
                            if (tail.prev == head) head.next = null;
                            tail = tail.prev;
                            //return true;
                        }
                    }

                    return true;
                }
                node = node.next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            Node node = head;
            int sum = 0;
            while (node != null)
            {
                sum++;
                node = node.next;
            }
            return sum;
        }

        public void InsertAfter(Node afterNode, Node newNode)
        {
            // Если есть узел после выбранного узла, то...
            if (afterNode.next != null)
            {
                // Задаем next-узел после нового узла
                newNode.next = afterNode.next;
                // Задаем prev-узел перед новым узлом
                newNode.prev = afterNode;
                // Задаем prev-узел узла стоящего после нового узла
                afterNode.next.prev = newNode;
            }
            else
            {
                // Задаем prev-узел нового узла
                newNode.prev = afterNode;
                // Задаем tail новый узел
                tail = newNode;
            }
            // Задаем next-узел после выбранного узла
            afterNode.next = newNode;
        }
    }
}
