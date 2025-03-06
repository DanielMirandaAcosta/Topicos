﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secuencial
{
    class Secuencial
    {
        static int sumaTotal = 0;

        static bool EsPrimo(int numero)
        {
            if (numero < 2) return false;
            for (int i = 2; i * i <= numero; i++)
            {
                if (numero % i == 0) return false;
            }
            return true;
        }
    
        static void Main()
        {
            Console.WriteLine("Ingrese el numero limite:");
            int N = int.Parse(Console.ReadLine());
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 1; i <= N; i++)
            {
                if (EsPrimo(i))
                {
                    sumaTotal += i;
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Suma total de numeros primos de forma secuencial hasta {N}: {sumaTotal}");
            Console.WriteLine($"Tiempo de ejecucion: {stopwatch.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}
