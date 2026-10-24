//KLassfil för GAME
//Spelets logik
//Starta spelet
//Skapa karaktär
//Hantera rummen
//Avgöra när spelet är slut



using System;
using System.Collections.Generic;

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

        //Håller koll på om spelet är igång
        private bool gameRunning = true;

        //Håller koll på om spelet är avklarat
        private bool gameCompleted = false;

        //Hanterar sparandet av spelets resultat
        private SavedResult savedResult = new SavedResult();



        /// //////////////////////////////////////////////


        //KONSTRUKTOR
        //Konstruktor som körs när ett Game objekt skapas
        public Game()
        {
            //PLAYER NAME
            //Variabel som lagrar spelarens namn
            //? kan innehålla text eller null
            string? playerName;

            //Do = fråga om namn ska altid köras minst en gång
            do
            {
                //Frågar spelaren om ett karaktärsnamn
                Console.WriteLine("What is your characters name?");

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
            //Skriver ut spelarens namn
            Console.WriteLine($"Spelare: {player.Name}");

            //Skriver ut spelarens aktuella hälsa
            Console.WriteLine($"Hälsa: {player.Health}");

            //Skriver ut hur många drycker spelaren har
            Console.WriteLine($"Potions: {player.Potions}");
        }


        //STARTMENY
        //Metod som visar startmenyn innan själva spelet börjar
        public void ShowStartMenu()
        {
            //Visar startmenyn så länge spelaren inte har valt att starta eller avsluta
            while (true)
            {


                //Visar spelets namn och välkomstmeddelande
                Console.WriteLine("//////////////////////////");
                Console.WriteLine("     DUNGEON EXPLORER");
                Console.WriteLine("//////////////////////////");
                Console.WriteLine();

                //Välkomnar spelaren
                Console.WriteLine($"Welcome, {player.Name}!");
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
                        ShowMenu();
                        return;


                    case "2":
                        //Visar tidigare spelresultat
                        ShowPreviousResults();
                        break;

                    case "3":
                        //Avslutar spelet
                        Console.WriteLine("Thanks for playing!");
                        gameRunning = false;

                        break;

                    default:
                        //Hanterar ett val som inte finns i menyn
                        Console.WriteLine("Invalid choice. Please enter 1, 2 or 3");
                        break;
                }
            }
        }


