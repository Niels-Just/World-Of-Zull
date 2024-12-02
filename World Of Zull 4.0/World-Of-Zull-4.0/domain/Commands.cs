using System.IO;
using World_Of_Zull_4._0._presentation;

namespace World_Of_Zull_4._0.domain
{
    public class Commands
    {
        private Room _currentRoom;
        private Dictionary<string, Room> _rooms;

        // Opdater spillerens position
        public Commands(Room startingRoom, Dictionary<string, Room> rooms)
        {
            _currentRoom = startingRoom; // Gem reference til den oprindelige currentRoom
            _rooms = rooms;
        }

        public void Move(string direction)
        {
            Room nextRoom = _currentRoom.FollowEdge(direction);
            if (nextRoom != null)
            {
                _currentRoom = nextRoom; // Opdater currentRoom
                _currentRoom.EnterRoomMsg();
            }
            else
            {
                Console.Clear();
                TextEffect.TxtEffect($"Du kan ikke gå {direction}. Der er ingen vej den vej!",20,200);
                _currentRoom.EnterRoomMsg();
            }
        
        }

        //bruges til at bevæge spilleren til ethvert rum uden behov for at være ved siden af det. (dev command)
        public void DevMove(Room nextRoom)
        {
            _currentRoom = nextRoom; // Opdater currentRoom
            _currentRoom.EnterRoomMsg();
        }

        public void Talk(Player player, string npcName)
        {
            //Skal burge NPC navn IsNullOrEmpty indbygget metode som tjekker om der står noget.
            if (string.IsNullOrEmpty(npcName))
            {
                Console.Clear();
                TextEffect.TxtEffect("Hvem forsøger du at tale med?", 20, 200);
                _currentRoom.EnterRoomMsg();
                return;
            }
            
            var npcInRoom = _currentRoom.npcer;
            if (npcInRoom.Count == 1 && npcName == npcInRoom[0].Name.ToLower())
            {
                var npc = npcInRoom[0];
                //unikt for fknorkel
                if (npc is NPCalien npcALien && npc.Name.ToLower() == "fnorkel")
                {
                    npcALien.TalkFnorkel(_currentRoom);
                }
                else
                {
                    //standard talk metode
                    npc.Talk(player);
                }
                _currentRoom.EnterRoomMsg();
            }
            else
            {
                Console.Clear();
                TextEffect.TxtEffect("Personen du leder efter er her ikke. Prøv at snakke med " + npcInRoom[0].Name, 20,
                    1000);
                _currentRoom.EnterRoomMsg();
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
            _currentRoom.EnterRoomMsg();
        }

        public void Inventory(Player player)
        {
            player.PrintInventory();
        }


        public void Assemble(Player player)
        {
            int intitemsleft = 8 - player.itemCount();
            if (_currentRoom == _rooms["baghaven"])
            {
                if (player.HasItem("Glasplade", "Inverter", "Æstetisk solfilm", "Energiomformer", "Energikrystal", "Sollys", "Energioptimeringschip", "Energiregulator"))
                {
                    Console.Clear();
                    TextEffect.TxtEffectNpc("Tillykke du hjalp fnorkel tilbage ud i rummet!", 40);
                    Console.WriteLine("Spillet er nu slut!");
                    System.Environment.Exit(0);
                    
                }
                else
                {
                    Console.Clear();
                    TextEffect.TxtEffect("Du har ikke alle delene!" + "\n\nDu mangler at finde " + intitemsleft + " dele før du kan lave et solpanel", 40, 4000);
                    _currentRoom.EnterRoomMsg();
                }
            }
            else
            {
                Console.Clear();
                TextEffect.TxtEffect("Du skal befinde dig i baghaven og have alle delene for at kunne bygge solcellen!" + "\n\nDu mangler at finde " + intitemsleft + " dele før du kan lave et solpanel", 40, 4000);
                _currentRoom.EnterRoomMsg();
            }
        }

        // Metode til at hente den opdaterede currentRoom
        public Room GetCurrentRoom()
        {
            return _currentRoom;
        }
    }
}
