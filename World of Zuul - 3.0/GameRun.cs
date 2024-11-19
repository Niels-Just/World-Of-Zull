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
            Room Baghaven = new Room("Baghaven", "Du kikker ned mod Baghaven.");
            Room Glad_Nabo = new Room("Glad Nabo", "Du kikker ned mod den glade nabo.");
            Room Sur_Nabo = new Room("Sur Nabo", "Du kikker ned mod den sure nabo.");
            Room Vej_Midt = new Room("Vej midt", "Du kikker ned mod vej midt.");
            Room Vej_Øst = new Room("Vej Øst", "Du kikker ned mod vej øst.");
            Room Vej_Vest = new Room("Vej Vest", "Du kikker ned mod vej vest.");
            Room Elektriker_Erik = new Room("Elektriker Erik", "Du kikker ned mod Elektriker Erik");
            Room Glas_Mager_glenn = new Room("Glas Mager Glenn", "Du kikker ned mod Glasmager Glenn.");
            Room Kunst_Haven = new Room("Kunst Haven", "Du kikker ned mod Kunsthaven");

            // Tilføj kanter mellem rum
            Baghaven.AddEdge("Nord", Vej_Midt);
            Baghaven.AddEdge("Øst", Sur_Nabo);
            Baghaven.AddEdge("Vest", Glad_Nabo);

            Vej_Midt.AddEdge("Syd", Baghaven);
            Vej_Midt.AddEdge("Øst", Vej_Øst);
            Vej_Midt.AddEdge("Vest", Vej_Vest);
            Vej_Midt.AddEdge("Nord", Elektriker_Erik);

            Sur_Nabo.AddEdge("Vest", Baghaven);
            Sur_Nabo.AddEdge("Nord", Vej_Øst);

            Glad_Nabo.AddEdge("Øst", Baghaven);
            Glad_Nabo.AddEdge("Nord", Vej_Vest);

            Vej_Øst.AddEdge("Nord", Kunst_Haven);
            Vej_Øst.AddEdge("Syd", Sur_Nabo);
            Vej_Øst.AddEdge("Vest", Vej_Midt);

            Vej_Vest.AddEdge("Nord", Glas_Mager_glenn);
            Vej_Vest.AddEdge("Syd", Glad_Nabo);
            Vej_Vest.AddEdge("Øst", Vej_Midt);

            Glas_Mager_glenn.AddEdge("Syd", Vej_Vest);
            Glas_Mager_glenn.AddEdge("Øst", Elektriker_Erik);

            Elektriker_Erik.AddEdge("Vest", Glas_Mager_glenn);
            Elektriker_Erik.AddEdge("Øst", Kunst_Haven);
            Elektriker_Erik.AddEdge("Syd", Vej_Midt);

            Kunst_Haven.AddEdge("Vest", Elektriker_Erik);
            Kunst_Haven.AddEdge("Syd", Vej_Øst);

            // Opret NPC'er 
            //Dette er NPCen uden spøgrsmål
            NPCalien fnorkel = new NPCalien("Fnorkel", "Fnorkel rumvæsnet der er stytet ned!","Du kan vel ikke hjælpe mig med at samle matterialer ind til solpannelet?");
            
            
            //Dette er hvis npcen skal kunne stille spørgsmål
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
                });
            
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
                   
                });

            // Tilføj NPC'er til rum
            Glad_Nabo.AddNPC(gladNabo);
            Sur_Nabo.AddNPC(surNabo);
            Baghaven.AddNPC(fnorkel);

            // Start i Baghaven
            Room currentRoom = Baghaven;
            Commands commands = new Commands(currentRoom); // Overfør reference til currentRoom
            currentRoom.EnterRoomMsg();

            while (true)
            {
                Console.WriteLine("Vælg nu hvad du vil gøre, er du i tvivl skriv 'Hjælp'");
                string command = Console.ReadLine().ToLower();

                string[] parts = command.Split(' ');

                if (parts[0] == "slut")
                {
                    break;
                }
                else if (parts[0] == "look" && parts.Length > 1)
                {
                    commands.Look(parts[1]);
                    currentRoom = commands.GetCurrentRoom(); // Opdater currentRoom efter Look
                }
                else if (parts[0] == "move" && parts.Length > 1)
                {
                    commands.Move(parts[1]);
                    currentRoom = commands.GetCurrentRoom(); // Opdater currentRoom efter Move
                }
                else if (parts[0] == "snak" && parts.Length > 1)
                {
                    if (parts[1].ToLower() == "fnorkel")
                    {
                        fnorkel.Talk(currentRoom); // Sender currentRoom med til Talk()
                    }
                }



                else if (parts[0] == "hjælp")
                {
                    commands.Hjælp();
                }
                else
                {
                    TekstEffektKlassen.TekstEffect("Dette kan ikke lade sig gøre!", 20, 2000);
                    currentRoom.EnterRoomMsg(); // Brug den opdaterede currentRoom
                }
            }
        }
    }
}