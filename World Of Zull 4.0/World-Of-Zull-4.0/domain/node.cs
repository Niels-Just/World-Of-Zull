namespace World_Of_Zull_4._0.domain;
public class Node
{
    protected string Name;
   
    protected Dictionary<string,Node> Edges = new Dictionary<string,Node>();

    public Node(string name)
    {
        this.Name = name;
    }

    public string GetName()
    {
        return Name;
    }
    
    public void AddEdge(string name, Node node)
    {
        Edges.Add(name.ToLower(), node);
    }
    
    public virtual Node FollowEdge(string direction) {
        if (Edges.TryGetValue(direction.ToLower(), out Node nextNode)) {
            return nextNode;
        } else {
            return null;
        }
    }
}