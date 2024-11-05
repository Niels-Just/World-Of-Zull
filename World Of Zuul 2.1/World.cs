namespace World_Of_Zuul;
/* World class for modeling the entire in-game world
 */

class World
{
     Space entry;
  
    //creating serval 'Space' objects and defining the connections between them.
    public World ()
    {
        Space Baghave = new Space("Baghave");
        Space Sur_Nabo = new Space("Sur_Nabo");
        Space Glad_Nabo   = new Space("Glad_Nabo");
        Space VejMidt     = new Space("Vej midt");
        Space VejØst  = new Space("VejØst");
        Space VejVest       = new Space("VejVest");
        Space Elektriker_Erik     = new Space("Elektriker_Erik");
        Space Glas_Mager_Erik      = new Space("Glas_Mager_Erik");
        Space Kunst_Haven     = new Space("Kunst_Haven");
    
        //defines how these spaces are conected
        Baghave.AddEdge("Nord",VejMidt);
        Baghave.AddEdge("Øst", Sur_Nabo);
        Baghave.AddEdge("Vest",Glad_Nabo);
        
        VejMidt.AddEdge("Syd",Baghave);
        VejMidt.AddEdge("Øst",VejØst);
        VejMidt.AddEdge("Vest",VejVest);
        VejMidt.AddEdge("Nord",Elektriker_Erik);
       
        Sur_Nabo.AddEdge("Vest",Baghave);
        Sur_Nabo.AddEdge("Nord",VejØst);
        
<<<<<<< HEAD
        Solvej28.AddEdge("Øst",Baghave);
        Solvej28.AddEdge("Nord",VejVest);
=======
        Glad_Nabo.AddEdge("Øst",Baghave);
        Glad_Nabo.AddEdge("Nord",VejMidt);
>>>>>>> refs/remotes/origin/main
        
        VejØst.AddEdge("Nord",Kunst_Haven);
        VejØst.AddEdge("Syd",Sur_Nabo);
        VejØst.AddEdge("Vest",VejMidt);
        
        VejVest.AddEdge("Nord",Glas_Mager_Erik);
        VejVest.AddEdge("Syd",Glad_Nabo);
        VejVest.AddEdge("Øst",VejMidt);
        
        Glas_Mager_Erik.AddEdge("Syd",VejVest);
        Glas_Mager_Erik.AddEdge("Øst",Elektriker_Erik);
        
        Elektriker_Erik.AddEdge("Vest",Glas_Mager_Erik);
        Elektriker_Erik.AddEdge("Øst",Kunst_Haven);
        Elektriker_Erik.AddEdge("Sud",VejMidt);
        
        Kunst_Haven.AddEdge("Vest",Elektriker_Erik);
        Kunst_Haven.AddEdge("Syd",VejØst);
    
        //starts at this location
        this.entry = Baghave;
        
        // Create and add items to room
        /* Item solar_cells = new Item("SolarCells", "Converts energy from light directly into electricity");
        Item battery = new Item("Battery", "Stores surplus electricity fom the solar panel for later use");
        Item frame = new Item("Frame", "The foundation for making a solar panel");
        Item glass_plane = new Item("Glass", "Protects the solar cells while still letting light through");
        
        Baghave.AddRoomItem(solar_cells);
        Sur_Nabo.AddRoomItem(battery);
        Glad_Nabo.AddRoomItem(frame);
        Glas_Mager_Glenn.AddRoomItem(glass_plane);

        island.AddRoomItem(solar_cells);
        warehouse.AddRoomItem(battery);
        park.AddRoomItem(frame);
        cave.AddRoomItem(glass_plane);
        home.AddRoomItem(battery);
        */

    }
  
    //allows access for the rest of the program
    public Space GetEntry () {
        return entry;
    }
}