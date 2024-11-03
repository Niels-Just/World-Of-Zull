namespace World_Of_Zuul;

class CommandInventory : BaseCommand, ICommand
{
    private Player player;

    public CommandInventory(Player player)
    {
        this.player = player;
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        player.PrintInventory();
    }

    public string GetDescription()
    {
        return "Displays inventory";
    }
}