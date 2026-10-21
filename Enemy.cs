
//Klassfil för speles fiender

using System;

//Namespace som som representerar spelet som klass tillhör
namespace DungeonExplorer
{

    //Klass som representerar enemy
    //Pubilk då denna används på fler delar i programmet
    //Properites för namn och health
    //get och set gör det möjligt att läsa av värdet samt tilldela ett nytt värde
    public class Enemy
    {
        //Pubilk property som lagrar karaktärens namn i en textsträng
        public string Name { get; set; }

        //Pubik property som lagrar karaktärens hälsa i heltal
        public int Health { get; set; }


        //KOnstruktor
        //Konstruktor som körst när ett nytt objekt för Enemy skapas
        //Public då den används på fler ställen i programmet
        //Parameter name tar emot namnet fienden (i en textsträng)
        public Enemy (string name)
        {
            //Tilldelar parameterns värde till property Name
            Name = name;

            //Tilldelar fienden 15 healthpoints från start
            Health = 30;

            
        }
    }
}