using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Resolve the Dijksta algorithm using Nodes and Qeue structures.
/// </summary>
public class Dijkstra
{
    /// <summary>
    /// Store the total iterations count
    /// </summary>
    public int Iterations { get; private set; }

    /// <summary>
    /// Store the total visited nodes count
    /// </summary>
    public int VisitedNodesQuantity { get; private set; }

    /// <summary>
    /// Store the time elapsed to finish a single search
    /// </summary>
    public double TimeToFinishTheSearch { get; private set; }

    /// <summary>
    /// Generate a path between two nodes using the Dijkstra algorithm.
    /// </summary>
    /// <param name="graphNodes">The graph containing the nodes and their relationships.</param>
    /// <param name="startNode">The start node.</param>
    /// <param name="destinyNode">The destiny node.</param>
    public void ResolveDijkstra(Node[] graphNodes, Node startNode, Node destinyNode)
    {
        List<Node> nodesToVisit = new List<Node>();
        List<Node> visitedNodes = new List<Node>();

        ResetInformations(graphNodes);

        Stopwatch stopwatch = Stopwatch.StartNew();

        startNode.DistanceFromStartNode = 0;

        nodesToVisit.AddRange(graphNodes);

        while (nodesToVisit.Count > 0)
        {
            Node currentNode = GetNodeToAnalyze(nodesToVisit);

            visitedNodes.Add(currentNode);
            nodesToVisit.Remove(currentNode);

            VisitedNodesQuantity++;

            foreach (KeyValuePair<Node, int> neighboor in currentNode.Neighboors)
            {
                if (visitedNodes.Contains(neighboor.Key))
                    continue;

                if ((currentNode.DistanceFromStartNode + neighboor.Value) < neighboor.Key.DistanceFromStartNode)
                {
                    neighboor.Key.DistanceFromStartNode = currentNode.DistanceFromStartNode + neighboor.Value;
                    neighboor.Key.ParentNode = currentNode;
                }

                Iterations++;
            }
        }

        stopwatch.Stop();
        TimeToFinishTheSearch = stopwatch.Elapsed.TotalMilliseconds;
    }

    /// <summary>
    /// Retrieve the next node to be analyzed (the node that has the minimum 
    /// distance).
    /// </summary>
    /// <param name="nodesCollection">The list of nodes.</param>
    /// <returns>The next node to be be analyzed.</returns>
    private Node GetNodeToAnalyze(List<Node> nodesCollection)
    {
        Node nextNode = nodesCollection[0];

        for (int i = 1; i < nodesCollection.Count; i++)
        {
            if (nodesCollection[i].DistanceFromStartNode < nextNode.DistanceFromStartNode)
                nextNode = nodesCollection[i];
        }

        return nextNode;
    }

    /// <summary>
    /// Clear all the node parent references.
    /// </summary>
    /// <param name="graphNodes">The collection of node informations.</param>
    private void ResetInformations(Node[] graphNodes)
    {
        foreach (Node node in graphNodes)
        {
            node.ParentNode = null;
            node.DistanceFromStartNode = int.MaxValue;
        }

        Iterations = 0;
        VisitedNodesQuantity = 0;
        TimeToFinishTheSearch = 0f;
    }
}