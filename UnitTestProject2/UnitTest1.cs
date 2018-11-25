using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitTwo;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDelete()
        {
            //value expected in head after first delete
            int expected1 = 1;
            //value expected in node next to head after first delete
            //value expected in head after second delete
            int expected2 = 2;
            //value expected in tail after first delete
            int expected3 = 3;

            LinkedList2 l2 = new LinkedList2();
            l2.AddInTail(new Node(1));
            l2.AddInTail(new Node(2));
            l2.AddInTail(new Node(3));
            l2.AddInTail(new Node(4));

            l2.Delete(4);

            Assert.AreEqual(expected1, l2.head.value);
            Assert.AreEqual(expected2, l2.head.next.value);
            Assert.AreEqual(expected3, l2.tail.value);

            l2.Delete(1);

            Assert.AreEqual(expected2, l2.head.value);
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
            LinkedList2 l2 = new LinkedList2();

            // Добавляем в список узлы со значениями 1, 2 и 4
            //
            l2.AddInTail(new Node(1));
            l2.AddInTail(new Node(2));
            l2.AddInTail(new Node(4));

            // Присваиваем ссылку на найденный узел из списка локальному объекту
            Node afterNode = l2.Find(2);

            // Добавляем в список новый узел после указанного
            l2.InsertAfter(afterNode, newNode);

            // Сравнение. Ожидаемое значение (3) == Актуальное третьего узла
            Assert.AreEqual(expectedNew, l2.head.next.next.value);
            // Сравнение. Ожидаемое значение (4) == Актуальное четвертого узла
            Assert.AreEqual(expectedNext, l2.head.next.next.next.value);
            // Сравнение. Ожидаемое значение (2) == prev'а нового узла
            Assert.AreEqual(expectedNode, newNode.prev.value);
            // Сравнение. Ожидаемое значение (3) == prev'а next'а нового узла
            Assert.AreEqual(expectedNew, newNode.next.prev.value);
            // Сравнение. Ожидаемое значение (3) == prev'а третьего узла
            Assert.AreEqual(expectedNew, l2.head.next.next.next.prev.value);
            // Сравнение. Ожидаемое значение (3) == prev'а последнего узла
            Assert.AreEqual(expectedNew, l2.tail.prev.value);
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
            LinkedList2 l2 = new LinkedList2();
            // Adding new nodes
            //
            l2.AddInTail(new Node(1));
            l2.AddInTail(new Node(2));
            // Adding new node next to another
            l2.InsertAfter(l2.Find(2), newNode);
            // Comparing. value =2 and value prev-node of tail
            Assert.AreEqual(expectedNode, l2.tail.prev.value);
            // Comparing. value =3 and value of tail
            Assert.AreEqual(expectedNew, l2.tail.value);
            // Comparing. value =3 and value of third node
            Assert.AreEqual(expectedNew, l2.head.next.next.value);
        }

        [TestMethod]
        public void TestAddHead()
        {
            //first head's value / tail's
            int expected1 = 1;
            //new head's value
            int expected2 = 2;
            //third node's value
            int expected3 = 3;

            //Creating new List
            LinkedList2 l2 = new LinkedList2();
            l2.AddInHead(new Node(1));

            Assert.AreEqual(expected1, l2.head.value);
            Assert.AreEqual(expected1, l2.tail.value);

            l2.AddInHead(new Node(2));

            Assert.AreEqual(expected2, l2.head.value);
            Assert.AreEqual(expected1, l2.head.next.value);
            Assert.AreEqual(expected1, l2.tail.value);

            l2.AddInHead(new Node(3));

            Assert.AreEqual(expected3, l2.head.value);
            Assert.AreEqual(expected1, l2.tail.value);
        }
    }
}
