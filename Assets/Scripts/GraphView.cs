using System.Linq;
using UnityEngine;

/// <summary>
/// Handle the nodes collection in the graphical representation
/// </summary>
public class GraphView : MonoBehaviour
{
    /// <summary>
    /// If true, use the unity's real distance between the nodes.
    /// </summary>
    [SerializeField]
    private bool useUnityDistances;

    /// <summary>
    /// Represent the graph data.
    /// </summary>
    public Graph graph;

    /// <summary>
    /// The visual nodes present in the scene.
    /// </summary>
    public NodeView[] NodeViewCollection { get; set; }

    void Awake()
    {
        graph = new Graph();
        NodeViewCollection = GameObject.FindObjectsOfType<NodeView>();

        /*for (int i = 0; i < NodeViewCollection.Length; i++)
        {
            NodeViewCollection[i].nodeIndex = i;
        }*/

        InitializeNodesData();
    }

    /// <summary>
    /// Initialize a collection of <see cref="Node"/> data containing all the nodes informations.
    /// </summary>
    private void InitializeNodesData()
    {
        graph.InitializeNodesCollectionFromView(NodeViewCollection, useUnityDistances);
    }
}