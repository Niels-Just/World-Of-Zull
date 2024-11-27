namespace World_Of_Zull_4._0.domain;
public class Node
{
    protected string name;
   
    protected Dictionary<string,Node> edges = new Dictionary<string,Node>();

    public Node(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }
    
    public void AddEdge(string name, Node node)
    {
        edges.Add(name.ToLower(), node);
    }
    
    public virtual Node FollowEdge(string direction) {
        if (edges.TryGetValue(direction.ToLower(), out Node nextNode)) {
            return nextNode;
        } else {
            return null;
        }
    }
}