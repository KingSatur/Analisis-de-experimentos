package modelo;

public class MergeSort {

	static void merge(int[] list, int l, int m, int r) 
	{ 
	    int i, j, k; 
	    int n1 = m - l + 1; 
	    int n2 =  r - m; 
	  
	    Integer L[] = new Integer[n1]; 
	    Integer R[] = new Integer[n2];
	  
	    
	    for (i = 0; i < n1; i++) 
	        L[i] = list[l + i]; 
	    for (j = 0; j < n2; j++) 
	        R[j] = list[m + 1+ j];
	    
	    i = 0; 
	    j = 0;  
	    k = l; 
	    while (i < n1 && j < n2) 
	    { 
	        if (L[i] <= R[j]) 
	        { 
	            list[k] = L[i]; 
	            i++; 
	        } 
	        else
	        { 
	            list[k] = R[j]; 
	            j++; 
	        } 
	        k++; 
	    } 
	  
	    while (i < n1) 
	    { 
	        list[k] = L[i]; 
	        i++; 
	        k++; 
	    }
	    while (j < n2) 
	    { 
	        list[k] = R[j]; 
	        j++; 
	        k++; 
	    } 
	} 
	  
	
	static void mergeSort(int[] list, int l, int r) 
	{ 
	    if (l < r) 
	    { 
	        int m = l+(r-l)/2; 
	   
	        mergeSort(list, l, m); 
	        mergeSort(list, m+1, r); 
	        merge(list, l, m, r); 
	    } 
	}
}
