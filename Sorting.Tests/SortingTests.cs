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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Quicksort_PassedNull_ThrowsArgumentNullException()
        {
            int[] a = null;
            Sorting.Qsort(a);
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
        public void Quicksort_Random100Test_AllSorted()
        {
            // Because of the constant seed we always have same test arrays.
            var rng = new Random(0);
            int testArraySize = 1000;
            for (int i = 0; i < 100; ++i)
            {
                int[] array = Enumerable.Range(0, testArraySize).Select(v => rng.Next(0, testArraySize)).ToArray();
                Sorting.Qsort(array);
                if (!IsSorted(array))
                {
                    // If test fails, you can set the breakpoint with condition "i == error_index".
                    Assert.Fail($"Array #{i} was not sorted.");
                }
            }
        }
        

        #endregion


        #region Mergesort tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
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
        public void Mergesort_ReversedArray_ReturnsSorted()
        {
            int arraySize = 100;
            int[] a = Enumerable.Range(0, arraySize).Reverse().ToArray();
            Sorting.Mergesort(a);
            Assert.IsTrue(IsSorted(a));
        }

        [TestMethod]
        public void Mergesort_Random100Test_AllSorted()
        {
            // Because of the constant seed we always have same test arrays.
            var rng = new Random(0);
            int testArraySize = 1000;
            for (int i = 0; i < 100; ++i)
            {
                int[] array = Enumerable.Range(0, testArraySize).Select(v => rng.Next(0, testArraySize)).ToArray();
                Sorting.Mergesort(array);
                if (!IsSorted(array))
                {
                    // If test fails, you can set the breakpoint with condition "i == error_index".
                    Assert.Fail($"Array #{i} was not sorted.");
                }
            }
        }
        

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
