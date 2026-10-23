//MAIN Klassfil

using System.Collections.Generic;

using DungeonExplorer;


//ÄNDRA ALLA UTSKRIFTER TILL ENGELSKA SEN!

Console.WriteLine("Character");

//Skapar nytt objekt av klassen Character med namnet Danni (OBS TEST!!!!)
Character player = new Character("Danni");

//Skriver ut karaktärens namn
Console.WriteLine($"Namn: {player.Name}");

//Skriver ut hälsa (startvärde)
Console.WriteLine($"Hälsa: {player.Health}");

//Skriver ut antal potions (startvärde)
Console.WriteLine($"Potions: {player.Potions}");

//Hämtar attackens grundskada och skriver ut den
//Anropar metoden attack och sparar i heltalsvariabeln damage
int damage = player.Attack();
Console.WriteLine($"Attackskada: {damage}");

//Minskar hälsan tillfälligt för att kunna testa en dryck
player.Health = 20;

//Försöker använda en dryck och kontrollerar resultatet
//Anropar medoden usepotion och sparar i bolean variabel potionUsed
bool potionUsed = player.UsePotion();

//Skriver ut om drycken användes
Console.WriteLine($"Användes drycken? {potionUsed}");

//Skriver ut hälsan och antalet drycker efter användningen
Console.WriteLine($"Hälsa efter dryck: {player.Health}");
Console.WriteLine($"Drycker kvar: {player.Potions}");

Console.WriteLine();
Console.WriteLine("ENEMY");

//TEST FÖR ENEMY

//Skapar nytt objekt för en ny fiende med namnet Troll
Enemy enemy = new Enemy("Troll");

//Skriver ut fiendens namn och hälsa
Console.WriteLine($"Fiendens namn: {enemy.Name}");
Console.WriteLine($"Fiendens hälsa: {enemy.Health}");


//Hämtar fiendens attackskada
//Anropar metoden attack och sparar i heltalsvariabeln damage
int enemyDamage = enemy.Attack();

//Skriver ut hur mycket skada fienden gör
Console.WriteLine($"Fiendens attackskada: {enemyDamage}");



//TEST FÖR ROOM
Console.WriteLine();
Console.WriteLine("ROOM");

//Skapar ett rum med nummer 1
Room room = new Room(1);

//Slumpar fram en händelse för rumme med metoden GenerateRandomEvent
room.GenerateRandomEvent();

//skriver ut rummets information
Console.WriteLine($"Rumsnummer: {room.RoomNumber}");
Console.WriteLine($"Händelse: {room.EventType}");

//TEST FÖR SPELRESULTAT
Console.WriteLine();
Console.WriteLine("SPELRESULTAT");

//Skapar ett testresultat för en avslutad spelomgång
GameResult result = new GameResult("Danni", true, 5);

//Skriver ut resultatets egenskaper
Console.WriteLine($"Spelare: {result.PlayerName}");
Console.WriteLine($"Vinst: {result.Victory}");
Console.WriteLine($"Utforskade rum: {result.RoomsExplored}");


Console.WriteLine();

//TEST FÖR ATT SPARA FLERA RESULTAT
// Skapar ett objekt som hanterar sparandet av spelresultat
SavedResult savesResultTest = new SavedResult();

//Skapar ett spelresultat
GameResult result1 = new GameResult("Danni", true, 5);

//Sparar båda spelresultaten
savesResultTest.SaveResult(result1);


Console.WriteLine("ett spelresultat har sparats.");


Console.WriteLine();
Console.WriteLine("HIGH SCORE");

//TEST FÖR ATT HÄMTA ALLA SPELRESULTAT
// Skapar ett objekt som hanterar sparade resultat
SavedResult savedResult = new SavedResult();

//Hämtar listan med sparade spelresultat
List<GameResult> results = savedResult.GetResults();

//Skriver ut hur många resultat som finns sparade
Console.WriteLine($"Antal sparade resultat: {results.Count}");


//TEST AV GAME-OBJEKT
Console.WriteLine();
Console.WriteLine("GAME");

//Skapar ett nytt spel
Game game = new Game();

game.ExploreNextRoom();
game.ExploreNextRoom();

//Visar spelets meny
game.ShowMenu();





