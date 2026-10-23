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


        //Metod som visar alla rum i spelet
        public void ShowRooms()
        {
            //Går igenom alla rum i rumlistan
            foreach (Room room in rooms)
            {
                //Skriver ut rummets nummer
                Console.WriteLine($"Room: {room.RoomNumber}");
                //Skriver ut typ av händelse
                Console.WriteLine($"Event: {room.EventType}");
                //Radbrytning
                Console.WriteLine();
            }
        }

    }

}