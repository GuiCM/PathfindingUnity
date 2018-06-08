using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Resolve the A Star algorithm using Nodes and Qeue structures.
/// </summary>
public class AStar
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
    /// Generate a path between two nodes using the A* algorithm.
    /// </summary>
    /// <param name="graphNodes">The graph containing the nodes and their relationships.</param>
    /// <param name="startNode">The start node.</param>
    /// <param name="destinyNode">The destiny node.</param>
    public void ResolveAStar(Node[] graphNodes, Node startNode, Node destinyNode)
    {
        List<Node> nodesToVisit = new List<Node>();
        List<Node> visitedNodes = new List<Node>();

        ResetInformations(graphNodes);

        Stopwatch stopwatch = Stopwatch.StartNew();

        startNode.DistanceFromStartNode = 0;
        
        nodesToVisit.Add(startNode);

        while (nodesToVisit.Count > 0)
        {
            Node currentNode = GetNodeToAnalyze(nodesToVisit, destinyNode);

            // If reached the destiny node, the search is done
            if (currentNode == destinyNode)
            {
                stopwatch.Stop();
                TimeToFinishTheSearch = stopwatch.Elapsed.TotalMilliseconds;
                return;
            }

            visitedNodes.Add(currentNode);
            nodesToVisit.Remove(currentNode);

            VisitedNodesQuantity++;

            // Calculate the edges for the current node
            foreach (KeyValuePair<Node, int> neighboor in currentNode.Neighboors)
            {
                if (visitedNodes.Contains(neighboor.Key))
                {
                    continue;
                }

                if (!nodesToVisit.Contains(neighboor.Key))
                {
                    nodesToVisit.Add(neighboor.Key);
                }

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
    /// Fill an estimate distance from each graph node to the destiny node, that
    /// is used by A* to direct the search.
    /// </summary>
    /// <param name="nodes"></param>
    /// <param name="destinyNode"></param>
    private int CalculateHeuristic(Node fromNode, Node toNode)
    {
        return Mathf.CeilToInt(Vector3.Distance(fromNode.ViewTransform.position, toNode.ViewTransform.position));
    }

    /// <summary>
    /// Retrieve the next node to be analyzed (the node that has the minimum 
    /// distance).
    /// </summary>
    /// <param name="nodesToVisit">The list of open nodes.</param>
    /// <returns>The next node to be be analyzed.</returns>
    private Node GetNodeToAnalyze(List<Node> nodesToVisit, Node destinyNode)
    {
        Node nodeToAnalyze = nodesToVisit[0];

        // (F = G + H) of the current selected node
        int fScoreCurrentNode = nodeToAnalyze.DistanceFromStartNode + CalculateHeuristic(nodeToAnalyze, destinyNode);

        for (int i = 1; i < nodesToVisit.Count; i++)
        {
            // (F = G + H) of the node collection
            int fScoreNode = nodesToVisit[i].DistanceFromStartNode + CalculateHeuristic(nodesToVisit[i], destinyNode);

            if (fScoreNode < fScoreCurrentNode)
            {
                nodeToAnalyze = nodesToVisit[i];
                fScoreCurrentNode = fScoreNode;
            }
        }

        return nodeToAnalyze;
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