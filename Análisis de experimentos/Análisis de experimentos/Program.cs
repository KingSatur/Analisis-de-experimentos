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

            for (int i = 0; i <= n - 1; i++)
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

        public void MergeSort(int[] input, int low, int high)
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSort(input, low, middle);
                MergeSort(input, middle + 1, high);
                Merge(input, low, middle, high);
            }
        }

        public void MergeSort(int[] input)
        {
            MergeSort(input, 0, input.Length - 1);
        }

        private void Merge(int[] input, int low, int middle, int high)
        {

            int left = low;
            int right = middle + 1;
            int[] tmp = new int[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left] < input[right])
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                }
                tmpIndex = tmpIndex + 1;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
            }

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
           
            int[] a = new int[100];

            for (int i = 0; i < a.Length; ++i)
            {
                if(i % 3 == 0)
                {
                    a[i] =-(new Random().Next(i * 200 + 1));
                }
                else
                {
                    a[i] = new Random().Next(i * 300 + 1);
                }
               
            
            }

            algoritmos.MergeSort(a);
        
            for(int i =0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
           


           
        }
    }
}
