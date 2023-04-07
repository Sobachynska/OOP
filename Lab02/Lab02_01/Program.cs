using System;

namespace MaxPositiveValue //максимальне позитивне значення
{
    static class ArrayExtensions
    
    {
        public static int[] ReplacePositiveWithMax(this int[] source)
        //ReplacePositiveWithMax - змінити позитивне на максимальне, метод розширення для int[]типу
        //за допомогою статичного класу ArrayExtensions
        {
            int max = source.Max(); 
            for (int i = 0; i < source.Length; i++) //цикл
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
            Console.WriteLine("Source array: [{0}]", string.Join(", ", source)); //string.Join() - метод
            Console.WriteLine("Destination array: [{0}]", string.Join(", ", destination));
        }
    }
}