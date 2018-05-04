using System.Collections.Generic;
using UnityEngine;

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
    /// The parent node of this node.
    /// </summary>
    public Node ParentNode { get; set; }

    /// <summary>
    /// The position of the node in the graphic representation.
    /// </summary>
    public Transform ViewTransform { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Node"/> class that represents a graph node data informations.
    /// </summary>
    /// <param name="viewTransform">The transform of this node in the graphical representation</param>
    public Node(Transform viewTransform)
    {
        this.ViewTransform = viewTransform;
        DistanceFromStartNode = int.MaxValue;

        Neighboors = new List<KeyValuePair<Node, int>>();
    }
}