using System;

namespace lab2
{
    public class Node
    {
        public char data;
        public Node next;
        public Node prev;
    };

    public class LinkedList
    {
        public Node head;
        public LinkedList()
        {
            head = null;
        }
        public void Print()
        {
            Node temp = this.head;
            if (temp != null)
            {
                Console.Write("The list contains: ");
                while (temp != null)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }
        }
        public int Length()
        {
            Node temp = this.head;
            if(temp != null)
            {
                int counter = 0;
                while (temp != null)
                {
                    counter++;
                    temp = temp.next;
                }
                return counter;
            }
            return 0;
        }
        public void Append(char c)
        {
            Node temp = this.head;
            if (temp == null)
            {
                this.head = new Node();
                this.head.data = c;
                return;
            }
            
            Node last = new Node();
            last.data = c;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = last;
            last.prev = temp;
        }
        public void Insert(char c, int i)
        {
            if (i < 0 || i >= this.Length()) throw new Exception("Wrong index");

            Node newNode = new Node();
            newNode.data = c;
            Node temp = this.head;
            if (i == 0)
            {
                this.head = newNode;
                newNode.next = temp;
                temp.prev = newNode;
                return;
            }
            else if (i > 0 && i <= this.Length() - 1)
            {
                Node temp2;
                for (int x = 0; x < i; x++)
                {
                    temp = temp.next;
                }
                temp2 = temp.prev;
                temp2.next = newNode;
                temp.prev = newNode;
                newNode.prev = temp2;
                newNode.next = temp;
                return;
            }
        }
        public char Delete(int i)
        {
            if (i < 0 || i >= this.Length()) throw new Exception("Wrong index");

            Node temp = this.head;
            char data;
            if(i == 0)
            {
                data = this.head.data;
                if(this.Length() == 1)
                {
                    this.head = null;
                    return data;
                }
                
                this.head = temp.next;
                this.head.prev = null;
                temp = null;
                return data;
            }
            
            else if (i == this.Length() - 1)
            {
                while(temp.next != null)
                {
                    temp = temp.next;
                }
                Node temp3 = temp.prev;
                data = temp.data;
                temp.data = '\0';
                temp.prev = null;
                temp3.next = null;
                return data;
            }
            
            else
            {
                for (int x = 0; x < i; x++)
                {
                    temp = temp.next;
                }
                data = temp.data;
                Node temp2 = temp.next;
                temp = temp.prev;
                temp.next = temp2;
                temp2.prev = temp;
                return data;
            }
        }
        public void DeleteAll(char c)
        {
            Node temp = this.head;
            int counter = 0;
            while (temp != null)
            {
                if (temp.data == c)
                {
                    this.Delete(counter);
                }
                else
                {
                    counter++;
                }
                temp = temp.next;
            }
        }
        public char Get(int i)
        {
            if (i < 0 || i >= this.Length()) throw new Exception("Wrong index");

            Node temp = this.head;
            for (int x = 0; x < i; x++) temp = temp.next;
            return temp.data;
        }
        public LinkedList Clone()   
        {
            Node temp = this.head;
            LinkedList newList = new LinkedList();
            if (this.Length() == 0) return newList;
            
            while(temp != null)
            {
                newList.Append(temp.data);
                temp = temp.next;
            }
            return newList;
        }
        public void Reverse()
        {
            int length = this.Length();
            if (length == 0 || length == 1)
            {
                Console.WriteLine("dude? nothing to reverse -.-");
                return;
            }
            Node tail = this.head;
            Node head = this.head;
            while (tail.next != null) tail = tail.next;
            for (int i = 0, l = length; i < l; i++, l--)
            {
                char temp;
                temp = head.data;
                head.data = tail.data;
                tail.data = temp;
                head = head.next;
                tail = tail.prev;
            }
        }
        public int FindFirst(char c)
        {
            Node temp = this.head;
            for(int i = 0; temp != null; temp = temp.next, i++)
            {
                if (temp.data == c) return i;
            }
            return -1;
        }
        public int FindLast(char c)
        {
            Node temp = this.head;
            while (temp.next != null) temp = temp.next;
            for (int i = (this.Length() - 1); temp != null; temp = temp.prev, i--)
            {
                if (temp.data == c) return i;
            }
            return -1;
        }
        public void Clear()
        {
            Node temp = this.head;
            Node temp2;
            while(temp != null)
            {
                temp2 = temp.next;
                temp.prev = null;
                temp.data = '\0';
                temp.next = null;
                temp = temp2;
            }
            this.head = null;
        }
        public void Extend(LinkedList list)
        {
            list = list.Clone();
            if (list.Length() == 0) return;
            Node temp = this.head;
            LinkedList listCopy = list.Clone();
            while (temp.next != null) temp = temp.next;
            temp.next = listCopy.head;
            listCopy.head.prev = temp;
        }
    };
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList MyList = new LinkedList();
            Console.WriteLine("Doubly linked list initialization,\nLength = {0},", MyList.Length());
            MyList.Print();

