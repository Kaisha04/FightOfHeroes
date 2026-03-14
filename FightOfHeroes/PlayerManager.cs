namespace FightOfHeroes;

public static class PlayerManager
{
    private static int _countOfHeroes = Enum.GetValues(typeof(HeroType)).Length;
    public static Hero CreatePlayer()
    {
        Console.WriteLine("Create a player");
        string name = InputHandler.TextInput(10, "Player name");
        Console.Clear();
        Console.WriteLine("Choose class of hero");
        ShowHerosTypes();
        HeroType heroType = (HeroType)InputHandler.DigitalInput(1,_countOfHeroes, "Choose class of player");
        Console.Clear();
        return heroType switch
        {
            HeroType.Paladin => new Paladin(name),
            HeroType.Assasin => new Assasin(name),
            HeroType.Mage => new Mage(name),
            HeroType.Vampire => new Vampire(name),
            _ => throw new ArgumentOutOfRangeException(nameof(heroType), heroType, null)
        };
    }
    public static Hero CreateBot()
    {
        string name = RandomNames();
        HeroType heroType = (HeroType)Random.Shared.Next(1,_countOfHeroes + 1);
        return heroType  switch
        {
            HeroType.Paladin => new Paladin(name),
            HeroType.Assasin => new Assasin(name),
            HeroType.Mage => new Mage(name),
            HeroType.Vampire => new Vampire(name),
            _ => throw new ArgumentOutOfRangeException(nameof(heroType), heroType, null)
        };
    }

    public static GameLoop.Actions BotMove(Hero first)
    {
        double healthPerc = first is IHeal ? (double)first.Health / first.MaxHealth * 100 : 100;
        double staminaPerc = (double)first.Stamina / first.MaxStamina * 100;
        int panicPerc = 50;
        if (healthPerc < panicPerc && healthPerc <= staminaPerc)
        {
            return GameLoop.Actions.Heal; 
        }
        if (staminaPerc < panicPerc)
        {
            return GameLoop.Actions.RestoreStamina; 
        }
        return GameLoop.Actions.Attack;
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
    public static string RandomNames()
    {
        return Random.Shared.Next(1,6) switch
        {
            1 => "Kater",
            2 => "Venom",
            3 => "Indo",
            4 => "Ferum",
            5 => "Invince",
            _ => "Unknown"
        };
    }

    public static void ShowPlayers(Hero first, Hero second)
    {
        const int colWidth = -25;
        
        Console.WriteLine($"{"--- Player 1 ---", colWidth} | --- Player 2 ---");
        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"{"Name: " + first.Name, colWidth} | {"Name: " + second.Name}");
        Console.WriteLine($"{"Health: " + first.Health, colWidth} | {"Health: " + second.Health}");
        Console.WriteLine($"{"Stamina: " + first.Stamina, colWidth} | {"Stamina: " + second.Stamina}");
        Console.WriteLine($"{"Armor: " + first.Armor, colWidth} | {"Armor: " + second.Armor}");
        Console.WriteLine($"{"Type of hero: " + first.HeroType, colWidth} | {"Type of hero: " + second.HeroType}");
    }
}