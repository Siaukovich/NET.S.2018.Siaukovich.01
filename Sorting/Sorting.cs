using System.Net.NetworkInformation;

namespace Sorting
{
    using System;

    /// <summary>
    /// Sorting class that contains methods for quicksort and mergesort.
    /// </summary>
    public static class Sorting
    {
        /// <summary>
        /// Quicksort algorithm. Array that was passed to this function will become sorted.
        /// </summary>
        /// <param name="array">
        /// Array that needs to be sorted.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Array is null.
        /// </exception>
        public static void Qsort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            Qsorting(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Method responsible for choosing pivot element and partitioning array.
        /// </summary>
        /// <param name="array">
        /// Array that needs to be sorted.
        /// </param>
        /// <param name="left">
        /// Left index of sub-array.
        /// </param>
        /// <param name="right">
        /// Right index of sub-array.
        /// </param>
        private static void Qsorting(int[] array, int left, int right)
        {
            if (left > right)
            {
                return;
            }

            var rng = new Random();
            int randomPivotIndex = rng.Next(left, right + 1);
            int pivotIndex = Partition(array, left, right, randomPivotIndex);

            Qsorting(array, left, pivotIndex - 1);
            Qsorting(array, pivotIndex + 1, right);
        }

        /// <summary>
        /// Rearranges elements in array in the way that elements that are larger than 
        /// the pivot are in the right side of it and elements that are lower that the
        /// pivot are in the left side of it.
        /// </summary>
        /// <param name="array">
        /// Array that needs to be sorted.
        /// </param>
        /// <param name="left">
        /// Left index of sub-array.
        /// </param>
        /// <param name="right">
        /// Right index of sub-array.
        /// </param>
        /// <param name="pivotIndex">
        /// The pivot element index.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
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

        /// <summary>
        /// Swaps two elements.
        /// </summary>
        /// <param name="a">
        /// First element.
        /// </param>
        /// <param name="b">
        /// Second element.
        /// </param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}