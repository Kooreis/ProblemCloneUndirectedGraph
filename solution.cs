Here is a C# console application that clones an undirected graph using a depth-first search (DFS) approach:

```C#
using System;
using System.Collections.Generic;

public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}

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

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        Node node1 = new Node(1);
        Node node2 = new Node(2);
        Node node3 = new Node(3);
        Node node4 = new Node(4);

        node1.neighbors = new List<Node> { node2, node4 };
        node2.neighbors = new List<Node> { node1, node3 };
        node3.neighbors = new List<Node> { node2, node4 };
        node4.neighbors = new List<Node> { node1, node3 };

        Node clone = solution.CloneGraph(node1);

        Console.WriteLine(clone.val);
        Console.WriteLine(clone.neighbors.Count);
    }
}
```

This program first creates a graph with 4 nodes and then clones it. The `CloneGraph` method uses a depth-first search to traverse the graph and clone it. It uses a dictionary to keep track of visited nodes to avoid cycles and to return the reference of the cloned node.