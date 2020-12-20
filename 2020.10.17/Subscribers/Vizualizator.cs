using System;
using System.Text;
using System.Threading;

namespace _2020._10._17
{
    class Vizualizator<T>
        where T : IComparable<T>
    {
        private int _speed;

        public Vizualizator(Sorter<T> sort, int speed)
        {
            _speed = speed;
            sort.SortProсTimeFix += FixArreyState;
            sort.Comparison += PrintComparision;
            sort.ProcessSwap += PrintSwap;
        }

        private void FixArreyState(object obj, SortProcessEventArgs<T> e)
        {
            string[] vizArrey = MakeArrAsString(e.GetArreyState());

            if (e.PivoteElement == -1)
            {
                PrintArrey(vizArrey);
            }
            else
            {
                PrintArreyWithPivote(vizArrey, e.PivoteElement);
            }

            Console.WriteLine();
        }

        private void PrintComparision(object obj, SortProcessEventArgs<T> e)
        {
            if (e.ComparisonProcess)
            {
                string[] vizArrey = MakeArrAsString(e.GetArreyState());

                Thread.Sleep(_speed);

                PrintArreyWithComprasion(vizArrey, e.FirstСomparable,
                        e.SecondComparable, e.PivoteElement);
            }
        }

        private void ClearArrLine(string[] line, int x = 0, int y = 0)
        {
            for (int i = 0; i < line.Length; i++)
            {
                for (int j = 0; j < line[i].Length; j++)
                {
                    Console.SetCursorPosition(x++, y);
                    Console.Write(' ');
                }
            }

            Console.SetCursorPosition(x, y);
        }

        private string[] MakeArrAsString(T[] arrey)
        {
            string[] vizArrey = new string[arrey.Length];

            for (int i = 0; i < arrey.Length; i++)
            {
                vizArrey[i] = arrey[i].ToString() + ' ';
            }

            return vizArrey;
        }

        private void PrintArrey(string[] vizArrey)
        {
            int x = 0;
            int y = 0;

            Console.SetCursorPosition(x, y);

            for (int i = 0; i < vizArrey.Length; i++)
            {
                Console.Write(vizArrey[i]);
                Console.SetCursorPosition(x += vizArrey[i].Length, y);
            }
        }

        private void PrintArreyWithPivote(string[] vizArrey, int pivot)
        {
            Console.OutputEncoding = Encoding.Unicode;

            int x = 0;
            int y = 0;

            if (pivot != -1)
            {
                ClearArrLine(vizArrey, x, y + 1);
            }

            Console.SetCursorPosition(x, y);

            for (int i = 0; i < vizArrey.Length; i++)
            {
                if (i == pivot)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(vizArrey[i]);
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write('↑');
                    Console.SetCursorPosition(x += vizArrey[i].Length, y);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(vizArrey[i]);
                    Console.SetCursorPosition(x += vizArrey[i].Length, y);
                }
            }
        }

        private void PrintArreyWithComprasion(string[] vizArrey, int first,
                int second, int pivot)
        {
            Console.OutputEncoding = Encoding.Unicode;

            int x = 0;
            int y = 0;

            if (pivot != -1)
            {
                ClearArrLine(vizArrey, x, y + 1);
            }

            Console.SetCursorPosition(x, y);

            for (int i = 0; i < vizArrey.Length; i++)
            {
                if (i == first || i == second)
                {
                    if (i == pivot)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(vizArrey[i]);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(x, y + 1);
                        Console.Write('↑');
                        Console.SetCursorPosition(x += vizArrey[i].Length, y);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(vizArrey[i]);
                        Console.SetCursorPosition(x += vizArrey[i].Length, y);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.Write(vizArrey[i]);
                    Console.SetCursorPosition(x += vizArrey[i].Length, y);
                }
            }
        }

        private void PrintSwap(object obj, SortProcessEventArgs<T> e)
        {
            if (e.SwopProcess)
            {
                string[] vizArreyIs = MakeArrAsString(e.GetArreyState());

                string[] vizArreyWas = new string[vizArreyIs.Length];

                for (int i = 0; i < vizArreyIs.Length; i++)
                {
                    if (i == e.FirstSwapable)
                    {
                        vizArreyWas[i] = vizArreyIs[e.SecondSwapable];
                    }
                    else
                    {
                        if (i == e.SecondSwapable)
                        {
                            vizArreyWas[i] = vizArreyIs[e.FirstSwapable];
                        }
                        else
                        {
                            vizArreyWas[i] = vizArreyIs[i];
                        }
                    }
                }

                PrintArreyWithSwap(vizArreyWas, vizArreyIs,
                    e.FirstSwapable, e.SecondSwapable, e.PivoteElement);
            }
        }

        private void PrintArreyWithSwap(string[] vizArreyWas, string[] vizArreyIs,
                int first, int second, int pivot)
        {
            Thread.Sleep(_speed);

            PrintColorSwap(vizArreyWas, first, second, pivot, ConsoleColor.DarkGreen);

            Thread.Sleep(_speed);

            ClearArrLine(vizArreyWas);

            PrintColorSwap(vizArreyIs, first, second, pivot, ConsoleColor.Green);
        }

        private void PrintColorSwap(string[] arrey, int firstArg, int secondArg,
            int pivot, ConsoleColor color)
        {
            Console.OutputEncoding = Encoding.Unicode;

            int x = 0;
            int y = 0;

            if (pivot != -1)
            {
                ClearArrLine(arrey, x, y + 1);
            }

            Console.SetCursorPosition(x, y);

            for (int i = 0; i < arrey.Length; i++)
            {
                if (i == firstArg || i == secondArg)
                {
                    if (i == pivot)
                    {
                        Console.ForegroundColor = color;
                        Console.Write(arrey[i]);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(x, y + 1);
                        Console.Write('↑');
                        Console.SetCursorPosition(x += arrey[i].Length, y);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = color;
                        Console.Write(arrey[i]);
                        Console.SetCursorPosition(x += arrey[i].Length, y);
                        Console.ResetColor();
                    }
                }
                else
                {
                    if (i == pivot)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(x, y + 1);
                        Console.Write('↑');
                        Console.SetCursorPosition(x, y);
                        Console.Write(arrey[i]);
                        Console.SetCursorPosition(x += arrey[i].Length, y);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(arrey[i]);
                        Console.SetCursorPosition(x += arrey[i].Length, y);
                    }
                }
            }
        }
    }
}
