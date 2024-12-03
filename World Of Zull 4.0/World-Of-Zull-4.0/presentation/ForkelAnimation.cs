namespace World_Of_Zull_4._0.presentation;

public class FnorkelAnimation
{
    
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
