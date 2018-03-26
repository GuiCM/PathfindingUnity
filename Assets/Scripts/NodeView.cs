using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NeighboorNode
{
    public Transform neighboorNode;
    public int distance;
}

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
    public NeighboorNode[] nodesToConect;

    /// <summary>
    /// Initializes all the conections that this node has with other nodes (all the edges linked to this node).
    /// </summary>
    public void InitializeNodeEdges()
    {
        foreach (NeighboorNode neighboorNode in nodesToConect)
        {
            NodeView neighboorNodeView = neighboorNode.neighboorNode.transform.GetComponent<NodeView>();

            node.Neighboors.Add(new KeyValuePair<Node, int>(neighboorNodeView.node, neighboorNode.distance));
        }
    }

    public void InitializeNodeEdgesWithUnityDistances()
    {
        foreach (NeighboorNode neighboorNode in nodesToConect)
        {
            NodeView neighboorNodeView = neighboorNode.neighboorNode.transform.GetComponent<NodeView>();

            //Calculate the distance
            int distance = Mathf.RoundToInt(Vector3.Distance(this.transform.position, neighboorNodeView.transform.position));

            node.Neighboors.Add(new KeyValuePair<Node, int>(neighboorNodeView.node, distance));
        }
    }
}