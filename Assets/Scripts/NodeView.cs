using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle each node in the graphical representation.
/// </summary>
public class NodeView : MonoBehaviour
{
    /// <summary>
    /// Represents the "name" of the node.
    /// </summary>
    public int nodeIndex;

    /// <summary>
    /// A reference for the correspondent node data (DijkstraV2 only).
    /// </summary>
    public Node node;

    /// <summary>
    /// Represents all the conections that this node contains to the other nodes on the graph.
    /// <para>This attribute stores all the transforms that will have a conection with this node.</para>
    /// </summary>
    public Transform[] nodesToConect;

    /// <summary>
    /// Initializes all the conections that this node has (all the edges linked to this node).
    /// </summary>
    public void InitializeNodeEdges()
    {
        foreach (Transform neighboorNodeTransform in nodesToConect)
        {
            NodeView neighboorNodeView = neighboorNodeTransform.transform.GetComponent<NodeView>();
            int distance = Mathf.RoundToInt(Vector3.Distance(transform.position, neighboorNodeTransform.position));

            node.Neighboors.Add(new KeyValuePair<Node, int>(neighboorNodeView.node, distance));
        }
    }
}