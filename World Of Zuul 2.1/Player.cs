namespace World_Of_Zuul;
// Vigtigt at namespace forbliver den samme. 

public class Player
{
    //maintains a list of items 
    private List<Item> inventory;
    
    //the inventory is initalized as an empty list when a 'Player' object is instantiated 
    public Player()
    {
        inventory = new List<Item>();
    }
    
    //adds item to iventory
    public void AddItem(Item item)
    {
        inventory.Add(item);
        Console.WriteLine($"{item} Added to Inventory");
    }

    //remove item from inventory
    public void RemoveItem(string itemName)
    {
        var item = inventory.Find(i => i.ItemName == itemName);
        //checks if items is in inentory
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
    
    //shows what is in inventory
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