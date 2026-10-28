//KLassfil för GAME
//Spelets logik
//Starta spelet
//Skapa karaktär
//Hantera rummen
//Avgöra när spelet är slut



using System;
using System.Collections.Generic;
using System.Threading.Tasks;

//Namespace som som representerar spelet som klass tillhör
namespace DungeonExplorer
{
    //KLASS: 
    //Skapar klassen Game som hanterar spelets logik och håller ihop alla delarna
    public class Game
    {
        //VARIABLER OCH LISTOR

        //Variabel player för spelarens karaktär
        private Character player;

        //Lista som ska innehålla spelets fem rum
        //Hämtar info från Room-klassen
        private List<Room> rooms = new List<Room>();

        //Anger hur många rum som ska finnas
        private int totalRooms = 5;

        //Listade namn på spelets fem rum 
        private List<string> roomNames = new List<string>
        {
            "The Forgotten Gate",
            "The Shadow Hall",
            "The Forgotten Crypt",
            "The Goblin's Lair",
            "The Cursed Chamber"
        };

        //Håller koll på hur många rum spelaren har utforskat
        //0 som starvärde
        private int currentRoom = 0;

        //Håller koll på hur många tomma rum som har skapats (ska va max 1)
        //0 som startvärde
        private int emptyRooms = 0;

        //Håller koll på om spelet är igång
        public bool GameRunning { get; private set; } = true;

        //Håller koll på om spelet är avklarat
        private bool gameCompleted = false;

        //Hanterar sparandet av spelets resultat
        private SavedResult savedResult = new SavedResult();

        //Lagrar antalet besegrade goblins
        //Startvärde 0
        private int goblinsDefeated = 0;



        /// //////////////////////////////////////////////


        //KONSTRUKTOR
        //Konstruktor som körs när ett Game objekt skapas
        public Game()
        {
            //PLAYER NAME
            //Variabel som lagrar spelarens namn
            //? kan innehålla text eller null
            string? playerName;


            do
            {
                //Färg på startsida
                Console.ForegroundColor = ConsoleColor.Magenta;
                //Visar spelets namn och välkomstmeddelande
                Console.WriteLine("//////////////////////////");
                Console.WriteLine("     DUNGEON EXPLORER");
                Console.WriteLine("//////////////////////////");
                Console.ResetColor();
                Console.WriteLine();

                Console.WriteLine("");

                //Welcome to Dungeon Explorer!
                Console.WriteLine("Welcome to Dungeon Explorer!");
                Console.WriteLine("");
                Console.WriteLine("Explore the five chambers of the dungeon,");
                Console.WriteLine("face it's creatures, and claim it's hidden treasures.");
                Console.WriteLine("");
                //Frågar spelaren om ett karaktärsnamn
                Console.WriteLine("Choose a name for your character");

                //Läser av namnet som spelaren skriver
                playerName = Console.ReadLine();

                //Kontrollerar om namnet är tomt eller bara innehåller mellanslag/blanksteg
                if (string.IsNullOrWhiteSpace(playerName))
                {
                    //Felmeddelande vid tomt/blank
                    Console.WriteLine("You must enter a name.");
                }

                //while = fråga körs så länge inmatat värde är tomt/blank
            } while (string.IsNullOrWhiteSpace(playerName));

            //Vid korrekt värde: 
            //Skapar spelarens karaktär med namn som spelare angivit
            player = new Character(playerName);

            //ROOMS
            //Skapar spelets fem rum
            //Loopas tills antalet är samma som totalRooms som är fem
            //Börjar från 1 (ej array)
            for (int i = 1; i <= totalRooms; i++)
            {

                //Skapar ett rum med det aktuella rumsnumret i loopen
                Room room = new Room(i);

                //Slumpar fram en händelse för det aktuella rummet
                //Anropar medtod från Room-klassen
                room.GenerateRandomEvent();

                //Kontrollerar om rummet blev tomt då max för detta ska vara ett
                if (room.EventType == RoomEvent.Empty)
                {
                    //Kontrollerar om två tomma rum har skapats
                    if (emptyRooms >= 1)
                    {
                        //Om gränsen är nådd blir rummet i stället en fiende
                        room.EventType = RoomEvent.Enemy;
                    }
                    else
                    {
                        //Ökar räknaren då ett tomt rum har skapats
                        emptyRooms++;
                    }
                }

                //Lägger till rummet i listan som samlar alla rum
                rooms.Add(room);
            }

        }


        /// //////////////////////////////////////////////


        //METODER

