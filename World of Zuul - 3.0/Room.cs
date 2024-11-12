namespace World_of_Zuul___3._0;

public class Room
{
    private string description;

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    private Dictionary<string, Room> exits;
    
    public Dictionary<string, Room> Exits
    {
        get { return exits; }
        set { exits = value; }
    }

    public Room(string description)
    {
        Description = description;
        Exits = new Dictionary<string, Room>();
    }

    public void SetExit(string direction, Room room)
    {
        //tildeler et specifikt rum
        Exits[direction]=room;
    }

    public Room GetExit(string direction)
    {
        Exits.TryGetValue(direction, out Room room);
        return room;
    }
}