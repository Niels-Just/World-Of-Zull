namespace World_of_Zuul___3._0;

public class Game
{
    Room Baghave;

    //creating serval 'Space' objects and defining the connections between them.
    public Game()
    {
    }
}



class program
{
    static void Main(string[] args)
    {
        Game game = new Game();

        
        Room Baghave = new Room("Baghave");
        Room Glad_Nabo = new Room("Glad Nabo");
        Room Sur_Nabo = new Room("Sur Nabo");
        Room Vej_Midt = new Room("Vej midt");
        Room Vej_Øst = new Room("Vej Øst");
        Room Vej_Vest = new Room("Vej Vest");
        Room Elektriker_Erik = new Room("Elektriker Erik");
        Room Glas_Mager_glenn = new Room("Glas Mager Glenn");
        Room Kunst_Haven = new Room("Kunst Haven");

        //defines how these spaces are conected
        Baghave.AddEdge("Nord", Vej_Midt);
        Baghave.AddEdge("Øst", Sur_Nabo);
        Baghave.AddEdge("Vest", Glad_Nabo);

        Vej_Midt.AddEdge("Syd", Baghave);
        Vej_Midt.AddEdge("Øst", Vej_Øst);
        Vej_Midt.AddEdge("Vest", Vej_Vest);
        Vej_Midt.AddEdge("Nord", Elektriker_Erik);

        Sur_Nabo.AddEdge("Vest", Baghave);
        Sur_Nabo.AddEdge("Nord", Vej_Øst);

        Glad_Nabo.AddEdge("Øst", Baghave);
        Glad_Nabo.AddEdge("Nord", Vej_Vest);

        Vej_Øst.AddEdge("Nord", Kunst_Haven);
        Vej_Øst.AddEdge("Syd", Sur_Nabo);
        Vej_Øst.AddEdge("Vest", Vej_Midt);

        Vej_Vest.AddEdge("Nord", Glas_Mager_glenn);
        Vej_Vest.AddEdge("Syd", Glad_Nabo);
        Vej_Vest.AddEdge("Øst", Vej_Midt);

        Glas_Mager_glenn.AddEdge("Syd", Vej_Vest);
        Glas_Mager_glenn.AddEdge("Øst", Elektriker_Erik);

        Elektriker_Erik.AddEdge("Vest", Glas_Mager_glenn);
        Elektriker_Erik.AddEdge("Øst", Kunst_Haven);
        Elektriker_Erik.AddEdge("Syd", Vej_Midt);

        Kunst_Haven.AddEdge("Vest", Elektriker_Erik);
        Kunst_Haven.AddEdge("Syd", Vej_Øst);
        
Console.WriteLine("Welcome to the World of Zuul!");
    }
}