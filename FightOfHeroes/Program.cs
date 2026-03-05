using FightOfHeroes;

//Create players
Console.WriteLine("Welcome to Fight Of Heroes!");
Hero playerOne = PlayerManager.CreatePlayer(); 
FightMechanics firstPlayer = new FightMechanics(playerOne);
Console.WriteLine("First player created!");
Console.WriteLine("Press any key to continue . . .");
Console.ReadLine();
Console.Clear();

Hero playerTwo;
Console.WriteLine("Is there second player?");
Console.WriteLine("Press any enter to confirm or any other key to decline.");
bool isFirstPlayerBot = false;
bool isSecondPlayerBot = false;
if (InputHandler.ConfirmEnter())
{
    playerTwo = PlayerManager.CreatePlayer();
    Console.WriteLine("Second player created!");
}
else
{
    playerTwo = PlayerManager.CreateBot();
    isSecondPlayerBot = true;
    Console.WriteLine("Bot created!");
}


FightMechanics secondPlayer = new FightMechanics(playerTwo);
Console.WriteLine("Press any key to continue . . .");
Console.ReadKey();
Console.Clear();
GameLoop fight = new GameLoop(firstPlayer, secondPlayer,isFirstPlayerBot, isSecondPlayerBot);
fight.Run();