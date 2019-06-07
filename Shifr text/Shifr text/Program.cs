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
        static void Main()
        {
            string stroka;
            Again:
            Console.Clear();
            switch(Menu())
            {
                case 1:
                    stroka = InputText();
                    goto Again;
                case 2:
                    goto Again;
                case 3:
                    goto Again;
                case 4:
                    goto Again;
                case 5:
                    break;
            }
        }
    }
}
