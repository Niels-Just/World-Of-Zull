using World_Of_Zull_4._0.presentation;
using World_Of_Zull_4._0.data.World_Of_Zull_4._0.presentation;
namespace World_Of_Zull_4._0.domain;

public class Room : Node
{
    //room beskrivelse, dette er relvant for look komandoen
    private string description;
    //Dette er relevant for NPC klassen
    public List<Npc> Npcer;
    public Room(string name, string description) : base(name)
    {
        this.description = description;
        Npcer = new List<Npc>();
    }
    
    //Denne metode bruges i look komandoen
    public string GetDescription()
    {
        return description;
    }
    
    //metode til at tilføje en NPC til et rum
    //det er nødvendigt at bruge object her da den skal kunne tilføje fra to forskellige npc klasser
    public void AddNpc(object? npc)
    {
        if (npc is Npc)
        {
            Npcer.Add((Npc)npc);
        }
        else if (npc is NpCalien)
        {
            Npcer.Add((NpCalien)npc);
        }
    }

    public void EnterRoomMsg()
    {
        Console.Clear();
        TextEffect.TxtEffect("Du befinder dig nu i: " + Name ,20,2000);
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Dine mulige retninger du kan bevæge dig er:");
        Console.ResetColor();
        
        foreach (var exit in Edges)
        {
            string direction = exit.Key;
            Room connectedRoom = (Room)exit.Value;
            Console.WriteLine($" - {direction}: {connectedRoom.GetDescription()}");
        }
        
        
        if (Npcer.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nHer befinder: ");
            Console.ResetColor();
            foreach (var npc in Npcer)
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