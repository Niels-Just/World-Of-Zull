namespace World_Of_Zuul;
/* World class for modeling the entire in-game world
 */

class World {
    //starting room
    Space Baghave;
  
    //creating serval 'Space' objects and defining the connections between them.
    public World () {
        Space Baghave    = new Space("Baghave");
<<<<<<< HEAD
        Space Glad_Nabo = new Space("Glad_Nabo");
        Space Sur_Nabo    = new Space("Sur_Nabo");
        Space Vej_Vest     = new Space("Vej_Vest");
        Space Vej_Øst      = new Space("Vej_øst");
        Space Vej_Midte  = new Space("Vej_Midte");
        Space Glas_Mager_Glenn       = new Space("Glas_Mager_Glenn");
        Space Elektriker_Erik     = new Space("Elektriker_Erik");
        Space Kunst_Haven      = new Space("Kunst_Haven");
    
        //defines how these spaces are conected
        Baghave.AddEdge("Nord" , Vej_Midte);
        Baghave.AddEdge("Øst", Sur_Nabo);
        Baghave.AddEdge("Vest", Glad_Nabo);
        Glad_Nabo.AddEdge("Øst", Baghave);
        Glad_Nabo.AddEdge("Nord", Vej_Vest);
        Sur_Nabo.AddEdge("Nord", Vej_Øst);
        Sur_Nabo.AddEdge("Vest", Baghave);
        Vej_Vest.AddEdge("Syd", Glad_Nabo);
        Vej_Vest.AddEdge("Nord", Glas_Mager_Glenn);
        Vej_Vest.AddEdge("Øst", Vej_Midte);
        Vej_Midte.AddEdge("Syd", Baghave);
        Vej_Midte.AddEdge("Øst", Vej_Øst);
        Vej_Midte.AddEdge("Vest", Vej_Vest);
        Vej_Midte.AddEdge("Nord", Elektriker_Erik);
        Vej_Øst.AddEdge("Nord", Kunst_Haven);
        Vej_Øst.AddEdge("Syd", Sur_Nabo);
        Vej_Øst.AddEdge("Vest", Vej_Midte);
        Glas_Mager_Glenn.AddEdge("Syd", Vej_Vest);
        Glas_Mager_Glenn.AddEdge("Øst", Elektriker_Erik);
        Elektriker_Erik.AddEdge("Vest", Glas_Mager_Glenn);
        Elektriker_Erik.AddEdge("Syd", Vej_Midte);
        Elektriker_Erik.AddEdge("Øst", Kunst_Haven);
        Kunst_Haven.AddEdge("Syd", Vej_Øst);
        Kunst_Haven.AddEdge("Vest", Elektriker_Erik);        
        
        
        //starts at this location
        this.entry = Baghave;
=======
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
        this.Baghave = Baghave;
>>>>>>> refs/remotes/origin/main
        
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
>>>>>>> refs/remotes/origin/main
    }
  
    //allows access for the rest of the program
    public Space GetEntry () {
        return Baghave;
    }
}