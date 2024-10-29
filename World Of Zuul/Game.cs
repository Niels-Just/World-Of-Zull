namespace World_Of_Zuul;
/* Main class for launching the game
 */
using System.Collections;

class Game {
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  
  
  private static void InitRegistry (Player player) {
    ICommand cmdExit = new CommandExit();
    registry.Register("exit", cmdExit);
    registry.Register("quit", cmdExit);
    registry.Register("bye", cmdExit);
    registry.Register("go", new CommandGo());
    registry.Register("help", new CommandHelp(registry));
    registry.Register("inventory", new CommandInventory(player));
  }
  

  static void Main (string[] args) {
    Console.WriteLine("Welcome to the World of Zuul!");
    
    // Opretter en player med et inventory, samt et item som man starter med
    Player player = new Player();
    Item flashlight = new Item("Flashlight", "Lets you navigate the dark");
    player.AddItem(flashlight);
    
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
