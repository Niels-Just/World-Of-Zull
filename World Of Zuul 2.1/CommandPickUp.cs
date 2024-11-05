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
        // Important for stability. If the player enters nothing after the "PickUp" command the program does not crash
        if (parameters.Length == 0)
        {
            Console.WriteLine("Choose an item to pick up.");
            return;
        }
        
        Space currentSpace = context.GetCurrent(); // context.GetCurrent() comes from the context class. Makes sure the item is taken from the current room the player is in
        
        foreach (string itemName in parameters)
        {
            // TakeItem method from Space class takes the item from the room and removes it. 
            Item roomItem = currentSpace.TakeItem(itemName);

            // If the item is present (Item != null), add item to player inventory.
            if (roomItem != null)
            {
                Console.WriteLine($"You picked up {roomItem.getItemName()}.");
                player.AddItem(roomItem);
            }
            // Write the following to terminal if item is not present.
            else
            {
                Console.WriteLine($"There is no {itemName} here.");
            }
        }
    }

    public string GetDescription()
    {
        return "Pick up an item";
    }
    
    
}