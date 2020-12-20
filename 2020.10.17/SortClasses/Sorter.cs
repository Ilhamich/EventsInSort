using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._10._17
{
    abstract class Sorter<T>
        where T : IComparable<T>
    {
        protected T[] _source;
        protected SortProcess<T> _timeFix;
        protected SortProcess<T> _swapFix;
        protected SortProcess<T> _сomparisonFix;

        public Sorter(T[] sourse)
        {
            _source = (T[])sourse.Clone();
        }

        public event SortProcess<T> SortProсTimeFix
        {
            add
            {
                _timeFix += value;
            }
            remove
            {
                _timeFix -= value;
            }
        }

        public event SortProcess<T> Comparison
        {
            add
            {
                _сomparisonFix += value;
            }
            remove
            {
                _сomparisonFix -= value;
            }
        }

        public event SortProcess<T> ProcessSwap
        {
            add
            {
                _swapFix += value;
            }
            remove
            {
                _swapFix -= value;
            }
        }

        public virtual T[] GetArreyCopy()
        {          
            return (T[])_source.Clone();
        }

        protected int Compare(T first, T second, object obj,
                SortProcessEventArgs<T> e)
        {
            _сomparisonFix?.Invoke(obj, e);

            int resolt = first.CompareTo(second);

            return resolt;
        }

        public virtual void Sort()
        {
            _timeFix?.Invoke(this, new SortProcessEventArgs<T>(GetArreyCopy()));

            Sorting();

            _timeFix?.Invoke(this, new SortProcessEventArgs<T>(GetArreyCopy()));
        }

        protected abstract void Sorting();
    }
}
