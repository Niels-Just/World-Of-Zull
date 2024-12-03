using World_Of_Zull_4._0._presentation;
namespace World_Of_Zull_4._0.presentation;

public class EndScreen
{

    public static void EndText()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        TextEffect.TxtEffectNoClear("Fnorkel:\n\n", 25, 500);
        Console.ResetColor();
        TextEffect.TxtEffectNpc("Jeg er en taknemmelig rejsende fra en fjern galakse. \n" +
                                "Det solpanel, du har skabt, er intet mindre end perfekt – en strålende bedrift!\n" +
                                "Jeg håber, at du nu er blevet oplyst om, hvor fantastiske solpaneler virkelig er. \n" +
                                "Tiden er inde til at forlade denne planet. Hvis vi skulle krydse veje igen i fremtiden, håber jeg at se dit tag fyldt med solpaneler!\n", 25);
    }
    
    public static void SlutAnimation()
    {
        // Mere detaljeret rumskib, der vender mod højre
        string[] spaceship =
        {

            "          / \\        ",
            "         /   \\       ",
            "        /     \\      ",
            "       /_______\\     ",
            "        |     |       ",
            "        |     |       ",
            "       /|_____|\\     ",
            "      /_________\\    ",
            "       |   |   |      ",
            "      /    |    \\    ",
            "     /     |     \\   ",
            "    |______|______|   ",
            "        | |   | |     ",
            "        |_|   |_|     ",
        };

        int screenWidth = 50; // Dynamisk konsolbredde
        int delay = 40; // Millisekunder mellem frames
        for (int i = 0; i < screenWidth; i++)
        {
            Console.Clear(); // Ryd skærmen
            // Tegn rumskibet
            foreach (string line in spaceship)
            {
                Console.WriteLine(new string(' ', i) + line);
            }
            Thread.Sleep(delay);
        }
    }
}
