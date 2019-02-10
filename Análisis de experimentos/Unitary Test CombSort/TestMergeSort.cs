using System;
using Análisis_de_experimentos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unitary_Test_CombSort
{
    [TestClass]
    public class TestMergeSort
    {

        private Ordenamientos ordenamientos;

        private void fillArray(int[] a)
        {
            for (int i = 0; i < a.Length; ++i)
            {
                if (i % 3 == 0)
                {
                    a[i] = -(new Random().Next(i * 200 + 1));
                }
                else
                {
                    a[i] = new Random().Next(i * 300 + 1);
                }
            }
        }

        [TestMethod]
        public void TestFactorOne()
        {

            ordenamientos = new Ordenamientos();
            int[] arrayOne = { 10, 40, 100, 2, 39, 21, 23, 43, 69, 88 };
            ordenamientos.MergeSort(arrayOne);
            int[] toTry = { 2, 10, 21, 23, 39, 40, 43, 69, 88, 100 };

            for (int i = 0; i < arrayOne.Length; i++)
            {
                Assert.IsTrue(arrayOne[i] == toTry[i]);
            }

        }

        [TestMethod]
        public void TestFactorTwo()
        {
            ordenamientos = new Ordenamientos();
            int[] arrayOne = new int[100];
            fillArray(arrayOne);
            ordenamientos.MergeSort(arrayOne);

            for (int i = 0; i < arrayOne.Length - 1; i++)
            {
                Assert.IsTrue((arrayOne[i] - arrayOne[i + 1]) <= 0);
            }

        }

        [TestMethod]
        public void TestFactorThree()
        {

            ordenamientos = new Ordenamientos();
            int[] arrayOne = new int[10000];
            fillArray(arrayOne);
            ordenamientos.MergeSort(arrayOne);

            for (int i = 0; i < arrayOne.Length - 1; i++)
            {
                Assert.IsTrue((arrayOne[i] - arrayOne[i + 1]) <= 0);
            }
        }


        [TestMethod]
        public void TestFactorFour()
        {

            ordenamientos = new Ordenamientos();
            int[] arrayOne = new int[1000000];
            fillArray(arrayOne);
            ordenamientos.MergeSort(arrayOne);

            for (int i = 0; i < arrayOne.Length - 1; i++)
            {
                Assert.IsTrue((arrayOne[i] - arrayOne[i + 1]) <= 0);
            }
        }

    }
}
