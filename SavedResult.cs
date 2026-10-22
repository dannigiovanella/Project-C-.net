//Klassfil som sparar tar emot och sparar resultatet i JSON
//Omvandlar informationen till JSON
//Sparar informationen till en JSON-fil


//Gör så att List (lista) kan användas i programmet. 
using System.Collections.Generic;

//System.IO används för att kunna hantera filer
//ex. kontroll. läsa av och skriva information till fil
using System.IO;

//System.Text.Json används för att kunna omvandla C# objekt till Json och omvänt
using System.Text.Json;

//Namespace som som representerar spelet som klass tillhör
namespace DungeonExplorer
{


    //Skapar en publik Klass som ansvarar för att spara spelresultat
    public class SavedResult
    {

        //Anger namnet på JSON-filen där spelresultatet ska sparas
        //Sparas i private variabel då bara ska användas inom denna klassen
        private string gameResultsJson = @"gameResults.json";


        //Metod för att spara spelresultat till JSON fil
        //void- returnerar inget värde. sparar bara data
        //GameResult är objektet som metoden tar emot
        //result - parametern som tar emot objeket i metoden
        public void SaveResult(GameResult result)
        {
            //Omvandlar spelresultatet till JSON-text
            string jsonText = JsonSerializer.Serialize(result);

            //Skriver json-texten till filen gameResults.json
            //File.WriteALLText skapar filen
            File.WriteAllText(gameResultsJson, jsonText);
        }

    }

}