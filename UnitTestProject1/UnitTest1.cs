using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {
            //value expected in list's head and tail
            //
            int headExpected = 2;
            int tailExpected = 7;

            LinkedList list = new LinkedList();
            list.AddInTail(new Node(2));
            list.AddInTail(new Node(7));
            Assert.AreEqual(headExpected, list.head.value);
            Assert.AreEqual(tailExpected, list.tail.value);
        }

        [TestMethod]
        public void TestFind()
        {
            //value expected in list's head and tail
            //
            int headExpected = 3;
            int tailExpected = 9;

            LinkedList list = new LinkedList();
            list.AddInTail(new Node(3));
            list.AddInTail(new Node(9));
            Node foundedNode1 = list.Find(3);
            Node foundedNode2 = list.Find(9);
            Assert.AreEqual(headExpected, foundedNode1.value);
            Assert.AreEqual(tailExpected, foundedNode2.value);
        }

        // Тест. Корректность удаления элемента.
        // Удаляется один последний элемент.
        [TestMethod]
        public void TestRemove_A()
        {
            //value expected in list's head and tail
            //
            int headExpected = 3;
            int tailExpected = 9;

            LinkedList list = new LinkedList();
            list.AddInTail(new Node(3));
            list.AddInTail(new Node(9));
            list.AddInTail(new Node(12));
            list.Remove(12);
            Assert.AreEqual(headExpected, list.head.value);
            Assert.AreEqual(tailExpected, list.tail.value);
        }

        // Тест. Корректность удаления элемента
        // из списка с одним элементом.
        [TestMethod]
        public void TestRemove_B()
        {
            //value expected in list's head and tail after first remove
            int expectedA = 9;

            LinkedList list = new LinkedList();
            list.AddInTail(new Node(3));
            list.AddInTail(new Node(9));

            list.Remove(3);

            Assert.AreEqual(expectedA, list.head.value);
            Assert.AreEqual(expectedA, list.tail.value);

            list.Remove(9);

            Assert.AreEqual(null, list.head);
            Assert.AreEqual(null, list.tail);
        }

        [TestMethod]
        public void TestRemoveAll_A()
        {
            //value expected in list's head and tail
            //
            int headExpected = 12;
            int tailExpected = 15;

            LinkedList list = new LinkedList();
            list.AddInTail(new Node(3));
            list.AddInTail(new Node(3));
            list.AddInTail(new Node(12));
            list.AddInTail(new Node(3));
            list.AddInTail(new Node(15));
            list.RemoveAll(3);
            Assert.AreEqual(headExpected, list.head.value);
            Assert.AreEqual(tailExpected, list.tail.value);
        }

        // Тест. Все узлы имеют одно и то же значение
        [TestMethod]
        public void TestRemoveAll_B()
        {
            

            LinkedList list = new LinkedList();
            list.AddInTail(new Node(3));

            list.RemoveAll(3);
            Assert.AreEqual(null, list.head);
            Assert.AreEqual(null, list.tail);

            list.AddInTail(new Node(3));
            list.AddInTail(new Node(3));

            list.RemoveAll(3);
            Assert.AreEqual(null, list.head);
            Assert.AreEqual(null, list.tail);
        }

        // Тест. Добавляет три узла и внедряет один после выбранного.
        // Проверка на связь каждого из них.
        [TestMethod]
        public void TestInsertAfter_A()
        {
            // Ожидаемое значение в выбранном узле
            int expectedA = 2;
            // Ожидаемое значение во внедренном узле и в связи выбранного узла
            int expectedB = 3;
            // Ожидаемое значение в связи нового узла и в хвосте
            int expectedC = 4;

            LinkedList list = new LinkedList();
            list.AddInTail(new Node(1));
            list.AddInTail(new Node(2));
            list.AddInTail(new Node(4));
            Node afterNode = list.Find(2);
            list.InsertAfter(afterNode, new Node(3));

            Assert.AreEqual(expectedA, list.head.next.value);
            Assert.AreEqual(expectedA, afterNode.value);
            Assert.AreEqual(expectedB, afterNode.next.value);
            Assert.AreEqual(expectedB, list.head.next.next.value);
            Assert.AreEqual(expectedC, afterNode.next.next.value);
            Assert.AreEqual(expectedC, list.tail.value);

            // Проверка на то, что после хвоста ничего нет
            //
            Assert.AreEqual(null, afterNode.next.next.next);
            Assert.AreEqual(null, list.tail.next);
        }

        // Тест. Добавляет два узла и проводит попытку внедрить новый узел
        // после узла равного null.
        [TestMethod]
        public void TestInsertAfter_B()
        {
            // Ожидаемое значение в первом добавленном узле
            int expectedA = 1;
            // Ожидаемое значение во втором добавленом узле
            int expectedB = 2;
            // Ожидаемое значение в третьем добавленом узле
            // Между первым и вторым
            int expectedC = 3;

            LinkedList list = new LinkedList();
            list.AddInTail(new Node(1));
            list.AddInTail(new Node(2));
            Node afterNode = list.Find(3);

            list.InsertAfter(afterNode, new Node(3));

            Assert.AreEqual(expectedB, list.head.next.value);
            Assert.AreEqual(expectedB, list.tail.value);
            Assert.AreEqual(null, list.head.next.next);
        }

        // Тест. Попытка внедрения первого узла при пустом списке
        // c выбранным узлом равным null;
        [TestMethod]
        public void TestInsertAfter_C()
        {
            // Ожидаемое значение в первом добавленном узле
            int expectedB = 2;
            // Ожидаемое значение во втором добавленном узле
            int expectedC = 3;

            LinkedList list = new LinkedList();
            Node afterNode = list.Find(1);
            list.InsertAfter(afterNode, new Node(2));

            Assert.AreEqual(expectedB, list.head.value);
            Assert.AreEqual(expectedB, list.tail.value);

            afterNode = list.head;
            list.InsertAfter(afterNode, new Node(3));

            Assert.AreEqual(expectedC, list.head.next.value);
            Assert.AreEqual(expectedC, list.tail.value);
            Assert.AreEqual(expectedC, afterNode.next.value);
        }
    }
}
