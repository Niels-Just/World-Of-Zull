namespace World_Of_Zuul;
// Vigtigt at namespace forbliver den samme. 

public class Player
{
    private List<Item> inventory;
    
    public Player()
    {
        inventory = new List<Item>();
    }

    public void AddItem(Item item)
    {
        inventory.Add(item);
        Console.WriteLine($"{item} Added to Inventory");
    }

    public void RemoveItem(string itemName)
    {
        var item = inventory.Find(i => i.ItemName == itemName);
        if (item != null)
        {
            inventory.Remove(item);
            Console.WriteLine($"{item} Removed from Inventory");
        }
        else
        {
            Console.WriteLine("You don't have this item in your inventory");
        }
    }
    public void PrintInventory()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("You don't have any items in your inventory");
        }
        else
        {
            Console.WriteLine("Your inventory:");
            foreach (var item in inventory)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}