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

    //Skapar klassen Game som hanterar spelets logik och håller ihop alla delarna
    public class Game
    {
        //PLAYER
        //Variabel player för spelarens karaktär
        //Private då denna används inom klassen bara
        private Character player;

        //ROOMS
        //Lista som ska innehålla spelets fem rum
        //Hämtar info från Room-klassen
        private List<Room> rooms = new List<Room>();

        //Anger hur många rum som ska finnas
        //Anges i heltal
        private int totalRooms = 5;
        //Håller koll på hur många rum spelaren har utforskat
        //0 som starvärde
        private int currentRoom = 0;
        //Håller koll på om spelet är igång
        private bool gameRunning = true;

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



        //METODER

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
                Console.WriteLine("3. View previous results");
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
                        //Visar ett meddelande tills resultatfunktionen är klar
                        Console.WriteLine("Previous results will be available soon.");
                        break;

                    case "4":
                        //Avslutar spel
                        Console.WriteLine("Thanks for playing!");
                        break;

                    default:
                        //Hanterar ett val som inte finns i menyn
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

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



        //Metod som låter spelaren utforska nästa rum
        public void ExploreNextRoom()
        {
            //Kontrollerar om alla rum redan har utforskats
            if (currentRoom >= totalRooms)
            {
                Console.WriteLine("You have explored all rooms.");
                return;
            }

            //Ökar antalet utforskade rum med ett
            currentRoom++;

            //Hämtar rummet som spelaren går in i
            //-1 då räkning av rum börjar från 1 och inte 0 som startvärde (som i index)
            Room room = rooms[currentRoom - 1];

            //Visar vilket rum spelaren har kommit till
            Console.WriteLine($"You enter room {room.RoomNumber}.");

            //Kontrollerar vilken händelse rummet innehåller
            switch (room.EventType)
            {
                case RoomEvent.Enemy:
                    Console.WriteLine("A dangerous goblin appears!");
                    break;

                case RoomEvent.Treasure:
                    Console.WriteLine("You found a treasure!");
                    break;

                case RoomEvent.Empty:
                    Console.WriteLine("This room is empty.");
                    break;
            }
        }




        //Metod som hanterar stide mella spelare och fiende
        //Enemy är objektet som metoden förväntar sig få och enemy är parametern som tar emot objektet
        public void StartCombat(Enemy enemy)
        {
            //Visar att striden börjar
            Console.WriteLine("Combat starts!");

            //Visar spelarens och fiendens hälsa
            Console.WriteLine($"{player.Name}: {player.Health} health");
            Console.WriteLine($"{enemy.Name}: {enemy.Health} health");

            //Hämtar spelarens attackskada
            //Lagras som heltal
            int damage = player.Attack();

            //minskar fiendens hälsa med spelarens skada
            enemy.Health = enemy.Health - damage;

            //Visar hur mycket skada spelaren gör
            Console.WriteLine($"{player.Name} attacks {enemy.Name}!");

            //Visar fiendens hälsa efter attacken
            Console.WriteLine($"{enemy.Name} health after attack: {enemy.Health}");
        }



    }

}