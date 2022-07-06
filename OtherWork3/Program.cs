using System;
using System.Linq;

namespace OtherWork3
{ 
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[0];
            int lenght = 0;
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
                                AddArray(Convert.ToInt32(number));
                                number = String.Empty;
                            }
                            else
                                number += stroka[i];
                            if (i == stroka.Length - 1)
                            {
                                AddArray(Convert.ToInt32(number));
                            }
                        }
                        break;

                    case "AddNumbers":
                        AddArray(InputInteger("Введите число: "));
                        break;

                    case "RemoveNumbers":
                        int removeNumber = InputInteger("Введите число: ");
                        array = array.Where(number => number != removeNumber).ToArray();
                        lenght = array.Length;
                        break;

                    case "Numbers":
                        for (int i = 0; i < array.Length; i++)
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

            void AddArray(int number)
            {
                Array.Resize(ref array, lenght + 1);
                array[lenght] = number;
                lenght++;
            }

            Console.ReadKey();
        }
    }
}
