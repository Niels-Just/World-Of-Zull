namespace World_Of_Zuul;
/* World class for modeling the entire in-game world
 */

class World {
    //starting room
    Space entry;
  
    //creating serval 'Space' objects and defining the connections between them.
    public World () {
        Space home    = new Space("Home");
        Space outside = new Space("Outside");
        Space roof    = new Space("Roof");
        Space park     = new Space("Park");
        Space store      = new Space("Store");
        Space warehouse  = new Space("Warehouse");
        Space lake       = new Space("Lake");
        Space island     = new Space("Island");
        Space cave      = new Space("Cave");
    
        //defines how these spaces are conected
        home.AddEdge("Door", outside);
        home.AddEdge("Ladder", roof);
        roof.AddEdge("Ladder", home);
        outside.AddEdge("Walkway", park);
        outside.AddEdge("Road", store);
        outside.AddEdge("Door", home);
        store.AddEdge("Gate", warehouse);
        store.AddEdge("Road", outside);
        warehouse.AddEdge("Gate", store);
        park.AddEdge("Path", lake);
        park.AddEdge("Walkway", outside);
        lake.AddEdge("Path", park);
        lake.AddEdge("Boat", island);
        island.AddEdge("Hole", cave);
        island.AddEdge("Boat", lake);
        cave.AddEdge("Hole", island);
    
        //starts at this location
        this.entry = home;
        
        // Create and add items to room
        Item solar_cells = new Item("SolarCells", "Converts energy from light directly into electricity");
        Item battery = new Item("Battery", "Stores surplus electricity fom the solar panel for later use");
        Item frame = new Item("Frame", "The foundation for making a solar panel");
        Item glass_plane = new Item("Glass", "Protects the solar cells while still letting light through");
        island.AddRoomItem(solar_cells);
        warehouse.AddRoomItem(battery);
        park.AddRoomItem(frame);
        cave.AddRoomItem(glass_plane);
        home.AddRoomItem(battery);
    }
  
    //allows access for the rest of the program
    public Space GetEntry () {
        return entry;
    }
}