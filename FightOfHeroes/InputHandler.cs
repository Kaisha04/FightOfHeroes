namespace FightOfHeroes;

public static class InputHandler
{
    public static string  TextInput(int maxLength, string text)
    {   string? input;
        while (true)
        {
            Console.WriteLine("Max length: " + maxLength);
            Console.Write($"{text}: ");
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {Console.WriteLine("Invalid input"); continue;}
            string clearInput = input.Trim(); 
            if (clearInput.Length > maxLength) Console.WriteLine("Too many characters");
            else return input;
        }
    }

    public static int DigitalInput(int min, int max, string input = "Input number")
    {
        while (true)
        {
            Console.WriteLine("Input number in range: " + min + "-" + max);
            Console.Write(input+": ");
            bool tryParse = Int32.TryParse(Console.ReadLine(), out int number);
            if (tryParse)
            {
                if (number < min || number > max)
                {
                    Console.WriteLine("Out of range");
                    continue;
                }
                return number;
            }
                Console.WriteLine("Invalid input");
        }
    }

    public static bool ConfirmEnter() => Console.ReadKey().Key == ConsoleKey.Enter;
}