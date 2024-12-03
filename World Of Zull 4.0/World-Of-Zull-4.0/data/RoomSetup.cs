using World_Of_Zull_4._0.data;
using World_Of_Zull_4._0.domain;

public class RoomSetup
{
    public static Dictionary<string, Room> InitalizeRooms()
    {
        //Laver rooms
        Room baghaven = new Room("baghaven", "Du kikker mod Baghaven.");
        Room gladNabo = new Room("den glade nabos hus", "Du kikker mod den glade nabo.");
        Room surNabo = new Room("den sure nabos hus", "Du kikker mod den sure nabo.");
        Room vejMidt = new Room("Vej midt", "Du kikker mod vej midt.");
        Room vejØst = new Room("Vej Øst", "Du kikker mod vej øst.");
        Room vejVest = new Room("Vej Vest", "Du kikker mod vej vest.");
        Room elektrikerErik = new Room("Elektriker Eriks hus", "Du kikker mod Elektriker Erik");
        Room glasMagerGlenn = new Room("Glasmager Glenns hus", "Du kikker mod Glasmager Glenn.");
        Room kunstHaven = new Room("Kunst Haven", "Du kikker mod Kunsthaven");
        
        
        //Initaliser NPC'er
        var npClist = NpcSetUp.InitalizeNpCs();
       
        //Tilføj npcer til rum
        /*NPClist.find søger i NPClist og finder det første element der matcher betignelsen
         betingelsen i dette tilfælde er "NPCernes navne, de kan findes i NCPSetup klassen.
         =>: Lambda-operatoren, adskiller parametrene fra udtrykket men skal bare ses som syntax.
         npc er i dette tilfælde paramter for lambda udtrykket men det kan hedde lige hvad det vil.
        */
        glasMagerGlenn.AddNpc(npClist.Find(npc => npc.Name == "Glasmager Glenn" ));
        surNabo.AddNpc(npClist.Find(npc => npc.Name == "Sur Nabo" ));
        elektrikerErik.AddNpc(npClist.Find(npc => npc.Name == "Elektriker Erik" ));
        gladNabo.AddNpc(npClist.Find(npc => npc.Name == "Glad Nabo" ));
        kunstHaven.AddNpc(npClist.Find(npc => npc.Name == "Kunstneren Karen" ));
        vejVest.AddNpc(npClist.Find(npc => npc.Name == "Bilejeren Bent" ));
        vejMidt.AddNpc(npClist.Find(npc => npc.Name == "Nabo Børnene" ));
        vejØst.AddNpc(npClist.Find(npc => npc.Name == "Gud" ));
        baghaven.AddNpc(npClist.Find(npc => npc.Name == "Fnorkel" ));
        
        
        
        // Tilføj kanter mellem rum
        // Pos (1,1)
        glasMagerGlenn.AddEdge("Syd", vejVest);
        glasMagerGlenn.AddEdge("Øst", elektrikerErik);
        
        // Pos (1,2)
        elektrikerErik.AddEdge("Vest", glasMagerGlenn);
        elektrikerErik.AddEdge("Øst", kunstHaven);
        elektrikerErik.AddEdge("Syd", vejMidt);
        
        // Pos (1,3)
        kunstHaven.AddEdge("Vest", elektrikerErik);
        kunstHaven.AddEdge("Syd", vejØst);
        
        // Pos (2,1)
        vejVest.AddEdge("Nord", glasMagerGlenn);
        vejVest.AddEdge("Syd", gladNabo);
        vejVest.AddEdge("Øst", vejMidt);
        
        // Pos (2,2)
        vejMidt.AddEdge("Syd", baghaven);
        vejMidt.AddEdge("Øst", vejØst);
        vejMidt.AddEdge("Vest", vejVest);
        vejMidt.AddEdge("Nord", elektrikerErik);
        
        // Pos (2,3)
        vejØst.AddEdge("Nord", kunstHaven);
        vejØst.AddEdge("Syd", surNabo);
        vejØst.AddEdge("Vest", vejMidt);
        
        // Pos (3,1)
        gladNabo.AddEdge("Øst", baghaven);
        gladNabo.AddEdge("Nord", vejVest);
        
        // Pos (3,2)
        baghaven.AddEdge("Nord", vejMidt);
        baghaven.AddEdge("Øst", surNabo);
        baghaven.AddEdge("Vest", gladNabo);
        
        // Pos (3,3)
        surNabo.AddEdge("Vest", baghaven);
        surNabo.AddEdge("Nord", vejØst);

        //Initialiser NPC'er
        var npcs = NpcSetUp.InitalizeNpCs();
        
        
        //Matcher string med den respektive room objekt, sådan at det kan refferes til senere i koden
        return new Dictionary<string, Room>
        {
            {"baghaven", baghaven},
            {"glad_nabo", gladNabo},
            {"sur_nabo", surNabo},
            {"vej_midt",vejMidt},
            {"vej_øst",vejØst},
            {"vej_vest",vejVest},
            {"elektriker_erik ",elektrikerErik},
            {"glas_mager_glenn",glasMagerGlenn},
            {"kunst_haven",kunstHaven},
        };
    }
}