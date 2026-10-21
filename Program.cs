//MAIN Klassfil

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
