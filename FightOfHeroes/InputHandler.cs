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
            else return clearInput;
        }
    }
    
    public static int DigitalInput(int min, int max, string input = "Input number", bool showRange = false)
    {
        while (true)
        {
            if (showRange)
                Console.WriteLine("Input number in range: " + min + "-" + max);
            Console.Write(input+": ");
            bool tryParse = Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out int number);
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

    public static void ConfirmEnter()
    {
        Console.WriteLine("For countinue, press any key...");
        Console.ReadKey();
    }
}