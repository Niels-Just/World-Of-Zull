namespace World_Of_Zuul;

class CommandSearch : BaseCommand, ICommand
{
    public CommandSearch()
    {
        description = "Search for items in a room";
    }
    
    public void Execute(Context context, string command, string[] parameters)
    {
        Space currentSpace = context.GetCurrent();
        currentSpace.ListRoomItems();
    }
    
}