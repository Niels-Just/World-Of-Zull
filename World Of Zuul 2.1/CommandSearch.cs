namespace World_Of_Zuul;

class CommandSearch : BaseCommand, ICommand
{
    public CommandSearch()
    {
        description = "Søg efter en genstand";
    }
    
    public void Execute(Context context, string command, string[] parameters)
    {
        Space currentSpace = context.GetCurrent();
        currentSpace.ListRoomItems();
    }
    
}