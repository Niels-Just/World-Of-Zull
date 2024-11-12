namespace World_of_Zuul___3._0;

class Program
{
    static void Main(string[] args)
    {
        Room room1 = new Room("a dark cave");
        Room room2 = new Room("a house");
        Room room3 = new Room("a forrest");
        Room room4 = new Room("a graveyard");
        
        room1.SetExit("north",room2);
        room2.SetExit("south",room1);
        room2.SetExit("east",room3);
        room3.SetExit("north",room2);
        
        //Starter spillet
        Game game = new Game(room1);
        game.ShowCurrentRoom();

        while (true)
        {
            Console.WriteLine("Enter a direction: \nnorth \nsouth \neast \nwest \n'exit' to quit:");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
            {
                break;
            }
            game.Move(input.ToLower());
        }
    }
} 