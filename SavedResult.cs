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


        //Skapar en private list som bara ska kunnas användas inom klassen
        //Lista som kan innehålla flera spelresultat
        private List<GameResult> results = new List<GameResult>();


        // Konstruktor som körs när ett GameDataService-objekt skapas.
        public SavedResult()
        {
            //Kontrollerar om JSON filen redan finns
            if (File.Exists(gameResultsJson))
            {
                //Läser innehållet i filen och sparar det som text
                string jsonText = File.ReadAllText(gameResultsJson);

                //Omvandlar JSON texten till en lista med GameResult-objekt
                // ! används för att tala om att att lista ska returneras med deserialize, inte null
                results = JsonSerializer.Deserialize<List<GameResult>>(jsonText)!;
            }
        }


        //Metod för att spara spelresultat till JSON fil
        //void- returnerar inget värde. sparar bara data
        //GameResult är objektet som metoden tar emot
        //result - parametern som tar emot objeket i metoden
        public void SaveResult(GameResult result)
        {

            //Lägger till det nya spelresultatet i listan
            results.Add(result);

            //Omvandlar spelresultatet till JSON-text
            //serializeroptions writeindented används för att spara lista med formatering för radbrytning
            string jsonText = JsonSerializer.Serialize(results, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            //Skriver json-texten till filen gameResults.json
            //File.WriteALLText skapar filen
            File.WriteAllText(gameResultsJson, jsonText);
        }

    }

}