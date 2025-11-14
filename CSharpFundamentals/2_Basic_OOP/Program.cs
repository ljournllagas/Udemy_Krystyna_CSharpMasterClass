class Program
{
    static void Main()
    {
        var numberToGuess = Dice.Roll();
        var guess = new GuessGame(numberToGuess, maxAttempts: 3);
        
        while (!guess.IsGameOver)
        {
            Console.WriteLine("Enter your guess: ");

            if (int.TryParse(Console.ReadLine(), out int number))
            {
             
                Console.WriteLine(guess.ProcessGuess(number));

            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}

public static class Dice
{
    private static readonly Random random = new Random();

    public static int Roll()
    {
        return random.Next(1, 7);
    }
}

public class GuessGame
{
    public int NumberToGuess { get; }

    private readonly int maxAttempts;

    private int _attempts { get; set; }

    public bool IsCorrect { get; private set; }

    public bool IsGameOver => IsCorrect || _attempts >= maxAttempts;

    public GuessGame(int numberToGuess, int maxAttempts)
    {
        NumberToGuess = numberToGuess;
        this.maxAttempts = maxAttempts;
    }

    public string ProcessGuess(int guess)
    {
        _attempts++;

        if (guess == NumberToGuess)
        {
            IsCorrect = true;
            return "You win!";
        }

        if (!IsGameOver)
        {
            return "Wrong number";
        }

        return "Wrong number\nYou lose!";
    }


}