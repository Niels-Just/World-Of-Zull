namespace World_Of_Zuul;

class CommandPeople : BaseCommand, ICommand
{
    public CommandPeople()
    {
        description = "Look for people in a room";
    }
    
    public void Execute(Context context, string command, string[] parameters)
    {
        Space currentSpace = context.GetCurrent();
        currentSpace.PrintNPCs();
    }
    
}