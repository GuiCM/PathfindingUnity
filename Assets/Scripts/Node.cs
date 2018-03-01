using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    /// <summary>
    /// List of neighboors of the node
    /// </summary>
    public IList<KeyValuePair<int, int>> Neighboors { get; set; }

    /// <summary>
    /// The distance from the start node
    /// </summary>
    public int Distance { get; set; }

    /// <summary>
    /// The index of the node (It must be unique to each node)
    /// </summary>
    public int Index { get; set; }

    public Node(int index)
    {
        this.Index = index;
        Neighboors = new List<KeyValuePair<int, int>>();
    }
}
