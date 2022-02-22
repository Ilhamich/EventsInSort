using System;

namespace _2020._10._17
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            bool exit = true;

            do
            {
                byte sortNum = UI.ChooseSort();
                int arraySize = UI.SetArreySize();
                int pouseSpeed = UI.SetPouse();

                InicialisationArray(out int[] array, arraySize);

                switch (sortNum)
                {
                    case 1:                       
                        QuickSortMenu(array, pouseSpeed);
                        break;

                    case 2:
                        InsertSortMenu(array, pouseSpeed);
                        break;

                    case 3:
                        SelectSortMenu(array, pouseSpeed);
                        break;

                    default:
                        exit = false;
                        break;
                }
            } while (exit);      
        }

        public static void InicialisationArray(out int[] array, int arraySize)
        {
            array = new int[arraySize];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 100);
            }
        }

        public static void QuickSortMenu<T>(T[] arrey, int pouseSpeed)
            where T : IComparable<T>
        {
            Sorter<T> sorterQuck = new QuickSort<T>(arrey);
            Vizualizator<T> vizForQS = new Vizualizator<T>(sorterQuck, pouseSpeed);
            Analyzer<T> forQS = new Analyzer<T>(sorterQuck, pouseSpeed);

            sorterQuck.Sort();

            UI.ShowSortResolt(forQS);
        }

        public static void InsertSortMenu<T>(T[] array, int pouseSpeed)
            where T : IComparable<T>
        {
            Sorter<T> insertSort = new InsertSort<T>(array);
            Vizualizator<T> vizForIS = new Vizualizator<T>(insertSort, pouseSpeed);
            Analyzer<T> forIS = new Analyzer<T>(insertSort, pouseSpeed);

            insertSort.Sort();

            UI.ShowSortResolt(forIS);
        }

        public static void SelectSortMenu<T>(T[] arrey, int pouseSpeed)
            where T : IComparable<T>
        {
            Sorter<T> selectSort = new SelectSort<T>(arrey);
            Vizualizator<T> vizForSS = new Vizualizator<T>(selectSort, pouseSpeed);
            Analyzer<T> forSS = new Analyzer<T>(selectSort, pouseSpeed);

            selectSort.Sort();

            UI.ShowSortResolt(forSS);
        }
    }
}
