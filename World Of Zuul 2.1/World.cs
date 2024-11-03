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
    
        //defines how these spaces are conected
        home.AddEdge("Door", outside);
        home.AddEdge("Ladder", roof);
        outside.AddEdge("Left", park);
        outside.AddEdge("Right", store);
        store.AddEdge("Gate", warehouse);
        park.AddEdge("Path", lake);
        lake.AddEdge("Boat", island);
    
        //starts at this location
        this.entry = home;
    }
  
    //allows access for the rest of the program
    public Space GetEntry () {
        return entry;
    }
}