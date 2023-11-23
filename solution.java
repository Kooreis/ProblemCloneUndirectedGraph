```java
import java.util.*;

class Node {
    public int val;
    public List<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new ArrayList<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new ArrayList<Node>();
    }

    public Node(int _val, ArrayList<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}

public class Main {
    private static HashMap<Node, Node> map = new HashMap<>();

    public static void main(String[] args) {
        Node node1 = new Node(1);
        Node node2 = new Node(2);
        Node node3 = new Node(3);
        Node node4 = new Node(4);

        node1.neighbors = Arrays.asList(node2, node4);
        node2.neighbors = Arrays.asList(node1, node3);
        node3.neighbors = Arrays.asList(node2, node4);
        node4.neighbors = Arrays.asList(node1, node3);

        Node clone = cloneGraph(node1);
        System.out.println(clone.val);
    }

    public static Node cloneGraph(Node node) {
        return clone(node);
    }

    private static Node clone(Node node) {
        if (node == null) return null;

        if (map.containsKey(node)) {
            return map.get(node);
        }

        Node clone = new Node(node.val, new ArrayList<>());
        map.put(node, clone);

        for (Node neighbor : node.neighbors) {
            clone.neighbors.add(clone(neighbor));
        }

        return clone;
    }
}
```