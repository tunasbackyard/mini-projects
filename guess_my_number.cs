using System;

namespace guess_my_number
{
   class Program
    {
        static void Main()
        {
            Random rand = new Random();
            Console.WriteLine("I'm guessing a number between 1-100"); int secretNumber = rand.Next(1, 100);
            int count = 1, guess;

            for (; (guess = getGuess()) != secretNumber; count++)
                Console.WriteLine($"The number is {(guess > secretNumber ? "less" : "greater")} than your guess.");
            Console.WriteLine($"Congrats, you got it in {count} tries and the number is {secretNumber}");
        }

        static int getGuess() => Convert.ToInt32(Console.ReadLine());

    }
}