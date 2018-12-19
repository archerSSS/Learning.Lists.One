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

        public List<Node> FindAll(int _value)
        {
            List<Node> list = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                    list.Add(node);
                node = node.next;
            }
            return list;
        }

        public bool Remove(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node == head && node == tail)
                    {
                        head = null;
                        tail = null;
                        return true;
                    }
                    else if (node.prev == null)
                    {
                        head = head.next;
                        node.next.prev = node.prev;
                        return true;
                    }
                    else if (node.next == null)
                    {
                        tail = tail.prev;
                        node.prev.next = node.next;
                        return true;
                    }
                    else
                    {
                        node.prev.next = node.next;
                        node.next.prev = node.prev;
                        return true;
                    }
                }
                node = node.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node == head && node == tail)
                    {
                        head = null;
                        tail = null;
                        return;
                    }
                    else if (node.prev == null)
                    {
                        head = head.next;
                        node.next.prev = node.prev;
                    }
                    else if (node.next == null)
                    {
                        tail = tail.prev;
                        node.prev.next = node.next;
                    }
                    else
                    {
                        
                        node.prev.next = node.next;
                        node.next.prev = node.prev;
                    }
                }
                node = node.next;
            }
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

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            // Если новый узел не задан, то метод завершает работу.
            if (_nodeToInsert == null) return;
            // Если указанный узел пуст, то...
            if (_nodeAfter == null)
            {
                // Если список пуст, то... ставим новый элемент в начале списка
                if (head == null) head = _nodeToInsert;
                // Иначе вставляем нвоый элемент в конец списка
                else tail.next = _nodeToInsert;
                // Присваиваем tail новый элемент
                tail = _nodeToInsert;
                return;
            }
            // Иначе если next указанного узла отсутствует, то...
            else if (_nodeAfter.next == null)
            {
                // Задаем prev нового узла
                _nodeToInsert.prev = _nodeAfter;
                // Если указанный узел идентичен узлу tail, то задаем tail новый узел
                if (_nodeAfter == tail) tail = _nodeToInsert;
            }
            // Иначе...
            else
            {
                // Задаем next-узел после нового узла
                _nodeToInsert.next = _nodeAfter.next;
                // Задаем prev-узел перед новым узлом
                _nodeToInsert.prev = _nodeAfter;
                // Задаем prev-узел узла стоящего после нового узла
                _nodeAfter.next.prev = _nodeToInsert;
            }
            // Задаем next-узел после выбранного узла
            _nodeAfter.next = _nodeToInsert;
        }
    }
}
