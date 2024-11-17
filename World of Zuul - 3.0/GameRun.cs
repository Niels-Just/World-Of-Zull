using System.Net.Http.Headers;

namespace World_of_Zuul___3._0;

class GameRun
{
    static void Main(string[] args)
    {
        GameRun game = new GameRun();
        
        Room Baghaven = new Room("Baghaven","Du kikker ned mod Baghaven.");
        Room Glad_Nabo = new Room("Glad Nabo","Du kikker ned mod den glade nabo.");
        Room Sur_Nabo = new Room("Sur Nabo","Du kikker ned mod den sure nabo.");
        Room Vej_Midt = new Room("Vej midt","Du kikker ned mod vej midt.");
        Room Vej_Øst = new Room("Vej Øst","Du kikker ned mod vej øst.");
        Room Vej_Vest = new Room("Vej Vest","Du kikker ned mod vej vest.");
        Room Elektriker_Erik = new Room("Elektriker Erik","Du kikker ned mod Elektriker Erik");
        Room Glas_Mager_glenn = new Room("Glas Mager Glenn","Du kikker ned mod Glasmager Glenn.");
        Room Kunst_Haven = new Room("Kunst Haven","Du kikker ned mod Kunsthaven");
        
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
        
        //Opret en NPC 
        NPC npc1 = new NPC("Glad Nabo","Hej Nabo :)\n");
        NPC npc2 = new NPC("Sur Nabo","Hej Nabo ):<\n");
        
        //tilføj NPC til rum
        Glad_Nabo.AddNPC(npc1);
        Sur_Nabo.AddNPC(npc2);
        
        //metode kaldt, således at vi kun skal kalde metoden på teksten for effekt.
        TekstEffektKlassen.TekstEffectNPC("Welcome to the World of Zuul",30);
        /*TekstEffektKlassen.TekstEffectNPC("Welcome to the World of Zuul! \n" +
                                          "I dette spil kan du bevæge dig mellem forskellige rum! \n" +
                                          "Du kan bevæge dig mellem rummene ved hjælp af 'move' kommandoen \n" +
                                          "for at bruge denne kommando, skal du skrive 'move' foran 'retningen'. \n" +
                                          "Hver gang du træder ind i et nyt rum, og når spillet starter vil du \n" +
                                          "bliver præsenteret for 1 eller flere forskellige mulige retninger! \n" +
                                          "Hvis du ønsker at se ind i et rummene før du bevæger dig der ind, \n" +
                                          "skal du simpelt skrive 'look' efterfulgt af 'retning'. \n" +
                                          "Dette er det vigtigste for nu, ønsker du mere hjælp, skriv 'Hjælp'.\n" +
                                          "Nu må du nyde spillet!", 30);*/
        
        Room currentRoom = Baghaven;
        Commands commands = new Commands(currentRoom);
        currentRoom.EnterRoomMsg();

        while (true)
        {
            Console.WriteLine("Vælg nu hvad du vil gøre, er du i tvivl skriv 'Hjælp'");
            string command = Console.ReadLine().ToLower();
            /*parts arrayet splittes således at der ved hjælp af if else statmets kan checkes for
             specifikke ord på en specifik plads i arrayet ved hjælp at se på et specifikt index*/
            string[] parts = command.Split(' ');

            if (parts[0] == "slut")
            {
                break;
            }
            //look kommando
            else if (parts[0] == "look" && parts.Length > 1)
            {
                commands.Look(parts[1]);
            }
            //move kommando
            else if (parts[0] == "move" && parts.Length > 1)
            {
                commands.Move(parts[1]);
            }
            //talk kommandoen
            else if (parts[0] == "snak" && parts.Length > 1)
            {
                commands.Talk(parts[1]);
            }
            //hjælp kommandoen
            else if (parts[0] == "hjælp")
            {
                commands.Hjælp();
            }
            else
            {
                TekstEffektKlassen.TekstEffect("Dette kan ikke lade sig gøre!",20,2000);
                currentRoom.EnterRoomMsg();
            }
        }
    }
}