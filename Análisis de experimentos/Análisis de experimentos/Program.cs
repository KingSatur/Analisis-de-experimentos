using System;
using System.Collections.Generic;
using System.IO;
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
        public static double factor = 1000.000;

        private int[] fillArray(int n)
        {
            int[] a = new int[n];

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

            return a;
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
            start = new TimeSpan(DateTime.Now.Ticks);

            MergeSort(input, 0, input.Length - 1);

            stop = new TimeSpan(DateTime.Now.Ticks);
            time = stop.Subtract(start).TotalMilliseconds;

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

        public void generarRepeticiones()
        {

            for(int j = 0; j < 4; j++)
            {
                Stream fs = new FileStream("./MergeSortFactor" + (j + 1) + ".txt", FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);

                for(int i = 0; i < 50; i++)
                {
                    if((j + 1) == 1)
                    {
                        MergeSort(fillArray(10000));
                        writer.WriteLine(time * factor);
                    }
                    else if((j + 1) == 2)
                    {
                        MergeSort(fillArray(100000));
                        writer.WriteLine(time * factor);
                    }
                    else if((j + 1) == 3)
                    {
                        MergeSort(fillArray(1000000));
                        writer.WriteLine(time * factor);
                    }

                }


                writer.Close();
                fs.Close();
            }
        }

        public void generarRepeticion2()
        {

            for (int j = 0; j < 4; j++)
            {
                Stream fs = new FileStream("./CombSortFactor" + (j + 1) + ".txt", FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);

                for (int i = 0; i < 50; i++)
                {
                    if ((j + 1) == 1)
                    {
                        CombSort(fillArray(10000));
                        writer.WriteLine(time * factor);
                    }
                    else if ((j + 1) == 2)
                    {
                        CombSort(fillArray(100000));
                        writer.WriteLine(time * factor);
                    }
                    else if ((j + 1) == 3)
                    {
                        CombSort(fillArray(1000000));
                        writer.WriteLine(time * factor);
                    }

                }

                writer.Close();
                fs.Close();
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

            Ordenamientos m = new Ordenamientos();
            m.generarRepeticion2();
 
           


           
        }
    }
}
