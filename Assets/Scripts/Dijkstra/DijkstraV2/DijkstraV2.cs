using System.Collections.Generic;

/// <summary>
/// Resolve the Dijksta algorithm using Nodes and Qeue structures.
/// </summary>
public class DijkstraV2
{
    public int Iterations { get; set; }

    public int VisitedNodesQuantity { get; set; }

    /// <summary>
    /// Generate a path between two nodes using the Dijkstra algorithm.
    /// </summary>
    /// <param name="graphNodes">The graph containing the nodes and their relationships.</param>
    /// <param name="startNode">The start node.</param>
    /// <param name="destinyNode">The destiny node.</param>
    public void CalculateDijkstra(Node[] graphNodes, Node startNode, Node destinyNode, bool stopOnDestiny)
    {
        List<Node> nodesToVisit = new List<Node>();
        List<Node> visitedNodes = new List<Node>();

        // Before calculate the path, clear the parent references (if it is recalculating)
        ClearParentReferences(graphNodes);

        // The distance from start node to itself is zero
        startNode.DistanceFromStartNode = 0;

        // Add all the nodes in the list to analyze
        nodesToVisit.AddRange(graphNodes);

        while (nodesToVisit.Count > 0)
        {
            Node currentNode = GetNodeToAnalyze(nodesToVisit);

            if (stopOnDestiny && currentNode == destinyNode)
            {
                return;
            }

            visitedNodes.Add(currentNode);
            nodesToVisit.Remove(currentNode);

            VisitedNodesQuantity++;

            // Calculate the edges for the current node
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
    }

    /// <summary>
    /// Clear all the node parent references.
    /// </summary>
    /// <param name="graphNodes">The collection of node informations.</param>
    private void ClearParentReferences(Node[] graphNodes)
    {
        foreach (Node node in graphNodes)
        {
            node.ParentNode = null;
            node.DistanceFromStartNode = int.MaxValue;
        }

        Iterations = 0;
        VisitedNodesQuantity = 0;
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
            {
                nextNode = nodesCollection[i];
            }
        }

        return nextNode;
    }

    #region Dijkstra with Queue

    /*
    /// <summary>
    /// Generate a path between two nodes using the Dijkstra algorithm.
    /// </summary>
    /// <param name="graphNodes">The graph containing the nodes and their relationships.</param>
    /// <param name="startNode">The start node.</param>
    /// <param name="destinyNode">The destiny node.</param>
    public void CalculateDijkstraQueue(Node[] graphNodes, Node startNode, Node destinyNode)
    {
        Queue<Node> nodesToVisit = new Queue<Node>();
        List<Node> visitedNodes = new List<Node>();

        // Before calculate the path, clear the parent references (if it is recalculating)
        ClearParentReferences(graphNodes);

        // The distance from start node to itself is zero
        startNode.DistanceFromStartNode = 0;

        // Put the start node on the queue to analyze
        nodesToVisit.Enqueue(startNode);

        while (nodesToVisit.Count > 0)
        {
            Node currentNode = nodesToVisit.Dequeue();
            visitedNodes.Add(currentNode);

            // Calculate the edges for the current node
            foreach (KeyValuePair<Node, int> neighboor in currentNode.Neighboors)
            {
                if ((currentNode.DistanceFromStartNode + neighboor.Value) < neighboor.Key.DistanceFromStartNode)
                {
                    neighboor.Key.DistanceFromStartNode = currentNode.DistanceFromStartNode + neighboor.Value;
                    neighboor.Key.ParentNode = currentNode;
                }

                // Add the neighboors to the queue to be analysed after
                if (!visitedNodes.Contains(neighboor.Key) && !nodesToVisit.Contains(neighboor.Key))
                {
                    nodesToVisit.Enqueue(neighboor.Key);
                }
            }
        }        
    }
    */

    #endregion Dijkstra with Queue
}