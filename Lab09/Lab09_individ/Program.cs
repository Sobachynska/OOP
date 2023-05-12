using System;

namespace EquationSolver
{
    public delegate double FunctionDelegate(double x);

    public class ChordMethodSolver
    {
        private const double Epsilon = 1e-6; // Точність обчислень

        public double Solve(FunctionDelegate function, double a, double b)
        {
            double fa = function(a);
            double fb = function(b);

            if (Math.Abs(fa) < Epsilon)
            {
                return a; // Значення a вже є коренем
            }

            if (Math.Abs(fb) < Epsilon)
            {
                return b; // Значення b вже є коренем
            }

            if (fa * fb > 0)
            {
                throw new ArgumentException("The function values at a and b must have opposite signs.");
            }

            double x;
            do
            {
                x = (a * fb - b * fa) / (fb - fa);
                double fx = function(x);

                if (Math.Abs(fx) < Epsilon)
                {
                    return x; // Знайдений корінь
                }

                if (fa * fx < 0)
                {
                    b = x;
                    fb = fx;
                }
                else
                {
                    a = x;
                    fa = fx;
                }
            } while (Math.Abs(b - a) > Epsilon);

            return (a + b) / 2; // Повертаємо середнє значення, як наближений корінь
        }
    }

    class Program
    {
        static double MyFunction(double x)
        {
            // Задайте свою функцію тут
            return x * x - 4;
        }

        static void Main(string[] args)
        {
            ChordMethodSolver solver = new ChordMethodSolver();
            FunctionDelegate function = MyFunction;

            double root = solver.Solve(function, 1, 3);
            Console.WriteLine("Root: " + root);
        }
    }
}