using System;
using System.Linq;
using System.Collections.Generic;

namespace OtherWork3
{ 
    class Program
    {
        static void Main(string[] args)
        {
            /*
            1 - Where(на примере данной команды array.Where(number => number != removeNumber).ToArray();) 
            в number записываются значения из массива и проверяется условие если number 
            не равен значению из переменной removeNumber то значение записывается, 
            а если равен то пропускается. ToArray() конвертирует метод (IEnumerable<int>) обратно в массив.
            Если писать подробно, то напоминает запрос из Базы Данных ((from number in array where number != removeNumber select number).ToArray();)
            А вот с первой командой я просто неразобрался как реализовать, поэтому написал уже, то что было на одном из дз.
            2 - Можно задать статический массив и по мере заполнения увеличивать или уменьшать переменную 
            в которой указанно колличество введенных значений массива.
            3 - Resize - изменяет размерность элементов до указанной веречины. Служит для реализации динамического массива.
            4 - ref - указывает на то, что значение передается по ссылке. Необходим для изменения размерности массива на который он указан.
            */

            int[] array = new int[1000];
            int lenght = 0;
            ConsoleKeyInfo end;
            string command;
            do
            {
                Console.Clear();
                Console.WriteLine("SetNumbers – пользователь вводит числа через пробел, а программа запоминает их в массив;" +
                                "\nAddNumbers – пользователь вводит числа, которые добавятся к уже существующему массиву;" +
                                "\nRemoveNumbers - пользователь вводит числа, которые если  найдутся в массиве, то будут удалены;" +
                                "\nNumbers – ввывод текущего массива;" +
                                "\nSum – найдется сумма всех элементов чисел;" +
                                "\nExit - выход.");
                command = InputString("Введите команду: ");
                Console.Clear();
                switch (command)
                {
                    case "SetNumbers":
                        Console.WriteLine("Введите массив через пробел");
                        string stroka = InputString("");                       
                        string number = String.Empty;

                        for(int i = 0; i < stroka.Length; i++)
                        {
                            if (stroka[i] == ' ')
                            {
                                array[lenght++] = (Convert.ToInt32(number));
                                number = String.Empty;
                            }
                            else
                                number += stroka[i];
                            if (i == stroka.Length - 1)
                            {
                                array[lenght++] = (Convert.ToInt32(number));
                            }
                        }
                        break;

                    case "AddNumbers":
                        do
                        {
                            array[lenght++] = (InputInteger("Введите число: "));
                            end = Permission("Желаете продолжить (y/n) ");
                            Console.WriteLine();
                        } while (end.Key.ToString() != "N");                       
                        break;

                    case "RemoveNumbers":
                        do
                        {
                            int removeNumber = InputInteger("Введите число: ");
                            for (int i = 0; i < lenght; i++)
                                if (array[i] == removeNumber)
                                    RemoveNumbers(i);
                            end = Permission("Желаете продолжить (y/n) ");
                            Console.WriteLine();
                        } while (end.Key.ToString() != "N");                       
                        break;

                    case "Numbers":
                        for (int i = 0; i < lenght; i++)
                        {
                            Console.Write(array[i] + " ");
                        }
                        Console.WriteLine();
                        break;

                    case "Sum":
                        int sum = 0;
                        for (int i = 0; i < array.Length; i++)
                        {
                            sum += array[i];
                        }
                        Console.WriteLine(sum);
                        break;
                }

                Console.Write("Press key to continue...");
                Console.ReadKey();

            } while (command != "Exit");

            

            string InputString(string str)
            {
                Console.Write(str);
                return Console.ReadLine();
            }

            int InputInteger(string str)
            {
                Console.Write(str);
                return int.Parse(Console.ReadLine());
            }

            void RemoveNumbers(int number)
            {
                for(int i = number; i < lenght; i++)
                {
                    array[i] = array[i + 1];
                }
                lenght--;
            }

            ConsoleKeyInfo Permission(string str)
            {
                bool flag = true;
                Console.Write(str);
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey();
                    if (key.Key.ToString() == "N" || key.Key.ToString() == "Y")
                        flag = false;
                } while (flag);
                return key;
            }

            Console.ReadKey();
        }
    }
}
