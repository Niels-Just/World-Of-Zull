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
            Console.WriteLine("Vælg en genstand at samle op");
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
                Console.WriteLine($"Du har opsamlet: {roomItem.getItemName()}");
                player.AddItem(roomItem);
            }
            // Write the following to terminal if item is not present.
            else
            {
                Console.WriteLine($"Der er ingen {itemName} her");
            }
        }
    }

    public string GetDescription()
    {
        return "Samle en genstand op";
    }
    
    
}