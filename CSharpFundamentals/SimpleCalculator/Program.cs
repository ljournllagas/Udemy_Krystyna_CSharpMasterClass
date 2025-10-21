class Program
{
    static void Main()
    {
        Console.WriteLine("Hello!");

        int num1 = ReadNumber("Input the first number:");
        int num2 = ReadNumber("Input the second number:");

        string operation = AskMathOperation();

        ComputeMathOperation(operation, num1, num2);
    }

    static int ReadNumber(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);

            if (int.TryParse(Console.ReadLine(), out int number))
                return number;

            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    static string AskMathOperation()
    {
        Console.WriteLine("\nWhat do you want to do with those numbers?");
        Console.WriteLine("[A]dd");
        Console.WriteLine("[S]ubtract");
        Console.WriteLine("[M]ultiply");

        while (true)
        {
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine()?.Trim().ToUpper();

            if (choice == "A" || choice == "S" || choice == "M")
                return choice;

            Console.WriteLine("Invalid option. Please enter A, S, or M.");
        }
    }

    static void ComputeMathOperation(string operation, int num1, int num2)
    {
        int result = operation switch
        {
            "A" => num1 + num2,
            "S" => num1 - num2,
            "M" => num1 * num2,
            _ => throw new InvalidOperationException("Unexpected operation.")
        };

        Console.WriteLine($"\nResult: {result}");
    }
}
