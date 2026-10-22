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



        //KONSTRUKTOR
        //Konstruktor som skapar ett nytt rum
        public Room(int roomNumber)
        {
            //Tilldelar rummets nummer
            RoomNumber = roomNumber;
        }
    }
}

















