using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge {
    /// <summary>
    /// The index of the node that this edge points to
    /// </summary>
    public int IndexDestinyNode { get; set; }

    /// <summary>
    /// The cost of the edge
    /// </summary>
    public int Cost { get; set; }

    /// <summary>
    /// Initialize a new instance of an edge
    /// </summary>
    /// <param name="destinyNode">The destiny node to link to this edge</param>
    /// <param name="cost">The cost of the node</param>
    public Edge(int destinyNode, int cost)
    {
        this.IndexDestinyNode = destinyNode;
        this.Cost = cost;
    }
}
