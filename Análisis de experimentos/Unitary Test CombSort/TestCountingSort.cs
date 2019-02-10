using System;
using Análisis_de_experimentos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unitary_Test_CombSort
{
    [TestClass]
    public class TestCountingSort
    {

        private Ordenamientos ordenamientos;

        private void fillArray(int[] a)
        {

            for(int i = 0; i < a.Length; i++)
            {
                a[i] = new Random().Next(1, a.Length) + i;
            }


        }

        [TestMethod]
        public void TestFactorOne()
        {

            ordenamientos = new Ordenamientos();
            int[] arrayOne = { 10, 40, 100, 2, 39, 21, 23, 43, 69, 88 };
            int[] ordenedArrayOne = ordenamientos.CountingSort(arrayOne);
            int[] toTry = { 2, 10, 21, 23, 39, 40, 43, 69, 88, 100 };

            for(int i = 0; i < ordenedArrayOne.Length; i++)
            {
                Assert.IsTrue(ordenedArrayOne[i] == toTry[i]);
            }

        }


        [TestMethod]
        public void TestFactorTwo()
        {

            ordenamientos = new Ordenamientos();
            int[] arrayOne = new int[1000];
            fillArray(arrayOne);
            int[] ordenedArrayOne = ordenamientos.CountingSort(arrayOne);

            for (int i = 0; i < ordenedArrayOne.Length - 1; i++)
            {
                Assert.IsTrue((ordenedArrayOne[i] - ordenedArrayOne[i + 1]) <= 0);
            }

        }


        [TestMethod]
        public void TestFactorThree()
        {

            ordenamientos = new Ordenamientos();
            int[] arrayOne = new int[10000];
            fillArray(arrayOne);
            int[] ordenedArrayOne = ordenamientos.CountingSort(arrayOne);


            for (int i = 0; i < ordenedArrayOne.Length - 1; i++)
            {
                Assert.IsTrue((ordenedArrayOne[i] - ordenedArrayOne[i + 1]) <= 0);
            }

        }


        [TestMethod]
        public void TestFactorFour()
        {

            ordenamientos = new Ordenamientos();
            int[] arrayOne = new int[1000000];
            fillArray(arrayOne);
            int[] ordenedArrayOne = ordenamientos.CountingSort(arrayOne);


            for (int i = 0; i < ordenedArrayOne.Length - 1; i++)
            {
                Assert.IsTrue((ordenedArrayOne[0] - ordenedArrayOne[1]) <= 0);
            }

        }
    }
}
