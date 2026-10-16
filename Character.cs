
//Klassfil för Character

//Användare skapar spelkaraktärkaraktär


using System;

//Namespace som som representerar spelet som klass tillhör
namespace DungeonExplorer
{

    //Klass som representerar spelarens karaktär
    //Pubilk då denna används på fler delar i programmet
    //Properites för namn, hälsa och potion
    //get och set gör det möjligt att läsa av värdet samt tilldela ett nytt värde
    public class Character
    {
        //Pubilk property som lagrar karaktärens namn i en textsträng
        public string Name { get; set; }

        //Pubik property som lagrar karaktärens hälsa i heltal
        public int Health { get; set; }

        //Pubilk property som lagrar antal potions karaktären har kvar i heltal
        public int Potions { get; set; }


        //KOnstruktor
        //Konstruktor som körst när ett nytt objekt för character skapas
        //Pub.ic då den används på fler ställen i programmet
        //Parameter name tar emot namnet på den nya karaktären (i en textsträng)
        public Character (string name)
        {
            //Tilldelar parameterns värde till property Name
            Name = name;

            //Tilldelar karaktären 30 healthpoints från start
            Health = 30;

            //Tilldelar karaktären två potions från start
            Potions = 2;
            
        }


    }


}



