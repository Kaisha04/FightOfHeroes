namespace FightOfHeroes;
///Треба доробити логіку битви з ботом. Зробити баланс. Погано логіка стаміни.
public class GameLoop
{
    private FightMechanics FirstPlayer{get; set;}
    private FightMechanics SecondPlayer{get; set;}
    public GameLoop(FightMechanics firstPlayer, FightMechanics secondPlayer)
    {
        FirstPlayer = firstPlayer;
        SecondPlayer = secondPlayer;
    }

    public void Run()
    {
        Console.WriteLine("=== FIGHT STARTED ===");
    
        while (FirstPlayer.Hero.IsAlive() && SecondPlayer.Hero.IsAlive())
        {
            Console.WriteLine("\n--------------------------------");
            MoveOfPlayer(FirstPlayer, SecondPlayer);
            if (!SecondPlayer.Hero.IsAlive())
            {
                Console.WriteLine($"{FirstPlayer.Hero.Name} WIN!");
                continue;
            }

            Console.WriteLine("--------------------------------");
            MoveOfPlayer(SecondPlayer, FirstPlayer);
            if (!FirstPlayer.Hero.IsAlive())
            {
                Console.WriteLine($" {SecondPlayer.Hero.Name} WIN!");
            }
        }
    
        Console.WriteLine("=== FIGHT FINISHED ===");
    }

    public static void MoveOfPlayer(FightMechanics fighter, FightMechanics defender)
    {
        bool heal = fighter.Hero is IHeal;
        Console.WriteLine($"{fighter.Hero.Name} is moving");
        Console.WriteLine("1 - Attack\n2 - Increase stamina");
        if (heal) Console.WriteLine("3 - Heal");
        int step = InputHandler.DigitalInput(1, heal ? 3 : 2,"Choose an option");

        switch (step)
        {
            case 1:
            {
                int damage = fighter.Attack();
                Console.WriteLine($"{fighter.Hero.Name} attacks for {damage} dmg!");

                int defence = defender.Defence(damage);
                Console.WriteLine($"{defender.Hero.Name} blocked {damage - defence} dmg and took {defence} dmg.");
                break;
            }
            case 2:
            {
                Console.WriteLine($"{fighter.Hero.Name} restored {fighter.IncreaseStamina()} stamina.");
                break;
            }
            case 3:
            {
                Console.WriteLine($"{fighter.Hero.Name} restored {fighter.Heal()} hp");
                break;
            }
        }
    }
}
