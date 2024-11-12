namespace World_of_Zuul___3._0;

class Room : Node
{
    public Room(string name) : base(name)
    {
<<<<<<< HEAD
        get { return description; }
        set { description = value; }
=======
>>>>>>> refs/remotes/origin/main
    }

    public void EnterRoomMsg()
    {
        //Her får hashsettet udskrevet alle keys (udgange i form af kompas direktioner) og printer dem ud til spilleren.
        Console.WriteLine("Du er nu ved " + name);
        HashSet<string> exits = edges.Keys.ToHashSet();
        Console.WriteLine("Dine mulige udgange er:");
        foreach (String exit in exits)
        {
            Console.WriteLine(" - " + exit);
        }
    }

    //returnere den overritede metode som en Room type istedet for hvad ellers ville blive til en Node type.
    public override Room FollowEdge (string direction) {
        return (Room) (base.FollowEdge(direction));
    }
<<<<<<< HEAD

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
=======
}
>>>>>>> refs/remotes/origin/main
