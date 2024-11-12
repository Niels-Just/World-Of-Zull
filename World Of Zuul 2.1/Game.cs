using System.Xml.Schema;
using Microsoft.Win32.SafeHandles;

namespace World_Of_Zuul;
/* Hovedklasse til at starte spillet
 */
using System.Collections;

class Game {
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  
  // Initialiserer kommandoer til spillet
  private static void InitRegistry (Player player) {
    ICommand cmdExit = new CommandExit();
    registry.Register("luk", cmdExit);
    registry.Register("gå", new CommandGo());
    registry.Register("hjælp", new CommandHelp(registry));
    registry.Register("inventar", new CommandInventory(player));
    registry.Register("opsamle", new CommandPickUp(player));
    registry.Register("søg", new CommandSearch());
    registry.Register("sammensæt", new CommandAssemble(player));
    registry.Register("folk", new CommandPeople());
    registry.Register("tal", new CommandTalk());
  }
  
  // Animerer en velkomstbesked
  private static void AnimatedText(string message, int delay, int displayTime)
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
  

  // Hovedfunktion for spillet
  static void Main (string[] args) {
    AnimatedText("Velkommen til World Of Zuul! \n", 10, 200);

    // Fnorkel NPC velkomst med langsom dialog
    AnimatedText("En mærkelig alien ved navn Fnorkel står foran dig, ser bekymret og lidt desperat ud.\n" +
                 "Fnorkel: \"Hilsner, rejsende! Jeg er Fnorkel, en udforsker fra en fjern galakse.\" \n" +
                 "Fnorkel: \"Mit rumskib styrtede ned her, og jeg har brug for solpaneler for at reparere det og vende hjem.\" \n" +
                 "Fnorkel: \"Kan du hjælpe mig med at samle de dele, der skal bruges til at bygge et kraftigt solpanelsystem?\" \n" +
                 "Fnorkel: \"Sammen udforsker vi dette land, samler delene og udnytter solens kraft!\" \n", 8,200);
    
    // Opsætning af spiller og initialisering af kommandoer
    Player player = new Player();
    Item frame = new Item("Frame", "The foundation for making a solar panel");
    Item glass = new Item("Glass", "Protects the solar cells while still letting light through");
    player.AddItem(glass);
    player.AddItem(frame);
  
    
    InitRegistry(player);
    context.GetCurrent().Welcome();
    
    // Hovedspilsloop
    while (context.IsDone() == false) {
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line != null) registry.Dispatch(line);
    }

    //if {}
    //Console.WriteLine("Game Over 😥");

    Console.WriteLine("Spillet er slut 😥");
  }
  
}
