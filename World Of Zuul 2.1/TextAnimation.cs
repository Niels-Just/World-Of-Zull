namespace World_Of_Zuul;

public static class TextAnimation
{
    public static void AnimatedText(string message, int delay, int displayTime)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(delay); // Forsinkelse for animationseffekt
        }
        Console.WriteLine();
        Thread.Sleep(displayTime);
        Console.Clear();
    }
}