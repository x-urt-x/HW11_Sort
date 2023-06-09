﻿using MergeSortingNS;

namespace HW15_Sort
{
    /// <summary>
    /// программа для сортировки массивов + их создание.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// юи, создание массива и запуск сортирови.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("введите коллество элементов массива");
            int len = int.Parse(Console.ReadLine());
            double[] array = new double[len];
            Console.WriteLine("авто заполнение массива (0/1)");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                Console.WriteLine("введите максимальное значение");
                int max = int.Parse(Console.ReadLine());
                Random random = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = random.Next() % max;
                }

                if (len < 50)
                {
                    Console.WriteLine("исходный массив:");
                    foreach (var item in array)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            else
            {
                for (int i = 0; i < len; i++)
                {
                    array[i] = double.Parse(Console.ReadLine());
                }
            }

            double[] sortedArr = { };
            try
            {
                sortedArr = MergeSorting.MergeSort(array);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }

            Console.WriteLine("отсортированный массив:");
            foreach (var item in sortedArr)
            {
                Console.WriteLine(item);
            }
        }
    }
}