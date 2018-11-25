using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTwo
{
    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node item)
        {
            if (head == null)
            {
                head = item;
                item.prev = null;
                item.next = null;
            }
            else
            {
                tail.next = item;
                item.prev = tail;
            }
            tail = item;
        }

        public Node Find(int val)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == val)
                    return node;
                node = node.next;
            }
            return null;
        }

        public void Delete(int val)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == val)
                {
                    if (node.next == null)
                        tail = node.prev;
                    if (node.prev != null)
                        node.prev.next = node.next;
                    else
                        head = head.next;
                    return;
                }
                node = node.next;
            }
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

        public void AddInHead(Node newHead)
        {
            if (head == null)
            {
                head = newHead;
                tail = newHead;
            }
            newHead.next = head;
            head = newHead;
        }
    }
}
