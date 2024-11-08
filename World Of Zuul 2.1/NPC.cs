namespace World_Of_Zuul;

public class NPC
{
    private List<Item> npcInventory;
    public string NpcName { get; set; }
    public string NpcDescription { get; set; }
    public List<string> Dialogue { get; set; }

    public NPC(string npcName, string npcDescription)
    {
        NpcName = npcName;
        NpcDescription = npcDescription;
        npcInventory = new List<Item>();
        Dialogue = new List<string>();
    }

    public string getNpcName()
    {
        return NpcName;
    }

    public override string ToString()
    {
        return$"{NpcName} - {NpcDescription}";
    }
    
    
    //adds item to npc iventory
    public void NpcAddItem(Item item)
    {
        npcInventory.Add(item);
    }

    //remove item from npc inventory
    public void NpcRemoveItem(string itemName)
    {
        foreach (var item in npcInventory)
        {
            if (item.ItemName == itemName)
            {
                npcInventory.Remove(item);
                return; // Return Exits the method when the item is removed
            }
        }
    }
    
    //shows what is in inventory
    public void NpcPrintInventory()
    {
        if (npcInventory.Count == 0)
        {
            Console.WriteLine($"{NpcName} har ikke nogle ting.");
        }
        else
        {
            Console.WriteLine($"{NpcName} har følgende ting:");
            foreach (var item in npcInventory)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    public void Talk()
    {
        Console.WriteLine("Talking...");
        NpcPrintInventory();
    }
}