            // Append()
            MyList.Append('a');
            Console.WriteLine("\nAdding letter 'a' to the list usind Append('a') method,\nLength = {0}", MyList.Length());
            MyList.Print();

            // Insert()
            try
            {
                MyList.Insert('b', 0);
                Console.WriteLine("\nInserting letter 'b' to the list on index 0 using Insert('b', 0) method\nLength = {0},", MyList.Length());
                MyList.Print();
            } catch (Exception ex)
            {
                Console.WriteLine("\n" + ex);
            }

            // Delete()

            try
            {
                char deleteReturn = MyList.Delete(0);
                Console.WriteLine("\nDeleting element on index 0 using Delete(0) method,\nDelete(0) method returned value is: {1},\nLength = {0},", MyList.Length(), deleteReturn);
                MyList.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex);
            }

            MyList.Append('c');
            MyList.Append('b');
            MyList.Append('f');
            MyList.Append('g');
            MyList.Append('a');
            MyList.Append('c');
            Console.WriteLine("\nAdded some elements using Append() method,\nLength = {0},", MyList.Length());
            MyList.Print();

            // DeleteAll()
            MyList.DeleteAll('c');
            Console.WriteLine("\nDeleting all 'c' elements using DeleteAll('c') method,\nLength = {0},", MyList.Length());
            MyList.Print();

            // Get()
            try
            {
                Console.WriteLine("\nGetting elements with index 0 and 3 using Get(0) and Get(3) methods,\nGet(0) returned value is: {0},\nGet(3) returned value is: {1}.", MyList.Get(0), MyList.Get(3));
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex);
            }

            // Clone()
            LinkedList MyListClone = MyList.Clone();
            Console.WriteLine("\nCloning list using Clone() method,\n" +
                "MyList == MyListClone statement is {0},\n" +
                "MyList.head == MyListClone.head statement is {1}.", MyList == MyListClone, MyList.head == MyListClone.head);
            Console.WriteLine("\nMyList Length is {0},", MyList.Length());
            MyList.Print();
            Console.WriteLine("\nMyListClone Length is {0},", MyListClone.Length());
            MyListClone.Print();

            // Reverse
            MyList.Reverse();
            Console.WriteLine("\nReversing the list using Reverse() method,\nLength = {0},", MyList.Length());
            MyList.Print();

            // FindFirst()
            Console.WriteLine("\nGetting index of the first met letter 'a' in the list using FindFirst('a') method,\nReturned value is: {0}.", MyList.FindFirst('a'));

            // FindLast()
            Console.WriteLine("\nGetting index of the last met letter 'a' in the list using FindLast('a') method,\nReturned value is: {0}.", MyList.FindLast('a'));

            // Extend()
            MyList.Extend(MyListClone);
            Console.WriteLine("\nExtending MyList with its clone MyListClone using MyList.Extend(MyListClone) method,\nLength = {0},", MyList.Length());
            MyList.Print();

            // Extend() linking test
            MyListClone.head.data = '0';
            Console.WriteLine("\nChecking Extend() method linking,\n" +
                "Changing MyListClone first element value from 'a' to '0',\n" +
                "MyListClone.head.data = {0}.\n" +
                "Checking if the value has changed in the extended list,", MyListClone.head.data);
            MyList.Print();

            // Clear()
            MyList.Clear();
            Console.WriteLine("\nClearing the list using Clear() method,\nLength = {0},", MyList.Length());
            MyList.Print();

            Console.WriteLine("\nDone. Linked list functionality description is finished.");
        }
    }
}
