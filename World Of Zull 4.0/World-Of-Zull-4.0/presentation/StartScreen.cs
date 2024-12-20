namespace World_Of_Zull_4._0.presentation
{
    public class StartScreen
    {
        public static void Show()
        {
            Console.Clear();
            string title = "      SOLARIUM";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n");
            
            TextEffect.TxtEffect(title, 30, 1000);
            
            Console.ResetColor();

            // Vis menuen og læs brugerens input
            ShowMenu();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\n\n\nSkriv 'start' for at starte spillet, eller 'slut' for at afslutte.\n");
            string userInput = Console.ReadLine().ToLower(); // Læs brugerens input og gør det til små bogstaver

            if (userInput == "start")
            {
                StartGame();  // Kald en metode til at starte spillet
            }
            else if (userInput == "slut")
            {
                ExitGame();   // Kald en metode til at afslutte spillet
            }
            //denne start kommando skipper introen for en hurtigere start.
            else if (userInput == "devskip")
            {
                Console.Clear();
            }
            else
            {
                // Hvis brugeren skriver noget andet, vis en fejlmeddelelse og gentag menuen
                TextEffect.TxtEffect("\nUgyldigt valg, prøv igen.",20,200);
                Console.Clear();
                ShowMenu();
            }
        }

        private static void StartGame()
        {
            Console.Clear();
            TextEffect.TxtEffect("Starter spillet.....", 30, 1000);

            
            Console.ResetColor();

            
             TextEffect.TxtEffectNpc("I dette spil spiller du som Solvej." +
                                               " \nSolvej er en pige, der bor i et hus sammen med sine forældre!" +
                                               "\nSolvej elsker klimaet! Endda så meget at hun har fået overtalt sine forældre til at få installeret solceller på taget!" +
                                               "\nSolvej har brugt sine egne lommepenge på at hjælpe sine forældre med at betale det!" +
                                               "\nHeldigt for hende og forældrene, får de masser af penge tilbage ved at sælge den overskydende energi!" +
                                               "\nEn dag da Solvej sidder ude i baghaven og nyder den dejlige sol, bliver der pludseligt helt mørkt." +
                                               "\nDer er noget stort som er fløjet lige ind foran solen, og det er direkte på vej ned mod Solvej!" +
                                               "\nSolvej skynder sig væk, og lige som hun når ind i huset, styrter en UFO ned i baghaven!", 25);
             
             
             TextEffect.TxtEffectNpc("Ufoen er gået helt i stykker!\n" +
                                               "På trods af den voldsomme situation, kan Solvej ikke lade hver med at ligge mærke til solcellen som sidder på UFOens tag!\n" +
                                               "Ud af den helt smadrede UFO, stiger en lang og tydeligt rundtosset skikkelse ud!\n" +
                                               "Først bliver Solvej lidt bange, men skikkelsen ser overhovedet ikke uhyggelig ud.\n" +
                                               "Skikkelsen lyder til at bande på et eller andet sprog, pludselig får den øje på Solvej!\n" +
                                               "Uden at tøve skifter den over i rigsdansk!\n", 25);

             Console.ForegroundColor = ConsoleColor.Yellow;
             TextEffect.TxtEffectNoClear("Fnorkel:\n", 25, 500);
             Console.ResetColor();
             TextEffect.TxtEffectNpc("Hilsner, rejsende! Jeg er Fnorkel, en udforsker fra en fjern galakse.\n" +
                                     "Mit rumskib styrtede ned her, og jeg har brug for solpaneler for at reparere det og vende hjem.\n" +
                                     "Kan du hjælpe mig med at samle de dele, der skal bruges til at bygge et kraftigt solpanelsystem?\n" +
                                     "Sammen udforsker vi dette land, samler delene og udnytter solens kraft!\n", 25);
             
             Console.ForegroundColor = ConsoleColor.Yellow;
             TextEffect.TxtEffectNoClear("Solvej tænker: \n\n", 25, 500);
             Console.ResetColor();
             
             TextEffect.TxtEffectNoClear("Jeg må hjælpe stakkels Fnorkel, så han kan komme tilbage til sin planet. \n" +
                                         "Desuden har jeg ikke lyst til at have ham boende i min baghave! \n" +
                                         "Hans rumskib er utroligt avanceret, fyldt med teknologi, jeg aldrig har set magen til på Jorden. \n" +
                                         "Men solpanelet – det genkender jeg! Fantastisk, at en så avanceret civilisation bruger vedvarende energi!\n\n", 25, 500);
             
             Console.ForegroundColor = ConsoleColor.Green;
             TextEffect.TxtEffectNoClear("Hun samler en ødelagt del op fra det smadrede solpanel og studerer den nøje. \n\n", 25, 500);
             Console.ResetColor();

             TextEffect.TxtEffectNpc(
                 "Dette kan jeg godt genskabe, men jeg mangler nogle essentielle dele. Måske kan nogen i nabolaget hjælpe mig med at finde dem.\n",
                 25);
             
             

            // Sæt farven tilbage til default, så den næste tekst ikke påvirkes af farverne
            Console.ResetColor();
        }

        private static void ExitGame()
        {
            Console.Clear();
            TextEffect.TxtEffect("\n\n\nAfslutter spillet!", 20, 300);
            Environment.Exit(0);  // Afslut programmet
        }
    }
}
