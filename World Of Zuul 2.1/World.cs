namespace World_Of_Zuul;
/* World class for modeling the entire in-game world
 */

class World {
    //starting room
    Space Baghave;
  
    //creating serval 'Space' objects and defining the connections between them.
    public World () {
        Space Baghave    = new Space("Baghave");
        Space Glad_Nabo = new Space("Glad Nabo");
        Space Sur_Nabo   = new Space("Sur Nabo");
        Space Vej_Midt     = new Space("Vej midt");
        Space Vej_Øst  = new Space("Vej Øst");
        Space Vej_Vest       = new Space("Vej Vest");
        Space Elektriker_Erik     = new Space("Elektriker Erik");
        Space Glas_Mager_glenn      = new Space("Glas Mager Glenn");
        Space Kunst_Haven     = new Space("Kunst Haven");
    
        //defines how these spaces are conected
        Baghave.AddEdge("Nord",Vej_Midt);
        Baghave.AddEdge("Øst", Sur_Nabo);
        Baghave.AddEdge("Vest", Glad_Nabo);
        
        Vej_Midt.AddEdge("Syd",Baghave);
        Vej_Midt.AddEdge("Øst",Vej_Øst);
        Vej_Midt.AddEdge("Vest",Vej_Vest);
        Vej_Midt.AddEdge("Nord",Elektriker_Erik);
       
        Sur_Nabo.AddEdge("Vest",Baghave);
        Sur_Nabo.AddEdge("Nord",Vej_Øst);
        
        Glad_Nabo.AddEdge("Øst",Baghave);
        Glad_Nabo.AddEdge("Nord",Vej_Vest);
        
        Vej_Øst.AddEdge("Nord",Kunst_Haven);
        Vej_Øst.AddEdge("Syd",Sur_Nabo);
        Vej_Øst.AddEdge("Vest",Vej_Midt);
        
        Vej_Vest.AddEdge("Nord",Glas_Mager_glenn);
        Vej_Vest.AddEdge("Syd",Glad_Nabo);
        Vej_Vest.AddEdge("Øst",Vej_Midt);
        
        Glas_Mager_glenn.AddEdge("Syd",Vej_Vest);
        Glas_Mager_glenn.AddEdge("Øst",Elektriker_Erik);
        
        Elektriker_Erik.AddEdge("Vest",Glas_Mager_glenn);
        Elektriker_Erik.AddEdge("Øst",Kunst_Haven);
        Elektriker_Erik.AddEdge("Syd", Vej_Midt);
        
        Kunst_Haven.AddEdge("Vest",Elektriker_Erik);
        Kunst_Haven.AddEdge("Syd",Vej_Øst);
    
        //starts at this location
        this.Baghave = Baghave;
        
        // Create and add items to room
        /* Item solar_cells = new Item("SolarCells", "Converts energy from light directly into electricity");
        Item battery = new Item("Battery", "Stores surplus electricity fom the solar panel for later use");
        Item frame = new Item("Frame", "The foundation for making a solar panel");
        Item glass_plane = new Item("Glass", "Protects the solar cells while still letting light through");
        island.AddRoomItem(solar_cells);
        warehouse.AddRoomItem(battery);
        park.AddRoomItem(frame);
        cave.AddRoomItem(glass_plane);
        home.AddRoomItem(battery);
        */
        
        // Create NPC's, add them to rooms and give them items
        NPC john = new NPC("John", "sød mand");
        Item bil = new Item("Bil", "john");
        Baghave.AddNPC(john);
        john.NpcAddItem(bil);
    }
  
    //allows access for the rest of the program
    public Space GetEntry () {
        return Baghave;
    }
}