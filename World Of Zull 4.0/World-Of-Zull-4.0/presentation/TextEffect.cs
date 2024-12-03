namespace World_Of_Zull_4._0._presentation
{
    public class TextEffect
    {
        public static void TxtEffect(string message, int pauseBetweenC, int pauseAfter)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(pauseBetweenC);
            }

            Thread.Sleep(pauseAfter);
            Console.Clear();
        }

        public static void TxtEffectNpc(string message, int pauseBetweenC)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(pauseBetweenC);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nTryk på 'enter' for at komme videre.");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        break;
                    }
                }
            }
            Console.ResetColor();
        }
        
        public static void TxtEffectNoClear(string message, int pauseBetweenC, int pauseAfter)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(pauseBetweenC);
            }

            Thread.Sleep(pauseAfter);
        }
    }
    
}
