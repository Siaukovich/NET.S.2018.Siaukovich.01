namespace Sorting.Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for Sorting class.
    /// </summary>
    [TestClass]
    public class SortingTests
    {
        #region Quicksort tests

        #region Full array sorting

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Quicksort_PassedNull_ThrowsArgumentNullException()
        {
            int[] a = null;
            Sorting.Qsort(a);
        }

        [TestMethod]
        public void Quicksort_EmptyArray_ReturnsEmptyArray()
        {
            int[] a = new int[0];
            Sorting.Qsort(a);
            Assert.IsTrue(a.Length == 0);
        }

        [TestMethod]
        public void Quicksort_OneElementArray_ReturnsSameArray()
        {
            int[] a = { 1 };
            int[] b = { 1 };
            Sorting.Qsort(a);
            Assert.IsTrue(a.SequenceEqual(b));
        }

        [TestMethod]
        public void Quicksort_ReversedArray_ReturnsSorted()
        {
            int arraySize = 100;
            int[] a = Enumerable.Range(0, arraySize).Reverse().ToArray();
            Sorting.Qsort(a);
            Assert.IsTrue(IsSorted(a));
        }

        [TestMethod]
        public void Quicksort_VeryBigArray_ReturnsSorted()
        {
            // Because of the constant seed we always have same test arrays.
            var rng = new Random(0);
            const int testArraySize = 10000000; // 10 000 000.
            int[] array = Enumerable.Repeat(0, testArraySize)
                .Select(v => rng.Next(-testArraySize, testArraySize))
                .ToArray();

            Sorting.Qsort(array);
            Assert.IsTrue(IsSorted(array));
        }

        [TestMethod]
        public void Quicksort_Random100Test_AllSorted()
        {
            // Because of the constant seed we always have same test arrays.
            var rng = new Random(0);
            int testArraySize = 1000;
            for (int i = 0; i < 100; ++i)
            {
                int[] array = Enumerable.Repeat(0, testArraySize)
                    .Select(v => rng.Next(-testArraySize, testArraySize))
                    .ToArray();

                Sorting.Qsort(array);
                if (!IsSorted(array))
                {
                    // If test fails, you can set the breakpoint with condition "i == errorIndex".
                    Assert.Fail($"Array #{i} was not sorted.");
                }
            }
        }
        

            #endregion

        #region Subarray sorting

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Quicksort_NullArraySubarraySorting_ThrowsArgumentNullException() =>
            Sorting.Qsort(null, 1, 4);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Quicksort_RightSubarrayBorderOutOfRange_ThrowsArgumentOutOfRangeException() =>
            Sorting.Qsort(Enumerable.Range(0, 100).ToArray(), 1, 101);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Quicksort_LeftSubarrayBorderOutOfRange_ThrowsArgumentOutOfRangeException() =>
            Sorting.Qsort(Enumerable.Range(0, 100).ToArray(), -1, 10);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Quicksort_LeftSubarrayBorderIsGreaterThanRight_ThrowsArgumentOutOfRangeException() =>
            Sorting.Qsort(Enumerable.Range(0, 100).ToArray(), 11, 1);

        [TestMethod]
        public void Quicksort_SortingSubarray_PartiallySortedArray()
        {
            var rng = new Random(0);
            int testArraySize = 100;
            int[] array = Enumerable.Range(0, testArraySize)
                .Select(v => rng.Next(-testArraySize, testArraySize))
                .ToArray();

            Sorting.Qsort(array, 1, 11);
            Assert.IsTrue(IsSorted(array.Skip(1).Take(10).ToArray()));
        }

        [TestMethod]
        public void Quicksort_SortingBigSubarray_PartiallySortedArray()
        {
            var rng = new Random(0);
            int testArraySize = 1000000;
            int[] array = Enumerable.Range(0, testArraySize)
                .Select(v => rng.Next(-testArraySize, testArraySize))
                .ToArray();

            int lowerBound = 20000;
            int higherBound = 500000;
            int subarrayLength = higherBound - lowerBound;

            Sorting.Qsort(array, lowerBound, higherBound);
            Assert.IsTrue(IsSorted(array.Skip(lowerBound).Take(subarrayLength).ToArray()));
        }

        #endregion

        #endregion


        #region Mergesort tests

        #region Full array sorting

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Mergesort_PassedNull_ThrowsArgumentNullException()
        {
            int[] a = null;
            Sorting.Mergesort(a);
        }

        [TestMethod]
        public void Mergesort_OneElementArray_ReturnsSameArrayy()
        {
            int[] a = { 1 };
            int[] b = { 1 };
            Sorting.Mergesort(a);
            Assert.IsTrue(a.SequenceEqual(b));
        }

        [TestMethod]
        public void Mergesort_EmptyArray_ReturnsEmptyArray()
        {
            int[] a = new int[0];
            Sorting.Mergesort(a);
            Assert.IsTrue(a.Length == 0);
        }

        [TestMethod]
        public void Mergesort_ReversedArray_ReturnsSorted()
        {
            int arraySize = 100;
            int[] a = Enumerable.Range(0, arraySize).Reverse().ToArray();
            Sorting.Mergesort(a);
            Assert.IsTrue(IsSorted(a));
        }

        [TestMethod]
        public void Mergesort_VeryBigArray_ReturnsSorted()
        {
            // Because of the constant seed we always have same test arrays.
            var rng = new Random(0);
            const int testArraySize = 10000000; // 10 000 000.
            int[] array = Enumerable.Repeat(0, testArraySize)
                .Select(v => rng.Next(-testArraySize, testArraySize))
                .ToArray();

            Sorting.Mergesort(array);
            Assert.IsTrue(IsSorted(array));
        }

        [TestMethod]
        public void Mergesort_Random100Test_AllSorted()
        {
            // Because of the constant seed we always have same test arrays.
            var rng = new Random(0);
            int testArraySize = 1000;
            for (int i = 0; i < 100; ++i)
            {
                int[] array = Enumerable.Repeat(0, testArraySize)
                    .Select(v => rng.Next(-testArraySize, testArraySize))
                    .ToArray();

                Sorting.Mergesort(array);
                if (!IsSorted(array))
                {
                    // If test fails, you can set the breakpoint with condition "i == errorIndex".
                    Assert.Fail($"Array #{i} was not sorted.");
                }
            }
        }

        #endregion

        #region Subarray sorting

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Mergesort_NullArraySubarraySorting_ThrowsArgumentNullException() => 
            Sorting.Mergesort(null, 1, 4);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Mergesort_RightSubarrayBorderOutOfRange_ThrowsArgumentOutOfRangeException() =>
            Sorting.Mergesort(Enumerable.Range(0, 100).ToArray(), 1, 101);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Mergesort_LeftSubarrayBorderOutOfRange_ThrowsArgumentOutOfRangeException() =>
            Sorting.Mergesort(Enumerable.Range(0, 100).ToArray(), -1, 10);

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Mergesort_LeftSubarrayBorderIsGreaterThanRight_ThrowsArgumentOutOfRangeException() =>
            Sorting.Mergesort(Enumerable.Range(0, 100).ToArray(), 11, 1);

        [TestMethod]
        public void Mergesort_SortingSubarray_PartiallySortedArray()
        {
            var rng = new Random(0);
            int testArraySize = 100;
            int[] array = Enumerable.Range(0, testArraySize)
                .Select(v => rng.Next(-testArraySize, testArraySize))
                .ToArray();

            Sorting.Mergesort(array, 1, 11);
            Assert.IsTrue(IsSorted(array.Skip(1).Take(10).ToArray()));
        }

        [TestMethod]
        public void Mergesort_SortingBigSubarray_PartiallySortedArray()
        {
            var rng = new Random(0);
            int testArraySize = 1000000;
            int[] array = Enumerable.Range(0, testArraySize)
                .Select(v => rng.Next(-testArraySize, testArraySize))
                .ToArray();

            int lowerBound = 20000;
            int higherBound = 500000;
            int subarrayLength = higherBound - lowerBound;

            Sorting.Mergesort(array, lowerBound, higherBound);
            Assert.IsTrue(IsSorted(array.Skip(lowerBound).Take(subarrayLength).ToArray()));
        }
        

        #endregion

        #endregion


        /// <summary>
        /// Checks if passed array is sorted.
        /// </summary>
        /// <param name="a">
        /// Array that needs to be checked.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True if array is sorted, false otherwise.
        /// </returns>
        private static bool IsSorted(int[] a)
        {
            for (int i = 1; i < a.Length; ++i)
            {
                if (a[i] < a[i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
