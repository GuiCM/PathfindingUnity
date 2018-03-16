using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to handle the visual nodes
/// </summary>
public class GraphView : MonoBehaviour
{
    private Graph graph = new Graph();

    /// <summary>
    /// The visual nodes present in the scene
    /// </summary>
    public NodeView[] NodeViewCollection { get; set; }

    void Awake()
    {
        // Get all nodes from editor mode
        NodeViewCollection = GameObject.FindObjectsOfType<NodeView>();

        //InitNodes();    
        //PrintNodesWithEdges();
    }

    /// <summary>
    /// Initialize a collection of <see cref="Node"/> data containing all the node informations
    /// </summary>
    private void InitNodes()
    {
        graph.InitNodesCollectionFromView(NodeViewCollection);
    }

    private void PrintNodesWithEdges()
    {
        for (int i = 0; i < NodeViewCollection.Length; i++)
        {
            string text = NodeViewCollection[i].name + "; Arestas: ";

            for (int j = 0; j < NodeViewCollection[i].node.Neighboors.Count; j++)
            {
                text += "(" + NodeViewCollection[i].node.Neighboors[j].Key + "; " + NodeViewCollection[i].node.Neighboors[j].Value + ") || ";
            }

            print(text);
            print("------------------------------------------------------------");
        }
    }

    #region REMOVE

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
    }

    #endregion REMOVE
}