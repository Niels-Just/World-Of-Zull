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
            Console.WriteLine("Der er intet rum denne vej!");
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
            Console.WriteLine("Du kan ikke gå denne vej");
        }
    }

    public void Hjælp()
    {
        Console.Clear();
        Console.WriteLine("Hjælp: Her er en beskrivelse af de tilgængelige kommandoer: \n" +
                                       "look [retning]' - Brug denne kommando for at se beskrivelsen af et rum i den angivne retning. \n" +
                                       "'move [retning]' - Brug denne kommando for at bevæge dig til et rum i den angivne retning. \n" +
                                       "'exit' - Brug denne kommando for at afslutte spillet. \n" +
                                       "For at bruge en retning skal du skrive retningen efter kommandoen, f.eks. 'look nord' eller 'move øst'.\n" +
                                       "\nTryk på hvilken som helst knap for at komme tilbage til rummet.");
        //venter på brugeren trykker enter eller andet.
        Console.ReadLine();
        Console.Clear();
        //når brugeren lukker hjælp vinduet, kommer teksten til rummet man er i op igen.
        currentRoom.EnterRoomMsg();
    }
}