        //SPELARINFO
        //Metod som visar spelarens information
        //Hämtar info från character-klass. Objekt player och dess egenskaper
        public void ShowPlayerInfo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            //Skriver ut spelarens namn
            Console.WriteLine($"Character: {player.Name}");

            //Skriver ut spelarens aktuella hälsa
            Console.WriteLine($"Health: {player.Health}");

            //Skriver ut hur många drycker spelaren har
            Console.WriteLine($"Potions: {player.Potions}");

            //Skriver ut hur mycke guld spelaren har
            Console.WriteLine($"Gold: {player.Gold}");
            Console.ResetColor();
        }


        //STARTMENY
        //Metod som visar startmenyn innan själva spelet börjar
        public async Task ShowStartMenu()
        {
            //Visar startmenyn så länge spelaren inte har valt att starta eller avsluta
            while (true)
            {


                //Välkomnar spelaren
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Welcome, {player.Name}!");
                Console.ResetColor();
                Console.WriteLine();

                //Visar alternativen i startmenyn
                //Starta eller avsluta spel
                Console.WriteLine("1. Start game");
                Console.WriteLine("2. View previous results");
                Console.WriteLine("3. Quit game");

                //Läser in spelarens val och sparar i ManuChoise. Får ha värdet null
                string? menuChoice = Console.ReadLine();

                //Kontrollerar vilket alternativ spelaren valde
                switch (menuChoice)
                {
                    case "1":
                        //Startar spelet med att visa huvudmenyn
                        await ShowMenu();
                        return;


                    case "2":
                        //Visar tidigare spelresultat
                        ShowPreviousResults();
                        break;

                    case "3":
                        //Avslutar spelet
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("");
                        Console.WriteLine("Thanks for playing!");
                        Console.ResetColor();
                        //markerar att spelet ska avslutas
                        GameRunning = false;

                        return;

                    default:
                        //Hanterar ett val som inte finns i menyn
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("");
                        Console.WriteLine("Choose your next move, adventurer. Enter 1, 2 or 3");
                        Console.ResetColor();
                        break;
                }
            }
        }


        //TIDIGARE SPELRESULTAT
        //Metod som visar tidigare sparade spelresultat
        public void ShowPreviousResults()
        {
            //Hämtar alla sparade spelresultat
            List<GameResult> results = savedResult.GetResults();

            //Visar rubriken
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine("////////// PREVIOUS RESULTS ///////////");
            Console.ResetColor();

            //Kontrollerar om det finns några sparade resultat
            if (results.Count == 0)
            {
                //Om inte visas felmeddelande
                Console.WriteLine("No previous results found.");
            }
            else
            {
                //Går igenom och visar varje sparat resultat
                foreach (GameResult result in results)
                {
                    //Visar spelarens namn
                    Console.WriteLine($"Player: {result.PlayerName}");

                    //Visar om spelaren vann eller förlorade
                    if (result.Victory)
                    {
                        Console.WriteLine("Result: Victory");
                    }
                    else
                    {
                        Console.WriteLine("Result: Defeat");
                    }

                    //Visar hur många rum spelaren utforskade
                    Console.WriteLine($"Rooms explored: {result.RoomsExplored}");

                    //Visar hur mycke guld som samlats in
                    Console.WriteLine($"Gold collected: {result.GoldCollected}");

                    //Skiljelinje mellan varje resultat
                    Console.WriteLine("----------------------------");
                }
            }

            //Väntar på att spelaren trycker enter så att resultaten hinner läsas
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("");
            Console.WriteLine("Press enter to return to the start menu.");
            Console.ResetColor();
            Console.ReadLine();
        }



        //HUVUDMENY
        //Metod som visar spelets huvudmeny
        public async Task ShowMenu()
        {
            //Visar menyn så länge spelet är igång
            while (GameRunning)
            {

                //Visar alternativ som spelaren kan välja
                Console.WriteLine("----------------------------");
                Console.WriteLine("What will you do, adventurer?");
                Console.WriteLine("");
                Console.WriteLine("1. Explore the next chamber");
                Console.WriteLine("2. View character status");
                Console.WriteLine("3. Abandon the dungeon");
                Console.WriteLine("----------------------------");


                //Läser in spelarens val. 1, 2, 3 eller 4
                string? menuChoice = Console.ReadLine();

                //Kontrollerar vilket alternativ spelaren valde
                switch (menuChoice)
                {
                    case "1":
                        //Låter spelaren utforska nästa rum
                        await ExploreNextRoom();
                        break;

                    case "2":
                        //Visar spelarens aktuella information
                        ShowPlayerInfo();
                        break;


                    case "3":
                        //Avslutar spel
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("");
                        Console.WriteLine("Thanks for playing!");
                        Console.ResetColor();
                        GameRunning = false;
                        break;

                    default:
                        //Hanterar ett val som inte finns i menyn
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("");
                        Console.WriteLine("Choose your next move, adventurer. Enter 1, 2 or 3.");
                        Console.ResetColor();
                        break;
                }
            }
        }


