using System;
using System.Collections;
using System.Collections.Generic;

namespace aStar1
{

    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] array = new int[40, 50]; // 1 - стена 0 пусто
            Random trand = new Random();

            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (trand.Next() % 3 == 0)
                        array[i, j] = 1;
                    else
                        array[i, j] = 0;
                }
            }
            array[39, 49] = 0; // финиш
            array[0, 0] = 0; //start


            //стенка свреху
            for (int i = 0; i < 52; i++)
                Console.Write(i % 10 + " ");
            Console.WriteLine();
            for (int i = 0; i < 53; i++)
                Console.Write("# ");
            Console.WriteLine();
            for (int i = 0; i < 40; i++)
            {
                //стенка слева
                Console.Write(i % 10 + " # ");
                //сама карта
                for (int j = 0; j < 50; j++)
                {
                    if (array[i, j] == 2)
                        Console.Write("* ");
                    if (array[i, j] == 0)
                        Console.Write("  ");
                    if (array[i, j] == 1)
                        Console.Write("# ");
                }
                //стенка справа
                Console.Write("#");
                Console.WriteLine();
            }
            //стенка снизу
            for (int i = 0; i < 53; i++)
                Console.Write("# ");
            Console.WriteLine();


            //решение изменение массива
            AStart t = new AStart();
            if (t.Solution(array, new Point(0, 0), new Point(49, 39))) // тут точку пихаем вначале у потом х
            {
                List<Point> path = t.GetPath();
                foreach (Point qur in path)
                {
                    array[qur.y, qur.x] = 2;
                }

                Console.WriteLine("решение: ");
                //стенка свреху
                for (int i = 0; i < 52; i++)
                    Console.Write(i % 10 + " ");
                Console.WriteLine();

                for (int i = 0; i < 53; i++)
                    Console.Write("# ");
                Console.WriteLine();
                for (int i = 0; i < 40; i++)
                {
                    //стенка слева
                    Console.Write(i % 10 +" # ");
                    //сама карта
                    for (int j = 0; j < 50; j++)
                    {
                        if (array[i, j] == 2)
                            Console.Write("* ");
                        if (array[i, j] == 0)
                            Console.Write("  ");
                        if (array[i, j] == 1)
                            Console.Write("# ");
                    }
                    //стенка справа
                    Console.Write("#");
                    Console.WriteLine();
                }
                //стенка снизу
                for (int i = 0; i < 53; i++)
                    Console.Write("# ");
            }
            else
                Console.WriteLine("Решения нет");
         



        }
    }
}
