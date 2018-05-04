using System.Collections.Generic;

/// <summary>
/// Resolve the Dijksta algorithm using the default structures.
/// </summary>
public class DefaultDijkstra
{
    /// <summary>
    /// Stores the full path cost (or distance) from the start node to all the other graph nodes.
    /// </summary>
    private List<int> costs;

    /// <summary>
    /// Stores the full path reference (nodes) from the start node to the destiny node.
    /// <para>The nodes that need to be traveled to get until the destiny node.</para>
    /// </summary>
    private List<int> path;

    /// <summary>
    /// Stores the parent of each node (the node that need to be traveled to get until this node).
    /// </summary>
    private int[] parentNodes;

    /// <summary>
    /// The list of the node costs if the dijkstra was already calculated.
    /// </summary>
    public List<int> NodeCosts
    {
        get
        {
            if (costs.Count > 0)
                return costs;
            else
                return null;
        }
    }

    /// <summary>
    /// Return the list of the path from the start node to the destiny node.
    /// </summary>
    public List<int> Path
    {
        get
        {
            if (path.Count > 0)
                return path;
            else
                return null;
        }
    }

    /// <summary>
    /// Initializes an instance of <see cref="DefaultDijkstra"/> class. 
    /// </summary>
    public DefaultDijkstra()
    {
        costs = new List<int>();
        path = new List<int>();
    }

    /// <summary>
    /// Generate a path between two nodes using the Dijkstra algorithm.
    /// </summary>
    /// <param name="graph">The graph containing the nodes and their relationships.</param>
    /// <param name="startNode">The start node.</param>
    /// <param name="destinyNode">The destiny node.</param>
    /// <param name="nodeCount">The total number of nodes.</param>
    public void CalculateDijkstra(int[,] graph, int startNode, int destinyNode, int nodeCount)
    {
        var distanceStartNodeToNode = InitializeDistanceNodes(nodeCount); // Distance between the start node, to all others node
        var isNodeVisited = new bool[nodeCount]; // The nodes that was already visited

        parentNodes = new int[nodeCount];
        parentNodes[startNode] = startNode;
        distanceStartNodeToNode[startNode] = 0; // Distance from the start node to itself is zero

        ClearLists();

        // Iterate through all the nodes in the scene
        for (int i = 0; i < nodeCount; i++)
        {
            // Get the node with the lowest cost to analyse
            var currentNode = -1;

            for (int j = 0; j < nodeCount; j++) // Select a node to be the next to be analysed
            {
                if (!isNodeVisited[j] && (currentNode < 0 || distanceStartNodeToNode[currentNode] > distanceStartNodeToNode[j]))
                {
                    currentNode = j;
                }
            }

            isNodeVisited[currentNode] = true;
            
            for (int j = 0; j < nodeCount; j++)
            {
                if ((graph[currentNode, j] > 0) && (distanceStartNodeToNode[currentNode] + graph[currentNode, j] < distanceStartNodeToNode[j]))
                {
                    distanceStartNodeToNode[j] = distanceStartNodeToNode[currentNode] + graph[currentNode, j];
                    parentNodes[j] = currentNode;
                }
            }
        }

        // Set the results data
        SetMainPath(startNode, destinyNode);
        SetCosts(distanceStartNodeToNode);
    }

    /// <summary>
    /// Clear the costs and the path list to calculate the Dijkstra.
    /// </summary>
    private void ClearLists()
    {
        costs.Clear();
        path.Clear();
    }

    /// <summary>
    /// Initialize an array of distances using max int value.
    /// </summary>
    /// <param name="nodeCount">The numbers of nodes present in the scene.</param>
    /// <returns>An array of distances with maximum int capacity.</returns>
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
    /// Fill the path between the start node and the destiny node.
    /// </summary>
    /// <param name="startNode">The start node.</param>
    /// <param name="destinyNode">The destiny node.</param>
    private void SetMainPath(int startNode, int destinyNode)
    {
        path.Add(destinyNode);
        int parentNode = destinyNode;

        do
        {
            parentNode = parentNodes[parentNode];
            path.Add(parentNode);
        } while (parentNode != startNode);
    }

    /// <summary>
    /// Set the cost from the start node to all the other graph nodes.
    /// </summary>
    /// <param name="nodeCosts">The distance between the start node to all other, calculated by the Dijkstra algorithm.</param>
    private void SetCosts(int[] nodeCosts)
    {
        for (int i = 0; i < nodeCosts.Length; i++)
        {
            costs.Add(nodeCosts[i]);
        }
    }

    #region REMOVED METHODS

    /*/// <summary>
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
    }*/

    /*/// <summary>
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
    }*/

    #endregion REMOVED METHODS
}
