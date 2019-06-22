using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class LinkedList
    {
        public static void LLMain()
        {
            LNode head = null;
            LinkedList.Append(ref head, 15);
            LinkedList.Append(ref head, 37);
            LinkedList.Append(ref head, 83);
            LinkedList.Append(ref head, 56);

            Console.WriteLine("Linked list:");
            LinkedList.Print(head);

            LinkedList.Reverse(ref head);

            Console.WriteLine();
            Console.WriteLine("Reversed Linked list:");
            LinkedList.Print(head);

            Console.WriteLine();
            //LinkedList.PrintRecursive(head);

            Console.WriteLine("Reverse of Reversed Linked list:");


            LinkedList.ReverseUsingRecursion(head);
            head = LinkedList.newHead;
            LinkedList.PrintRecursive(head);
        }

        public static void Append(ref LNode head, int data)
        {
            if (head != null)
            {
                LNode current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = new LNode();
                current.Next.Data = data;
            }
            else
            {
                head = new LNode();
                head.Data = data;
            }
        }

        public static void Print(LNode head)
        {
            if (head == null) return;

            LNode current = head;
            do
            {
                Console.Write("{0} ", current.Data);
                current = current.Next;
            } while (current != null);
        }

        public static void PrintRecursive(LNode head)
        {
            if (head == null)
            {
                Console.WriteLine();
                return;
            }

            Console.Write("{0} ", head.Data);
            PrintRecursive(head.Next);
        }

        public static void Reverse(ref LNode head)
        {
            if (head == null) return;

            LNode prev = null, current = head, next = null;

            while (current.Next != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            current.Next = prev;
            head = current;
        }

        public static LNode newHead;

        public static void ReverseUsingRecursion(LNode head)
        {
            if (head == null) return;

            if (head.Next == null)
            {
                newHead = head;
                return;
            }

            ReverseUsingRecursion(head.Next);
            head.Next.Next = head;
            head.Next = null;

        }
    }
    public class LNode
    {
        public int Data = 0;
        public LNode Next = null;
    }
}
