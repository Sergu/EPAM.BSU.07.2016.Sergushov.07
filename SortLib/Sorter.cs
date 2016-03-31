using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSortLib
{
    public static class Sorter
    {
        public static void BubbleSort<T>(T[] arr, IComparer<T> comparer)
        {
            if (ReferenceEquals(arr, null))
                throw new NullReferenceException();
            if (ReferenceEquals(comparer, null))
                throw new NullReferenceException();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (comparer.Compare(arr[j], arr[j + 1]) > 0)
                    {
                        Swap<T>(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }
        public static void ShakerSort<T>(T[] arr, IComparer<T> comparer)
        {
            if (ReferenceEquals(arr, null))
                throw new NullReferenceException();
            if (ReferenceEquals(comparer, null))
                throw new NullReferenceException();

            int right = 0;
            int left = arr.Length - 1;
            int count = 0;

            while (right <= left)
            {
                for (int i = right; i < left; i++)
                {
                    count++;
                    if (comparer.Compare(arr[i], arr[i + 1]) > 0)
                        Swap<T>(ref arr[i], ref arr[i + 1]);
                }
                left--;

                for (int i = left; i > right; i--)
                {
                    count++;
                    if (comparer.Compare(arr[i - 1], arr[i]) > 0)
                        Swap<T>(ref arr[i - 1], ref arr[i]);
                }
                right++;
            }
        }
        private static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
    }
}
