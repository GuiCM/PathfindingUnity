using System.Collections.Generic;

public class Dijkstra
{
    private List<string> costs;
    private List<string> parentNodesPath;
    private int[] parentNodes;

    public List<string> Costs
    {
        get
        {
            if (costs.Count > 0)
                return costs;
            else
                return null;
        }
    }

    public List<string> ParentNodesPath
    {
        get
        {
            if (parentNodesPath.Count > 0)
                return parentNodesPath;
            else
                return null;
        }
    }

    public Dijkstra()
    {
        costs = new List<string>();
        parentNodesPath = new List<string>();
    }

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

    public void TestDijkstra()
    {
        var distancesCost = GeneratePath(CreateGraphMock(), 5, 10, 12);

        fillCosts(distancesCost, 5);
    }

    /// <summary>
    /// Generate a path between two nodes using the Dijkstra algorithm
    /// </summary>
    /// <param name="graph">The graph containing the nodes and their relationships</param>
    /// <param name="initialNode">The start node</param>
    /// <param name="destinyNode">The destiny node</param>
    /// <param name="nodeCount">The total number of nodes</param>
    /// <returns>A list of nodes with the path</returns>
    public int[] GeneratePath(int[,] graph, int initialNode, int destinyNode, int nodeCount)
    {
        var distanceFromStartNodeToNode = InitializeDistanceNodes(nodeCount); // Distance between the initial node, to all others node        
        var isNodeVisited = new bool[nodeCount]; // The nodes that was already visited

        parentNodes = new int[nodeCount];
        parentNodes[initialNode] = initialNode;
        distanceFromStartNodeToNode[initialNode] = 0; // Distance from the start node to itself must be zero

        for (int i = 0; i < nodeCount; i++) // Iterate through all the nodes in the environment
        {
            #region NEXT NODE TO BE ANALYSED

            var currentNode = -1;

            for (int j = 0; j < nodeCount; j++) // Select a node to be the next to be analysed
            {
                if (!isNodeVisited[j] && (currentNode < 0 || distanceFromStartNodeToNode[currentNode] > distanceFromStartNodeToNode[j]))
                {
                    currentNode = j;
                }
            }

            #endregion NEXT NODE TO BE ANALYSED

            isNodeVisited[currentNode] = true;

            for (int j = 0; j < nodeCount; j++)
            {
                if ((graph[currentNode, j] > 0) && (distanceFromStartNodeToNode[currentNode] + graph[currentNode, j] < distanceFromStartNodeToNode[j]))
                {
                    distanceFromStartNodeToNode[j] = distanceFromStartNodeToNode[currentNode] + graph[currentNode, j];
                    parentNodes[j] = currentNode;
                }
            }
        }

        GeneratePath(initialNode, nodeCount);

        return distanceFromStartNodeToNode;
    }

    /// <summary>
    /// Initialize an array of distances using max int value
    /// </summary>
    /// <param name="nodeCount">The numbers of nodes present in the environment</param>
    /// <returns>An array of distances with maximum int capacity</returns>
    private int[] InitializeDistanceNodes(int nodeCount)
    {
        var distanceNodes = new int[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            distanceNodes[i] = int.MaxValue;
        }

        return distanceNodes;
    }

    /// <summary>
    /// Fill the cost list with the costs to all nodes from the start node
    /// </summary>
    /// <param name="distances">The distance collection from the Dijkstra algorithm result</param>
    /// <param name="startNode">The start node</param>
    private void fillCosts(int[] distances, int startNode)
    {
        startNode++;

        costs.Add("Nó " + startNode + " para ele mesmo: " + distances[startNode - 1]);

        for (int i = 0; i < distances.Length; i++)
        {
            if (i == (startNode - 1))
                continue;

            costs.Add("Nó " + startNode + " para nó " + (i + 1) + ": " + distances[i]);
        }
    }

    private void GeneratePath(int startNode, int nodeCount)
    {
        parentNodesPath.Add("Nó inicial");

        string text = string.Empty;
        for (int i = 0; i < nodeCount; i++)
        {
            if (i == startNode)
                continue;

            int parentNode = i;
            text = string.Empty;

            do
            {
                text += (parentNodes[parentNode] + 1) + ", ";
                parentNode = parentNodes[parentNode];
            } while (parentNode != startNode);


            text = text.Remove(text.LastIndexOf(','));
            parentNodesPath.Add(text);
        }        
    }
}
