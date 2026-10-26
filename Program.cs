//MAIN Klassfil
//Ansvarar för att starta spelet
//Starta om spelet om spelaren väljer att spela igen

using System;

//Namespace som som representerar spelet som klass tillhör
using DungeonExplorer;


//Variabel som styr om spelaren vill spela igen
bool playAgain = true;

//upprepar spelet så länge spelaren vill spela igen
while (playAgain)
{

    //Skapar ett nytt spel
    Game game = new Game();

    //Visar spelets startmeny
    game.ShowStartMenu();


    //Variabel som lagrar spelarens svar
    //Kan innehålla nullvärde
    string? playAgainAnswer;

    // Upprepar frågan tills spelaren skriver Yes eller No
    do
    {
        //Frågar om spelaren vill spela igen
        Console.WriteLine("");
        Console.WriteLine("Do you want to play again? Yes or No?");

        //Läser in svaret och gör om det till stora bokstäver
        //toupper anropas bara om värdet inte är null
        playAgainAnswer = Console.ReadLine()?.ToUpper();

        //Kontrollerar att svaret är Ye eller No
        if (playAgainAnswer != "YES" && playAgainAnswer != "NO")
        {
            //Visas om spelaren har skrivit ett ogiltigt svar
            Console.WriteLine("");
            Console.WriteLine("The dungeon doesn't understand! Please enter Yes or No.");
        }

    } while (playAgainAnswer != "YES" && playAgainAnswer != "NO");

    //Kontrollerar spelarens svar 
    //Om yes är true börjar ett nytt spel
    if (playAgainAnswer == "YES")
    {
        //Sätter variabeln till true
        //Loopen börjar om och ett nytt spel skapas
        //Spelaren tas tillbaka till start
        playAgain = true;
    }
    else
    {
        //Om yes är false:
        //Sätter variabeln till false
        //Loopen avslutas och programmet går vidare till slutet
        playAgain = false;

        //Visar ett meddelande innan avslut
        Console.WriteLine("Thanks for playing Dungeon Explorer!");
    }
}







