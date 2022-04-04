using System;

namespace array_calculations
{
   class Program
    {
        static void Main()
        {
            Random rand = new Random();
            int[] array = getRandomNumberArray(rand,50);
            printArray(array);
            Console.WriteLine($"\n\nmax:{findMax(array)} min:{findMin(array)}");
            Console.WriteLine($"standard deviation: {calcStandardDeviation(array)}");
        }

        static int[] getRandomNumberArray(Random randGenerator,int lengthOfArray)
        {
            int[] array = new int[lengthOfArray];
           for (int i = 0; i < lengthOfArray; i++)
                array[i]= (randGenerator.Next(1,1000));

           return array;
        }

        static void printArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }

        static int findMin(int[] array)
        {
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
                if (array[i] < min)
                    min = array[i];
            return min;
        }

        static int findMax(int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
                if (array[i] > max)
                    max = array[i];
            return max;
        }

        static double calcMean(int[] array)
        {
            int total=0;
            for (int i = 0; i < array.Length; i++)
               total += array[i];

            return ((double)total)/array.Length;
        }

        static double calcStandardDeviation(int[] array)
        {
            double mean=calcMean(array);
            double total=0.0;
            for (int i = 0; i < array.Length; i++)
                total+= ( (array[i] - mean) * (array[i] - mean));
            
            return Math.Sqrt( total / (array.Length) );
        }
    }
}