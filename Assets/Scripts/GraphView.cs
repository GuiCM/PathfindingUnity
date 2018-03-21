using System.Linq;
using UnityEngine;

/// <summary>
/// Handle the nodes collection in the graphical representation
/// </summary>
public class GraphView : MonoBehaviour
{
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
        NodeViewCollection = GameObject.FindObjectsOfType<NodeView>().OrderBy(x => x.nodeIndex).ToArray();

        InitializeNodesData();
    }

    /// <summary>
    /// Initialize a collection of <see cref="Node"/> data containing all the nodes informations.
    /// </summary>
    private void InitializeNodesData()
    {
        graph.InitNodesCollectionFromView(NodeViewCollection);
    }

    #region REMOVE
    /*
    /// <summary>
    /// Create a simple structure to be used by the Dijkstra algorithm
    /// <para>The structure respect the rule Ex.: graph[0, 3] = 3 (Node 0 to node 3 has an edge with cost 3)</para>
    /// </summary>
    private void InitializeDijkstraNodes()
    {
        int nodeCount = NodeViewCollection.Length;
        int[,] graphArray = new int[nodeCount, nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            List<KeyValuePair<int, int>> currentNodeNeighboors = (List<KeyValuePair<int, int>>)graph.nodeCollection[i].Neighboors;
            for (int j = 0; j < currentNodeNeighboors.Count; j++)
            {
                graphArray[i, currentNodeNeighboors[j].Key] = currentNodeNeighboors[j].Value; // Ex.: graph[0, 3] = 4
                graphArray[currentNodeNeighboors[j].Key, i] = currentNodeNeighboors[j].Value; // Ex.: graph[3, 0] = 4
            }
        }
    }*/

    #endregion REMOVE
}