namespace World_Of_Zuul;
/* World class for modeling the entire in-game world
 */

class World {
  Space entry;
  
  public World () {
    Space home    = new Space("Home");
    Space outside = new Space("Outside");
    Space roof    = new Space("Roof");
    Space park     = new Space("Park");
    Space store      = new Space("Store");
    Space warehouse  = new Space("Warehouse");
    Space lake       = new Space("Lake");
    Space island     = new Space("Island");
    
    home.AddEdge("Door", outside);
    home.AddEdge("Ladder", roof);
    outside.AddEdge("Left", park);
    outside.AddEdge("Right", store);
    store.AddEdge("Gate", warehouse);
    park.AddEdge("Path", lake);
    lake.AddEdge("Boat", island);
    
    this.entry = home;
  }
  
  public Space GetEntry () {
    return entry;
  }
}

