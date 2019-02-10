	package modelo;

public class CombSort {
	//para encontrar la brecha entre los elementos.
	int getNextGap(int gap) 
    { 
        //Reducción de la brecha por factor de contracción  
        gap = (gap*10)/13; 
        if (gap < 1) 
            return 1; 
        return gap; 
    } 
  
    // Función para ordenar arr [] usando Comb Sort
    void sort(int arr[]) 
    { 
        int n = arr.length; 
  
        // inicialización de la brecha
        int gap = n; 
  
        // se  Inicializa swapped como true para asegurarse 
        //de que el bucle se ejecuta
        boolean swapped = true;
        
        while (gap != 1 || swapped == true) 
        { 
            gap = getNextGap(gap); 

            swapped = false; 
  
            // Compara todos los elementos con la brecha actual.
            for (int i=0; i<n-gap; i++) 
            { 
                if (arr[i] > arr[i+gap]) 
                { 
                    // intercambiar arr[i] y arr[i+gap] 
                    int temp = arr[i]; 
                    arr[i] = arr[i+gap]; 
                    arr[i+gap] = temp;  
                    swapped = true; 
                } 
            } 
        } 
    } 

}
