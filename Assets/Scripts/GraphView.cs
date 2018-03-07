using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphView : MonoBehaviour
{
    private Dijkstra dijkstra;
    private NodeView[] nodeViewCollection;
    private Graph graph = new Graph();

    void Start()
    {
        // Get all nodes from the editor mode
        nodeViewCollection = GameObject.FindObjectsOfType<NodeView>();

        InitNodes();

        PrintNodesWithEdges();

        dijkstra = new Dijkstra();
        dijkstra.TestDijkstra();

        string text = string.Empty;

        for (int i = 0; i < dijkstra.Costs.Count; i++)
        {       
            text += dijkstra.Costs[i];
            text += " caminho: " + dijkstra.ParentNodesPath[i];
            text += "\n";
        }

        print(text);
    }

    /// <summary>
    /// Initialize a collection of <see cref="Node"/> data containing all the node informations
    /// </summary>
    private void InitNodes()
    {        
        graph.InitNodesCollectionFromView(nodeViewCollection);
    }

    /// <summary>
    /// Create a simple structure to be used by the Dijkstra algorithm
    /// <para>The structure respect the rule Ex.: graph[0, 3] = 3 (Node 0 to node 3 has an edge with cost 3)</para>
    /// </summary>
    private void InitializeDijkstraNodes()
    {
        int nodeCount = nodeViewCollection.Length;
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

    private void PrintNodesWithEdges()
    {        
        for (int i = 0; i < nodeViewCollection.Length; i++)
        {
            string text = nodeViewCollection[i].name + "; Arestas: ";

            for (int j = 0; j < nodeViewCollection[i].node.Neighboors.Count; j++)
            {
                text += "(" + nodeViewCollection[i].node.Neighboors[j].Key + "; " + nodeViewCollection[i].node.Neighboors[j].Value + ") || ";
            }

            print(text);
            print("------------------------------------------------------------");
        }                
    }
}