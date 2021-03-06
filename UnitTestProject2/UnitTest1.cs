﻿using System;
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
            Assert.AreEqual(node2, list[1]);
            Assert.AreEqual(node3, list[2]);
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

        // Тест на удаление двух элементов из середины списка
        // Список проверяется на наличие всех элементов после удаления
        //
        [TestMethod]
        public void TestRemoveAll_D()
        {
            // ожидаемое значение в 1-ом и 2-ом узлах
            int exp0 = 0;
            // ожидаемое значение в 3-ем и 4-ом узлах
            int exp2 = 2;
            // количество оставшихся узлов после удаления
            int exp4 = 4;


            LinkedList2 l = new LinkedList2();
            l.AddInTail(new Node(0));
            l.AddInTail(new Node(0));
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(2));

            l.RemoveAll(1);

            Assert.AreEqual(exp0, l.head.value);
            Assert.AreEqual(exp0, l.head.next.value);
            Assert.AreEqual(exp0, l.head.next.prev.value);
            Assert.AreEqual(null, l.head.prev);
            Assert.AreEqual(null, l.head.next.prev.prev);
            Assert.AreEqual(null, l.head.next.next.prev.prev.prev);
            Assert.AreEqual(exp0, l.head.next.next.prev.value);
            Assert.AreEqual(exp2, l.head.next.next.next.prev.value);
            Assert.AreEqual(exp2, l.head.next.next.value);
            Assert.AreEqual(exp2, l.head.next.next.next.value);
            Assert.AreEqual(exp2, l.head.next.next.next.prev.value);
            Assert.AreEqual(exp0, l.head.next.next.prev.value);
            Assert.AreEqual(exp0, l.head.next.next.prev.prev.value);
            Assert.AreEqual(null, l.head.next.next.next.next);
            Assert.AreEqual(null, l.head.next.next.prev.prev.prev);
            Assert.AreEqual(exp2, l.tail.value);
            Assert.AreEqual(exp2, l.tail.prev.value);
            Assert.AreEqual(exp0, l.tail.prev.prev.value);
            Assert.AreEqual(exp0, l.tail.prev.prev.prev.value);
            Assert.AreEqual(exp0, l.tail.prev.prev.prev.next.value);
            Assert.AreEqual(exp2, l.tail.prev.prev.prev.next.next.value);
            Assert.AreEqual(exp2, l.tail.prev.prev.prev.next.next.next.value);
            Assert.AreEqual(null, l.tail.prev.prev.prev.prev);
            Assert.AreEqual(null, l.tail.prev.prev.prev.next.next.next.next);

            Assert.AreEqual(exp4, l.Count());
        }

        [TestMethod]
        public void TestRemove_E()
        {
            LinkedList2 l = new LinkedList2();
            l.AddInTail(new Node(0));
            l.AddInTail(new Node(0));
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(3));
            l.AddInTail(new Node(3));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(2));
            
            l.Remove(1);
            l.RemoveAll(3);
            l.Remove(1);

            Assert.AreEqual(0, l.head.value);
            Assert.AreEqual(0, l.head.next.value);
            Assert.AreEqual(1, l.head.next.next.value);
            Assert.AreEqual(0, l.head.next.next.prev.value);
            Assert.AreEqual(1, l.head.next.next.next.prev.value);
        }

        [TestMethod]
        public void TestInsertAfter_A()
        {
            // Ожидаемое значение во 2-ом узле
            int exp2 = 2;

            // Ожидаемое значение после вставки. В новом 3-ем узле 
            int exp3 = 3;

            // Ожидаемое значение до вставки. В 3-ем узле
            int exp4 = 4;

            // Создает новый узел
            Node newNode = new Node(3);

            // Создает новый список
            LinkedList2 l = new LinkedList2();

            // Добавляем в список узлы со значениями 1, 2 и 4
            //
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(4));

            // Находим узел из списка
            Node afterNode = l.Find(2);

            // Добавляем в список новый узел после указанного
            l.InsertAfter(afterNode, newNode);

            // Сравнение. Ожидаемое значение (3) == Актуальное третьего узла
            Assert.AreEqual(exp3, l.head.next.next.value);
            // Сравнение. Ожидаемое значение (4) == Актуальное четвертого узла
            Assert.AreEqual(exp4, l.head.next.next.next.value);
            // Сравнение. Ожидаемое значение (2) == prev'а нового узла
            Assert.AreEqual(exp2, newNode.prev.value);
            // Сравнение. Ожидаемое значение (3) == prev'а next'а нового узла
            Assert.AreEqual(exp3, newNode.next.prev.value);
            // Сравнение. Ожидаемое значение (3) == prev'а третьего узла
            Assert.AreEqual(exp3, l.head.next.next.next.prev.value);
            // Сравнение. Ожидаемое значение (3) == prev'а последнего узла
            Assert.AreEqual(exp3, l.tail.prev.value);
            // Сравнение. Ожидаемое значение (3) == next'а второго узла
            Assert.AreEqual(exp3, afterNode.next.value);
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
            LinkedList2 l = new LinkedList2();
            l.AddInTail(new Node(1));
            l.AddInTail(new Node(2));
            l.AddInTail(new Node(3));

            l.InsertAfter(l.Find(1), new Node(4));

            Assert.AreEqual(1, l.head.value);
            Assert.AreEqual(4, l.head.next.value);
        }

        [TestMethod]
        public void TestInsertAfter_D()
        {
            LinkedList2 l = new LinkedList2();
            Node node = l.Find(1);
            l.InsertAfter(node, new Node(4));

            Assert.AreEqual(4, l.head.value);
            Assert.AreEqual(4, l.tail.value);
        }
    }
}