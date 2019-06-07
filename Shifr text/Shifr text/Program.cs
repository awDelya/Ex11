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
            matr = new string[11,11];
            DoMatr(text);
            string stroka = matr[5, 5];
            stroka = stroka + matr[5,6];
            for (int j = 6; j > 3; j--)
                stroka = stroka + matr[4,j];
            for (int i = 5; i < 7; i++)
                stroka = stroka + matr[i,4];
            for (int j = 5; j < 8; j++)
                stroka = stroka + matr[6, j];
            for (int i = 5; i > 2; i--)
                stroka = stroka + matr[i, 7];
            for (int j = 6; j > 2; j--)
                stroka = stroka + matr[3, j];
            for (int i = 4; i < 8; i++)
                stroka = stroka + matr[i, 3];
            for (int j = 4; j < 9; j++)
                stroka = stroka + matr[7, j];
            for (int i = 6; i > 1; i--)
                stroka = stroka + matr[i, 8];
            for (int j = 7; j > 1; j--)
                stroka = stroka + matr[2, j];
            for (int i = 3; i < 9; i++)
                stroka = stroka + matr[i, 2];
            for (int j = 3; j < 10; j++)
                stroka = stroka + matr[8, j];
            for (int i = 7; i > 0; i--)
                stroka = stroka + matr[i, 9];
            for (int j = 8; j > 0; j--)
                stroka = stroka + matr[1, j];
            for (int i = 2; i < 10; i++)
                stroka = stroka + matr[i, 1];
            for (int j = 2; j < 11; j++)
                stroka = stroka + matr[9, j];
            for (int i = 8; i > -1; i--)
                stroka = stroka + matr[i, 10];
            for (int j = 9; j > -1; j--)
                stroka = stroka + matr[0, j];
            for (int i = 1; i < 11; i++)
                stroka = stroka + matr[i, 0];
            for (int j = 1; j < 11; j++)
                stroka = stroka + matr[10, j];
            return stroka;
        }
        static void Main()
        {
            string stroka = "";
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