/// ///////////////////////////// OBS: LÄGG TILL TOATLT SKATTER I RESULTAT HÄR!


        //TIDIGARE SPELRESULTAT
        //Metod som visar tidigare sparade spelresultat
        public void ShowPreviousResults()
        {
            //Hämtar alla sparade spelresultat
            List<GameResult> results = savedResult.GetResults();

            //Visar rubriken
            Console.WriteLine();
            Console.WriteLine("////////// PREVIOUS RESULTS ///////////");

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

                    //Skiljelinje mellan varje resultat
                    Console.WriteLine("----------------------------");
                }
            }

            //Väntar på att spelaren trycker enter så att resultaten hinner läsas
            Console.WriteLine("Press enter to return to the start menu.");
            Console.ReadLine();
        }



        //HUVUDMENY
        //Metod som visar spelets huvudmeny
        public void ShowMenu()
        {
            //Visar menyn så länge spelet är igång
            while (gameRunning)
            {

                //Visar alternativ som spelaren kan välja
                Console.WriteLine(" DUNGEON EXPLORER ");
                Console.WriteLine("1. Explore next room");
                Console.WriteLine("2. View player status");
                Console.WriteLine("4. Quit game");

                //Läser in spelarens val. 1, 2, 3 eller 4
                string? menuChoice = Console.ReadLine();

                //Kontrollerar vilket alternativ spelaren valde
                switch (menuChoice)
                {
                    case "1":
                        //Låter spelaren utforska nästa rum
                        ExploreNextRoom();
                        break;

                    case "2":
                        //Visar spelarens aktuella information
                        ShowPlayerInfo();
                        break;


                    case "3":
                        //Avslutar spel
                        Console.WriteLine("Thanks for playing!");
                        gameRunning = false;
                        break;

                    default:
                        //Hanterar ett val som inte finns i menyn
                        Console.WriteLine("Invalid choice. Please enter 1, 2 or 3.");
                        break;
                }
            }
        }

        //VISA RUM

        //Metod som visar alla rum i spelet
        public void ShowRooms()
        {
            //Går igenom alla rum i rumlistan
            foreach (Room room in rooms)
            {
                //Skriver ut rummets nummer
                Console.WriteLine($"Room: {room.RoomNumber}");

                //KOntrollerar vilken händelse som rummet innehåller
                //KOntrollerar mot värdet som finns i EventType
                //skriver ut meddelande för respektive händelse
                switch (room.EventType)
                {
                    //Enemy
                    case RoomEvent.Enemy:
                        //Meddelande vid fiende
                        Console.WriteLine("A dangerous goblin appears!");

                        //Skapar en fiende med namnet Goblin
                        Enemy enemy = new Enemy("Goblin");

                        //Visar fiendens namn och hälsa
                        Console.WriteLine($"Enemy: {enemy.Name}");
                        Console.WriteLine($"Enemy health: {enemy.Health}");
                        break;

                    //Treasure
                    case RoomEvent.Treasure:
                        //Meddelande vid skatt
                        Console.WriteLine("You found a treasure!");
                        break;

                    //Empty
                    case RoomEvent.Empty:
                        //Meddelande vid tomt
                        Console.WriteLine("This room is empty.");
                        break;
                }

                //Tom rad mellan rummen
                Console.WriteLine();
            }
        }


        //UTFORSKA RUM
        //Metod som låter spelaren utforska nästa rum
        public void ExploreNextRoom()
        {
            //Kontrollerar om alla rum redan har utforskats
            if (currentRoom >= totalRooms)
            {
                Console.WriteLine("You have explored all rooms.");

                //Kontrollerar att segern inte redan har registrerats
                if (!gameCompleted)
                {
                    //Skapar ett spelresultat som visar att spelaren har vunnit
                    GameResult result = new GameResult(
                        player.Name,
                        true,
                        currentRoom
                    );

                    //Sparar spelresultatet i JSON filen
                    savedResult.SaveResult(result);

                    //Visar ett meddelande när spelaren har klarat alla rum
                    Console.WriteLine("Congratulations! You have completed the dungeon!");
                    Console.WriteLine("You can now choose to quit the game from the menu");
                }

                return;
            }

            //Ökar antalet utforskade rum med ett
            currentRoom++;

            //Hämtar rummet som spelaren går in i
            //-1 då räkning av rum börjar från 1 och inte 0 som startvärde (som i index)
            Room room = rooms[currentRoom - 1];

            //Visar vilket rum spelaren har kommit till
            Console.WriteLine($"Room {currentRoom} of {totalRooms}");
            //Visar namnet på rummet som spelaren kommit till
            Console.WriteLine($"You enter: {roomNames[currentRoom - 1]}");

            //Kontrollerar vilken händelse rummet innehåller
            switch (room.EventType)
            {
                case RoomEvent.Enemy:

                    //Skapar en fiende
                    Enemy enemy = new Enemy("Goblin");

                    Console.WriteLine("A dangerous goblin appears!");

                    //Startar en strid mellan spelare och fienden
                    StartCombat(enemy);

                    break;

                case RoomEvent.Treasure:
                    Console.WriteLine("You found a treasure!");
                    break;

                case RoomEvent.Empty:
                    Console.WriteLine("This room is empty.");
                    break;
            }
        }


        //STRID
        //Metod som hanterar stide mella spelare och fiende
        //Enemy är objektet som metoden förväntar sig få och enemy är parametern som tar emot objektet
        public void StartCombat(Enemy enemy)
        {
            //Visar att striden börjar
            Console.WriteLine("Combat starts!");

            //Fortsätter striden så länge både spelaren och fienden lever (har mer än 0 i hälsa)
            while (player.Health > 0 && enemy.Health > 0)
            {

                //Visar spelarens och fiendens hälsa
                Console.WriteLine();
                Console.WriteLine($"{player.Name}: {player.Health} health");
                Console.WriteLine($"{enemy.Name}: {enemy.Health} health");

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
                        int damage = player.Attack();
                        enemy.Health = enemy.Health - damage;

                        //Skriver ut attack mot fiende
                        Console.WriteLine($"{player.Name} attacks {enemy.Name}!");
                        //Skriver ut fiendens hälsa efter attack
                        Console.WriteLine($"{enemy.Name} health after attack: {enemy.Health}");

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
                        }

                        break;

                    case "p":
                        //Försöker använda en dryck.
                        bool potionUsed = player.UsePotion();

                        //Visar om drycken kunde användas
                        if (potionUsed)
                        {
                            //Om man använder en potion
                            Console.WriteLine("You used a potion!");
                        }
                        else
                        {
                            //Om man inte har någon potion 
                            Console.WriteLine("You cannot use a potion right now.");
                        }
                        break;

                    default:
                        //Om man inte skrivit in rätt val
                        Console.WriteLine("Invalid choice. Choose A or P.");
                        break;
                }
            }


            //Kontrollerar om spelaren har besegrats
            if (player.Health <= 0)
            {
                //Meddelande om spelaren besegrats
                Console.WriteLine("You have been defeated!");

                //Skapar ett resultat som innehåller spelarens uppgifter
                GameResult result = new GameResult(
                    player.Name,
                    false,
                    currentRoom
                );

                //Sparar resultatet i JSON filen
                savedResult.SaveResult(result);

                //Då avslutas spelet
                gameRunning = false;
            }
            //Kontrollerar om fienden har besegrats
            else if (enemy.Health <= 0)
            {
                //Meddelande om spelaren besegrar fienden
                Console.WriteLine($"You defeated the {enemy.Name}!");
            }

        }

    }

}