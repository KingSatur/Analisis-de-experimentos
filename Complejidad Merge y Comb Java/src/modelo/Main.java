package modelo;

import java.io.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Main {
	
	static void save(List<String> datos) {
		
		File f = new File("C:\\Users\\JOSE2\\OneDrive\\Documentos\\LabPI1\\Analisis-de-experimentos\\Complejidad Merge y Comb Java\\Files\\Time.txt");
		BufferedWriter bw;
		File f2 = new File("C:\\Users\\JOSE2\\OneDrive\\Documentos\\LabPI1\\Analisis-de-experimentos\\Complejidad Merge y Comb Java\\Files\\Space.txt");
		BufferedWriter bw2;
		
		
		try {
			
			bw =  new BufferedWriter(new FileWriter(f));
			bw2 =  new BufferedWriter(new FileWriter(f2));
			for (String s : datos) {
				String ss[] = s.split(" ");
				bw.write(ss[0]);
				bw.newLine();
				bw2.write(ss[1]);
				bw2.newLine();
			}

			bw.close();
			bw2.close();
			
			System.out.println("Listo");
			
		}catch ( Exception e){
			
		}
	}
	
	private static String listToString(List<String> datos) {
		String r = "";
		for (String s : datos) {
			r +=s+"\n";
		}
		return r;
	}
	
	static List<String>  MergeTimeInfo (int[] list) {
		List<String> data = new ArrayList<>();
		for (int i = 0; i < 50; i++) {
			MergeSort m = new MergeSort();
			int cont = 0;
			Randomizer(list, cont);
			long inicio_NS = System.nanoTime();
			m.mergeSort(list, 0, list.length - 1);
			//c.sort(arre);
			long duracion_NS = System.nanoTime()-inicio_NS;
			
			cont += (Integer.BYTES*list.length)+((list.length*Math.log(list.length))* Integer.BYTES);
			
			data.add(duracion_NS+" "+cont);
		}
		System.out.println("Merge Ready");
		return data;
	}
	
	static List<String>  CombTimeInfo (int[] list) {
		List<String> data = new ArrayList<>();
		for (int i = 0; i < 50; i++) {
			CombSort c = new CombSort();
			int cont = 0;
			Randomizer(list, cont);
			long inicio_NS = System.nanoTime();
			c.sort(list);
			//c.sort(arre);
			long duracion_NS = System.nanoTime()-inicio_NS;
			
			cont += (Integer.BYTES*list.length)+(2* Integer.BYTES);			
			data.add(duracion_NS+" "+cont);
		}
		System.out.println("Comb Ready");
		return data;
	}
	
	static private int[] Randomizer(int[] list, int cont){
		
		for (int i = 0; i < list.length; i++) {
			Integer a = new Random().nextInt();
			list[i] = a;
			cont += a.BYTES;
			
		}
		//System.out.println(cont);
		return list;
	}
	
	public static void main(String[] args) {
		
		int[] arr1 =  new int[(int)Math.pow(10, 4)];
		int[] arr2 =  new int[(int)Math.pow(10, 5)];
		int[] arr3 =  new int[(int)Math.pow(10, 6)];
		
		List<String> s = new ArrayList<>();
		
		//Merge
		s.addAll(MergeTimeInfo(arr1));
		s.addAll(MergeTimeInfo(arr2));
		s.addAll(MergeTimeInfo(arr3));
		
		//Comb
		s.addAll(CombTimeInfo(arr1));
		s.addAll(CombTimeInfo(arr2));
		s.addAll(CombTimeInfo(arr3));
		
		save(s);
	}

}
