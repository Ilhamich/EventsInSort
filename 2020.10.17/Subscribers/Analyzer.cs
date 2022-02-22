using System;
using System.Diagnostics;

namespace _2020._10._17
{
    class Analyzer<T> where T : IComparable<T>
    {
        private Stopwatch _timer;

        // -1 sort not start yet, 0 sort is start, 1 sort is done
        public sbyte SortProcess { get; private set; } = -1;

        public int Speed { get; private set; }

        public int ComparisonCount { get; private set; }

        public int SwopCount { get; private set; }

        public long TimeCount
        {
            get
            {
                int pouse = (ComparisonCount + SwopCount + SwopCount) * Speed;

                return _timer.ElapsedMilliseconds - pouse;
            }
        }

        public Analyzer(Sorter<T> aSorter, int speed)
        {
            Speed = speed;

            aSorter.SortProсTimeFix += FixSortTime;
            aSorter.ProcessSwap += FixSwap;
            aSorter.Comparison += FixCompare;
        }

        private void FixCompare(object obj, SortProcessEventArgs<T> e)
        {
            if (e.ComparisonProcess)
            {
                ComparisonCount++;
            }
        }

        private void FixSwap(object obj, SortProcessEventArgs<T> e)
        {
            if (e.SwopProcess)
            {
                SwopCount++;
            }
        }

        private void FixSortTime(object obj, SortProcessEventArgs<T> e)
        {
            if (SortProcess == -1)
            {
                SortProcess = 0;
                _timer = new Stopwatch();
                _timer.Start();
            }
            else
            {
                if (SortProcess == 0)
                {
                    _timer.Stop();
                    SortProcess = 1;
                }
            }
        }
    }
}
