using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitOne;

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

        [TestMethod]
        public void TestDelete()
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

        [TestMethod]
        public void TestDeleteMultiple()
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

        [TestMethod]
        public void TestGetCombinedList()
        {
            //value expected in list's head and tail
            //
            int headExpected = 7;
            int tailExpected = 15;

            LinkedList list1 = new LinkedList();
            LinkedList list2 = new LinkedList();
            list1.AddInTail(new Node(3));
            list1.AddInTail(new Node(6));
            list2.AddInTail(new Node(4));
            list2.AddInTail(new Node(9));
            LinkedList list3 = list1.GetCombinedList(list1, list2);
            Assert.AreEqual(headExpected, list3.head.value);
            Assert.AreEqual(tailExpected, list3.tail.value);
        }
    }
}
