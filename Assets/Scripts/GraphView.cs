using System.Collections.Generic;
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

    /// <summary>
    /// A list of int to hold the start node indexes that the algorithms will calculate
    /// </summary>
    public List<int> startNodesIndex;

    /// <summary>
    /// A list of int to hold the destiny node indexes that the algorithms will calculate
    /// </summary>
    public List<int> destinyNodesIndex;

    void Awake()
    {
        graph = new Graph();
        NodeViewCollection = GameObject.FindObjectsOfType<NodeView>();

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