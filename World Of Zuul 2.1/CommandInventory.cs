namespace World_Of_Zuul;

class CommandInventory : BaseCommand, ICommand
{
    //dette gemmer en refence af et player objekt. inventory bruger dette til at få adgang til playerens items.
    private Player player;

    
    //denne metode gør at inventory kan få adgang til playerens inventar når metoden køres.
    //Dette gør den ved at tage player metoden fra player classens metode som laver en list til playerens inventory.
    public CommandInventory(Player player)
    {
        this.player = player;
    }
    
//denne metode bruger contex som er playerens lokation, string command som er navnet på commanden man vil skrive for at aktivere metoden,
//og string parameters som jeg antager er det array som indeholder alle playerens items. Her vil den printe alle player itemsne.
    public void Execute(Context context, string command, string[] parameters)
    {
        player.PrintInventory();
    }
//denne metode skrive hvad commanden gør hvilkt bruges til help commanden.
    public string GetDescription()
    {
        return "Viser dit inventar";
    }
}