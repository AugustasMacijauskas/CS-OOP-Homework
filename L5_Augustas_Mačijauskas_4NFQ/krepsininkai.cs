using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    /// <summary>
    /// 
    /// </summary>
    class Krepsininkai
    {
        private Node first;
        private Node last;
        private Node link;
        private Node insertionHelper;

        public Krepsininkai()
        {
            this.last = new Node(null, null);
            this.first = new Node(null, last);
            this.insertionHelper = first;
            this.link = null;
        }

        public void Start()
        {
            link = first.Next;
        }

        public bool isEmpty()
        {
            return link.Next == null;
        }

        public void Next()
        {
            link = link.Next;
        }

        public Krepsininkas ImtiKrepsininka()
        {
            return link.Duomenys;
        }

        public void AddFirst(Krepsininkas duom)
        {
            first.Next = new Node(duom, first.Next);
        }

        public void AddLast(Krepsininkas duom)
        {
            insertionHelper.Next = new Node(duom, last);
            insertionHelper = insertionHelper.Next;
        }

        public void Clear()
        {
            while (first.Next != null)
            {
                link = first.Next;
                first.Next.Duomenys = null;
                first = first.Next.Next;
                link = null;
            }

            first = last;
        }

        public void Sort()
        {
            bool switched = true;
            Node temp1, temp2;

            while(switched)
            {
                switched = false;
                temp1 = temp2 = first.Next;
                while(temp2.Next != null)
                {
                    if (temp2.Duomenys <= temp1.Duomenys)
                    {
                        switched = true;
                        Krepsininkas temp = temp1.Duomenys;
                        temp1.Duomenys = temp2.Duomenys;
                        temp2.Duomenys = temp;
                    }

                    temp1 = temp2;
                    temp2 = temp2.Next;
                }
            }
        }

        public void Filter(int amzius)
        {
            Node iterator = first;
            while (iterator.Next != last)
            {
                if (iterator.Next.Duomenys.Amžius > amzius)
                {
                    // Deleted element data should be erased.
                    // iterator.Next.Duomenys = null;
                    iterator.Next = iterator.Next.Next;
                }
                else
                {
                    iterator = iterator.Next;
                }
            }
        }
    }
}
