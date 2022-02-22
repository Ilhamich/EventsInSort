using System;

namespace _2020._10._17
{
    class SelectSort<T> : Sorter<T> where T : IComparable<T>
    {     
        public SelectSort(T[] source) : base(source)
        {
        }

        protected override void Sorting()
        {
            for (int i = 0; i < _source.Length; i++)
            {
                int min = i;

                for (int j = i; j < _source.Length; j++)
                {
                    if (Compare(_source[j], _source[min], this, 
                        new SortProcessEventArgs<T>(true, _source, j, min)) < 0)
                    {
                        min = j;
                    }
                }

                if (i != min)
                {
                    Swap(i, min);
                }
            }
        }

        private void Swap(int firNum, int secNum)
        {
            T tmp = _source[firNum];
            _source[firNum] = _source[secNum];
            _source[secNum] = tmp;

            _swapFix?.Invoke(this, new SortProcessEventArgs<T>(_source, true, firNum, secNum));
        }
    }
}

