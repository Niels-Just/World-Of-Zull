namespace World_of_Zuul___3._0;

public class Room
{
    public string Description { get; }
    public Dictionary<string, Room> Exits { get; set; }

    public Room(string description)
    {
        Description = description;
        Exits = new Dictionary<string, Room>();
    }

    public void SetExit(string direction, Room room)
    {
        Exits[direction]=room;
    }

    public Room GetExit(string direction)
    {
        Exits.TryGetValue(direction, out Room room);
        return room;
    }
}