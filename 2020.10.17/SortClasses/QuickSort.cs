using System;
using System.Collections;
using System.Collections.Generic;

namespace _2020._10._17
{
    class QuickSort<T> : Sorter<T>
        where T : IComparable<T>
    {
        public QuickSort(T[] sourse)
            :base(sourse)
        {
        }

        protected override void Sorting()
        {
            QuickS();
        }

        private void QuickS(int start = 0, int end = 0)
        {
            int left = start;
            int right;

            if (end == 0)
            {
                end = _source.Length - 1;
                right = end;
            }
            else
            {
                right = end;
            }

            int pivot = (left + right) / 2;

            SortProcess(left, right, ref pivot);

            if (pivot - start > 1)
            {
                QuickS(start, pivot - 1);
            }

            if (end - pivot > 1)
            {
                QuickS(pivot + 1, end);
            }
        }

        private void SortProcess(int left, int right, ref int pivot)
        {
            while (left < right)
            {
                while (Compare(_source[left]
                           ,_source[pivot]
                           , this
                           , new SortProcessEventArgs<T>(true, _source, left, pivot, pivot)) <= 0
                        && left < pivot)
                {                 
                    left++;
                }
            
                while (Compare(_source[right]
                           , _source[pivot]
                           , this
                           , new SortProcessEventArgs<T>(true, _source, right, pivot, pivot)) >= 0
                        && right > pivot)
                {              
                    right--;
                }

                if (left < right)
                {
                    if (left == pivot)
                    {
                        Swap(pivot, pivot + 1, pivot);
                        pivot++;

                        if (right != pivot)
                        {
                            Swap(pivot - 1, right, pivot);
                        }               
                    }
                    else
                    {
                        if (right == pivot)
                        {
                            Swap(pivot - 1, pivot, pivot);
                            pivot--;

                            if (pivot != left)
                            {
                                Swap(left, pivot + 1, pivot);
                            }                        
                        }
                        else
                        {
                            Swap(left, right, pivot);
                        }
                    }
                }
            }
        }

        private void Swap(int firNum, int secNum, int pivot)
        {
            T tmp = _source[firNum];
            _source[firNum] = _source[secNum];
            _source[secNum] = tmp;

            _swapFix?.Invoke(this, new SortProcessEventArgs<T>(_source, true, firNum, secNum, pivot));
        }     
    }
}
