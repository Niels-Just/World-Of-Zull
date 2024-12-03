using World_Of_Zull_4._0.presentation;
using World_Of_Zull_4._0.data.World_Of_Zull_4._0.presentation;
namespace World_Of_Zull_4._0.domain;

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
                return;
            }
        }
    }

    public int ItemCount()
    {
        return inventory.Count;
    }

    //shows what is in inventory
    public void PrintInventory()
    {
        /*her bliver der tjekket for hver item i ens inventory og hvis man har skaffet det vil der blive udskrevet i konsollen hvilke items man har og
        hvor mange man mangler dette er en modificere kopi af texteffect metoden så den passer til det den skal gøre :) */
        Console.ForegroundColor = ConsoleColor.Yellow; 
        Console.WriteLine("Dit inventar:\n"); 
        Console.ResetColor(); 
        foreach (Item item in inventory)
        {
            foreach (char c in item.ItemName)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        //viser hvor mange items man mangler før man er færdig med spillet og skriver det ud til spilleren
        int intitemsleft = 8 - inventory.Count;
        string stringitemsleft = "Du mangler at finde " + intitemsleft + " items indtil du kan lave et solpanel";
            
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (char c in stringitemsleft)
        {
            Console.Write(c);
            Thread.Sleep(30);
        }
        Console.WriteLine();
        Console.ResetColor();
        TextEffect.TxtEffectNpc("", 0);
        
    }
    public void GiveAllItems(Dictionary<string, Item> items)
    {
        foreach (var item in items.Values)
        {
            inventory.Add(item);
        }
    }
}