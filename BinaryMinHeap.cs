using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incassator
{
    class BinaryMinHeap
    {
        private List<int> list;

        public int heapSize
        {
            get
            {
                return this.list.Count();
            }
        }
        public void add(int value)
        {
            list.Add(value);
            int i = heapSize - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && list[parent] > list[i])
            {
                int temp = list[i];
                list[i] = list[parent];
                list[parent] = temp;

                i = parent;
                parent = (i - 1) / 2;
            }
        }
        public void heapify(int i)
        {
            int leftChild;
            int rightChild;
            int largestChild;

            for (; ; )
            {
                leftChild = 2 * i + 1;
                rightChild = 2 * i + 2;
                largestChild = i;

                if (leftChild < heapSize && list[leftChild] < list[largestChild])
                {
                    largestChild = leftChild;
                }

                if (rightChild < heapSize && list[rightChild] < list[largestChild])
                {
                    largestChild = rightChild;
                }

                if (largestChild == i)
                {
                    break;
                }

                int temp = list[i];
                list[i] = list[largestChild];
                list[largestChild] = temp;
                i = largestChild;
            }
        }
        public void buildHeap(List<int> sourceArray)
        {
            list = sourceArray.ToList();
            for (int i = heapSize / 2; i >= 0; i--)
            {
                heapify(i);
            }
        }

        public int getMin()
        {
            if (list.Count == 0)
                return -1;
            int result = list[0];
            list[0] = list[heapSize - 1];
            list.RemoveAt(heapSize - 1);
            heapify(0);
            return result;
        }
    }
}
