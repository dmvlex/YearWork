using System;
using System.Diagnostics;


namespace YearWork
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Курсовая работа по АСД. Харитонов Александр 20-ЗКБ-ПР2";



            const int ArrayLenght = 15; // Длинна массива значений
            int[] unsortArray = new int[ArrayLenght]; //массив несортированных значений

            Random rand = new Random(); //генератор рандомных значений
            Stopwatch time = new Stopwatch(); // объект секундомера, для программы.

            time.Start(); //времени на выполнение
            for (int i = 0; i < unsortArray.Length; i++)
            {
                unsortArray[i] = rand.Next(0, 9999); //заполнение массива случайными значениями
            }

            //вывод исходного массива
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Исходный массив: ");
            Console.ResetColor();

            foreach (int item in unsortArray)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //добавление и заполнение дерева из массива
            BinaryTree<int> tree = new BinaryTree<int>();

            
            foreach (int item in unsortArray) // заполнение дерева
            {
                tree.Add(item);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Итоговое дерево: ");
            Console.ResetColor();

            tree.PrintTree();
            time.Stop(); //остановка секундомера
            Console.WriteLine();

            //Вывод времени 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Время исполнения программы: ");
            Console.ResetColor();
            Console.WriteLine(time.Elapsed);

            Console.ReadKey();


        }
    }
}

