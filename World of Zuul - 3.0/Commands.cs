namespace World_of_Zuul___3._0;

public class Commands
{
    private Room currentRoom;
    
    //opadter hele tiden spilleren position, dette er en instansvariabel 
    //er nødvendigt for at 'move' og 'look' kommandoen kan få rum data
    public Commands(Room startingRoom)
    {
        currentRoom = startingRoom;
    }
    
    public void Look(string direction)
    {
        if (currentRoom == null)
        {
            Console.WriteLine("Dette er ikke muligt!");
        }
        Room nextRoom = currentRoom.FollowEdge(direction);
        if (nextRoom != null)
        { 
            Console.Clear();
            //metoden bliver kaldt på description når man kalder look kommandoen
            TekstEffektKlassen.TekstEffect(nextRoom.GetDescription(),30,350);
            //room enter msg bliver vist igen efter look kommandoen
            currentRoom.EnterRoomMsg();
        }
        else
        { 
            Console.Clear();
            TekstEffektKlassen.TekstEffect("Der er intet rum denne vej!",40,2000);
            currentRoom.EnterRoomMsg();
        }
    }

    public void Move(string direction)
    {
        Room nextRoom = currentRoom.FollowEdge(direction);
        if (nextRoom != null)
        {
            currentRoom = nextRoom;
            currentRoom.EnterRoomMsg();
        }
        else
        {
            Console.Clear();
            TekstEffektKlassen.TekstEffect("Du kan ikke gå denne vej",40,200);
            currentRoom.EnterRoomMsg();
        }
    }

    public void Talk(string npcName)
    {
        //henter listen af NPCer i det rum spilleren befinder sig i
        var npcsInRoom = currentRoom.npcer;

        if (npcsInRoom.Count == 0)
        {
            {
                Console.Clear();
                TekstEffektKlassen.TekstEffect("Du forsøger at tale med nogen, men ingen svare.",20,200);
                currentRoom.EnterRoomMsg();
                return;
            }
        }

        if (npcsInRoom.Count == 1)
        {
            var npc = npcsInRoom.First();
            npc.Talk();
            currentRoom.EnterRoomMsg();
        }
    }

    public void Hjælp()
    {
        Console.Clear();
        Console.WriteLine("Hjælp: Her er en beskrivelse af de tilgængelige kommandoer: \n" +
                                       "look [retning]' - Brug denne kommando for at se beskrivelsen af et rum i den angivne retning. \n" +
                                       "'move [retning]' - Brug denne kommando for at bevæge dig til et rum i den angivne retning. \n" +
                                       "'slut' - Brug denne kommando for at aflutte spillet. \n" +
                                       "'snak [NPC navn]' - Bruge denne kommando for snakke med en NPC\n"+
                                       "\nTryk på hvilken som helst knap for at komme tilbage til rummet.");
        //venter på brugeren trykker enter eller andet.
        Console.ReadLine();
        Console.Clear();
        //når brugeren lukker hjælp vinduet, kommer teksten til rummet man er i op igen.
        currentRoom.EnterRoomMsg();
    }
}
