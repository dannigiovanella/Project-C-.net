//Klassfil för att lagra resultat av en spelomgång
//Lagrar spelarens namn, vinst eller förlust och hur många rum som upptäckts
//Behövs för att spara dessa i JSON


using System;

//Namespace som som representerar spelet som klass tillhör
namespace DungeonExplorer
{


    //Skapar en publik klass GameResult för att lagra spelresultat
    public class GameResult
    {


        //Egenskap som anger spelarens namn i en textsträng
        public string PlayerName { get; set; }

        //Egenskap som anger om spelaren vann eller förlorade
        //bool för true/false
        public bool Victory { get; set; }

        //Egenskap som lagrar hur många rum spelaren utforskat
        //Sparas i heltal
        public int RoomsExplored
        {
            get; set;
        }

        //Egenskap som lagrar hur mycket guld spelaren samlat in
        public int GoldCollected { get; set; }


        //Konstruktor som skapar ett nytt spelresultat
        //Spelarens namn i en textsträng
        //Vinst eller ej som booleks
        //Antal rum som heltal
        public GameResult(string playerName, bool victory, int roomsExplored, int goldCollected)
        {
            //Sparar spelarens namn
            PlayerName = playerName;

            //Sparar om spelomgången slutade med vinst eller förlust
            Victory = victory;

            //Sparar antalet utforskade rum
            RoomsExplored = roomsExplored;

            //Sparar hur mycket guld spelaren samlat in
            GoldCollected = goldCollected;
        }
    }

}


