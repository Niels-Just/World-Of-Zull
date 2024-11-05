using Microsoft.Win32.SafeHandles;

namespace World_Of_Zuul;
/* Main class for launching the game
 */
using System.Collections;
//her laver vi et nyt objekt (world) som har informationerne om vores verden altså hvilke steder man kan gå hen osv.
//efter det sætter den context til noden hvor man starter. Den sættter icommand til "i dont know what you are saying" og derefter
//sætter den 
class Game {
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  
  //her bliver de forskellige commands lavet så man kan interagere med verdenen eksempelvis quit for at lukke programmet eller go for at bevæge sig
  private static void InitRegistry (Player player) {
    ICommand cmdExit = new CommandExit();
    registry.Register("exit", cmdExit);
    registry.Register("quit", cmdExit);
    registry.Register("bye", cmdExit);
    registry.Register("go", new CommandGo());
    registry.Register("help", new CommandHelp(registry));
    registry.Register("inventory", new CommandInventory(player));
    registry.Register("PickUp", new CommandPickUp(player));
    registry.Register("Search", new CommandSearch());
    registry.Register("Assemble", new CommandAssemble(player));
  }
  
//Dette er main koden som kører starten af spillet. Der bliver skabt et spiller objekt og derefter giver man ham et item.
//While loopet sørger for at spillet looper og læser dit input med readline indtil Context.isdone==true hvorefter spillet stopper
//og du får beskeden "game over"
  static void Main (string[] args) {
    Console.WriteLine("Welcome to the World of Zuul!");
    
    // Opretter en player med et inventory, samt et item som man starter med
    Player player = new Player();
    Item frame = new Item("Frame", "The foundation for making a solar panel");
    Item glass = new Item("Glass", "Protects the solar cells while still letting light through");
    player.AddItem(glass);
    player.AddItem(frame);
    
    InitRegistry(player);
    context.GetCurrent().Welcome();
    
    while (context.IsDone()==false) {
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line!=null) registry.Dispatch(line);
    }
    Console.WriteLine("Game Over 😥");
  }
}

