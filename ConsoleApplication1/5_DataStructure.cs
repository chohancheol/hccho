using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class _5_DataStructure
    {

        public void List()
        {
            //ArrayList
            ArrayList myList = new ArrayList();
            myList.Add(90);
            myList.Add(88);
            myList.Add(75);


            //List<T>
            List<int> myList2 = new List<int>();
            myList2.Add(90);
            myList2.Add(88);
            myList2.Add(75);
            int val = myList2[1];


            //SortedList<TKey, TValue>
            SortedList<int, string> list = new SortedList<int, string>();
            list.Add(1001, "Tim");
            list.Add(1020, "Ted");
            list.Add(1010, "Kim");

            string name = list[1001];

            foreach (KeyValuePair<int, string> kv in list)
            {
                Console.WriteLine("{0}:{1}", kv.Key, kv.Value);
            }

            //LinkedList<T> 클래스
            LinkedList<string> list2 = new LinkedList<string>();
            list2.AddLast("Apple");
            list2.AddLast("Banana");
            list2.AddLast("Lemon");

            LinkedListNode<string> node = list2.Find("Banana");
            LinkedListNode<string> newNode = new LinkedListNode<string>("Grape");

            // 새 Grape 노드를 Banana 노드 뒤에 추가
            list2.AddAfter(node, newNode);

            // 리스트 출력
            list2.ToList().ForEach(p => Console.WriteLine(p));

            // Enumerator를 이용한 리스트 출력
            foreach (var m in list2)
            {
                Console.WriteLine(m);
            }



        }

        public void QueueStack()
        {
            //Queue class
            Queue<int> q = new Queue<int>();
            q.Enqueue(120);
            q.Enqueue(130);
            q.Enqueue(150);

            int next = q.Dequeue(); // 120
            next = q.Dequeue(); // 130

            //Stack class
            Stack<double> s = new Stack<double>();
            s.Push(10.5);
            s.Push(3.54);
            s.Push(4.22);

            double val = s.Pop(); //4.22


        }

        public void Dictionary()
        {
            //Dictionary
            Dictionary<int, string> emp = new Dictionary<int, string>();
            emp.Add(1001, "Jane");
            emp.Add(1002, "Tom");
            emp.Add(1003, "Cindy");

            string name = emp[1002];
            Console.WriteLine(name);

            //ConcurrentDictionary
            var dict = new ConcurrentDictionary<int, string>();

            Task t1 = Task.Factory.StartNew(() =>
            {
                int key = 1;
                while (key <= 100)
                {
                    if (dict.TryAdd(key, "D" + key))
                    {
                        key++;
                    }
                    Thread.Sleep(100);
                }
            });

            Task t2 = Task.Factory.StartNew(() =>
            {
                int key = 1;
                string val;
                while (key <= 100)
                {
                    if (dict.TryGetValue(key, out val))
                    {
                        Console.WriteLine("{0},{1}", key, val);
                        key++;
                    }
                    Thread.Sleep(100);
                }
            });

            Task.WaitAll(t1, t2);
        }
    }
}
