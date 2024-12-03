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
                                "Tiden er inde til at forlade denne planet. \n" +
                                "Hvis vi skulle krydse veje igen i fremtiden, håber jeg at se solpaneler dække alle tage!\n" +
                                "Spred budskabet Solvej så dennde drøm kan blive sandhed.\n", 25);
    }
    
    public static void EndAnimation()
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

        int screenHeight = Console.WindowHeight;
        int delay = 100; // Delay mellem hvornår "rumskibet" bevæger sig.
        for (int i = screenHeight; i >= 0; i--)
        {
            Console.Clear(); 
            for (int j = 0; j < spaceship.Length; j++)
            {
                int position = i + j; 
                if (position >= 0 && position < screenHeight) 
                {
                    Console.SetCursorPosition(0, position); 
                    Console.WriteLine(spaceship[j]);
                }
            }
            Thread.Sleep(delay);
        }
    }
}
