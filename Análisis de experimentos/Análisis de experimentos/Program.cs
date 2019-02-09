using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Análisis_de_experimentos
{
    class Ordenamientos
    {

        private TimeSpan stop;
        private TimeSpan start;
        private double time;

        public int[] CountingSort(int[] array)
        {

            start = new TimeSpan(DateTime.Now.Ticks);

            int[] count = new int[11];

            for (int i = 0; i < array.Length; i++)
            {
                int value = array[i];
                count[value]++;
            }

            for (int i = 1; i < count.Length; i++)
            {
                count[i] = count[i] + count[i - 1];
            }

            int[] sorted = new int[array.Length];

            for (int i = array.Length - 1; i >= 0; i--)
            {
                int value = array[i];
                int position = count[value] - 1;
                sorted[position] = value;

                count[value]--;
            }

            stop = new TimeSpan(DateTime.Now.Ticks);
            time = stop.Subtract(start).TotalMilliseconds;

            return sorted;
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

            int[] a = new int[1000000];
            Ordenamientos algoritmos = new Ordenamientos();

            for (int i = 0; i < a.Length; ++i)
            {
                a[i] = new Random().Next(100000);
            }

            algoritmos.CombSort(a);

            Console.WriteLine(algoritmos.time);
        }
    }
}
