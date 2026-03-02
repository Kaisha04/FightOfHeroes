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
if (InputHandler.ConfirmEnter())
{
    playerTwo = PlayerManager.CreatePlayer();
    Console.WriteLine("Second player created!");
}
else
{
    playerTwo = PlayerManager.CreateBot();
    Console.WriteLine("Bot created!");
}


FightMechanics secondPlayer = new FightMechanics(playerTwo);
Console.Clear();
PlayerManager.ShowPlayers(playerOne, playerTwo);
Console.WriteLine("Press any key to continue . . .");
Console.ReadKey();
Console.Clear();
GameLoop fight = new GameLoop(firstPlayer, secondPlayer);
fight.Run();