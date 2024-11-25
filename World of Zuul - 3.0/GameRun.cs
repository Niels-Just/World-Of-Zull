using System;
using System.Net.Sockets;

namespace World_of_Zuul___3._0
{
    class GameRun
    {
        static void Main(string[] args)
        {
            StartScreen.Show();
            
            GameRun game = new GameRun();

            // Definer rum og NPC'er
            Room Baghaven = new Room("baghaven", "Du kikker mod baghaven.");
            Room Glad_Nabo = new Room("den glade nabos hus", "Du kikker mod den glade nabo.");
            Room Sur_Nabo = new Room("den sure nabos hus", "Du kikker mod den sure nabo.");
            Room Vej_Midt = new Room("Vej midt", "Du kikker mod vej midt.");
            Room Vej_Øst = new Room("Vej Øst", "Du kikker mod vej øst.");
            Room Vej_Vest = new Room("Vej Vest", "Du kikker mod vej vest.");
            Room Elektriker_Erik = new Room("Elektriker Eriks hus", "Du kikker mod Elektriker Erik");
            Room Glasmager_Glenn = new Room("Glasmager Glenns hus", "Du kikker mod Glasmager Glenn.");
            Room Kunsthaven = new Room("Kunsthaven", "Du kikker mod Kunsthaven");
            
            // Tilføj kanter mellem rum
            // Pos (1,1)
            Glasmager_Glenn.AddEdge("Syd", Vej_Vest);
            Glasmager_Glenn.AddEdge("Øst", Elektriker_Erik);
            
            // Pos (1,2)
            Elektriker_Erik.AddEdge("Vest", Glasmager_Glenn);
            Elektriker_Erik.AddEdge("Øst", Kunsthaven);
            Elektriker_Erik.AddEdge("Syd", Vej_Midt);
            
            // Pos (1,3)
            Kunsthaven.AddEdge("Vest", Elektriker_Erik);
            Kunsthaven.AddEdge("Syd", Vej_Øst);
            
            // Pos (2,1)
            Vej_Vest.AddEdge("Nord", Glasmager_Glenn);
            Vej_Vest.AddEdge("Syd", Glad_Nabo);
            Vej_Vest.AddEdge("Øst", Vej_Midt);
            
            // Pos (2,2)
            Vej_Midt.AddEdge("Syd", Baghaven);
            Vej_Midt.AddEdge("Øst", Vej_Øst);
            Vej_Midt.AddEdge("Vest", Vej_Vest);
            Vej_Midt.AddEdge("Nord", Elektriker_Erik);
            
            // Pos (2,3)
            Vej_Øst.AddEdge("Nord", Kunsthaven);
            Vej_Øst.AddEdge("Syd", Sur_Nabo);
            Vej_Øst.AddEdge("Vest", Vej_Midt);
            
            // Pos (3,1)
            Glad_Nabo.AddEdge("Øst", Baghaven);
            Glad_Nabo.AddEdge("Nord", Vej_Vest);
            
            // Pos (3,2)
            Baghaven.AddEdge("Nord", Vej_Midt);
            Baghaven.AddEdge("Øst", Sur_Nabo);
            Baghaven.AddEdge("Vest", Glad_Nabo);

            // Pos (3,3)
            Sur_Nabo.AddEdge("Vest", Baghaven);
            Sur_Nabo.AddEdge("Nord", Vej_Øst);


            
            // Opretter player obejektet. Giver spilleren et inventar.
            Player player = new Player();
            
            //Items til npcer. Skal ændres senere
            Item part0 = new Item("item name", "description");
            Item part1 = new Item("part1", "part1");
            Item part2 = new Item("part2", "part2");
            Item part3 = new Item("part3", "part3");
            Item part4 = new Item("part4", "part4");
            Item part5 = new Item("part5", "part5");
            Item part6 = new Item("part6", "part6");
            Item part7 = new Item("part7", "part7");
            Item part8 = new Item("part8", "part8");
            
            //laver en liste til items (bruges til devcommanden som tilføjer items med det samme) og tilføjer de items vi har
            List<Item> items = new List<Item>();
            items.Add(part1);
            items.Add(part2);
            items.Add(part3);
            items.Add(part4);
            items.Add(part5);
            items.Add(part6);
            items.Add(part7);
            items.Add(part8);
            
            // Opret NPC'er 
            //Dette er NPCen uden spøgrsmål
            Item temp = new Item("temp", "temp");
            NPCalien fnorkel = new NPCalien("Fnorkel", "Fnorkel rumvæsnet der er styrtet ned!","Du kan vel ikke hjælpe mig med at samle materialer ind til solpanelet?", false, temp);
            
            
            //Dette er hvis npcen skal kunne stille spørgsmål
            NPC glasmagerGlenn = new NPC(
                "Glasmager Glenn",
                "Hej Nabo",
                new List<Question>
                {
                    new Question("Det her er det første spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmål!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true,
                
                part1
                );   
            
            NPC elektrikerErik = new NPC(
                "Elektriker Erik", 
                "Hej Nabo",
                new List<Question>
                {
                    new Question("Det her er det første spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmål!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true,
                
                part2
                );        
            
            NPC kunstKaren = new NPC(
                "Kunstneren Karen",
                "Hej Nabo",
                new List<Question>
                {
                    new Question("Det her er det første spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmål!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true,
                
                part3
                );
            
            NPC bilejerenBent = new NPC(
                "Bilejeren Bent",
                "Hej Nabo",
                new List<Question>
                {
                    new Question("Det her er det første spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmål!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true,
                
                part4
                );
            
             NPC naboBørn = new NPC(
                 "Nabo Børnene",
                 "Hej Nabo",
                 new List<Question>
                 {
                     new Question("Det her er det første spørgsmål!",
                         new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                         1),
                     new Question("Det her er det andet spørgsmål!",
                         new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                         2)
                 },
                 true,
                 
                 part5
                 );           
                
            NPC gud = new NPC(
                "Gud",
                "Hej Nabo",
                new List<Question>
                {
                    new Question("Det her er det første spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmål!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true,
                
                part6
                );
                
            NPC gladNabo = new NPC(
                "Glad Nabo",
                "Hej Nabo :)",
                new List<Question>
                {
                    new Question("Det her er det første spørgsmål!", 
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" }, 
                        2),
                    new Question("Det her er det andet spørgsmål!", 
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" }, 
                        2)
                },
                true,
                
                part7
                );
            
            NPC surNabo = new NPC(
                "Sur Nabo",
                "Hej Nabo ):<",
                new List<Question>
                {
                    new Question("Det her er det første spørgsmål!", 
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" }, 
                        1),
                    new Question("Det her er det andet spørgsmål!", 
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" }, 
                        2)
                   
                },
                true,
                
                part8
                );

            // Tilføj NPC'er til rum
            Glasmager_Glenn.AddNPC(glasmagerGlenn);
            Elektriker_Erik.AddNPC(elektrikerErik);
            Kunsthaven.AddNPC(kunstKaren);
            Vej_Vest.AddNPC(bilejerenBent);
            Vej_Midt.AddNPC(naboBørn);
            Vej_Øst.AddNPC(gud);
            Glad_Nabo.AddNPC(gladNabo);
            Baghaven.AddNPC(fnorkel);
            Sur_Nabo.AddNPC(surNabo);
            

            // Start i Baghaven
            Room currentRoom = Baghaven;
            Commands commands = new Commands(currentRoom); // Overfør reference til currentRoom
            currentRoom.EnterRoomMsg();

            while (true)
            {
                Console.WriteLine("Vælg nu hvad du vil gøre, er du i tvivl skriv 'Hjælp'");
                string command = Console.ReadLine().ToLower();

                /*Her bliver parts som er et string array delt op ved hvert mellemrum
                 Dette er smart fordi at man kan kalde if else statments og tjekke hvad der står på de forskellige steder i arrayet
                 det vil også sige at man kan checke hvad brugeren skriver ind, for eksempel kan man tjekke om, hvis der står slut som det første
                 lige meget hvad der står efter slutter spillet*/
                string[] parts = command.Split(' ');
                
                
                
                if (parts[0] == "slut")
                {
                    break;
                }

                // Dette if statement gør det nemmere for os at bevæge os hurtigere rundt.
                else if (parts[0] == "devtp" && parts.Length > 1)
                {
                    Dictionary<string, Room> Roomdictionary = new Dictionary<string, Room>
                    {
                        { "baghaven", Baghaven },
                        { "glad_nabo", Glad_Nabo },
                        { "sur_nabo", Sur_Nabo },
                        { "vej_midt", Vej_Midt },
                        { "vej_øst", Vej_Øst },
                        { "vej_vest", Vej_Vest },
                        { "elektriker_erik", Elektriker_Erik },
                        { "glas_mager_glenn", Glasmager_Glenn },
                        { "kunst_haven", Kunsthaven }
                    };

                    if (Roomdictionary.TryGetValue(parts[1].ToLower(), out Room nextRoom))
                    {
                        commands.DevMove(nextRoom);
                        currentRoom = commands.GetCurrentRoom();
                    }
                    else
                    {
                        Console.Clear();
                        TextEffect.TxtEffect("Dette er ikke et rum", 40, 800);
                        currentRoom.EnterRoomMsg();
                    }
                }
                else if (parts[0] == "gå" && parts.Length > 1)
                {
                    commands.Move(parts[1]);
                    currentRoom = commands.GetCurrentRoom(); // Opdater currentRoom efter Move
                }
                else if (parts[0] == "snak" && parts.Length == 1 && parts[1].ToLower() == "fnorkel")
                {
                        fnorkel.TalkFnorkel(Baghaven);
                    currentRoom = commands.GetCurrentRoom(); 
                }
                else if (parts[0] == "snak" && parts.Length == 2)
                {
                    commands.Talk(player, parts[1]);
                    currentRoom = commands.GetCurrentRoom(); 
                }
                
                //tjekker om npcen har 2 navne og sætter et mellemrum ind for at kunne sammenligne npcname og npcinroom[0] i talk commanden.
                
                else if (parts[0] == "snak" && parts.Length == 3)
                {
                        commands.Talk(player, $"{parts[1]} {parts[2]}");
                        currentRoom = commands.GetCurrentRoom(); 
                }
                else if (parts[0] == "inventar")
                {
                    commands.Inventory(player);
                    currentRoom.EnterRoomMsg();
                }
                else if (parts[0] == "byg")
                {
                    if (commands.GetCurrentRoom() == Baghaven)
                    {
                        commands.Assemble(player);
                    }
                    else
                    {
                        Console.WriteLine("Du skal befinde dig i baghaven før du kan bygge solpanelet.");
                    }
                }
                
                else if (parts[0] == "devadd" && parts.Length > 1)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (parts[1] == items[i].ItemName.ToLower())
                        {
                            player.AddItem(items[i]);
                        }
                    }
                }
                
                else if (parts[0] == "hjælp")
                {
                    commands.Hjælp();
                }
                else
                {
                    TextEffect.TxtEffect("Dette kan ikke lade sig gøre!", 20, 2000);
                    currentRoom.EnterRoomMsg(); // Brug den opdaterede currentRoom
                }
            }
        }
    }
}