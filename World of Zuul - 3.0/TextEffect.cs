namespace World_of_Zuul___3._0
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
            Console.WriteLine("\n\nTryk på 'enter' for at komme videre.");
            
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
        }
    }
}
