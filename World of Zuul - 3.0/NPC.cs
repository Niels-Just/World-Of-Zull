namespace World_of_Zuul___3._0;

public class NPC
{
    public string Name;
    public string Description;

    public NPC(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Talk()
    {
        Console.Clear();
        TekstEffektKlassen.TekstEffectNPC($"{Name}: {Description}", 40); 
    }
}