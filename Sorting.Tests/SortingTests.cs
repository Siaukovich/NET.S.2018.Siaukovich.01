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
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergesortThrowsIfNull()
        {
            int[] a = null;
            Sorting.Mergesort(a);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuicksortThrowsIfNull()
        {
            int[] a = null;
            Sorting.Qsort(a);
        }

        [TestMethod]
        public void QuicksortForOneElement()
        {
            int[] a = { 1 };
            Sorting.Qsort(a);
            Assert.IsTrue(a[0] == 1 && a.Length == 1);
        }

        [TestMethod]
        public void MergesortForOneElement()
        {
            int[] a = { 1 };
            Sorting.Mergesort(a);
            Assert.IsTrue(a[0] == 1 && a.Length == 1);
        }

        [TestMethod]
        public void QuicksortRandom100Test()
        {
            var rng = new Random(0);
            int size = 1000;
            for (int i = 0; i < 100; ++i)
            {
                int[] array = Enumerable.Range(0, size).Select(v => rng.Next(v)).ToArray();
                Sorting.Qsort(array);
                Assert.IsTrue(IsSorted(array));
            }
        }

        [TestMethod]
        public void MergesortRandom100Test()
        {
            var rng = new Random(0);
            int size = 1000;
            for (int i = 0; i < 100; ++i)
            {
                int[] array = Enumerable.Range(0, size).Select(v => rng.Next(v)).ToArray();
                Sorting.Mergesort(array);
                Assert.IsTrue(IsSorted(array));
            }
        }

        private static bool IsSorted(int[] a)
        {
            for (int i = 1; i < a.Length; ++i)
                if (a[i] < a[i - 1])
                    return false;

            return true;
        }
    }
}
