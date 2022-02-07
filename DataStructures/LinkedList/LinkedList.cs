using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T>? Next { get; set; }

        public Node(T data)
        {
            Value = data;
            Next = null;
        }

        public Node()
        {
            Value = default;
            Next = null;
        }
    }

    public class MyLinkedList<T>
    {
        private Node<T> head = new();

        public MyLinkedList()
        {
        }

        #region "Utility"
        public bool IsEmpty() => head.Next == null;

        public int Count()
        {
            int listLength = 0;
            var temp = head;

            while (temp?.Next != null)
            {
                listLength++;
                temp = temp.Next;
            }
            return listLength;
        }
        #endregion

        #region "Insertion"

        public void AddNodeAtBeginning(T data)
        {
            Node<T> newNode = new(data);

            if(IsEmpty())
            {
                head.Next = newNode;
            }
            else
            {
                newNode.Next = head.Next;
                head.Next = newNode;
            }
        }
        public void AddNodeAtEnd(T data)
        {
            Node<T> newNode = new(data);

            if (IsEmpty())
            {
                head.Next = newNode;
            }
            else
            {
                var temp = head.Next;
                while(temp?.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
            }
        }

        public void AddNodeAtIndex(T data, int index)
        {
            if(index < 0)
            {
                throw new ArgumentOutOfRangeException("index should be non-negative value");
            }

            if(index > Count())
            {
                throw new ArgumentOutOfRangeException("index");
            }

            var temp = head;
            int currentListLength = 0;

            while(temp.Next != null && currentListLength+1 < index)
            {
                temp = temp?.Next;
                currentListLength++;
            }

            Node<T> newNode = new Node<T>(data);
            newNode.Next = temp.Next;
            temp.Next = newNode;
            
        }
        #endregion

        #region "Deletion"
        public void DeleteFirstNode()
        {
            if(IsEmpty())
            {
                throw new Exception("List is Empty");
            }

            var temp = head.Next;
            head.Next = temp.Next;

            // instead we can also use the below
            // head.Next = head.Next.Next;
        }

        public void DeleteLastNode()
        {
            if (IsEmpty())
            {
                throw new Exception("List is Empty");
            }

            // If list has only 1 element.
            if(Count() == 1)
            {
                head.Next = null;
            }

            var temp = head.Next;
            while(temp.Next != null && temp.Next.Next != null)
            {
                temp = temp?.Next;
            }

            temp.Next = null;
        }

        public void DeleteNodeAtIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index should be non-negative value");
            }

            if (index > Count())
            {
                throw new ArgumentOutOfRangeException("index");
            }

            var temp = head;
            int currentListLength = 0;

            while (temp.Next != null && currentListLength + 1 < index)
            {
                temp = temp?.Next;
                currentListLength++;
            }

            temp.Next = temp.Next.Next;
        }
        #endregion

        #region "Traversing & Searching"
        public bool Exists(T data)
        {
            if (!IsEmpty())
            {
                var temp = head.Next;
                do
                {
                    if (temp.Value.Equals(data))
                    {
                        return true;
                    }
                    temp = temp.Next;
                }
                while (temp != null);

            }
            return false;
        }

        public List<T> Traverse()
        {
            List<T> result = new();
            if (!IsEmpty())
            {
                var temp = head?.Next;
                

                do
                {
                    result.Add(temp.Value);
                    temp = temp.Next;
                }
                while (temp != null);
            }
            return result;
        }
        #endregion

        #region "Reverse"

        public void ReverseWithIteration()
        {
            if(!IsEmpty() || Count() > 1)
            {
                var current = head.Next;
                var currentPlusOne = current?.Next;
                var currentPlusTwo = currentPlusOne?.Next;
                int index = 0;

                while(currentPlusOne != null)
                {
                    var temp = current;
                    if(index == 0)
                    {
                        temp.Next = null;
                    }

                    if(currentPlusTwo!= null)
                    {
                        currentPlusOne.Next = temp;
                        current = currentPlusOne;
                        currentPlusOne = currentPlusTwo;
                        currentPlusTwo = currentPlusTwo?.Next;
                    }
                    else
                    {
                        currentPlusOne.Next = temp;
                        head.Next = currentPlusOne;
                        currentPlusOne = null;
                    }
                    index++;
                }

            }
        }

        public void ReverseWithIteration_v2()
        {
            if (!IsEmpty() || Count() > 1)
            {
                Node<T> prev = null;

                Node<T> next = null;
                Node<T> current = head.Next;

                while(current != null)
                {
                    next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                }
                head.Next = prev;
            }
        }

        public void ReverseWithRecursion()
        {

        }
        #endregion
    }
}
