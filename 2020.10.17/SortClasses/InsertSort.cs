using System;

namespace _2020._10._17
{
    class InsertSort<T> : Sorter<T>
        where T : IComparable<T>
    {
        public InsertSort(T[] sourse)
            : base(sourse)
        {
        }

        protected override void Sorting()
        {
            T tmp;

            for (int i = 0; i < _source.Length; i++)
            {
                tmp = _source[i];
                int nextI = i;

                for (int j = i - 1; j > -1; j--)
                {
                    if (Compare(_source[j], tmp, this, new SortProcessEventArgs<T>
                            (true, _source, j, nextI)) > 0)
                    {                      
                        _source[j + 1] = _source[j];
                        _source[j] = tmp;

                        _swapFix?.Invoke(this, new SortProcessEventArgs<T>(_source, true, nextI--, j));
                    }
                }
            }
        }
    }
}
