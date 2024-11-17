namespace World_of_Zuul___3._0;

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


}