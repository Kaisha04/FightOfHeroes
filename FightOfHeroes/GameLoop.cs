namespace FightOfHeroes;
public class GameLoop
{
    private bool IsFirstPlayerBot { get; set; }
    private bool IsSecondPlayerBot { get; set; }
    private FightMechanics FirstPlayer{get; set;}
    private FightMechanics SecondPlayer{get; set;}
    public GameLoop(FightMechanics firstPlayer, FightMechanics secondPlayer, bool isFirstPlayerBot, bool isSecondPlayerBot)
    {
        FirstPlayer = firstPlayer;
        SecondPlayer = secondPlayer;
        IsFirstPlayerBot = isFirstPlayerBot;
        IsSecondPlayerBot = isSecondPlayerBot;
    }

    public void Run()
    {
         
        Console.WriteLine("=== FIGHT STARTED ===");
    
        while (FirstPlayer.Hero.IsAlive() && SecondPlayer.Hero.IsAlive())
        {
            PlayerManager.ShowPlayers(FirstPlayer.Hero, SecondPlayer.Hero);
            Console.WriteLine("\n--------------------------------");
            MoveOfPlayer(FirstPlayer, SecondPlayer,IsFirstPlayerBot);
            if (!SecondPlayer.Hero.IsAlive())
            {
                Console.WriteLine($"{FirstPlayer.Hero.Name} ------------WIN!------------");
                PlayerManager.ShowPlayers(FirstPlayer.Hero, SecondPlayer.Hero);
                continue;
            }
            Console.WriteLine("--------------------------------");
            MoveOfPlayer(SecondPlayer, FirstPlayer, IsSecondPlayerBot);
            if (!FirstPlayer.Hero.IsAlive())
            {
                Console.WriteLine($" {SecondPlayer.Hero.Name} ------------WIN!------------");
                PlayerManager.ShowPlayers(FirstPlayer.Hero, SecondPlayer.Hero);
            }
        }
        
    
        Console.WriteLine("=== FIGHT FINISHED ===");
    }

    public static void MoveOfPlayer(FightMechanics fighter, FightMechanics defender, bool isBot)
    {
        
        bool heal = fighter.Hero is IHeal;
        Console.WriteLine($"{fighter.Hero.Name} is moving");
        int step;
        if (isBot) step = PlayerManager.BotMove(fighter.Hero);
        else
        {
            Console.WriteLine("1 - Attack\n2 - Increase stamina");
            if (heal) Console.WriteLine("3 - Heal");
             step = InputHandler.DigitalInput(1, heal ? 3 : 2,"Choose an option");   
        }

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
