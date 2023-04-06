﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    // Generic : 클래스 혹은 함수의 틀을 만드는 디자인, 특정 타입에 대해 클래스 혹은 함수가 사용될 경우,
    // "컴파일 타임" 에 해당 타입에 대한 클래스 혹은 함수가 정의됨.

    // Generic class의 where 제한자 : Generic의 타입에 제한을 걸 때 사용
    // (ex. T 타입은 반드시 IComparable<T> 또는 IComparable을 상속받은 타입이어야 한다
    internal class MyDynamicArray<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public int Capacity
        {
            get
            {
                return _data.Length;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public T this[int index]
        {
            get
            {
                return _data[index];
            }
            set
            {
                _data[index] = value;
            }
        }
        private const int DEFAULT_SIZE = 1;
        private T[] _data = new T[DEFAULT_SIZE];
        private int _count = 0;

        //삽입 알고리즘
        //일반적인 경우에 O(1)
        //공간이 모자를 경우에 기존 데이터를 전부 순회하면서 복제해야하기 때문에 O(N)
        public void Add(T item)
        {
            //삽입 공간이 모자랄 경우
            if (_count >= _data.Length)
            {
                //1. 더큰 크기의 새로운 배열을 만든다.
                T[] tmp = new T[_data.Length + (int)Math.Ceiling(Math.Log10(_data.Length))+DEFAULT_SIZE];

                //2. 기존 데이터를 복제한다.
                for (int i = 0; i < _count; i++)
                {
                    tmp[i] = _data[i];
                }

                //3. 데이터배열 참조를 새로운 배열로 바꿔준다.
                _data = tmp;
            }

            _data[_count] = item;
            _count++;
        }

        //탐색 알고리즘
        // O(N)
        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                //if (Comparer<T>.Default.Compare(_data[i], item) == 0)
                if (item.CompareTo(_data[i])==0)
                    return true;
            }
            return false;
        }

        public int FindIndex(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                //if (Comparer<T>.Default.Compare(_data[i], item) == 0)
                if (item.CompareTo(_data[i]) == 0)
                    return i;
            }

            return -1;
        }

        public T Find(Predicate<T> match)
        {
            for (int i = 0; i < _count; i++)
            {
                if (match.Invoke(_data[i]))
                    return _data[i];
            }
            return default(T);
        }

        // 삭제 알고리즘
        // O(N)
        public void RemoveAt(int index)
        {
            //지우고자하는 인덱스 뒤부터 끝까지를 한칸씩 앞으로 당김
            for (int i = index; i < _count -1; i++)
            {
                _data[i] = _data[i + 1];
            }
            _count--;
            _data[_count] = default(T);
        }

        public bool Remove(T item)
        {
            int index = FindIndex(item);

            if (index < 0)
                return false;
            RemoveAt(index);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
