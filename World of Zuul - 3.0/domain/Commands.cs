using World_of_Zuul___3._0.presentation;
using System.IO;

namespace World_of_Zuul___3._0.domain
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
            _currentRoom = nextRoom; // Opdater currentRoom
            _currentRoom.EnterRoomMsg();
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
                TextEffect.TxtEffect("Personen du leder efter er her ikke. prøv at snakke med " + npcInRoom[0].Name, 20,
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

                string filePath = Path.Combine(@"Sample\Sample.txt");

                string fileContent = File.ReadAllText(filePath);

                Console.WriteLine(fileContent);
            }
            catch
            {
                Console.WriteLine("der er sket en fejl");
            }

            /*String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Sample.txt");

                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            /*Console.WriteLine("Hjælp: Her er en beskrivelse af de tilgængelige kommandoer: \n" +
                              "'gå [retning]' - Brug denne kommando for at bevæge dig til et rum i den angivne retning. \n" +
                              "'slut' - Brug denne kommando for at afslutte spillet. \n" +
                              "'snak [NPC navn]' - Brug denne kommando for at tale med en NPC\n" +
                              "'svar [nummer]' - Brug denne kommando for at svare på spørgsmål\n" +
                              "'inventar' - Giver en liste og genstande i dit inventar\n" +
                              "'byg' - Samle solpanelet når du har fået alle delene\n" +
                              "Dev Commands: 'devtp [rum]' - tp'er dig til et vilkårligt rum\n" +
                              "Dev Commands: 'devskip' - Skipper introen");*/
            TextEffect.TxtEffectNpc("", 20);
            ;
            _currentRoom.EnterRoomMsg();
        }

        public void Inventory(Player player)
        {
            player.PrintInventory();
        }


        public void Assemble(Player player)
        {
            if (_currentRoom == _rooms["baghaven"])
            {
                if (player.HasItem("part1") && player.HasItem("part2") && player.HasItem("part3") && player.HasItem("part4") && player.HasItem("part5") 
                    && player.HasItem("part6") && player.HasItem("part7") && player.HasItem("part8")) // Indsæt nødvendige items her
                {
                    Console.Clear();
                    TextEffect.TxtEffectNpc("Tillyke du hjalp fnorkel tilbage ud i rummet!", 20);
                    Console.WriteLine("Spillet er nu slut!");
                    System.Environment.Exit(0);
                    
                }
                else
                {
                    TextEffect.TxtEffect("Du har ikke alle delene!",20,200);
                    _currentRoom.EnterRoomMsg();
                }
            }
            else
            {
                TextEffect.TxtEffect("Du skal befinde dig i baghaven for at kunne bygge solcellen og have alle delene!", 20, 200);
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
