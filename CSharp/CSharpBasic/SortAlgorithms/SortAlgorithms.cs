﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    internal class SortAlgorithms
    {
        #region Bubble Sort
        /// <summary>
        /// 거품정렬
        /// 처음부터 끝까지 순회하면서 바로뒤의 요소가 현재 요소보다 작으면 스왑
        /// 위 과정을 N -1 번 수행.
        /// 한번 전체 스왑을 할 때마다 가장 마지막 자리가 고정됨.
        /// Stable. (정렬후에 정렬전의 순서가 보장됨)
        /// O(N^2)
        /// </summary>
        public static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }
        #endregion

        #region Selection Sort
        /// <summary>
        /// 선택정렬
        /// 처음부터 끝까지 순회하면서 현재 값보다 작은 값을 가진 인덱스를 찾아 스왑.
        /// 한번 outer 돌때마다 가장 작은 인덱스가 고정됨.
        /// UnStable. (정렬후에 정렬전의 순서가 보장안됨)
        /// O(N^2)
        /// </summary>
        public static void SelectionSort(int[] arr)
        {
            int minIdx = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                minIdx = i;
                //i 뒤의 가장 작은 값을 가진 인덱스 찾기
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIdx])
                        minIdx = j;
                }

                //i뒤에 더 작은 값의 인덱스를 찾았으면 스탑
                if (i != minIdx)
                    Swap(ref arr[i], ref arr[minIdx]);
            }
        }

        #endregion

        #region Insertion Sort
        /// <summary>
        /// 삽입 정렬
        /// 현재 위치보다 이전 위치들 중에서 더 큰값이 있으면 더 큰값으로 현재 위치에 덮어쓰고
        /// 덮어쓰기가 끝나면 마지막으로 덮어쓸 때 참조했던 위치에 현재 위치 값을 덮어씀.
        /// 현재 탐색 위치 이전까지의 모든 인덱스가 정렬된 상태를 유지하면서 정렬진행
        /// O(N^2)
        /// </summary>
        public static void InsertionSort(int[] arr)
        {
            int j, key;

            for (int i = 1; i < arr.Length; i++)
            {
                key = arr[i];
                j = i - 1;
                while (j >= 0 &&
                        arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        #endregion

        #region Merge Sort
        /// <summary>
        /// 병합 정렬
        /// Ω(NlogN)
        /// θ(NlogN)
        /// O(NlogN)
        /// 공간복잡도 O(n)
        /// stable
        /// </summary>
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        public static void MergeSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int mid = end + (start - end) / 2 - 1; // == (start + end) / 2 
                //start와 end의 합연산 결과가 int의 표현보다 높을경우 오버플로우가 일어나는것을 방지하기 위함
                MergeSort(arr, start, mid);
                MergeSort(arr, mid + 1, end);

                Merge(arr, start, mid, end);
            }
        }

        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int[] origin = new int[end + 1];
            for (int i = 0; i < end + 1; i++)
                origin[i] = arr[i];

            int part1 = start;
            int part2 = mid + 1;
            int tmp = start;

            while (part1 <= mid && part2 <= end)
            {
                if (origin[part1] <= origin[part2])
                {
                    arr[tmp++] = origin[part1++];
                    //tmp++;
                    //part1++;
                }
                else
                {
                    arr[tmp++] = origin[part2++];
                }
            }

            //남은 part1 들을 tmp 위치에 쭉 이어서 덮어쓴다
            for (int i = 0; i < mid - part1; i++)
            {
                arr[tmp + i] = origin[part1 + i];
            }
        }

        #endregion

        #region QuickSort
        /// <summary>
        /// 빠른정렬
        /// Ω(NlogN)
        /// θ(NlogN)
        /// O(N^2)
        /// UnStable
        /// </summary>
        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length -1);
        }

        public static void QuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(arr, start, end);
                QuickSort(arr, start, pivot - 1);
                QuickSort(arr, pivot + 1, end);
            }
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int standard = arr[end + (start - end) / 2 - 1];

            while (true)
            {
                while (arr[start] < standard) start++;
                while (arr[end] > standard) end--;

                if (start < end)
                    Swap(ref arr[start], ref arr[end]);
                else
                    return end;
            }
        }

        #endregion

        #region HeapSort
        /// <summary>
        /// 힙 정렬
        /// Heap 자료구조로 변환하여 정렬하는 방법,
        /// 한번 SIFT 연산할때마다 Min 혹은 Max값이 하나씩 고정됨.
        /// 트리형태 구조 특성상 O(N Log N)의 시간복잡도를 가짐
        /// </summary>

        public static void HeapSort(int[] arr)
        {
            //Max 힙 구조로 변환
            HeapifyTopDown(arr);
            //HeapifyBottomUp(arr);

            InverseHeapify(arr);
        }

        public static void InverseHeapify(int[] arr)
        {
            int end = arr.Length- 1;
            while (end > 0)
            {
                Swap(ref arr[0], ref arr[end]);
                end--;
                SIFT_Down(arr, end, 1);
            }
        }

        /// <summary>
        /// O(N)
        /// </summary>
        public static void HeapifyBottomUp(int[] arr)
        {
            int end = arr.Length -1;
            int current = end;
            while (current >= 0)
            {
                SIFT_Down(arr, end, current--);
            }
        }

        /// <summary>
        /// O(NLogN)
        /// </summary>
        public static void HeapifyTopDown(int[] arr)
        {
            int end = 1;
            while (end < arr.Length)
            {
                SIFT_Up(arr, 0, end++);
            }
        }

        public static void SIFT_Up(int[] arr,int root, int current)
        {
            int parent = (current - 1) / 2;
            while (current > root)
            {
                if (arr[current] > arr[parent])
                {
                    Swap(ref arr[current], ref arr[parent]);
                    current = parent;
                    parent = (current - 1) / 2;
                }
                else
                {
                    return;
                }
            }
        }

        public static void SIFT_Down(int[] arr, int end, int current)
        {
            int parent = (current - 1) / 2;

            while (current <= end)
            {
                //오른쪽 자식이 더 크면 오른쪽을 스왑
                if (current + 1 <= end &&
                    arr[current] < arr[current + 1])
                    current++;

                if (arr[current] > arr[parent])
                {
                    Swap(ref arr[current], ref arr[parent]);
                    parent = current;
                    current = parent * 2 + 1;   //왼쪽자식으로감
                }
                else
                {
                    return;
                }
            }
        }

        #endregion

        //ref 키워드
        //인자를 참조형태로 받을 때 사용
        private static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
    }
}
