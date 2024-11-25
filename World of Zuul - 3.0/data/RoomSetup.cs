using World_of_Zuul___3._0.domain;

namespace World_of_Zuul___3._0.data;

public class RoomSetup
{
    public static Dictionary<string, Room> InitalizeRooms()
    {
        //Laver rooms
        Room Baghaven = new Room("baghaven", "Du kikker mod Baghaven.");
        Room Glad_Nabo = new Room("den glade nabos hus", "Du kikker mod den glade nabo.");
        Room Sur_Nabo = new Room("den sur nabos hus", "Du kikker mod den sure nabo.");
        Room Vej_Midt = new Room("Vej midt", "Du kikker mod vej midt.");
        Room Vej_Øst = new Room("Vej Øst", "Du kikker mod vej øst.");
        Room Vej_Vest = new Room("Vej Vest", "Du kikker mod vej vest.");
        Room Elektriker_Erik = new Room("Elektriker Eriks hus", "Du kikker mod Elektriker Erik");
        Room Glas_Mager_glenn = new Room("Glas Mager Glenns hus", "Du kikker mod Glasmager Glenn.");
        Room Kunst_Haven = new Room("Kunst Haven", "Du kikker mod Kunsthaven");
        
        
        //Initaliser NPC'er
        var NPClist = NPCSetUp.InitalizeNPCs();
       
        //Tilføj npcer til rum
        /*NPClist.find søger i NPClist og finder det første element der matcher betignelsen
         betingelsen i dette tilfælde er "NPCernes navne, de kan findes i NCPSetup klassen.
         =>: Lambda-operatoren, adskiller parametrene fra udtrykket men skal bare ses som syntax.
         npc er i dette tilfælde paramter for lambda udtrykket men det kan hedde lige hvad det vil.
        */
        Glas_Mager_glenn.AddNPC(NPClist.Find(element => element.Name == "Glas Mager Glenn" ));
        Sur_Nabo.AddNPC(NPClist.Find(npc => npc.Name == "Sur Nabo" ));
        Elektriker_Erik.AddNPC(NPClist.Find(npc => npc.Name == "Elektriker Erik" ));
        Glad_Nabo.AddNPC(NPClist.Find(npc => npc.Name == "Glad Nabo" ));
        Kunst_Haven.AddNPC(NPClist.Find(npc => npc.Name == "Kunstneren Karen" ));
        Vej_Vest.AddNPC(NPClist.Find(npc => npc.Name == "Bilejeren Bent" ));
        Vej_Midt.AddNPC(NPClist.Find(npc => npc.Name == "Nabo Børnene" ));
        Vej_Øst.AddNPC(NPClist.Find(npc => npc.Name == "Gud" ));
        Baghaven.AddNPC(NPClist.Find(npc => npc.Name == "Fnorkel" ));
        
        
        
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

        //Initialiser NPC'er
        var npcs = NPCSetUp.InitalizeNPCs();
        
        
        //Matcher string med den respektive room objekt, sådan at det kan refferes til senere i koden
        return new Dictionary<string, Room>
        {
            {"baghaven", Baghaven},
            {"glad_nabo", Glad_Nabo},
            {"sur_nabo", Sur_Nabo},
            {"vej_midt",Vej_Midt},
            {"vej_øst",Vej_Øst},
            {"vej_vest",Vej_Vest},
            {"elektriker_erik ",Elektriker_Erik},
            {"glas_mager_glenn",Glas_Mager_glenn},
            {"kunst_haven",Kunst_Haven},
        };
    }
}