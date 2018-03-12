using System.Collections.Generic;

public class DefaultDijkstra
{
    private List<string> costs;
    private List<string> parentNodesPath;
    private int[] parentNodes;
    private List<int> mainPath;

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

    public List<int> MainPath
    {
        get
        {
            if (mainPath.Count > 0)
                return mainPath;
            else
                return null;
        }
    }

    public DefaultDijkstra()
    {
        costs = new List<string>();
        parentNodesPath = new List<string>();
    }

    /// <summary>
    /// Generate a path between two nodes using the Dijkstra algorithm
    /// </summary>
    /// <param name="graph">The graph containing the nodes and their relationships</param>
    /// <param name="startNode">The start node</param>
    /// <param name="destinyNode">The destiny node</param>
    /// <param name="nodeCount">The total number of nodes</param>
    /// <returns>A list of nodes with the path</returns>
    public int[] CalculateDijkstra(int[,] graph, int startNode, int destinyNode, int nodeCount)
    {
        var distanceFromStartNodeToNode = InitializeDistanceNodes(nodeCount); // Distance between the initial node, to all others node        
        var isNodeVisited = new bool[nodeCount]; // The nodes that was already visited

        parentNodes = new int[nodeCount];
        parentNodes[startNode] = startNode;
        distanceFromStartNodeToNode[startNode] = 0; // Distance from the start node to itself must be zero

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

    #region AUXILIAR METHODS

    /// <summary>
    /// Fill the cost list with the costs to all nodes from the start node
    /// </summary>
    /// <param name="distances">The distance collection from the Dijkstra algorithm result</param>
    /// <param name="startNode">The start node</param>
    private void FillCosts(int[] distances, int startNode)
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

    /// <summary>
    /// Generate a string with the path for the start node to all the other nodes
    /// </summary>
    /// <param name="startNode">The start node</param>
    /// <param name="nodeCount">The node count</param>
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

    #endregion AUXILIAR METHODS

    #region TEST

    /// <summary>
    /// Creates a mock of a graph
    /// </summary>
    /// <returns>An multi-dimensional array containing the nodes and its edges</returns>
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

    /// <summary>
    /// Test the dijkstra algorithm with an mocked graph
    /// </summary>
    public void TestDijkstra()
    {
        int startNode = 5;
        int nodeCount = 12;
        int destinyNode = 10;

        var distancesCost = CalculateDijkstra(CreateGraphMock(), startNode, destinyNode, nodeCount);

        GeneratePath(startNode, nodeCount);
        FillCosts(distancesCost, startNode);
        SetMainPath(startNode, destinyNode);
    }

    private void SetMainPath(int startNode, int destinyNode)
    {
        mainPath.Add(destinyNode);
        int parentNode = destinyNode;

        do
        {
            parentNode = parentNodes[parentNode];
            mainPath.Add(parentNode);
        } while (parentNode != startNode);
    }

    #endregion TEST
}
