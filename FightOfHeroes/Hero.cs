namespace FightOfHeroes;

public abstract class Hero
{
    public static bool HeroHeal(Hero hero) => hero is IHeal;
    
    //Name of player
    public string? Name {get; private set;}
    
    //Player health
    public int MaxHealth {get; private protected set;}
    public int Health {get; private protected set;}
    
    //Player armor
    public int MaxArmor {get; private protected set;}
    public int Armor {get; set;}

    //Player stamina
    public int MaxStamina {get; private set;}
    public int Stamina  {get; private protected set;}
    
    public HeroType HeroType {get; private set;}
    
    public Hero()
    {}

     public Hero(string name, int maxHealth, int armor, int maxStamina, HeroType heroType)
    {
        Name = name;
        
        MaxHealth = maxHealth;
        Health = MaxHealth;
        
        MaxArmor = armor;
        Armor = MaxArmor;
        
        MaxStamina = maxStamina;
        Stamina = MaxStamina;
        
        HeroType = heroType;
    }
    //IsAliveCheck
    public bool IsAlive() =>  Health > 0;

    public void LostStamina(int lostStamina)
    {
        if (Stamina - lostStamina < 0) Stamina = 0;
        else Stamina -= lostStamina;
    }
    public void ApplyStamina(int lostStamina)
    {
        if (lostStamina + Stamina > MaxStamina) MaxStamina = Stamina;
        else Stamina += lostStamina;
    }
    
    
    public void ApplyDamage(int damage)
    {
        if (Health - damage < 0) Health = 0;
        else Health -= damage;
    }

    public void LostArmor(int pointsOfArmor)
    {
        if (Armor - pointsOfArmor < 0) Armor = 0;
        else Armor -= pointsOfArmor;
    }
    
    //Show stats of player
    public void ShowStats()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Health: {Health}");
        Console.WriteLine($"Armor: {Armor}");
        Console.WriteLine($"Stamina: {Stamina}");
    }
    
}

public class Paladin : Hero
{
    public  Paladin(string name) : base(name, 100, 50, 50, HeroType.Paladin)
    {}
}

public class Assasin : Hero
{
    public Assasin(string name) : base(name, 100, 50, 50, HeroType.Assasin)
    {}
}

public class Mage : Hero, IHeal
{
    public void GetHeal(int heal)
    {
        if (Health + heal > MaxHealth) MaxHealth = Health;
        else Health += heal;
    }
    public Mage(string name) : base(name, 100, 50, 50, HeroType.Mage)
    {}
}

public class Vampire : Hero, IHeal
{
    
    public void GetHeal(int heal)
    {
        if (Health + heal > MaxHealth) MaxHealth = Health;
        else Health += heal;
    }
    public Vampire(string name) : base(name, 100, 50, 50,HeroType.Mage)
    {}
}
public enum HeroType : byte
{
    Paladin = 1,
    Assasin,
    Mage,
    Vampire
}