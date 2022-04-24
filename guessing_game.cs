namespace GuessingGame
{
    static class Program
    {
        static void Main(string[] args)
        {
            Game.start();
            Game.getCorrectGuesses();
            Game.printStatistics();
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
    }

    static class Game
    {
        private static List<int> player1Inputs = new List<int>();
        private static List<int> player2Inputs = new List<int>();
        private static int numberOfGuesses = 5;
        private static List<Ball> pulledBalls = new List<Ball>();

        private static List<Ball> player1CorrectGuesses = new List<Ball>();
        private static List<Ball> player2CorrectGuesses = new List<Ball>();
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

        public static void getCorrectGuesses()
        {
            for (int i = 0; i < numberOfGuesses; i++)
            {
                for(int j = 0; j< numberOfGuesses; j++)
                {
                    if(pulledBalls[i].number == player1Inputs[j]) 
                        player1CorrectGuesses.Add(pulledBalls[i]);

                    if (pulledBalls[i].number == player2Inputs[j])
                        player2CorrectGuesses.Add(pulledBalls[i]);
                }
            }
        }
        public static void printStatistics()
        {
            HashSet<int> correctGuesses = new HashSet<int>();
            foreach(Ball ball in player1CorrectGuesses)
                correctGuesses.Add(ball.number);

            Console.WriteLine($"Oyuncu 1:\n=== Doğru tahminler:{string.Join(",",correctGuesses)}\n" +
                $"=== {correctGuesses.Count} doğru tahmin.\n\n");
            
            int player1GuessCount = correctGuesses.Count;
            correctGuesses.Clear();
            foreach (Ball ball in player2CorrectGuesses)
                correctGuesses.Add(ball.number);

            Console.WriteLine($"Oyuncu 2:\n=== Doğru tahminler:{string.Join(",", correctGuesses)}\n" +
                $"=== {correctGuesses.Count} doğru tahmin.\n\n");

            Console.WriteLine($"\t{ checkWinner(player1GuessCount,correctGuesses.Count) }");
        }

        private static string checkWinner(int player1GuessCount,int player2GuessCount)
        {
            if (player1GuessCount == player2GuessCount) return "berabere";
            return (player1GuessCount > player2GuessCount) ? "oyuncu 1 kazandı" : "oyuncu 2 kazandı";
        }
    }

}