using System;

namespace World_of_Zuul___3._0
{
    class GameRun
    {
        static void Main(string[] args)
        {
            StartScreen.Show();
            
            GameRun game = new GameRun();

            // Definer rum og NPC'er
            Room Baghaven = new Room("baghaven", "Du kikker ned mod Baghaven.");
            Room Glad_Nabo = new Room("den glade nabos hus", "Du kikker ned mod den glade nabo.");
            Room Sur_Nabo = new Room("den sur nabos hus", "Du kikker ned mod den sure nabo.");
            Room Vej_Midt = new Room("Vej midt", "Du kikker ned mod vej midt.");
            Room Vej_Øst = new Room("Vej Øst", "Du kikker ned mod vej øst.");
            Room Vej_Vest = new Room("Vej Vest", "Du kikker ned mod vej vest.");
            Room Elektriker_Erik = new Room("Elektriker Eriks hus", "Du kikker ned mod Elektriker Erik");
            Room Glas_Mager_glenn = new Room("Glas Mager Glenns hus", "Du kikker ned mod Glasmager Glenn.");
            Room Kunst_Haven = new Room("Kunst Haven", "Du kikker ned mod Kunsthaven");

            
            // Tilføj kanter mellem rum
            // Pos (1,1)
            Glas_Mager_glenn.AddEdge("Syd", Vej_Vest);
            Glas_Mager_glenn.AddEdge("Øst", Elektriker_Erik);
            
            // Pos (1,2)
            Elektriker_Erik.AddEdge("Vest", Glas_Mager_glenn);
            Elektriker_Erik.AddEdge("Øst", Kunst_Haven);
            Elektriker_Erik.AddEdge("Syd", Vej_Midt);
            
            // Pos (1,3)
            Kunst_Haven.AddEdge("Vest", Elektriker_Erik);
            Kunst_Haven.AddEdge("Syd", Vej_Øst);
            
            // Pos (2,1)
            Vej_Vest.AddEdge("Nord", Glas_Mager_glenn);
            Vej_Vest.AddEdge("Syd", Glad_Nabo);
            Vej_Vest.AddEdge("Øst", Vej_Midt);
            
            // Pos (2,2)
            Vej_Midt.AddEdge("Syd", Baghaven);
            Vej_Midt.AddEdge("Øst", Vej_Øst);
            Vej_Midt.AddEdge("Vest", Vej_Vest);
            Vej_Midt.AddEdge("Nord", Elektriker_Erik);
            
            // Pos (2,3)
            Vej_Øst.AddEdge("Nord", Kunst_Haven);
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
            
            // Opret NPC'er 
            //Dette er NPCen uden spøgrsmål
            NPCalien fnorkel = new NPCalien("Fnorkel", "Fnorkel rumvæsnet der er stytet ned!","Du kan vel ikke hjælpe mig med at samle matterialer ind til solpannelet?", false, "solcelle");
            
            
            //Dette er hvis npcen skal kunne stille spørgsmål
            NPC glasmagerGlenn = new NPC(
                "Glasmager Glen",
                "Hej Nabo",
                new List<Question>
                {
                    new Question("Det her er det først spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmålet!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true,
                "item 1"
                );   
            
            NPC elektrikerErik = new NPC(
                "Elektriker Erik", 
                "Hej Nabo",
                new List<Question>
                {
                    new Question("Det her er det først spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmålet!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true,
                "item 2"
                );        
            
            NPC kunstKaren = new NPC(
                "Kunstneren Karen",
                "Hej Nabo",
                new List<Question>
                {
                    new Question("Det her er det først spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmålet!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true,
                "item 3"
                );
            
            NPC bilejerenBent = new NPC(
                "Bilejeren Bent",
                "Hej Nabo",
                new List<Question>
                {
                    new Question("Det her er det først spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmålet!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true,
                "item 4"
                );
            
             NPC naboBørn = new NPC(
                 "Nabo Børnene",
                 "Hej Nabo",
                 new List<Question>
                 {
                     new Question("Det her er det først spørgsmål!",
                         new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                         1),
                     new Question("Det her er det andet spørgsmålet!",
                         new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                         2)
                 },
                 true,
                 "item 5"
                 );           
                
            NPC gud = new NPC(
                "Gud",
                "Hej Nabo",
                new List<Question>
                {
                    new Question("Det her er det først spørgsmål!",
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" },
                        1),
                    new Question("Det her er det andet spørgsmålet!",
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" },
                        2)
                },
                true,
                "item 6"
                );
                
            NPC gladNabo = new NPC(
                "Glad Nabo",
                "Hej Nabo :)",
                new List<Question>
                {
                    new Question("Det her er det første spørgsmål!", 
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" }, 
                        2),
                    new Question("Hvad er det andet spørgsmål!", 
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" }, 
                        2)
                },
                true,
                "item 7"
                );
            
            NPC surNabo = new NPC(
                "Sur Nabo",
                "Hej Nabo ):<",
                new List<Question>
                {
                    new Question("Det her er det først spørgsmål!", 
                        new string[] { "Svar 1 (Rigtigt)", "Svar 2 (Forkert)", "Svar 3 (Forkert)" }, 
                        1),
                    new Question("Det her er det andet spørgsmålet!", 
                        new string[] { "Svar 1 (Forkert)", "Svar 2 (Rigtigt)", "Svar 3 (Forkert)" }, 
                        2)
                   
                },
                true,
                "item 8"
                );

            // Tilføj NPC'er til rum
            Glas_Mager_glenn.AddNPC(glasmagerGlenn);
            Elektriker_Erik.AddNPC(elektrikerErik);
            Kunst_Haven.AddNPC(kunstKaren);
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
                else if (parts[0] == "gå" && parts.Length > 1)
                {
                    commands.Move(parts[1]);
                    currentRoom = commands.GetCurrentRoom(); // Opdater currentRoom efter Move
                }
                else if (parts[0] == "snak" && parts.Length > 1)
                {
                    if (parts[1].ToLower() == "fnorkel")
                    {
                        fnorkel.TalkFnorkel(Baghaven); 
                    }
                    else
                    {
                        commands.Talk(parts[1]);
                    }
                    currentRoom = commands.GetCurrentRoom(); 
                }
                else if (parts[0] == "inventar")
                {
                    commands.Inventory(player);
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