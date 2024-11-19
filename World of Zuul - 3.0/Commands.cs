namespace World_of_Zuul___3._0
{
    public class Commands
    {
        private Room currentRoom;

        // Opdater spillerens position
        public Commands(Room startingRoom)
        {
            currentRoom = startingRoom; // Gem reference til den oprindelige currentRoom
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
                TekstEffektKlassen.TekstEffect(nextRoom.GetDescription(), 30, 1200);
                currentRoom.EnterRoomMsg();
            }
            else
            { 
                Console.Clear();
                TekstEffektKlassen.TekstEffect("Der er intet rum denne vej!", 40, 2000);
                currentRoom.EnterRoomMsg();
            }
        }

        public void Move(string direction)
        {
            Room nextRoom = currentRoom.FollowEdge(direction);
            if (nextRoom != null)
            {
                currentRoom = nextRoom;  // Opdater currentRoom
                currentRoom.EnterRoomMsg();
            }
            else
            {
                Console.Clear();
                TekstEffektKlassen.TekstEffect("Du kan ikke gå denne vej", 40, 200);
                currentRoom.EnterRoomMsg();
            }
        }

        public void Talk(string npcName)
        {
            var npcsInRoom = currentRoom.npcer;

            if (npcsInRoom.Count == 0)
            {
                Console.Clear();
                TekstEffektKlassen.TekstEffect("Du forsøger at tale med nogen, men ingen svarer.", 20, 200);
                currentRoom.EnterRoomMsg();
                return;
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
                               "'look [retning]' - Brug denne kommando for at se beskrivelsen af et rum i den angivne retning. \n" +
                               "'move [retning]' - Brug denne kommando for at bevæge dig til et rum i den angivne retning. \n" +
                               "'slut' - Brug denne kommando for at afslutte spillet. \n" +
                               "'snak [NPC navn]' - Brug denne kommando for at tale med en NPC\n" +
                               "\nTryk på hvilken som helst knap for at komme tilbage til rummet.");
            Console.ReadLine();
            Console.Clear();
            currentRoom.EnterRoomMsg();
        }

        // Metode til at hente den opdaterede currentRoom
        public Room GetCurrentRoom()
        {
            return currentRoom;
        }
    }
}
