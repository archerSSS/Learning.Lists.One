using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFindAll_A()
        {
            LinkedList2 l = new LinkedList2();
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(1));

            Node node1 = l.Find(1);
            Node node2 = node1.next.next;
            Node node3 = node2.next.next;

            List<Node> list = l.FindAll(1);
            
            Assert.AreEqual(node1, list[0]);
            Assert.AreEqual(node2, list[0].next);
            Assert.AreEqual(node2, list[1]);
            Assert.AreEqual(node1, list[1].prev);
            Assert.AreEqual(node3, list[2]);
            Assert.AreEqual(null, list[2].next);
        }

        [TestMethod]
        public void TestRemove_A()
        {
            // after first remove, value expected in prev of founded node
            // after second remove, value expected in prev of tail
            int expected1 = 1;
            // after first remove, value expected in prev of tail and next of head
            int expected3 = 3;
            // after first remove, value expected in next of founded node
            // after second remove, value expected in next of head
            int expected4 = 4;

            LinkedList2 l = new LinkedList2();
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(3));
            l.AddInTail(new Node(4));
            Node founded = l.Find(3);

            l.Remove(2);

            Assert.AreEqual(expected3, l.head.next.value);
            Assert.AreEqual(expected3, l.tail.prev.value);
            Assert.AreEqual(expected1, founded.prev.value);
            Assert.AreEqual(expected4, founded.next.value);

            l.Remove(3);

            Assert.AreEqual(expected1, l.tail.prev.value);
            Assert.AreEqual(expected4, l.head.next.value);
            Assert.AreEqual(null, l.tail.prev.prev);
            Assert.AreEqual(null, l.head.next.next);

            l.Remove(4);

            Assert.AreEqual(expected1, l.tail.value);
            Assert.AreEqual(expected1, l.head.value);
        }

        [TestMethod]
        public void TestRemove_B()
        {
            // after remove, value expected in next of founded node
            int expected4 = 4;

            LinkedList2 l = new LinkedList2();
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(3));
            l.AddInTail(new Node(4));
            Node founded = l.Find(2);

            l.Remove(3);

            Assert.AreEqual(expected4, founded.next.value);

            l.Remove(4);

            Assert.AreEqual(null, founded.next);
        }

        [TestMethod]
        public void TestRemove_C()
        {
            //value expected in prev node of tail after second delete
            int expected1 = 1;
            //value expected in node next to head after first delete
            //value expected in head after second delete
            int expected2 = 2;
            //value expected in tail after first delete
            int expected3 = 3;

            LinkedList2 l = new LinkedList2();
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(3));
            Node node = l.Find(2);

            l.Remove(2);
            
            Assert.AreEqual(expected3, l.head.next.value);
            Assert.AreEqual(expected1, l.tail.prev.value);
            Assert.AreEqual(expected1, node.prev.value);
            
            Console.WriteLine(l.head.next.value);
            
            l.Remove(3);

            Assert.AreEqual(expected1, l.head.value);
            Assert.AreEqual(expected1, l.tail.value);
            Assert.AreEqual(null, l.head.next);
            Assert.AreEqual(null, l.tail.prev);

            
        }

        [TestMethod]
        public void TestRemove_D()
        {
            // после удаления, ожидаемое значение 1-го узла
            int expected1 = 1;

            // после удаления, ожидаемое значение next'а узла head
            // prev 4-го узла отсчет от head
            // prev узла tail
            int expected2 = 2;

            // после удаления, ожидаемое значение 4-го узла отсчет от head
            // узла tail
            // next 2-го узла отсчет от tail
            int expected4 = 4;

            LinkedList2 l = new LinkedList2();
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(3));
            l.AddInTail(new Node(4));
            l.Remove(3);
            Assert.AreEqual(expected1, l.head.value);
            Assert.AreEqual(expected2, l.head.next.value);
            Assert.AreEqual(expected4, l.head.next.next.value);
            Assert.AreEqual(expected2, l.head.next.next.prev.value);
            Assert.AreEqual(expected4, l.tail.value);
            Assert.AreEqual(expected4, l.tail.prev.next.value);
            Assert.AreEqual(expected2, l.tail.prev.value);
            Assert.AreEqual(null, l.tail.prev.next.next);
        }

        [TestMethod]
        public void TestRemoveAll_A()
        {
            // value expected in prev of tail
            int expected1 = 1;
            // value expected in next of head
            int expected5 = 5;

            LinkedList2 l = new LinkedList2();
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(3));
            l.AddInTail(new Node(3));
            l.AddInTail(new Node(5));

            l.RemoveAll(3);

            Assert.AreEqual(expected1, l.tail.prev.value);
            Assert.AreEqual(expected5, l.head.next.value);
        }

        [TestMethod]
        public void TestRemoveAll_B()
        {
            // value expected in head, next of head, tail, prev of tail
            int expected2 = 2;

            LinkedList2 l = new LinkedList2();
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(1));

            l.RemoveAll(1);

            Assert.AreEqual(expected2, l.head.value);
            Assert.AreEqual(expected2, l.head.next.value);
            Assert.AreEqual(expected2, l.tail.value);
            Assert.AreEqual(expected2, l.tail.prev.value);
        }

        [TestMethod]
        public void TestRemoveAll_C()
        {
            LinkedList2 l = new LinkedList2();
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(1));

            l.RemoveAll(1);

            Assert.AreEqual(null, l.head);
            Assert.AreEqual(null, l.tail);
        }

        [TestMethod]
        public void TestInsertAfter_A()
        {
            // Ожидаемое значение в найденом узле -- второй в списке
            int expectedNode = 2;

            // Ожидаемое значение в новом узле -- третий в списке после метода AddNextTo()
            int expectedNew = 3;

            // Ожидаемое значение в узле -- в списке третий до метода AddNextTo() и четвертый после
            int expectedNext = 4;

            // Создает новый узел
            Node newNode = new Node(3);

            // Создает новый список
            LinkedList2 l = new LinkedList2();

            // Добавляем в список узлы со значениями 1, 2 и 4
            //
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(4));

            // Присваиваем ссылку на найденный узел из списка локальному объекту
            Node afterNode = l.Find(2);

            // Добавляем в список новый узел после указанного
            l.InsertAfter(afterNode, newNode);

            // Сравнение. Ожидаемое значение (3) == Актуальное третьего узла
            Assert.AreEqual(expectedNew, l.head.next.next.value);
            // Сравнение. Ожидаемое значение (4) == Актуальное четвертого узла
            Assert.AreEqual(expectedNext, l.head.next.next.next.value);
            // Сравнение. Ожидаемое значение (2) == prev'а нового узла
            Assert.AreEqual(expectedNode, newNode.prev.value);
            // Сравнение. Ожидаемое значение (3) == prev'а next'а нового узла
            Assert.AreEqual(expectedNew, newNode.next.prev.value);
            // Сравнение. Ожидаемое значение (3) == prev'а третьего узла
            Assert.AreEqual(expectedNew, l.head.next.next.next.prev.value);
            // Сравнение. Ожидаемое значение (3) == prev'а последнего узла
            Assert.AreEqual(expectedNew, l.tail.prev.value);
            // Сравнение. Ожидаемое значение (3) == next'а второго узла
            Assert.AreEqual(expectedNew, afterNode.next.value);
            // Сравнение. Ожидаемое значение (4) == next'а нового узла
            Assert.AreEqual(expectedNext, newNode.next.value);
        }

        [TestMethod]
        public void TestInsertAfter_B()
        {
            // expected value in prev-node of tail
            int expectedNode = 2;
            // expected value in tail
            int expectedNew = 3;
            // Creating new node
            Node newNode = new Node(3);

            // Creating new list
            LinkedList2 l = new LinkedList2();
            // Adding new nodes
            //
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(2));
            // Adding new node next to another
            l.InsertAfter(l.Find(2), newNode);
            // Comparing. value =2 and value prev-node of tail
            Assert.AreEqual(expectedNode, l.tail.prev.value);
            // Comparing. value =3 and value of tail
            Assert.AreEqual(expectedNew, l.tail.value);
            // Comparing. value =3 and value of third node
            Assert.AreEqual(expectedNew, l.head.next.next.value);
        }

        [TestMethod]
        public void TestInsertAfter_C()
        {
            // value expected in node-head in all phases except 1st
            int expected1 = 1;
            // value expected in: 
            // 2nd-node(tail) in phases: 2, 3
            // 3rd-node(tail) in phase 4
            // 3rd-node in phase 5
            int expected2 = 2;
            // value expected in 4th-node(tail) in phase 5
            int expected3 = 3;
            // value expected in 2nd-node in phase 4
            int expected10 = 10;


            LinkedList2 l = new LinkedList2();

            // 1st phase
            //
            l.InsertAfter(null, new Node(2));
            Assert.AreEqual(null, l.head);

            // 2nd phase
            //
            l.InsertAfter(new Node(1), new Node(2));
            Assert.AreEqual(expected1, l.head.value);
            Assert.AreEqual(expected2, l.head.next.value);
            Assert.AreEqual(expected1, l.tail.prev.value);
            Assert.AreEqual(expected2, l.tail.value);

            // 3rd phase
            //
            l.InsertAfter(new Node(2), new Node(3));
            Assert.AreEqual(expected1, l.head.value);
            Assert.AreEqual(expected2, l.head.next.value);
            Assert.AreEqual(expected1, l.tail.prev.value);
            Assert.AreEqual(expected2, l.tail.value);

            // 4th phase
            //
            Node node = l.head;
            l.InsertAfter(node, new Node(10));
            Assert.AreEqual(expected1, l.head.value);
            Assert.AreEqual(expected10, l.head.next.value);
            Assert.AreEqual(expected10, l.tail.prev.value);
            Assert.AreEqual(expected2, l.tail.value);
            Assert.AreEqual(expected1, node.value);
            Assert.AreEqual(expected10, node.next.value);

            // 5th phase
            //
            node = l.tail;
            l.InsertAfter(node, new Node(3));
            Assert.AreEqual(expected3, l.tail.value);
            Assert.AreEqual(expected2, l.tail.prev.value);
            Assert.AreEqual(expected3, l.head.next.next.next.value);
            Assert.AreEqual(expected2, l.head.next.next.next.prev.value);
        }
    }
}