using World_Of_Zull_4._0._presentation;
using World_Of_Zull_4._0.domain;
namespace World_Of_Zull_4._0.data;

public class GameLogic
{
    private Dictionary<string, Item> items; //Definer items relvant således at ItemSetUp kan bruges
    private Room currentRoom;
    private Commands commands;
    private Player player;
    private Dictionary<string, Room> rooms;
    private NPCalien fnorkel; //Tilføj fnorkel npc
    private bool isDev = true;
    
    public GameLogic()
    {
        rooms = RoomSetup.InitalizeRooms();
        player = PlayerSetUp.InitializePlayer();
        currentRoom = rooms["baghaven"]; //start i baghaven
        commands = new Commands(currentRoom, rooms);
        items = ItemSetUp.GetAllItems(); //Initialiser items
    }
    
    public void RunGame()
    {
        currentRoom.EnterRoomMsg();    
        while (true)
        {
            Console.WriteLine("\nVælg nu hvad du vil gøre, er du i tvivl skriv 'Hjælp'");
            string command = Console.ReadLine().ToLower();

            /*Her bliver parts som er et string array delt op ved hvert mellemrum
             Dette er smart fordi at man kan kalde if else statments og tjekke hvad der står på de forskellige steder i arrayet
             det vil også sige at man kan checke hvad brugeren skriver ind, for eksempel kan man tjekke om, hvis der står slut som det første
             lige meget hvad der står efter slutter spillet*/
            string[] parts = command.Split(' ');

            if (parts[0] == "slut") break;

            switch (parts[0])
            {
                case "byg":
                        commands.Assemble(player);
                    break;

                case "inventar":
                    Console.Clear();
                    commands.Inventory(player);
                    currentRoom.EnterRoomMsg();
                    break;

                case "gå":
                    if (parts.Length > 1)
                    {
                        commands.Move(parts[1]); //kalder Move kun hvis en retning er angivet
                    }
                    else
                    {
                        Console.Clear();
                        TextEffect.TxtEffect("Du skal angive en retning efter 'gå' kommandoen.",20,200);
                        currentRoom.EnterRoomMsg();
                    }
                    break;

                case "snak":
                    if (parts.Length == 1)
                    {
                        //hvis bare man skriver snak uden noget efter
                        Console.Clear();
                        TextEffect.TxtEffect("Angiv et NPC navn efter snak",20,250);
                        currentRoom.EnterRoomMsg();
                    }
                    else switch (parts.Length)
                    {
                        case 1 when parts[1].ToLower() == "fnorkel".ToLower():
                            fnorkel.TalkFnorkel(currentRoom);
                            break;
                        case 2:
                            commands.Talk(player,parts[1]);
                            break;
                        //tjekker om npcen har 2 navne og sætter et mellemrum ind for at kunne sammenligne npcname og npcinroom[0] i talk commanden.
                        case 3:
                            commands.Talk(player, $"{parts[1]} {parts[2]}");
                            break;
                    }
                    currentRoom = commands.GetCurrentRoom();
                    break;
                
                case "hjælp":
                    commands.Hjælp();
                    break;
                
                case "hjem":
                    commands.Home();
                    break;
                
                case "devadd":
                    if (isDev)
                    {
                        var items = ItemSetUp.GetAllItems();
                        player.GiveAllItems(items);
                    }
                    else                                                                                         
                    {                                                                                            
                        TextEffect.TxtEffect("Dette kan ikke lade sig gøre!", 20, 200);                                  
                        currentRoom.EnterRoomMsg();                                                              
                    }                                                                                            
                    break;

                case "devtp":
                    if (parts.Length > 1 && isDev)
                    {
                        string room = parts[1];
                        if (rooms.TryGetValue(room, out var tpRoom))
                        {
                            currentRoom = tpRoom;
                            commands.DevMove(currentRoom);
                        }
                        else
                        {
                            TextEffect.TxtEffect("Dette rum findes ikke", 20, 200);
                            currentRoom.EnterRoomMsg();
                        }
                    }
                    else if (isDev)
                    {
                        TextEffect.TxtEffect("Mangler input for rum", 20, 200);
                        currentRoom.EnterRoomMsg();
                    }
                    else    
                    {
                        TextEffect.TxtEffect("Dette kan ikke lade sig gøre!", 20, 2000);
                        currentRoom.EnterRoomMsg(); 
                    }
                    break;


                default:
                        TextEffect.TxtEffect("Dette kan ikke lade sig gøre!", 20, 2000);
                        currentRoom.EnterRoomMsg();
                        break;

                
            }
        }
    }
}
