package test;

import static org.junit.jupiter.api.Assertions.*;

import java.util.Random;

import org.junit.Assert;
import org.junit.jupiter.api.Test;

import modelo.CombSort;

class TestCombSort {


	 private CombSort ordenamientos;

	 void fillArray(int[] a)
	    {
	        for (int i = 0; i < a.length; ++i)
	        {
	            if (i % 3 == 0)
	            {
	                a[i] = -(new Random().nextInt(i * 200 + 1));
	            }
	            else
	            {
	                a[i] = new Random().nextInt(i * 300 + 1);
	            }
	        }
	    }


     @Test
     public void TestFactorOne()
     {

         ordenamientos = new CombSort();
         int[] arrayOne = new int[10000];
         fillArray(arrayOne);
         ordenamientos.sort(arrayOne);

         for (int i = 0; i < arrayOne.length - 1; i++)
         {
             Assert.assertTrue((arrayOne[i] - arrayOne[i + 1]) <= 0);
         }

     }

     @Test
     public void TestFactorTwo()
     {

         ordenamientos = new CombSort();
         int[] arrayOne = new int[100000];
         fillArray(arrayOne);
         ordenamientos.sort(arrayOne);

         for (int i = 0; i < arrayOne.length - 1; i++)
         {
             Assert.assertTrue((arrayOne[i] - arrayOne[i + 1]) <= 0);
         }

     }

     @Test
     public void TestFactorThree()
     {


         ordenamientos = new CombSort();
         int[] arrayOne = new int[1000000];
         fillArray(arrayOne);
         ordenamientos.sort(arrayOne);

         for (int i = 0; i < arrayOne.length - 1; i++)
         {
             Assert.assertTrue((arrayOne[i] - arrayOne[i + 1]) <= 0);
         }

     }


}
