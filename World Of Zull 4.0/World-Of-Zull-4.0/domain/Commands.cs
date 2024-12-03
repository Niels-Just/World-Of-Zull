using World_Of_Zull_4._0._presentation;
using World_Of_Zull_4._0.presentation;

namespace World_Of_Zull_4._0.domain
{
    public class Commands
    {
        private Room currentRoom;
        private Dictionary<string, Room> rooms;

        // Opdater spillerens position
        public Commands(Room startingRoom, Dictionary<string, Room> rooms)
        {
            currentRoom = startingRoom; // Gem reference til den oprindelige currentRoom
            this.rooms = rooms;
        }

        public void Move(string direction)
        {
            Room nextRoom = currentRoom.FollowEdge(direction);
            if (nextRoom != null)
            {
                currentRoom = nextRoom; // Opdater currentRoom
                currentRoom.EnterRoomMsg();
            }
            else
            {
                Console.Clear();
                TextEffect.TxtEffect($"Du kan ikke gå {direction}. Der er ingen vej den vej!",20,200);
                currentRoom.EnterRoomMsg();
            }
        
        }

        //Bruges til at bevæge spilleren til ethvert rum uden behov for at være ved siden af det. (dev command)
        public void DevMove(Room nextRoom)
        {
            currentRoom = nextRoom; // Opdater currentRoom
            currentRoom.EnterRoomMsg();
        }

        public void Talk(Player player, string npcName)
        {
            //Skal burge NPC navn IsNullOrEmpty indbygget metode som tjekker om der står noget.
            if (string.IsNullOrEmpty(npcName))
            {
                Console.Clear();
                TextEffect.TxtEffect("Hvem forsøger du at tale med?", 20, 200);
                currentRoom.EnterRoomMsg();
                return;
            }
            
            var npcInRoom = currentRoom.Npcer;
            if (npcInRoom.Count == 1 && npcName == npcInRoom[0].Name.ToLower())
            {
                var npc = npcInRoom[0];
                //unikt for fknorkel
                if (npc is NpCalien npcALien && npc.Name.ToLower() == "fnorkel")
                {
                    npcALien.TalkFnorkel(currentRoom);
                }
                else
                {
                    //standard talk metode
                    npc.Talk(player);
                }
                currentRoom.EnterRoomMsg();
            }
            else
            {
                Console.Clear();
                TextEffect.TxtEffect("Personen du leder efter er her ikke. Prøv at snakke med " + npcInRoom[0].Name, 20,
                    1000);
                currentRoom.EnterRoomMsg();
            }
        }

        public void Hjælp()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                string currentdirectory = Directory.GetCurrentDirectory();
                string filePath = Path.Combine(currentdirectory, "Sample","Help.txt");
                string fileContent = File.ReadAllText(filePath);
                Console.WriteLine(fileContent);
            }
            catch
            {
                Console.WriteLine("der er sket en fejl");
            }
            TextEffect.TxtEffectNpc("", 20);
            currentRoom.EnterRoomMsg();
        }

        public void Inventory(Player player)
        {
            player.PrintInventory();
        }


        public void Assemble(Player player)
        {
            int intitemsleft = 8 - player.ItemCount();
            if (currentRoom == rooms["baghaven"])
            {
                if (player.HasItem("Glasplade", "Inverter", "Æstetisk solfilm", "Energiomformer", "Energikrystal", "Sollys", "Energioptimeringschip", "Energiregulator"))
                {
                    Console.Clear();
                    TextEffect.TxtEffectNpc("Tillykke du hjalp fnorkel tilbage ud i rummet!", 40);
                    //animations metode.
                    FnorkelAnimation.SlutAnimation();
                    Console.Clear();
                    Console.WriteLine("Spillet er nu slut, tak for at spille!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    TextEffect.TxtEffect("Du har ikke alle delene!" + "\n\nDu mangler at finde " + intitemsleft + " dele før du kan lave et solpanel", 40, 2000);
                    currentRoom.EnterRoomMsg();
                }
            }
            else
            {
                Console.Clear();
                TextEffect.TxtEffect("Du skal befinde dig i baghaven og have alle delene for at kunne bygge solcellen!" + "\n\nDu mangler at finde " + intitemsleft + " dele før du kan lave et solpanel", 40, 2000);
                currentRoom.EnterRoomMsg();
            }
        }

        public void Home()
        {
            Console.Clear();
            currentRoom= rooms["baghaven"];
            currentRoom.EnterRoomMsg();
        }

        // Metode til at hente den opdaterede currentRoom
        public Room GetCurrentRoom()
        {
            return currentRoom;
        }
    }
}
