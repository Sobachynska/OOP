using System;

namespace MaxPositiveValue
{
    static class ArrayExtensions
    {
        public static int[] ReplacePositiveWithMax(this int[] source)
        {
            int max = source.Max();
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] > 0)
                {
                    source[i] = max;
                }
            }
            return source;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] source = { 5, 2, -7, 1, 9 };
            int[] destination = source.ReplacePositiveWithMax();
            Console.WriteLine("Source array: [{0}]", string.Join(", ", source));
            Console.WriteLine("Destination array: [{0}]", string.Join(", ", destination));
        }
    }
}