namespace World_Of_Zuul;
/* Node class for modeling graphs
 */

class Node {
  protected string name;
  //maps direction strings, allow the game to define connections between different nodes.
  protected Dictionary<string, Node> edges = new Dictionary<string, Node>();
  //this list contains items that can be within the node.
  private List<Item> items;
 
  //initalizes the node with a given name and initializes the 'items' list.
  public Node (string name) {
    this.name = name;
    items = new List<Item>();
  }
  
  //return the name of the node
  public String GetName () {  
    return name;
  }
  
  //adds a connection to another node
  public void AddEdge (string name, Node node) {
    edges.Add(name, node);
  }
  
  //takes a direction as a parameter and returns the connected node.
  public virtual Node FollowEdge (string direction) {
    return edges[direction];
  }

  //Method to add item to the room
  public void AddItem(Item item)
  {
    items.Add(item);
    Console.WriteLine($"{item.ItemName} has been added to {name}");
  }

  //displays items in the room
  public void ShowItems()
  {
    if (items.Count == 0)
    {
      Console.WriteLine("There is no items in the room.");
    }
    else
    {
      Console.WriteLine("The following items are in the room:");
      foreach (var item in items)
      {
        Console.WriteLine(item.ToString());
      }
    }
  }
}


