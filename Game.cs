//KLassfil för GAME
//Spelets logik
//Starta spelet
//Skapa karaktär
//Hantera rummen
//Avgöra när spelet är slut



using System;

//Namespace som som representerar spelet som klass tillhör
namespace DungeonExplorer
{


    //Skapar klassen Game som hanterar spelets logik och håller ihop alla delarna
    public class Game
    {

        //Variabel player för spelarens karaktär
        //Private då denna används inom klassen bara
        private Character player;


        //KONSTRUKTOR
        //Konstruktor som körs när ett Game objekt skapas
        public Game()
        {

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
        }



        //METODER

        //Metod som visar spelarens information i konsolen
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

    }

}