using System;

namespace GuessingGame
{
    static class Program
    {
        static void Main(string[] args)
        {
            Game.start();
            Game.checkWinner();
        }
    }


    class Ball
    {
        public int number;
    }

    static class Bag
    {
        public static List<Ball> balls = new List<Ball>();
        private static int numberOfBalls = 50;

        public static void create()
        {
            for(int i = 0;i < numberOfBalls;i++)
            {
                Ball ball = new Ball();
                ball.number = getBallNumber(i);
                balls.Add(ball);
            }
        }

        private static int getBallNumber(int i)
        {
            return i % 10;
        }

        public static void shuffle()
        {
            Random rand = new Random();
            for(int i = 0;i < numberOfBalls; i++)
            {
                int newIndex = rand.Next(0,50);
                Ball temp = balls[i];
                balls[i] = balls[newIndex];
                balls[newIndex] = temp;
            }
        }

        public static void printBag()
        {
            foreach(Ball ball in balls)
                Console.Write(ball.number);
        }
    }

    static class Game
    {
        private static List<int> player1Inputs = new List<int>();
        private static List<int> player2Inputs = new List<int>();
        private static int numberOfGuesses = 5;
        private static List<Ball> pulledBalls = new List<Ball>();
        public static void start()
        {
            Bag.create();
            Bag.shuffle();
            getPlayerInputs();
            getBallsFromBag();
        }

        private static void getPlayerInputs()
        {
            Console.WriteLine("Oyuncu 1, (0-9) arasında 5 tahminde bulun");
            for(int i = 0; i < numberOfGuesses; i++)
            {
                Console.WriteLine($"{i+1}.tahmin: ");
                int guess = Convert.ToInt32(Console.ReadLine());
                player1Inputs.Add(guess);
            }
            Console.WriteLine("Oyuncu 2, (0-9) arasında 5 tahminde bulun");
            for (int i = 0; i < numberOfGuesses; i++)
            {
                Console.WriteLine($"{i + 1}.tahmin: ");
                int guess = Convert.ToInt32(Console.ReadLine());
                player2Inputs.Add(guess);
            }
            Console.Clear();
        }

        private static void getBallsFromBag()
        {
            Random rand = new Random();
            for(int i = 0; i < numberOfGuesses; i++)
            {
                int randomIndex = rand.Next(0, 50);
                pulledBalls.Add(Bag.balls[randomIndex]);
            }
        }

        public static void checkWinner()
        {
            HashSet<Ball> player1CorrectGuesses = new HashSet<Ball>();
            string player1CorrectBalls = "";

            HashSet<Ball> player2CorrectGuesses = new HashSet<Ball>();
            string player2CorrectBalls = "";


            for (int i = 0; i < numberOfGuesses; i++)
            {
                for(int j = 0; j< numberOfGuesses; j++)
                {
                    if(pulledBalls[i].number == player1Inputs[j]) {
                        player1CorrectGuesses.Add(pulledBalls[i]);
                        player1CorrectBalls = player1CorrectBalls + " " +pulledBalls[i].number.ToString();
                    }

                    if (pulledBalls[i].number == player2Inputs[j])
                    {
                        player2CorrectGuesses.Add(pulledBalls[i]);
                        player2CorrectBalls = player2CorrectBalls + " " + pulledBalls[i].number.ToString();
                    }
                }
            }


            Console.WriteLine(
                $"[{( (player1CorrectGuesses.Count > player2CorrectGuesses.Count) ? "kazanan" : "kaybeden" )}] Oyuncu 1\nDoğru Tahminler{player1CorrectBalls}, {player1CorrectGuesses.Count} doğru tahmin.\n\n" +
                $"[{((player1CorrectGuesses.Count < player2CorrectGuesses.Count) ? "kazanan" : "kaybeden")}] Oyuncu 2\nDoğru Tahminler{player2CorrectBalls}, {player2CorrectGuesses.Count} doğru tahmin.\n\n"
                );
        }
    }

}