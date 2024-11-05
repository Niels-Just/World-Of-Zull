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
  }
  
  //return the name of the node
  public String GetName () {  
    return name;
  }
  
  //adds a connection to another node
  public void AddEdge (string name, Node node) {
    edges.Add(name.ToLower(), node);
  }
  
  //takes a direction as a parameter and returns the connected node.
  public virtual Node FollowEdge(string direction) {
    // Attempt to retrieve the next node using case-insensitive lookup
    if (edges.TryGetValue(direction.ToLower(), out Node nextNode)) {
      return nextNode; // Return the found node
    } else {
      return null; // Return null if no edge matches the direction
    }
  }
}





