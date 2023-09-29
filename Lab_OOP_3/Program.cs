using System;

namespace lab3_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Функция: y = x * arctg(x) - ln(sqrt(1 + x^2))  ");
            Console.WriteLine("Диапазон изменения аргумента x: 0,1 <= x <= 0,8       n = 10");
            Console.WriteLine("Диапазон изменения аргумента x: 0,1 <= x <= 0,8       n = 10");
            int n = 10;
            float e = 0.0001F;
            for (float x = 0.1F; x <= 0.8F; x += 0.07F)
            {
                double sn = SummationRowSN(x, n);
                double se = SummationRowSE(x, e);
                double y = CalculatingFunction(x);
                string xOut = x.ToString("0.00");
                string snOut = sn.ToString("0.00000000000000");
                string seOut = se.ToString("0.00000000000000");
                string yOut = y.ToString("0.00000000000000");
                Console.WriteLine("X = " + xOut + "         SN = " + snOut + "         SE = " + seOut + "       Y = " + yOut);
            }
            Console.ReadKey();
        }

        //вычисление значений функции
        static double CalculatingFunction(float x)
        {
            double y = x * Math.Atan(x) - Math.Log(Math.Sqrt(1 + Math.Pow(x, 2)));
            return y;
        }
        //вычисление по сумме ряда - арифмитический
        static double SummationRowSN(float x, int n)
        {
            double valueN = 0;
            double sum = 0;
            for (int i = 1; i <= n; i ++)
            {
                valueN = Math.Pow(x, 2 * i) / (2 * i * (2 * i - 1));
                if (i % 2 == 1)
                    sum += valueN;
                else
                    sum -= valueN;
            }
            return sum;
        }
        //вычисление по сумме ряда - итерационный
        static double SummationRowSE(float x, float e)
        {
            double valueN1 = 1;
            double valueN2 = 1;
            int n = 1;
            double sum = 0;
            do
            {
                valueN1 = valueN2;
                valueN2 = Math.Pow(x, 2 * n) / (2 * n * (2 * n - 1));
                if (n % 2 == 1)
                    sum += valueN2;
                else
                    sum -= valueN2;
                n++;
            } while ((valueN1 - valueN2) > e);
            return sum;
        }
    }
}
