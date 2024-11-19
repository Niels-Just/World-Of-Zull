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
                TextEffect.TxtEffect(nextRoom.GetDescription(), 30, 1200);
                currentRoom.EnterRoomMsg();
            }
            else
            { 
                Console.Clear();
                TextEffect.TxtEffect("Der er intet rum denne vej!", 40, 2000);
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
                TextEffect.TxtEffect("Du kan ikke gå denne vej", 40, 200);
                currentRoom.EnterRoomMsg();
            }
        }

        public void Talk(string npcName)
        {
            //Skal burge NPC navn IsNullOrEmpty indbygget metode som tjekker om der står noget.
            if (string.IsNullOrEmpty(npcName))
            {
                Console.Clear();
                TextEffect.TxtEffect("Hvem forsøger du at tale med?",20,200);
                currentRoom.EnterRoomMsg();
                return;
            }
            
            var npcsInRoom = currentRoom.npcer;
            if (npcsInRoom.Count == 0)
            {
                Console.Clear();
                TextEffect.TxtEffect("Her er ingen at tale med",20,200);
                currentRoom.EnterRoomMsg();
                return;
            }
            
            if (npcsInRoom.Count == 1)
            {
                var npc = npcsInRoom[0];
                npc.Talk();
                currentRoom.EnterRoomMsg();
            }
        }

        public void Hjælp()
        {
            Console.Clear();
            Console.WriteLine("Hjælp: Her er en beskrivelse af de tilgængelige kommandoer: \n" +
                              "'gå [retning]' - Brug denne kommando for at bevæge dig til et rum i den angivne retning. \n" +
                              "'slut' - Brug denne kommando for at afslutte spillet. \n" +
                              "'snak [NPC navn]' - Brug denne kommando for at tale med en NPC\n" +
                              "'svar [nummer]' - Brug denne kommando for at svare på spørgsmål\n" +
                              "'inventar' - Giver en liste og genstande i dit inventar\n" + 
                              "'byg' - Samle solpanelet når du har fået alle delene"); 
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tryk på 'enter' for at komme tilbage til rummet.");;
            Console.ResetColor();
            
            Console.ReadLine();
            Console.Clear();
            currentRoom.EnterRoomMsg();
        }
        
        public void Inventory(Player player)
        {
            player.PrintInventory();
        }
        
        public void Assemble(Player player)
        {
            if (player.HasItem("Frame, Glass")) // Indsæt nødvendige items her
            {
                //Console.WriteLine("You've sucessfully assembled a solar panel!");
                Item solar_panel = new Item("Sopanel", "Producere vedvarende energi!");
                player.AddItem(solar_panel);
            }
            else
            {
                Console.WriteLine("Du har ikke alle delene!");
            }
        }

        // Metode til at hente den opdaterede currentRoom
        public Room GetCurrentRoom()
        {
            return currentRoom;
        }
    }
}