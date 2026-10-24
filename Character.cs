
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

        //Pubilk propert som lagrar karaktärens antal guldmynt
        public int Gold { get; set; }

        //KOnstruktor
        //Konstruktor som körst när ett nytt objekt för character skapas
        //Public då den används på fler ställen i programmet
        //Parameter name tar emot namnet på den nya karaktären (i en textsträng)
        public Character(string name)
        {
            //Tilldelar parameterns värde till property Name
            Name = name;

            //Tilldelar karaktären 30 healthpoints från start
            Health = 30;

            //Tilldelar karaktären två potions från start
            Potions = 2;

            //Tilldelar karaktären noll guldmynt från start
            Gold = 0;

        }



        //Action  metoder

        //Attackera
        //Metod som returnerar hur mycket skada karaktären gör vid en attack
        //Public då metod ska användas på andra delar i programmet
        //Skada räknas i heltal
        public int Attack()
        {
            //Returnerar attackens grundskada
            return 5;
        }

        //Läka
        //Metod som försöker använda en potion
        //bool - Returnerar true om drycken används och false om det inte går
        //Public då metod ska användas på andra delar i programmet
        //Helth och potions används från character objektet
        public bool UsePotion()
        {
            //Kontrollerar om karaktären saknar drycker
            if (Potions <= 0)
            {
                return false;
            }

            //Kontrollerar om karaktärens hälsa redan är full (30 health poits)
            if (Health >= 30)
            {
                return false;
            }

            //Återställer 10 health points men inte mer än 30
            //Math.Min väljer det lägsta av två värden. Om health är 25 blir resultatet 30 inte 35
            Health = Math.Min(Health + 10, 30);

            //Minskar antalet drycker med ett
            Potions = Potions - 1;

            //Bekräftar att drycken användes
            return true;
        }





    }


}