        //UTFORSKA RUM
        //Metod som låter spelaren utforska nästa rum
        public async Task ExploreNextRoom()
        {
            /////Hantering av rum  //////

            //Kontrollerar om alla rum redan har utforskats

            //Ökar antalet utforskade rum med ett
            currentRoom++;

            //Hämtar rummet som spelaren går in i
            //-1 då räkning av rum börjar från 1 och inte 0 som startvärde (som i index)
            Room room = rooms[currentRoom - 1];

            //Visar vilket rum spelaren har kommit till
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Room {currentRoom} of {totalRooms}");
            //Visar namnet på rummet som spelaren kommit till
            Console.WriteLine($"You enter: {roomNames[currentRoom - 1]}");
            Console.ResetColor();


            //////// Hanterar händelse //////

            //Kontrollerar vilken händelse rummet innehåller
            switch (room.EventType)
            {
                case RoomEvent.Enemy:

                    //Skapar en fiende
                    Enemy enemy = new Enemy("Goblin");

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("");
                    Console.WriteLine("A dangerous goblin appears!");
                    Console.ResetColor();

                    //Startar en strid mellan spelare och fienden
                    await StartCombat(enemy);

                    break;

                //Hanterar upphittad skatt (spelaren ska kunna samla in en sakt som är ett random nummer från 10 - 50)
                case RoomEvent.Treasure:

                    //KOntrollerar om skatten redan blivit insamlad
                    if (room.TreasureCollected)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("This treasure has already been claimed.");
                        break;
                    }

                    //Visar att en skatt har hittats
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You found a treasure!");
                    Console.ResetColor();


                    //Spelaren får välja om skatten ska samlas in
                    Console.WriteLine("");
                    Console.Write("Choose an option:");
                    Console.WriteLine("");
                    Console.WriteLine("1. Collect treasure");
                    Console.WriteLine("2. Leave treasure");


                    //Läser in vad spelaren valt. sparas som text i choice
                    //+ nullhantering
                    string choice = Console.ReadLine() ?? "";

                    //Kontrollerar spelarens val (1 eller 2) och skriver ut meddelande för valet
                    if (choice == "1")
                    {

                        //Markerar skatten som insamlad (ska inte gå o samla in fler gånger)
                        room.TreasureCollected = true;

                        Console.WriteLine("");
                        Console.WriteLine("You have collected the treasure!");

                        //Slumpar fram en belöning mellan 10 och 50 guldmynt
                        //Sparas i goldFound som heltal
                        Random random = new Random();
                        int goldFound = random.Next(10, 51);

                        //Lägger till guldmynten i spelarens totala guldmängd
                        //Hanteras med character-klass
                        player.Gold = player.Gold + goldFound;

                        //Visar spelaren hur mycket guld som hittats
                        Console.WriteLine("");
                        Console.WriteLine($"You found {goldFound} gold coins!");

                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You left the treasure behind.");
                    }
                    else
                    {
                        //Om man trycker nåt annat
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("");
                        Console.WriteLine("The dungeon does not understand your command. The treasure lies forgotten.");
                        Console.ResetColor();
                    }

                    break;


                //Rummet är tomt
                case RoomEvent.Empty:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Nothing here but cold stone and the distant sound of dripping water.");
                    Console.ResetColor();
                    break;
            }

