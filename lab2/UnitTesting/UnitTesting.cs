using lab2;
using NUnit.Framework;

namespace UnitTesting
{
    public class Tests
    {
        [Test]
        public void LengthTest1()
        {
            LinkedList list = new();
            int expected = 0;
            Assert.AreEqual(expected, list.Length());
        }
        [Test]
        public void LengthTest2()
        {
            LinkedList list = new();
            int expected = 2;
            list.Append('2');
            list.Append('s');
            Assert.AreEqual(expected, list.Length());
        }
        [Test]
        public void LengthTest3()
        {
            LinkedList list = new();
            int expected = 1;
            list.Append('2');
            list.Append('s');
            list.Delete(1);
            Assert.AreEqual(expected, list.Length());
        }
        [Test]
        public void TestAppend1()
        {
            LinkedList list = new();
            char expected = 'b';
            list.Append(expected);
            Assert.AreEqual(expected, list.head.data);
        }
        [Test]
        public void TestAppend2()
        {
            LinkedList list = new();
            char expected = 'c';
            list.Append('b');
            list.Append(expected);
            Assert.AreEqual(expected, list.head.next.data);
        }
        [Test]
        public void TestInsert()
        {
            LinkedList list = new();
            char expected = 'b';
            list.Append('a');
            list.Append('c');
            list.Insert(expected, 1);
            Assert.AreEqual(expected, list.head.next.data);
        }
        [Test]
        public void TestDelete()
        {
            LinkedList list = new();
            list.Append('1');
            list.Append('2');
            list.Delete(1);
            int expected = 1;
            Assert.AreEqual(expected, list.Length());
        }
        [Test]
        public void TestDeleteAll()
        {
            LinkedList list = new();
            list.Append('1');
            list.Append('2');
            list.Append('1');
            list.DeleteAll('1');
            int expected = 1;
            Assert.AreEqual(expected, list.Length());
        }
        [Test]
        public void TestGet()
        {
            LinkedList list = new();
            list.Append('a');
            list.Append('b');
            list.Append('c');
            char expected = 'b';
            char actual = list.Get(1);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestClone1()
        {
            LinkedList list = new();
            list.Append('a');
            LinkedList copy = list.Clone();
            // values are equal
            Assert.AreEqual(copy.head.data, list.head.data);
        }
        [Test]
        public void TestClone2()
        {
            LinkedList list = new();
            list.Append('a');
            LinkedList copy = list.Clone();
            // links are not equal
            Assert.AreNotEqual(copy.head, list.head);
        }
        [Test]
        public void TestReverse1()
        {
            // для непарної кількості
            LinkedList list = new();
            char[] expected = { 'c', 'b', 'a' };
            char[] actual = new char[expected.Length];
            list.Append('a');
            list.Append('b');
            list.Append('c');
            list.Reverse();
            Node temp = list.head;
            for(int i = 0; temp != null; i++)
            {
                actual[i] = temp.data;
                temp = temp.next;
            }
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestReverse2()
        {
            // для парної кількості
            LinkedList list = new();
            char[] expected = {'d', 'c', 'b', 'a' };
            char[] actual = new char[expected.Length];
            list.Append('a');
            list.Append('b');
            list.Append('c');
            list.Append('d');
            list.Reverse();
            Node temp = list.head;
            for (int i = 0; temp != null; i++)
            {
                actual[i] = temp.data;
                temp = temp.next;
            }
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestFindFirst()
        {
            // для парної кількості
            LinkedList list = new();
            list.Append('b');
            list.Append('a');
            list.Append('c');
            list.Append('a');
            int expected = 1;
            Assert.AreEqual(expected, list.FindFirst('a'));
        }
        [Test]
        public void TestFindLast()
        {
            // для парної кількості
            LinkedList list = new();
            list.Append('b');
            list.Append('a');
            list.Append('c');
            list.Append('a');
            int expected = 3;
            Assert.AreEqual(expected, list.FindLast('a'));
        }
        [Test]
        public void TestClear()
        {
            // для парної кількості
            LinkedList list = new();
            list.Append('b');
            list.Append('a');
            list.Append('c');
            list.Append('a');
            list.Clear();
            int expected = 0;
            Assert.AreEqual(expected, list.Length());
        }
        [Test]
        public void TestExtend()
        {
            // для парної кількості
            LinkedList list = new();
            char[] expected = {'a', 'b', 'c', 'd', '5', '2'};
            char[] actual = new char[expected.Length];
            list.Append('a');
            list.Append('b');
            list.Append('c');
            list.Append('d');
            LinkedList list2 = new();
            list2.Append('5');
            list2.Append('2');
            list.Extend(list2);
            Node temp = list.head;
            for(int i = 0; temp != null; i++)
            {
                actual[i] = temp.data;
                temp = temp.next;
            }
            Assert.AreEqual(expected, actual);
        }
    }
}