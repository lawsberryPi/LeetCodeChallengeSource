using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogic
{
    public class Heap
    {
        public List<int> HeapArray { set; get; }
        public Heap()
        {
            HeapArray = new List<int>();
        }

        public void Push(int element)
        {
            HeapArray.Add(element);
            Heapify(HeapArray.Count - 1, element);
        }
        // pop means, the root need to heapify downwards, right ?
        // 
        public int Pop()
        {
            var popItem = HeapArray[0];
            var lastElement = HeapArray[HeapArray.Count - 1];
            HeapArray.RemoveAt(HeapArray.Count - 1);
            HeapArray[0] = lastElement;
            ReverseHeapify(0, lastElement);
            return popItem; 
        }

        public void ReverseHeapify(int index, int element)
        {
            if (index == HeapArray.Count - 1) return;
            var leftChildIndex = index * 2 + 1;
            var rightChildIndex = index * 2 + 2;
            var smallerIndex = leftChildIndex < rightChildIndex ? leftChildIndex : rightChildIndex;
            if (element > HeapArray[smallerIndex])
            {
                Swap(index, smallerIndex);
            }
        }

        private void Heapify(int index, int element)
        {
            if (index == 0) return;
            var parentIndex = (index - 1) / 2;
            var parentElement = HeapArray[parentIndex];
            if(parentElement > element)
            {
                Swap(index, parentIndex);
                Heapify(parentIndex, element);
            }
        }

        private void Swap(int left, int right)
        {
            var temp = HeapArray[left];
            HeapArray[left] = HeapArray[right];
            HeapArray[right] = temp;
        }
    }
}
