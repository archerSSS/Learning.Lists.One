using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)   head = _item;
            else                tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }
        
        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            if (head == null) return false;
            Node present = head;
            Node previous = null;
            while (present != null)
            {
                if (head.value == _value)
                {
                    if (head == tail) tail = null;
                    head = head.next;
                    return true;
                }
                else if (present.value == _value)
                {
                    if (present.next == null) tail = previous;
                    present = present.next;
                    previous.next = present;
                    return true;
                }
                previous = present;
                present = present.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            Node present = head;
            Node previous = null;
            if (head == null) return;
            while (present != null)
            {
                if (head.value == _value)
                    head = head.next;
                else if (present.value == _value)
                {
                    present = present.next;
                    previous.next = present;
                    continue;
                }
                previous = present;
                present = present.next;
            }
            tail = previous;
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
            if (_nodeAfter != null && head != null)
            {
                if (_nodeAfter.next != null)
                    _nodeToInsert.next = _nodeAfter.next;
                else
                    tail = _nodeToInsert;
                _nodeAfter.next = _nodeToInsert;
            }
            else if (head == null)
            {
                head = _nodeToInsert;
                tail = _nodeToInsert;
            }
        }
    }
}
