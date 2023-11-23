```python
class Node:
    def __init__(self, val = 0, neighbors = None):
        self.val = val
        self.neighbors = neighbors if neighbors is not None else []

def cloneGraph(node):
    if not node:
        return node
    m = {node: Node(node.val)}
    stack = [node]
    while stack:
        n = stack.pop()
        for neighbor in n.neighbors:
            if neighbor not in m:
                stack.append(neighbor)
                m[neighbor] = Node(neighbor.val)
            m[n].neighbors.append(m[neighbor])
    return m[node]

def main():
    node1 = Node(1)
    node2 = Node(2)
    node3 = Node(3)
    node4 = Node(4)
    node1.neighbors = [node2, node4]
    node2.neighbors = [node1, node3]
    node3.neighbors = [node2, node4]
    node4.neighbors = [node1, node3]
    clone = cloneGraph(node1)
    print(clone.val)
    print([n.val for n in clone.neighbors])

if __name__ == "__main__":
    main()
```