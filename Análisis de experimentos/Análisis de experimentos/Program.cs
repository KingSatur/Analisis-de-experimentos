using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Análisis_de_experimentos
{
    public class Ordenamientos
    {

        private TimeSpan stop;
        private TimeSpan start;
        private double time;

        public int[] CountingSort(int[] A)
        {

            start = new TimeSpan(DateTime.Now.Ticks);

            int n = A.Length - 1;
            int k = A[0];
            for (int i = 1; i <= n; i++)
            {
                if (A[i] > k)
                {
                    k = A[i];
                }
            }
            int[] C = new int[k + 1];

            for (int i = 0; i <= k; i++)
            {
                C[i] = 0;
            }
            for (int i = 0; i <= n; i++)
            {
                C[A[i]] = C[A[i]] + 1;
            }
            for (int i = 1; i <= k; i++)
            {
                C[i] = C[i] + C[i - 1];
            }
            int[] B = new int[n + 1];
            for (int i = n; i >= 0; i--)
            {
                C[A[i]] = C[A[i]] - 1;
                B[C[A[i]]] = A[i];
            }

            stop = new TimeSpan(DateTime.Now.Ticks);
            time = stop.Subtract(start).TotalMilliseconds;

            return B;

        }

        private int getNextGap(int gap)
        {
            // Reduccion de contraccion 
            gap = (gap * 10) / 13;
            if (gap < 1)
                return 1;
            return gap;
        }
 
        public void CombSort(int[] arr)
        {

            start = new TimeSpan(DateTime.Now.Ticks);

            int n = arr.Length;

            // Inicializar la brecha
            int gap = n;

            //Inicializarla en true para entre al while 
            bool swapped = true;

            //Mientras la brecha sea > 1 se mantendra y realizara intercambios
            while (gap != 1 || swapped == true)
            {
                // Calculara la proxima brecha
                gap = getNextGap(gap);

                // Cambiarla a falso para saber si hubo intercambio
                swapped = false;

                // Compara los elementos que estan a la distancia que indica la brecha 
                for (int i = 0; i < n - gap; i++)
                {
                    if (arr[i] > arr[i + gap])
                    {
                        // Intercambia arr[i] con arr[i+gap] 
                        int temp = arr[i];
                        arr[i] = arr[i + gap];
                        arr[i + gap] = temp;

                        //Se coloca true porque se realizo un intercambio anteriormente
                        swapped = true;
                    }
                }
            }

            stop = new TimeSpan(DateTime.Now.Ticks);
            time = stop.Subtract(start).TotalMilliseconds;

        }

        public static void Main(string[] args)
        {

            Ordenamientos algoritmos = new Ordenamientos();
            /**
            int[] a = new int[1000000];

            for (int i = 0; i < a.Length; ++i)
            {
                a[i] = new Random().Next(100000);
            }
            **/

            /**
            algoritmos.CountingSort(a);

            Console.WriteLine(algoritmos.time);
            **/

            int[] arrayOne = { 10, 40, 100, 2, 39, 21, 23, 43, 69, 88 };
            int[] ordenedArrayOne = algoritmos.CountingSort(arrayOne);

            for(int i =0; i < ordenedArrayOne.Length; i++)
            {
                Console.WriteLine(ordenedArrayOne[i]);
            }


           
        }
    }
}
