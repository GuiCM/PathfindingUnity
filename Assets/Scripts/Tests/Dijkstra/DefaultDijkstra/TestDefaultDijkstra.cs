using System.Collections.Generic;
using UnityEngine;

public class TestDefaultDijkstra : MonoBehaviour
{
    [SerializeField]
    private LineDrawer lineDrawer;

    [SerializeField]
    private int startNode;
    [SerializeField]
    private int destinyNode;

    private DefaultDijkstra defaultDijkstra;

    private void Start()
    {
        if (lineDrawer == null)
        {
            Debug.LogWarning("LineDrawer object not attached to the TestDefaultDijkstra!");
            return;
        }
        
        startNode = 0;
        destinyNode = 8;
        defaultDijkstra = new DefaultDijkstra();
        CallDefaultDijkstra();
    }

    /// <summary>
    /// Call the method that calculate the dijkstra algorithm with an mocked graph.
    /// </summary>
    public void CallDefaultDijkstra()
    {
        int startNode = this.startNode;
        int destinyNode = this.destinyNode;
        int nodeCount = 12;        

        defaultDijkstra.CalculateDijkstra(CreateGraphMock(), startNode, destinyNode, nodeCount);

        // Obtain the results
        List<int> path = defaultDijkstra.Path;
        if (path == null)
        {
            Debug.LogWarning("The \"path\" list is empty, probably the dijkstra wasn't calculated yet.");
            return;
        }

        List<int> costs = defaultDijkstra.NodeCosts;
        if (costs == null)
        {
            Debug.LogWarning("The \"costs\" list is empty, probably the dijkstra wasn't calculated yet.");
            return;
        }

        // Show the results
        lineDrawer.DrawPath(path);
        ShowCostsOnDebug(costs, startNode);
    }

    /// <summary>
    /// Show the full cost (distances) between the start node to all the other graph nodes on the editor console.
    /// </summary>
    /// <param name="nodeCosts">The node costs.</param>
    /// <param name="startNode">The start node.</param>
    private void ShowCostsOnDebug(List<int> nodeCosts, int startNode)
    {
        startNode++;
        string costsFormatted = "Custos(distâncias); \nNó inicial(" + startNode + ") para ele mesmo: " + nodeCosts[startNode - 1] + "\n";

        for (int i = 0; i < nodeCosts.Count; i++)
        {
            if (i == (startNode - 1))
                continue;

            costsFormatted += startNode + " -> " + i + ": " + nodeCosts[i] + "\n";
        }

        print(costsFormatted);
    }

    /// <summary>
    /// Creates a mock of a graph.
    /// </summary>
    /// <returns>An multi-dimensional array containing the nodes and its edges.</returns>
    public int[,] CreateGraphMock()
    {
        var mockGraph = new int[12, 12];

        //All the nodes and edges connecting them
        mockGraph[0, 1] = 2;
        mockGraph[0, 6] = 6;
        mockGraph[0, 11] = 10;
        mockGraph[1, 0] = 2;
        mockGraph[1, 6] = 5;
        mockGraph[1, 9] = 3;
        mockGraph[1, 3] = 1;
        mockGraph[1, 2] = 5;
        mockGraph[2, 1] = 5;
        mockGraph[2, 9] = 4;
        mockGraph[2, 8] = 5;
        mockGraph[2, 4] = 6;
        mockGraph[3, 1] = 1;
        mockGraph[4, 8] = 5;
        mockGraph[4, 2] = 6;
        mockGraph[4, 10] = 9;
        mockGraph[5, 6] = 2;
        mockGraph[6, 0] = 6;
        mockGraph[6, 1] = 5;
        mockGraph[6, 5] = 2;
        mockGraph[6, 7] = 7;
        mockGraph[7, 6] = 7;
        mockGraph[7, 8] = 3;
        mockGraph[8, 2] = 5;
        mockGraph[8, 7] = 3;
        mockGraph[8, 4] = 5;
        mockGraph[9, 1] = 3;
        mockGraph[9, 2] = 4;
        mockGraph[9, 10] = 11;
        mockGraph[9, 11] = 3;
        mockGraph[10, 4] = 9;
        mockGraph[10, 9] = 11;
        mockGraph[11, 0] = 10;
        mockGraph[11, 9] = 3;

        return mockGraph;
    }
}
