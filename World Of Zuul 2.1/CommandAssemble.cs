namespace World_Of_Zuul;

class CommandAssemble : BaseCommand, ICommand
{
    private Player player;

    public CommandAssemble(Player player)
    {
        this.player = player;
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (player.HasItem("Frame", "Glass"))
        {
            Console.WriteLine("You've sucessfully assembled a solar panel!");
            Item solar_panel = new Item("Solar Panel", "Produces sustainable energy!");
            player.AddItem(solar_panel);
        }
        else
        {
            Console.WriteLine("You don't have the required parts!");
        }
    }
    
    public string GetDescription()
    {
        return "Assembles af solar panel when you have all the parts";
    }
}