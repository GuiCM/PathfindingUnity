using System.Collections.Generic;

/// <summary>
/// Represents a node with only data informations from the graph.
/// </summary>
public class Node
{
    /// <summary>
    /// The neighboors of the node.
    /// </summary>
    public List<KeyValuePair<Node, int>> Neighboors;

    /// <summary>
    /// The distance from the start node.
    /// </summary>
    public int DistanceFromStartNode { get; set; }

    /// <summary>
    /// The node that is parent of this node.
    /// </summary>
    public Node ParentNode { get; set; }

    /// <summary>
    /// The index of the node (It must be unique to each node).
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Node"/> class that represents a graph node data informations.
    /// </summary>
    /// <param name="index">The node index (Got from editor mode).</param>
    public Node(int index)
    {
        this.Index = index;
        Neighboors = new List<KeyValuePair<Node, int>>();

        DistanceFromStartNode = int.MaxValue;
    }
}
