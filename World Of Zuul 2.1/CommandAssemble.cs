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
            //Console.WriteLine("You've sucessfully assembled a solar panel!");
            Item solar_panel = new Item("Sopanel", "Producere vedvarende energi!");
            player.AddItem(solar_panel);
            Console.WriteLine("Gennemført spillet!");
            context.MakeDone();
        }
        else
        {
            Console.WriteLine("You don't have the required parts!");
        }
    }
    
    public string GetDescription()
    {
        return "Sammensæt delene til et solpanel";
    }
}