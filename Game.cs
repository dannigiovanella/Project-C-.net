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
            //Skapar spelarens karaktär och ger den ett namn
            // OBS! Danni är bara test. ta bort sen!!!
            player = new Character("Danni");
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