namespace FightOfHeroes;


public class FightMechanics
{
    private static Random _random = new Random();
    public Hero Hero { get; }
    public FightMechanics(Hero hero)
    {
        Hero = hero;
    }
    
    public int Attack()
    {
        bool minStamina = Hero.Stamina / 2 < 10;
        if (minStamina)
        {
            int damage = _random.Next(1, Math.Max(2, Hero.Stamina));
            
            return damage;   
        }
         return _random.Next(Hero.Stamina / 2, Hero.Stamina);
    }

    public int Defence(int damage)
    {
        if (Hero.Armor > 0)
        {
            int blockPercent = _random.Next(10, 51) * Hero.Armor / 100;
            Hero.LostArmor(blockPercent);
            int finalDamage = damage - blockPercent;
            if (finalDamage <= 0)
            {
                Hero.ApplyDamage(0);
                return finalDamage;    
            }
            Hero.ApplyDamage(finalDamage);
            return finalDamage;
        }
    
        Hero.ApplyDamage(damage);
        return damage;
    }

    public int IncreaseStamina()
    {
        if (Hero.Stamina >= Hero.MaxStamina) 
        {
            return 0;
        }
        int differenceInStamina = Hero.MaxStamina - Hero.Stamina;
        int restoredStamina = _random.Next(1, differenceInStamina + 1);
        Hero.ApplyStamina(restoredStamina);
        return restoredStamina;
    }
    
    public int Heal()
    {
        if (Hero is IHeal)
        {
            int heal;
            bool minStamina = Hero.Stamina / 2 < 10;
            if (minStamina)
            {
                heal = _random.Next(1, Math.Max(2, Hero.Stamina));
                Hero.LostStamina(heal);
                ((IHeal)Hero).GetHeal(heal);
                return heal;   
            }
             heal = _random.Next(Hero.Stamina / 2, Hero.Stamina);
             Hero.LostStamina(heal);
            ((IHeal)Hero).GetHeal(heal);
            return heal;
        }
        throw new Exception("Heal not found");
    }
}