            //Kontrollerar om spelaren har utforskat alla rum och fortfarande lever
            if (currentRoom >= totalRooms && player.Health > 0 && !gameCompleted)
            {
                //Markerar att spelet är avslutat
                gameCompleted = true;

                //Skapar ett spelresultat som visar att spelaren har vunnit
                GameResult result = new GameResult(
                    player.Name,
                    true,
                    currentRoom,
                    player.Gold
                );

                //Sparar spelresultatet i json filen
                await savedResult.SaveResultAsync(result);

                //Visar meddelande när spelaren har klarat alla rum
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Congratulations! You have completed the dungeon!");
                Console.WriteLine("You have survived all five chambers!");
                Console.WriteLine();
                //Visar hur mycket guld spelaren har samlat in
                Console.WriteLine($"Gold collected: {player.Gold}");
                //Visar hur många goblins spelaren har besegrat
                Console.WriteLine($"Goblins defeated: {goblinsDefeated}");
                Console.ResetColor();


                //Avslutar spelet
                GameRunning = false;
            }

        }


        //STRID
        //Metod som hanterar stide mella spelare och fiende
        //async används för att kunna använda await
        //task visar att metoden körs asynkontoch inte returnerar ett värde
        //Enemy är objektet som metoden förväntar sig få och enemy är parametern som tar emot objektet
        public async Task StartCombat(Enemy enemy)
        {
            //Visar att striden börjar
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Combat starts!");
            Console.ResetColor();

            //Fortsätter striden så länge både spelaren och fienden lever (har mer än 0 i hälsa)
            while (player.Health > 0 && enemy.Health > 0)
            {

                //Visar spelarens och fiendens hälsa
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine($"{player.Name}: {player.Health} health");
                //Visar hur många potions spelaren har kvar
                Console.WriteLine($"Potions remaining: {player.Potions}");
                Console.WriteLine("");
                Console.WriteLine($"{enemy.Name}: {enemy.Health} health");
                Console.ResetColor();

                //Visar spelarens val under striden
                Console.WriteLine();
                Console.WriteLine("Choose an action:");
                Console.WriteLine("[A] Attack");
                Console.WriteLine("[P] Use potion");

                //Läser av spelarens val
                string? combatChoice = Console.ReadLine();

                //Kontrollerar vilket alternativ spelaren valde
                //a för attack, p för att använda potion 
                //tolower för både små och stora bokstäver
                switch (combatChoice?.ToLower())
                {
                    case "a":
                        //Spelaren attackerar
                        //Attackstyrka sparas i damage
                        //Fiendens hälsa minskas med attackstyrkan
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        int damage = player.Attack();
                        enemy.Health = enemy.Health - damage;


                        //Skriver ut attack mot fiende

                        Console.WriteLine($"{player.Name} attacks {enemy.Name}!");
                        //Skriver ut fiendens hälsa efter attack
                        Console.WriteLine($"{enemy.Name} health after attack: {enemy.Health}");
                        Console.WriteLine("");

                        //Kontrollerar om fienden fortfarande lever (om den har mer än 0) 
                        if (enemy.Health > 0)
                        {
                            //Fienden attackerar spelaren tilbaka om den lever
                            //Attackstyrka sparas i enemyDamage
                            //Spelarens hälsa minskas med fiendens attackstyrka
                            int enemyDamage = enemy.Attack();
                            player.Health = player.Health - enemyDamage;

                            //Skriver ut fiendens attack
                            Console.WriteLine($"{enemy.Name} attacks {player.Name}!");
                            //skriver ut spelarens hälsa efter attack
                            Console.WriteLine($"{player.Name} health after attack: {player.Health}");
                            Console.ResetColor();
                        }

                        break;

                    case "p":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        //Försöker använda en dryck.
                        bool potionUsed = player.UsePotion();

                        //Visar om drycken kunde användas
                        if (potionUsed)
                        {
                            //Om man använder en potion
                            Console.WriteLine("You used a potion!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            //Kontrollerar om spelaren saknar potions
                            Console.WriteLine("");

                            if (player.Potions <= 0)
                            {
                                Console.WriteLine("Your potion pouch is empty. The dungeon offers no mercy.");
                            }
                            //Kontrollerar om spelarens hälsa redan är full
                            else if (player.Health >= 30)
                            {
                                Console.WriteLine("Your health is already full. You don't need a potion right now.");
                            }
                        }

                        break;


                    default:
                        //Om man inte skrivit in rätt val
                        Console.WriteLine("");
                        Console.WriteLine("The shadows cloud your judgment. Choose A to attack or P to use a potion.");
                        Console.ResetColor();
                        break;
                }
            }


            //Kontrollerar om spelaren har besegrats
            if (player.Health <= 0)
            {
                //Meddelande om spelaren besegrats
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Darkness claims another soul. Your adventure ends here...");
                Console.ResetColor();

                //Skapar ett resultat som innehåller spelarens uppgifter
                GameResult result = new GameResult(
                    player.Name,
                    false,
                    currentRoom,
                    player.Gold
                );

                //Sparar resultatet i JSON filen
                await savedResult.SaveResultAsync(result);

                //Då avslutas spelet
                GameRunning = false;
            }
            //Kontrollerar om fienden har besegrats
            else if (enemy.Health <= 0)
            {

                //Ökar räknaren med en när spelaren besegrar en fiende
                goblinsDefeated++;

                //Meddelande om spelaren besegrar fienden
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You defeated the {enemy.Name}!");
                Console.ResetColor();
            }

        }

    }

}