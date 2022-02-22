using System;

namespace _2020._10._17
{
    static class UI
    {
        const int LOWER_SPEED_BORDER = 40;
        const int HIGHT_SPEED_BORDER = 1500;

        static readonly string[] _sortListMenu =
        {
            "1 ->Быстрая сортировка",
            "2 ->Сортировка вставками",
            "3 ->Сортировка выбором",
            "0 ->Выход"
        };

        static readonly string[] _menu =
        {
                "Нужно выбрать размер массива",
                "Не меньше 5 не больше 30",
                "Размер массива = "
        };

        static readonly string[] _pouseMenu =
        {
            "Установка паузы для отображения сортировки",
            "Не меньше 40 не больше 1500",
            "В миллисекундах равна : "
        };

        public static byte ChooseSort()
        {
            int x = 0;
            int y = 0;

            PrintMenu(_sortListMenu, ref x, ref y);

            string choose;
            string enter = "Enter -> ";
            byte enterSort = 0;
            bool resolt = true;

            do
            {
                Console.SetCursorPosition(x, y);
                Console.Write(enter);
                Console.SetCursorPosition(x + enter.Length, y);
                choose = Console.ReadLine();

                resolt = !byte.TryParse(choose, out enterSort);

                if (resolt || enterSort < 0 || enterSort > 3)
                {
                    ClearLine(choose, x + enter.Length, y);
                }
            } while (resolt || enterSort < 0 || enterSort > 3);

            ClearArreyOfLines(_sortListMenu);

            string forClear = enter + ' ' + choose;

            ClearLine(forClear, x, y);

            return Convert.ToByte(choose);
        }

        private static void ClearArreyOfLines(string[] line, int x = 0, int y = 0)
        {
            for (int i = 0; i < line.Length; i++)
            {
                ClearLine(line[i], x, y);

                x = 0;
                y += 1;
            }
        }

        private static void ClearLine(string line, int x = 0, int y = 0)
        {
            for (int j = 0; j < line.Length; j++)
            {
                Console.SetCursorPosition(x++, y);
                Console.Write(' ');
            }
        }

        private static void PrintMenu(string[] menu, ref int x , ref int y) 
        {
            for (int i = 0; i < _menu.Length; i++)
            {
                Console.SetCursorPosition(x, y++);
                Console.Write(menu[i]);
            }
        }

        public static int SetArreySize()
        {
            bool convert = false;
            int size = 0;

            int x = 0;
            int y = 0;

            PrintMenu(_menu, ref x, ref y);

            string lineSize = string.Empty;

            do
            {
                Console.SetCursorPosition(x + _menu[_menu.Length - 1].Length, y - 1);
                lineSize = Console.ReadLine();

                convert = !int.TryParse(lineSize, out size);

                if (convert || size < 5 || size > 30)
                {
                    ClearLine(lineSize, x + _menu[_menu.Length - 1].Length, y - 1);
                }
            } while (convert || size < 5 || size > 30);

            ClearArreyOfLines(_menu);

            ClearLine(lineSize, x + _menu[_menu.Length - 1].Length, y - 1);

            return size;
        }

        public static void ShowSortResolt<T>(Analyzer<T> sort)
            where T : IComparable<T>
        {
            int x = 20;
            int y = 1;

            Console.SetCursorPosition(x, y++);
            Console.Write("Сравнений было : {0}", sort.ComparisonCount);
            Console.SetCursorPosition(x, y++);
            Console.Write("Перестановок было : {0}", sort.SwopCount);
            Console.SetCursorPosition(x, y);
            Console.Write("Затраченное время = {0} миллисекунд", sort.TimeCount);
            Console.ReadKey();
            Console.Clear();
        }

        public static int SetPouse()
        {
            int x = 0;
            int y = 0;

            PrintMenu(_pouseMenu, ref x, ref y);

            bool resolt = true;
            int pouseSpeed = 0;
            string enter = string.Empty;

            do
            {
                Console.SetCursorPosition(x + _pouseMenu[_pouseMenu.Length - 1].Length, y - 1);
                enter = Console.ReadLine();

                resolt = !int.TryParse(enter, out pouseSpeed);

                if (resolt || pouseSpeed < LOWER_SPEED_BORDER || pouseSpeed > HIGHT_SPEED_BORDER)
                {
                    ClearLine(enter, x + _pouseMenu[_pouseMenu.Length - 1].Length, y - 1);
                }
            } while (resolt || pouseSpeed < LOWER_SPEED_BORDER || pouseSpeed > HIGHT_SPEED_BORDER);

            ClearArreyOfLines(_pouseMenu);

            ClearLine(enter, x + _pouseMenu[_pouseMenu.Length - 1].Length, y - 1);

            return pouseSpeed;
        }
    }
}
