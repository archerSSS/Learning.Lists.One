using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }


        public void AddInTail(Node item)
        {
            if (head == null) head = item;
            else tail.next = item;
            tail = item;
        }

        public Node Find(int val)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == val) return node;
                node = node.next;
            }
            return null;
        }

        public bool Remove(int val)
        {
            Node present = head;
            Node previous = null;
            if (head == null) return false;
            while (present != null)
            {
                if (head.value == val)
                {
                    head = head.next;
                    return true;
                }
                else if (present.value == val)
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

        public void RemoveAll(int val)
        {
            Node present = head;
            Node previous = null;
            if (head == null) return;
            while (present != null)
            {
                if (head.value == val)
                    head = head.next;
                else if (present.value == val)
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

        public List<Node> FindAll(int val)
        {
            Node node = head;
            List<Node> nodes = new List<Node>();
            while (node != null)
            {
                if (node.value == val) nodes.Add(node);
                node = node.next;
            }
            return nodes;
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

        public void InsertAfter(int index, Node new_node)
        {
            Node node = head;
            for (int x = 0; x < Count(); x++)
            {
                if (x == index)
                {
                    new_node.next = node.next;
                    node.next = new_node;
                }
                if (node.next == null) tail = node;
                node = node.next;
            }
        }

        public LinkedList GetCombinedList(LinkedList l1, LinkedList l2)
        {
            LinkedList new_list = new LinkedList();
            Node firstNode = l1.head;
            Node secondNode = l2.head;

            if (l1.Count() == l2.Count())
            {
                for (int x = 0; x < l1.Count(); x++)
                {
                    new_list.AddInTail(new Node(firstNode.value + secondNode.value));
                    firstNode = firstNode.next;
                    secondNode = secondNode.next;
                }
                return new_list;
            }
            return null;
        }
    }
}
