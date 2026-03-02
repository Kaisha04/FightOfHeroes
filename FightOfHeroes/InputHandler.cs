namespace FightOfHeroes;

public static class InputHandler
{
    public static string  TextInput(int maxLength)
    {   string input = string.Empty;
        while (true)
        {
            Console.ReadLine();
            Console.WriteLine("Max length: " + maxLength);
            Console.Write("Enter Hero name: ");
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {Console.WriteLine("Invalid input"); continue;}
            string ClearInput = input.Trim(); 
            if (ClearInput.Length > maxLength) Console.WriteLine("Too many characters");
            else return input;
        }
    }

    public int DigitalInput()
    {
        //Доробити ввід цифр 
    }
    public static void ShowHerosTypes()
    {
        int i = 0;
        foreach (var heroType in Enum.GetValues(typeof(HeroType)).Cast<HeroType>())
        {
            i++;
            Console.WriteLine(i + ". "+ heroType);
            }
    }
}