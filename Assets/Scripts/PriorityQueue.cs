using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace felixro
{   


    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List <T> data;

        public PriorityQueue()
        {
            this.data = new List <T>();
        }

        public void Enqueue(T item)
        {
            data.Add(item);

            int ci = data.Count - 1; // child index; start at end
            while (ci > 0)
            {
                int pi = (ci - 1) / 2; // parent index
                if (data[ci].CompareTo(data[pi]) >= 0)
                {
                    break; // child item is larger than (or equal) parent so we're done
                }

                T tmp = data[ci];
                data[ci] = data[pi];
                data[pi] = tmp;

                ci = pi;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new System.IndexOutOfRangeException("Queue empty");
            }

            int li = data.Count - 1;
            T frontItem = data[0];
            data[0] = data[li];
            data.RemoveAt(li);

            --li;
            int pi = 0;
            while (true)
            {
                int ci = pi * 2 + 1;

                if (ci  > li)
                {
                    break;
                }

                int rc = ci + 1;

                if (rc  <= li && data[rc].CompareTo(data[ci])  < 0)
                {
                    ci = rc;
                }

                if (data[pi].CompareTo(data[ci]) <= 0) 
                {
                    break;
                }

                T tmp = data[pi]; 
                data[pi] = data[ci]; 
                data[ci] = tmp;

                pi = ci;
            }

            return frontItem;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new System.IndexOutOfRangeException("Queue empty");
            }

            return data[0];
        }

        public bool IsEmpty()
        {
            return data.Count <= 0;
        }

        public int GetCount()
        {
            return data.Count;
        }
    }
}
