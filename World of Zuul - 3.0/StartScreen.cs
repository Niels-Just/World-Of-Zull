namespace World_of_Zuul___3._0
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
            else
            {
                // Hvis brugeren skriver noget andet, vis en fejlmeddelelse og gentag menuen
                Console.WriteLine("\nUgyldigt valg, prøv igen.");
                ShowMenu();
            }
        }

        private static void StartGame()
        {
            Console.Clear();
            TextEffect.TxtEffect("Starter spillet.....", 30, 1000);

            
            Console.ResetColor();

            
             TextEffect.TxtEffectNpc("I Dette spil spiller du som Solvej." +
                                               "\nSolvej er en pige, hun bor alene i hendes forældres hus!" +
                                               "\nSolvej elskeeeer klimaet! Enda så meget at hun har fået installeret solceller på hele taget!" +
                                               "\nSolvej har selv betalt det, med hendes egne lommepenge!" +
                                               "\nHedligt for hende, for hun masser af sine penge tilbage ved at sælge den overskydende energi!" +
                                               "\nEn dag da SolVej sidder ude i baghaven og nyder den dejlige sol, bliver der pluseligt helt mørkt." +
                                               "\nDer er noget stort som er fløjet lige ind foran solen og det er direkte på vej mod Solvej!" +
                                               "\nSolvej skynder sig væk, og ligesom hun når ind i huset brager en UFO Ned i baghaven!", 3);
             
             
             TextEffect.TxtEffectNpc("Ufoen er gået helt i stykker!\n" +
                                               "På trods af den voldsomme situation, kan Solvej ikke lade hver med at ligge mærke til solcelleren som sidder på UFOens tag!\n" +
                                               "Ud af den helt smadret UFO stiger en lang og tydeligt rundtossede skikkelse ud!\n" +
                                               "Først bliver Solvej lidt bange, men skikkelsen ser overhovdet ikke uhyggelig ud.\n" +
                                               "Skikkelsen lyder til at bande på et eller andet sprog, pluselig for skikkelsen øje på Solvej!\n" +
                                               "Uden at tøve skifter skikkelsen over i risdansk!\n" +
                                               "Du må hjælpe mig siger den!", 3);

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
