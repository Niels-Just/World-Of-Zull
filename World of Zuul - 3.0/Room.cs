namespace World_of_Zuul___3._0;

 public class Room : Node
{
    //room beskrivelse, dette er relvant for look komandoen
    private string description;
    //Dette er relevant for NPC klassen
    public List<NPC> npcer;
    public Room(string name, string description) : base(name)
    {
        this.description = description;
        npcer = new List<NPC>();
    }
    
    //Denne metode bruges i look komandoen
    public string GetDescription()
    {
        return description;
    }
    
    //metode til at tilføje en NPC til et rum
    public void AddNPC(NPC npc)
    {
        npcer.Add(npc);
    }

    public void EnterRoomMsg()
    {
        Console.Clear();
        TekstEffektKlassen.TekstEffect("Du befinder dig ved: " + name ,20,2000);
        
        //Her får hashsettet udskrevet alle keys (udgange i form af kompas direktioner) og printer dem ud til spilleren.
        HashSet<string> exits = edges.Keys.ToHashSet();
        Console.WriteLine("Dine mulige retninger du kan bevæger dig er:");
        foreach (String exit in exits)
        {
            Console.WriteLine(" - " + exit);
        }
        
        if (npcer.Count > 0)
        {
            Console.WriteLine("\nHer befinder: ");
            foreach (var npc in npcer)
            {
                Console.WriteLine($"- {npc.Name} sig\n");
            }
        }
    }
    
   

    //returnere den overritede metode som en Room type istedet for hvad ellers ville blive til en Node type.
    public override Room FollowEdge(string direction)
    {
        return (Room)(base.FollowEdge(direction));
    }
}


