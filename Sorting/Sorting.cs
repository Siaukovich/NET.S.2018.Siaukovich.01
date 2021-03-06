﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sorting.cs" company="Epam">
//   
// </copyright>
// <summary>
//   Sorting class that contains methods for quicksort and mergesort.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sorting
{
    using System;

    /// <summary>
    /// Sorting class that contains methods for quicksort and mergesort.
    /// </summary>
    public static class Sorting
    {
        #region Public Methods

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
            ThrowForNull(array);

            Qsorting(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Quicksort algorithm. Subarray of passed array
        /// from left index to right index will become sorted.
        /// </summary>
        /// <param name="array">
        /// Array which subarray needs to be sorted.
        /// </param>
        /// <param name="left">
        /// Left subarray index.
        /// </param>
        /// <param name="right">
        /// Right subarray index.
        /// </param>
        public static void Qsort(int[] array, int left, int right)
        {
            ThrowForInvalidArguments(array, left, right);

            Qsorting(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Mergesort algorithm. Array that was passed to this function will become sorted.
        /// </summary>
        /// <param name="array">
        /// Array that needs to be sorted.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Array is null.
        /// </exception>
        public static void Mergesort(int[] array)
        {
            ThrowForNull(array);

            Mergesorting(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Mergesort algorithm. Subarray of passed array
        /// from left index to right index will become sorted.
        /// </summary>
        /// <param name="array">
        /// Array which subarray needs to be sorted.
        /// </param>
        /// <param name="left">
        /// Left subarray index.
        /// </param>
        /// <param name="right">
        /// Right subarray index.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Array is null.
        /// </exception>
        public static void Mergesort(int[] array, int left, int right)
        {
            ThrowForInvalidArguments(array, left, right);

            Mergesorting(array, 0, array.Length - 1);
        }
        
        #endregion

        #region Private Methods

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

            int randomPivotIndex = (left + right) / 2;
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

        /// <summary>
        /// Divides array into subarrays and sorts them.
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
        private static void Mergesorting(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int middle = (left + right) / 2;
            Mergesorting(array, left, middle);
            Mergesorting(array, middle + 1, right);

            Merge(array, left, middle, right);
        }

        /// <summary>
        /// Performs merging of sorted sub-arrays.
        /// </summary>
        /// <param name="array">
        /// Array that needs to be sorted.
        /// </param>
        /// <param name="left">
        /// Left index of sub-array.
        /// </param>
        /// <param name="middle">
        /// The middle.
        /// </param>
        /// <param name="right">
        /// Right index of sub-array.
        /// </param>
        private static void Merge(int[] array, int left, int middle, int right)
        {
            var leftSubarray = new int[middle - left + 1];
            var rightSubarray = new int[right - middle];

            for (int i = 0; i < leftSubarray.Length; ++i)
            {
                leftSubarray[i] = array[left + i];
            }

            for (int i = 0; i < rightSubarray.Length; ++i)
            {
                rightSubarray[i] = array[middle + 1 + i];
            }

            int leftIndex = 0;
            int rightIndex = 0;
            int arrayIndex = left;

            while (leftIndex < leftSubarray.Length && rightIndex < rightSubarray.Length)
            {
                if (leftSubarray[leftIndex] < rightSubarray[rightIndex])
                {
                    array[arrayIndex] = leftSubarray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    array[arrayIndex] = rightSubarray[rightIndex];
                    rightIndex++;
                }

                arrayIndex++;
            }

            // If there are still some elements in leftSubarray.
            while (leftIndex < leftSubarray.Length)
            {
                array[arrayIndex] = leftSubarray[leftIndex];
                leftIndex++;
                arrayIndex++;
            }

            // If there are still some elements in rightSubarray.
            while (rightIndex < rightSubarray.Length)
            {
                array[arrayIndex] = rightSubarray[rightIndex];
                rightIndex++;
                arrayIndex++;
            }
        }

        /// <summary>
        /// Checks if passed array is valid.
        /// </summary>
        /// <param name="array">
        /// Array that needs to be checked.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if array is null.
        /// </exception>
        private static void ThrowForNull(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
        }

        /// <summary>
        /// Checks if passed parameters are valid.
        /// </summary>
        /// <param name="array">
        /// Array which subarray needs to be sorted.
        /// </param>
        /// <param name="left">
        /// Left subarray index.
        /// </param>
        /// <param name="right">
        /// Right subarray index.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown in four cases: array is null, left  0, right &gt array.Length, left > right.
        /// </exception>
        private static void ThrowForInvalidArguments(int[] array, int left, int right)
        {
            ThrowForNull(array);

            if (left < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(left), $"{nameof(left)} can not be below 0.");
            }

            if (right > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(right), $"{nameof(right)} can not be more than array size (array.Length = {array.Length}.");
            }

            if (left > right)
            {
                throw new ArgumentOutOfRangeException(nameof(left), $"{nameof(left)} can not be more than {nameof(right)}. left = {left}, right = {right}");
            }
        }

        #endregion
    }
}