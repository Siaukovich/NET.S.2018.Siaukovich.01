namespace Sorting
{
    using System;

    /// <summary>
    /// Sorting class that contains methods for quicksort and mergesort.
    /// </summary>
    public static class Sorting
    {
        public static void Qsort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Qsorting(array, 0, array.Length - 1);
        }

        private static void Qsorting(int[] array, int left, int right)
        {
            if (left > right)
                return;

            var rng = new Random();
            int randomPivotIndex = rng.Next(left, right + 1);
            int pivotIndex = Partition(array, left, right, randomPivotIndex);

            Qsorting(array, left, pivotIndex - 1);
            Qsorting(array, pivotIndex + 1, right);
        }

        private static int Partition(int[] array, int left, int right, int pivotIndex)
        {
            int pivot = array[pivotIndex];
            Swap(ref array[pivotIndex], ref array[right]);
            int swapPosition = left;

            for (int i = left; i < right; ++i)
            {
                if (array[i] < pivot)
                {
                    Swap(ref array[i], ref array[swapPosition]);
                    swapPosition++;
                }
            }

            Swap(ref array[swapPosition], ref array[right]);
            return swapPosition;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
