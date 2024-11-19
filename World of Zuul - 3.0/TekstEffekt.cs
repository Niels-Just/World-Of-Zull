namespace World_of_Zuul___3._0
{
    public class TekstEffektKlassen
    {
        public static void TekstEffect(string besked, int pauseMellemC, int pauseEfter)
        {
            foreach (char c in besked)
            {
                Console.Write(c);
                Thread.Sleep(pauseMellemC);
            }
            Thread.Sleep(pauseEfter);
            Console.Clear();
        }

        public static void TekstEffectNPC(string besked, int pauseMellemC)
        {
            foreach (char c in besked)
            {
                Console.Write(c);
                Thread.Sleep(pauseMellemC);
            }
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine("\n\nKlik på 'enter' for at komme videre.");
            
            //Console.ForegroundColor = ConsoleColor.Black; 
            Console.ResetColor();
            
            Console.ReadLine();
            Console.Clear();
        }
    }
}
