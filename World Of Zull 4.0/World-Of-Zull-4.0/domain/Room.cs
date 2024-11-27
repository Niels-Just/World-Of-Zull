using World_Of_Zull_4._0._presentation;
using World_Of_Zull_4._0.data.World_Of_Zull_4._0.presentation;
namespace World_Of_Zull_4._0.domain;

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
    //det er nødvendigt at bruge object her da den skal kunne tilføje fra to forskellige npc klasser
    public void AddNPC(object npc)
    {
        if (npc is NPC)
        {
            npcer.Add((NPC)npc);
        }
        else if (npc is NPCalien)
        {
            npcer.Add((NPCalien)npc);
        }
    }

    public void EnterRoomMsg()
    {
        Console.Clear();
        TextEffect.TxtEffect("Du befinder dig nu i: " + name ,20,2000);
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Dine mulige retninger du kan bevæge dig er:");
        Console.ResetColor();
        
        foreach (var exit in edges)
        {
            string direction = exit.Key;
            Room connectedRoom = (Room)exit.Value;
            Console.WriteLine($" - {direction}: {connectedRoom.GetDescription()}");
        }
        
        
        if (npcer.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nHer befinder: ");
            Console.ResetColor();
            foreach (var npc in npcer)
            {
                Console.WriteLine($"- {npc.Name} sig");
            }
        }
    }
    
    
    //returnere den overritede metode som en Room type istedet for hvad ellers ville blive til en Node type.
    public override Room FollowEdge(string direction)
    {
        return (Room)(base.FollowEdge(direction));
    }
    
    
}