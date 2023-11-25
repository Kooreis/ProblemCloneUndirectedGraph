public class Solution
{
    private Dictionary<Node, Node> visited = new Dictionary<Node, Node>();

    public Node CloneGraph(Node node)
    {
        if (node == null)
        {
            return node;
        }

        if (visited.ContainsKey(node))
        {
            return visited[node];
        }

        Node cloneNode = new Node(node.val, new List<Node>());
        visited[node] = cloneNode;

        foreach (var neighbor in node.neighbors)
        {
            cloneNode.neighbors.Add(CloneGraph(neighbor));
        }
        return cloneNode;
    }
}