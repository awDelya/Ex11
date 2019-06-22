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
        private static int Menu()//печать меню
        {
            Color.Print("\n\t Выберите пункт меню", ConsoleColor.Magenta);
            Color.Print("\n\n 1) Написать текст в программу" +
                        "\n\n 2) Зашифровать текст" +
                        "\n\n 3) Расшифровать текст" +
                        "\n\n 4) Напечатать результат" +
                        "\n\n 5) Выход" +
                        "\n\n 6) Использовать существующие символы", ConsoleColor.Cyan);
            Color.Print("\n\n Цифра: ", ConsoleColor.Black, ConsoleColor.White);
            return Number.Check(1, 6);
        }
        public static string InputText()//создание текста
        {
            Color.Print("\n Напишите строку размером 121 символ: ", ConsoleColor.Yellow);
            string temp = Number.SymbolRu();
            char[] b = temp.ToCharArray();//для подсчета кол-ва символов
            if(b.Count() != 121)
            {
                Console.Clear();
                Color.Print("\n Введеная строка меньше или больше 121 символа, пожалуйста повторите ввод!\n", ConsoleColor.Red);
                InputText();
            }
            return temp;
        }
        private static string[,] matr;//матрица для шифрования и расшифрования
        private static void DoMatr(string text)//заполнение матрицы
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
        private static string EncryptText(string text)//шифрование текста
        {
            string stroka = null;
            const int n = 11;
            const int m = 11;
            matr = new string[n, m];
            DoMatr(text);
            int row = 0;
            int col = 0;
            int dx = 1;//направление по горизонтали
            int dy = 0;//направление по вертикали
            int dirChanges = 0;
            int visits = m;
            for (int i = 0; i < matr.Length; i++)//обход матрицы с первого элемента по спирали
            {
                stroka = stroka + matr[row, col];
                if (--visits == 0)
                {
                    visits = m * (dirChanges % 2) + n * ((dirChanges + 1) % 2) - (dirChanges / 2 - 1) - 2;//формирования нового пути для обхода строки или столбца
                    int temp = dx;
                    dx = -dy;
                    dy = temp;
                    dirChanges++;
                }
                col += dx;
                row += dy;
            }
            return new string(stroka.ToCharArray().Reverse().ToArray());//запись результата шифрования в строку, начиная с последнего элемента
        }
        private static string DecryptText(string text)//расшифровка текста
        {
            string stroka = new string(text.ToCharArray().Reverse().ToArray());
            char[] array = stroka.ToCharArray();
            const int n = 11;
            const int m = 11;
            matr = new string[n, m];
            int row = 0;
            int col = 0;
            int dx = 1;//направление по горизонтали
            int dy = 0;//направление по вертикали
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
                    stroka = stroka + matr[i,j];//формирование строки после расшифровки
            return stroka;
        }
        static bool ok = false;
        static string stroka = null;
        static void Main()
        {
            Console.Clear();
            switch(Menu())
            {
                case 1://создание текста
                    stroka = InputText();
                    ok = true;
                    Main(); break;
                case 2://шифрование текста
                    if (ok)
                    {
                        stroka = EncryptText(stroka);
                        Color.Print("\n Зашифровано!", ConsoleColor.Magenta);
                    }
                    else
                        Color.Print("\n Сперва введите текст!", ConsoleColor.Red);
                    Text.GoBackMenu();
                    Main(); break;
                case 3://расшифровка текста
                    if (ok)
                    {
                        stroka = DecryptText(stroka);
                        Color.Print("\n Расшифровано!", ConsoleColor.Magenta);
                    }
                    else
                        Color.Print("\n Сперва введите текст!", ConsoleColor.Red);
                    Text.GoBackMenu();
                    Main(); break;
                case 4://печать строки
                    if (ok)
                    {
                        Color.Print("\n Результат: \n\n", ConsoleColor.Magenta);
                        Color.Print(stroka);
                    }
                    else
                        Color.Print("\n Сперва введите текст!", ConsoleColor.Red);
                    Text.GoBackMenu();
                    Main(); break;
                case 5:
                    break;
                case 6:
                    stroka = "Здравствуй, мир! Привет, сосед и этот розовый пахучий красивый куст сирени! Что это такое? Голубое чистое небо? Жизнь мох";
                    ok = true;
                    Color.Print("\n Добавлено.", ConsoleColor.Magenta);
                    Text.GoBackMenu(); Main(); break;
            }
        }
    }
}
