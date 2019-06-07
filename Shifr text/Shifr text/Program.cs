using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_methods;

namespace Shifr_text
{
    class Program
    {
        private static int Menu()
        {
            Color.Print("\n\t Выберите пункт меню", ConsoleColor.Magenta);
            Color.Print("\n\n 1) Написать текст в программу" +
                        "\n\n 2) Зашифровать текст" +
                        "\n\n 3) Расшифровать текст" +
                        "\n\n 4) Напечатать результат" +
                        "\n\n 5) Выход", ConsoleColor.Cyan);
            Color.Print("\n\n Цифра: ", ConsoleColor.Black, ConsoleColor.White);
            return Number.Check(1, 5);
        }
        public static string InputText()
        {
            Again:
            Color.Print("\n Напишите строку размером 121 символ: ", ConsoleColor.Yellow);
            string temp = Number.SymbolRu();
            char[] b = temp.ToCharArray();
            if(b.Count() != 121)
            {
                Console.Clear();
                Color.Print("\n Введеная строка меньше или больше 121 символа, пожалуйста повторите ввод!\n", ConsoleColor.Red);
                goto Again;
            }
            return temp;
        }
        private static string[,] matr;
        private static void DoMatr(string text)
        {
            int k = 0;
            char[] array = text.ToCharArray();
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    matr[i, j] = Convert.ToString(array[k]);
                    k++;
                }
            }
        }
        private static string EncryptText(string text)
        {
            string stroka = null;
            const int n = 11;
            const int m = 11;
            matr = new string[n, m];
            DoMatr(text);

            int row = 0;
            int col = 0;
            int dx = 1;
            int dy = 0;
            int dirChanges = 0;
            int visits = m;

            for (int i = 0; i < matr.Length; i++)
            {
                stroka = stroka + matr[row, col];
                if (--visits == 0)
                {
                    visits = m * (dirChanges % 2) + n * ((dirChanges + 1) % 2) - (dirChanges / 2 - 1) - 2;
                    int temp = dx;
                    dx = -dy;
                    dy = temp;
                    dirChanges++;
                }

                col += dx;
                row += dy;
            }
            return new string(stroka.ToCharArray().Reverse().ToArray());
        }
        private static string DecryptText(string text)
        {
            string stroka = new string(text.ToCharArray().Reverse().ToArray());
            char[] array = stroka.ToCharArray();
            const int n = 11;
            const int m = 11;
            matr = new string[n, m];

            int row = 0;
            int col = 0;
            int dx = 1;
            int dy = 0;
            int dirChanges = 0;
            int visits = m;

            for (int i = 0; i < matr.Length; i++)
            {
                matr[row, col] = Convert.ToString(array[i]);
                if (--visits == 0)
                {
                    visits = m * (dirChanges % 2) + n * ((dirChanges + 1) % 2) - (dirChanges / 2 - 1) - 2;
                    int temp = dx;
                    dx = -dy;
                    dy = temp;
                    dirChanges++;
                }

                col += dx;
                row += dy;
            }
            stroka = null;
            for (int i = 0; i < 11; i++)
                for (int j = 0; j < 11; j++)
                    stroka = stroka + matr[i,j];
            return stroka;
        }
        static void Main()
        {
            string stroka = null;
            Again:
            Console.Clear();
            switch(Menu())
            {
                case 1:
                    stroka = InputText();
                    goto Again;
                case 2:
                    stroka = EncryptText(stroka);
                    goto Again;
                case 3:
                    stroka = DecryptText(stroka);
                    goto Again;
                case 4:
                    Color.Print("Ваша строка выглядит так: " + stroka, ConsoleColor.Green);
                    Text.GoBackMenu();
                    goto Again;
                case 5:
                    break;
            }
        }
    }
}
