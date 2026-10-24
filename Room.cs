// Klassfil för Room
//vilket nummer rummet har (1–5)
//vilken typ av händelse rummet innehåller

using System;

//Namespace som som representerar spelet som klass tillhör
namespace DungeonExplorer
{

    //HÄNDELSE I ETT RUM
    //Enum används för att ett bestämt antal förutbestämda värden används
    //Ett rum innehåller tre möjliga händelser, Fiende, skatt eller tomt
    public enum RoomEvent
    {
        Enemy,
        Treasure,
        Empty
    }

    //BESKRIVNING AV RUM
    //Klass som beskriver ett rum i grottan
    //Public då denna klass används på flera delar i programmet
    // Klass som beskriver ett rum i grottan.
    public class Room
    {
        //Egenskap som sparar rummets nummer
        //Sparas som heltal
        public int RoomNumber { get; set; }

        //Egenskap EventType som lagrar vilken händelse rummet innehåller 
        //De tre bestämda i RoomEvent
        public RoomEvent EventType { get; set; }

        //Egenskap som visar om skatten i rummet redan har samlats in
        public bool TreasureCollected { get; set; }



        //KONSTRUKTOR
        //Konstruktor som skapar ett nytt rum
        public Room(int roomNumber)
        {
            //Tilldelar rummets nummer
            RoomNumber = roomNumber;
        }



        //SKAPA EN RANDOM HÄNDELSE

        //Metod som slumpmässigt väljer en händelse för rummet
        //Publik metod då denna använd på flera delar i programmet
        public void GenerateRandomEvent()
        {
            //Skapar en objket för att slumpa fram en händelse
            Random random = new Random();

            //random.Next slumpar fram ett heltal. 0, 1 eller 2. (övre gräns 3 ingår inte i resultat)
            //Sparar som heltal i eventNumber
            int eventNumber = random.Next(0, 3);

            //Väljer händelse utifrån det slumpade talet
            //0 = fiende. 1 = skatt. 2 = tomt
            if (eventNumber == 0)
            {
                EventType = RoomEvent.Enemy;
            }
            else if (eventNumber == 1)
            {
                EventType = RoomEvent.Treasure;
            }
            else
            {
                EventType = RoomEvent.Empty;
            }
        }
    }
}

















