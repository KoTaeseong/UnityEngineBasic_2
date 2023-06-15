using  SortAlgorithms;
using System.Diagnostics;

int[] arr = { 1, 4, 3, 3, 9, 8, 7, 2, 5, 0 };
Random random = new Random();
arr = Enumerable.Repeat(0, 1000).Select(i => random.Next(0, 100000)).ToArray() ;

Stopwatch stopwatch= Stopwatch.StartNew();

//SortAlgorithms.SortAlgorithms.InsertionSort(arr); // 100000 5000ms
//SortAlgorithms.SortAlgorithms.SelectionSort(arr); // 100000 7500ms
//SortAlgorithms.SortAlgorithms.BubbleSort(arr); // 100000 31400ms
//SortAlgorithms.SortAlgorithms.MergeSort(arr); // 100000 12000ms
SortAlgorithms.SortAlgorithms.QuickSort(arr); // 100000 ms
stopwatch.Stop();

//for (int i = 0; i < arr.Length; i++)
//{
//    Console.Write($"{arr[i]}, ");
//}
Console.WriteLine($"Elapsed {stopwatch.ElapsedMilliseconds} ms");
