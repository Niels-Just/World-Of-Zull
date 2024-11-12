namespace World_of_Zuul___3._0;

public class Game
{
    private Room currentRoom;

    public Game(Room startingRoom)
    {
        currentRoom = startingRoom;
    }

    public void Move(string direction)
    {
        Room nextRoom = currentRoom.GetExit(direction);
        if (nextRoom != null)
        {
         currentRoom = nextRoom;
         Console.WriteLine($"You moved to: {currentRoom.Description}");
        }
        else
        {
            Console.WriteLine("You need to enter a valid room!");
        }
    }

    public void ShowCurrentRoom()
    {
        Console.WriteLine($"You are in: {currentRoom.Description}");
    }
}