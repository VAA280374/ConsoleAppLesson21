using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppLesson21
{
    internal class Program
    {
        // Размеры поляны
        const int nI = 50;
        const int nJ = 60;
        // Переменная поляны
        static int[,] array = new int[nI, nJ];

        static void Gardener1()
        {
            for (int j = 0; j < nJ; j++)
            {
                for (int i = 0; i < nI; i++)
                {
                    if (array[i, j] == 0) array[i, j] = 1;
                    Thread.Sleep(1);
                }
            }

        }
        static void Gardener2()
        {
            for (int i = nI-1; i >= 0; i--)
            {
                for (int j = nJ - 1; j >= 0; j--)
                {
                    if (array[i, j] == 0) array[i, j] = 2;
                    Thread.Sleep(1);
                }
            }

        }

        static void Main(string[] args)
        {
            // Инициализация поляны
            for (int i = 0; i < nI; i++)
            {
                for (int j = 0; j < nJ; j++)
                {
                    array[i, j] = 0;
                }
            }

            ThreadStart threadStart = new ThreadStart(Gardener2);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Gardener1();


            // Вывод поляны на печать.
            for (int j = 0; j < nJ; j++)
            {
                for (int i = 0; i < nI; i++)
                {
                    Console.Write(" {0}", array[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
