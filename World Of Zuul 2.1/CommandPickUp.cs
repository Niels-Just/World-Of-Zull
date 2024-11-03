namespace World_Of_Zuul;

class CommandPickUp : BaseCommand, ICommand
{
    private Player player;

    public CommandPickUp(Player player)
    {
        this.player = player;
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (parameters.Length > 1)
        {
            Console.WriteLine("Choose an item to pick up");
            return;
        }
        // Retrieves item from the current room
        string itemName = parameters[0];
        Space currentSpace = context.GetCurrent();
        // TakeItem method from Space class takes the item from the room and removes it. 
        Item roomItem = currentSpace.TakeItem(itemName);
        
        // If there an item is present (Item != null) add item to player inventory. 
        if (roomItem != null)
        {
            player.AddItem(roomItem);
            Console.WriteLine($"You picked up {roomItem.getItemName()}.");
        }
        // Write the following to terminal if item is not present.
        else
        {
            Console.WriteLine($"There is no {itemName} here.");
        }
    }

    public string GetDescription()
    {
        return "Pick up an item";
    }
    
    
}