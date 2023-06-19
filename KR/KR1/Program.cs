using System;
using System.Text;

namespace SumPosl
{
    class SumPosl
    {
        private int n;
        private double[] x;

        public SumPosl(int n, double[] x)
        {
            this.n = n;
            this.x = x;
        }

        public double CalculateSum()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            if (x.Length != n)
            {
                throw new ArgumentException("Кількість елементів масиву x повинна дорівнювати значенню p.");
            }

            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += x[i] * x[(i + 1) % n];
            }

            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            int n = 4;  // натуральне число n
            double[] x = { 2, 1, 7, 4.5 };  // дійсні числа X1, X2, X3, X4
            Console.WriteLine("n=" + n);
            Console.WriteLine("Масив x:");
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine("X" + (i + 1) + ": " + x[i]);
            }

            SumPosl poslidovnist = new SumPosl(n, x);
            double sum = poslidovnist.CalculateSum();

            Console.WriteLine("Сума послідовності: " + sum);
        }
    }
}
