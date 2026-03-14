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
                InputHandler.ConfirmEnter();
                continue;
            }
            Console.WriteLine("--------------------------------");
            MoveOfPlayer(SecondPlayer, FirstPlayer, IsSecondPlayerBot);
            if (!FirstPlayer.Hero.IsAlive())
            {
                Console.WriteLine($" {SecondPlayer.Hero.Name} ------------WIN!------------");
                PlayerManager.ShowPlayers(FirstPlayer.Hero, SecondPlayer.Hero);
                InputHandler.ConfirmEnter();
            }
            InputHandler.ConfirmEnter();
            Console.Clear();
        }
        
    
        Console.WriteLine("=== FIGHT FINISHED ===");
    }

    public static void MoveOfPlayer(FightMechanics fighter, FightMechanics defender, bool isBot)
    {
        
        Console.WriteLine($"{fighter.Hero.Name} is moving");
        Actions step;
        if (isBot) 
             step = PlayerManager.BotMove(fighter.Hero);
        else
        {
            List<Actions> choices = PermitAction(fighter);
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {GetDisplayName(choices[i])}");
            }
            step = ChooseAction(choices);
        }

        Console.WriteLine();
        switch (step)
        {
            case Actions.Attack:
            {
                int damage = fighter.Attack();
                Console.WriteLine($"{fighter.Hero.Name} attacks for {damage} dmg!");

                int defence = defender.Defence(damage);
                Console.WriteLine($"{defender.Hero.Name} blocked {damage - defence} dmg and took {defence} dmg.");
                break;
            }
            case Actions.RestoreStamina:
            {
                Console.WriteLine($"{fighter.Hero.Name} restored {fighter.IncreaseStamina()} stamina.");
                break;
            }
            case Actions.Heal:
            {
                Console.WriteLine($"{fighter.Hero.Name} restored {fighter.Heal()} hp");
                break;
            }
        }
    }
    
    
    private static List<Actions> PermitAction(FightMechanics hero)
    {
        List<Actions> choices = new List<Actions>();
        choices.Add(Actions.Attack);
        if (hero.Hero.Stamina < hero.Hero.MaxStamina)
            choices.Add(Actions.RestoreStamina);

        if (hero.Hero is IHeal && hero.Hero.Health < hero.Hero.MaxHealth)
            choices.Add(Actions.Heal);
        return choices;
    }
    
    private static Actions ChooseAction(List<Actions> actions)
    {
        
      int choice =  InputHandler.DigitalInput(1,actions.Count,"Choose an option");
      return actions[choice - 1];
    }
    public enum Actions : Byte
    {
        Attack = 1,
        RestoreStamina,
        Heal
    }

    public static string GetDisplayName(Actions action)
    {
        return action switch
        {
            Actions.Attack => "Attack",
            Actions.RestoreStamina => "Restore stamina",
            Actions.Heal => "Heal",
            _ => throw new ArgumentOutOfRangeException(nameof(action), action, null)
        };
    }
}
