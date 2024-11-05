namespace World_Of_Zuul;
/* World class for modeling the entire in-game world
 */

class World {
    
  
    //creating serval 'Space' objects and defining the connections between them.
    public World ()
    {
        Space Baghave = new Space("Baghave");
        Space Solvej32 = new Space("Solvej32");
        Space Solvej28   = new Space("Solvej28");
        Space VejMidt     = new Space("Vej midt");
        Space VejØst  = new Space("VejØst");
        Space VejVest       = new Space("VejVest");
        Space Solvej31     = new Space("Solvej31");
        Space Solvej29      = new Space("Solvej29");
        Space Solvej33     = new Space("Solvej33");
    
        //defines how these spaces are conected
        Baghave.AddEdge("Nord",VejMidt);
        Baghave.AddEdge("Øst", Solvej32);
        Baghave.AddEdge("Vest",Solvej28);
        
        VejMidt.AddEdge("Syd",Baghave);
        VejMidt.AddEdge("Øst",VejØst);
        VejMidt.AddEdge("Vest",VejVest);
        VejMidt.AddEdge("Nord",Solvej31);
       
        Solvej32.AddEdge("Vest",Baghave);
        Solvej32.AddEdge("Nord",VejØst);
        
        Solvej28.AddEdge("Øst",Baghave);
        Solvej28.AddEdge("Nord",VejMidt);
        
        VejØst.AddEdge("Nord",Solvej33);
        VejØst.AddEdge("Syd",Solvej32);
        VejØst.AddEdge("Vest",VejMidt);
        
        VejVest.AddEdge("Nord",Solvej29);
        VejVest.AddEdge("Syd",Solvej28);
        VejVest.AddEdge("Øst",VejMidt);
        
        Solvej29.AddEdge("Syd",VejVest);
        Solvej29.AddEdge("Øst",Solvej31);
        
        Solvej31.AddEdge("Vest",Solvej29);
        Solvej31.AddEdge("Øst",Solvej33);
        Solvej31.AddEdge("Sud",VejMidt);
        
        Solvej33.AddEdge("Vest",Solvej31);
        Solvej33.AddEdge("Syd",VejØst);
    
        //starts at this location
        this.entry = Baghave;
        
        // Create and add items to room
        /* Item solar_cells = new Item("SolarCells", "Converts energy from light directly into electricity");
        Item battery = new Item("Battery", "Stores surplus electricity fom the solar panel for later use");
        Item frame = new Item("Frame", "The foundation for making a solar panel");
        Item glass_plane = new Item("Glass", "Protects the solar cells while still letting light through");
<<<<<<< HEAD
        Baghave.AddRoomItem(solar_cells);
        Sur_Nabo.AddRoomItem(battery);
        Glad_Nabo.AddRoomItem(frame);
        Glas_Mager_Glenn.AddRoomItem(glass_plane);
=======
        island.AddRoomItem(solar_cells);
        warehouse.AddRoomItem(battery);
        park.AddRoomItem(frame);
        cave.AddRoomItem(glass_plane);
        home.AddRoomItem(battery);
        */

    }
  
    //allows access for the rest of the program
    public Space GetEntry () {
        return Baghave;
    }
}