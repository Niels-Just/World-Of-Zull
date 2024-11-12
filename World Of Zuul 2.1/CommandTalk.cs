namespace World_Of_Zuul;

class CommandTalk : BaseCommand, ICommand
{
    
    public void Execute(Context context, string command, string[] parameters)
    {
        // Important for stability. If the player enters nothing after the "PickUp" command the program does not crash
        if (parameters.Length == 0)
        {
            Console.WriteLine("Vælg en at tale med");
            return;
        }
        
        Space currentSpace = context.GetCurrent(); // context.GetCurrent() comes from the context class. Makes sure the item is taken from the current room the player is in
        
        foreach (string npcName in parameters)
        {
            NPC npc = currentSpace.GetNpcByName(npcName);
            if (npc != null!)
            {
                npc.Talk();
            }
            // Write the following to terminal if npc is not present.
            else
            {
                Console.WriteLine($"Der er ingen ved navn {npcName} her");
            }
        }
    }

    public string GetDescription()
    {
        return "Tal med en person";
    }
    
    
}