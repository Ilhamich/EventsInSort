using System;

namespace _2020._10._17
{
    class SortProcessEventArgs<T> : EventArgs
    {
        private T[] _arreyState;

        public SortProcessEventArgs(T[] arreyState)
        {
            _arreyState = (T[])arreyState.Clone();
            ComparisonProcess = false;
            SwopProcess = false;
            PivoteElement = -1;
        }

        public SortProcessEventArgs(bool comparisonProc, T[] arreyState,
                int firComparable, int secComparable, int pivotElement = -1)
        {
            _arreyState = (T[])arreyState.Clone();
            ComparisonProcess = comparisonProc;
            SwopProcess = false;
            FirstСomparable = firComparable;
            SecondComparable = secComparable;
            PivoteElement = pivotElement;
        }

        public SortProcessEventArgs(T[] arreyState, bool swapProcess,
            int firstElement, int secondElement, int pivot = -1)
        {
            _arreyState = (T[])arreyState.Clone();
            ComparisonProcess = false;
            SwopProcess = swapProcess;
            FirstSwapable = firstElement;
            SecondSwapable = secondElement;
            PivoteElement = pivot;
        }

        public bool ComparisonProcess { get; }

        public bool SwopProcess { get; }

        // -1 pivote absent
        public int PivoteElement { get; }

        public int FirstСomparable { get; }

        public int SecondComparable { get; }

        public int FirstSwapable { get; }

        public int SecondSwapable { get; }

        public T[] GetArreyState()
        {
            return (T[])_arreyState.Clone();
        }
    }
}
