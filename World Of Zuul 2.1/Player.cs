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
    
    public bool HasItem(params string[] itemNames)
    {
        bool itemfound = false;
        foreach (var itemName in itemNames)
        {
            foreach (var item in inventory)
            {
                if (item.ItemName == itemName)
                {
                    itemfound = true;
                    break; // If item is found in inventory itemfound == true and it starts looking for the next item.
                }
            }
            if (itemfound == false)
            {
                return false; // If Item is not found the bool HasItem() returns false.
            }
        }
        return true; // Only if itemfound == true for all items (ex. HasItem(item1, item2, item3) the method returns true
    }
    
    //adds item to iventory
    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    //remove item from inventory
    public void RemoveItem(string itemName)
    {
        foreach (var item in inventory)
        {
            if (item.ItemName == itemName)
            {
                inventory.Remove(item);
                Console.WriteLine($"{itemName} fjernet fra dit inventar");
                return; // Return Exits the method when the item is removed
            }
        }
    }

    //shows what is in inventory
    public void PrintInventory()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("Du har ingen genstande i dit inventar");
        }
        else
        {
            Console.WriteLine("Dit inventar:");
            foreach (var item in inventory)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}