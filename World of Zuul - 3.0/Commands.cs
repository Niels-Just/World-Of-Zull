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

        //bruges til at bevæge spilleren til ethvert rum uden behov for at være ved siden af det. (dev command)
        public void DevMove(Room NextRoom)
        {
                currentRoom = NextRoom;  // Opdater currentRoom
                currentRoom.EnterRoomMsg();
        }
        
        public void Talk(Player player, string npcName)
        {
            //Skal burge NPC navn IsNullOrEmpty indbygget metode som tjekker om der står noget.
            if (string.IsNullOrEmpty(npcName))
            {
                Console.Clear();
                TextEffect.TxtEffect("Hvem forsøger du at tale med?",20,200);
                currentRoom.EnterRoomMsg();
                return;
            }
            
            var npcInRoom = currentRoom.npcer;
            if (npcInRoom.Count == 0)
            {
                Console.Clear();
                TextEffect.TxtEffect("Her er ingen at tale med",20,200);
                currentRoom.EnterRoomMsg();
                return;
            }
            
            if (npcInRoom.Count == 1 && npcName == npcInRoom[0].Name.ToLower())
            {
                var npc = npcInRoom[0];
                npc.Talk(player);
                currentRoom.EnterRoomMsg();
            }
            else
            {
                Console.Clear();
                TextEffect.TxtEffect("Personen du leder efter er her ikke. prøv at snakke med " + npcInRoom[0].Name,20,1000);
                currentRoom.EnterRoomMsg();
            }
        }

        public void Hjælp()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hjælp: Her er en beskrivelse af de tilgængelige kommandoer: \n" +
                              "'gå [retning]' - Brug denne kommando for at bevæge dig til et rum i den angivne retning. \n" +
                              "'slut' - Brug denne kommando for at afslutte spillet. \n" +
                              "'snak [NPC navn]' - Brug denne kommando for at tale med en NPC\n" +
                              "'svar [nummer]' - Brug denne kommando for at svare på spørgsmål\n" +
                              "'inventar' - Giver en liste og genstande i dit inventar\n" + 
                              "'byg' - Samle solpanelet når du har fået alle delene\n" +
                              "Dev Commands: 'devtp [rum]' - tp'er dig til et vilkårligt rum\n" + 
                              "Dev Commands: 'devskip' - Skipper introen"); 
            TextEffect.TxtEffectNpc("", 20);;
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