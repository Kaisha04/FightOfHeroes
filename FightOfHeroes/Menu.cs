namespace FightOfHeroes;

public static class Menu
{
    public static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to Fight Of Heroes");
        
    }

    public static void MainMenu()
    {
        Console.WriteLine("1 - One Player mode");
        Console.WriteLine("2 - Two Players mode");
        Console.WriteLine("3 - Only bots mode");
        switch (InputHandler.DigitalInput(1,3,"Choose mode"))
        {
             case 1: OnePlayerMode(); break;
             case 2: TwoPlayerMode(); break;
             case 3: OnlyBotMode(); break;
             default: throw new Exception("Invalid option");
        }
    }

    public static void OnePlayerMode()
    {
        Start(false,true);
    }

    public static void TwoPlayerMode()
    {
        Start(false,false);
    }

    public static void OnlyBotMode()
    {
        Start(true,true);
    }

    private static void Start(bool firstPlayerBot, bool secondPlayerBot)
    {
        Hero playerOne;
        Hero playerTwo;
        if (firstPlayerBot) playerOne = PlayerManager.CreateBot(); 
        else playerOne = PlayerManager.CreatePlayer();
        FightMechanics firstPlayer = new FightMechanics(playerOne);
        Console.WriteLine("First player created!");
        Console.WriteLine("Press any key to continue . . .");
        Console.ReadKey();
        Console.Clear();

        if (secondPlayerBot) playerTwo = PlayerManager.CreateBot();
        else playerTwo = PlayerManager.CreatePlayer();
        Console.WriteLine("Second player created!");
        
        FightMechanics secondPlayer = new FightMechanics(playerTwo);
        Console.WriteLine("Press any key to continue . . .");
        Console.ReadKey();
        Console.Clear();
        GameLoop fight = new GameLoop(firstPlayer, secondPlayer,firstPlayerBot, secondPlayerBot);
        fight.Run();
    }
}