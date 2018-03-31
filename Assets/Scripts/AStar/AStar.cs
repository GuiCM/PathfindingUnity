using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Resolve the A Star algorithm using Nodes and Qeue structures.
/// </summary>
public class AStar
{
    public int Iterations { get; set; }

    public int VisitedNodesQuantity { get; set; }

    /// <summary>
    /// Generate a path between two nodes using the Dijkstra algorithm.
    /// </summary>
    /// <param name="graphNodes">The graph containing the nodes and their relationships.</param>
    /// <param name="startNode">The start node.</param>
    /// <param name="destinyNode">The destiny node.</param>
    public void CalculateAStar(Node[] graphNodes, Node startNode, Node destinyNode)
    {
        #region SETUP

        List<Node> nodesToVisit = new List<Node>();
        List<Node> visitedNodes = new List<Node>();

        // Before calculate the path, clear the parent references (if it is recalculating)
        ClearParentReferences(graphNodes);

        #endregion SETUP

        // The distance from start node to itself is zero
        startNode.DistanceFromStartNode = 0;

        // Add all the nodes to be analyzed
        nodesToVisit.Add(startNode);

        while (nodesToVisit.Count > 0)
        {
            Node currentNode = GetNodeToAnalyze(nodesToVisit, destinyNode);            

            // If reached the destiny node, the search is done
            if (currentNode == destinyNode)
                return;

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
        Node nextNode = nodesToVisit[0];

        // (F = G + H) of the current selected node
        int fScoreCurrentSelectedNode = nextNode.DistanceFromStartNode + CalculateHeuristic(nextNode, destinyNode);

        for (int i = 1; i < nodesToVisit.Count; i++)
        {            
            // (F = G + H) of the node collection
            int fScoreNode = nodesToVisit[i].DistanceFromStartNode + CalculateHeuristic(nodesToVisit[i], destinyNode);

            if (fScoreNode < fScoreCurrentSelectedNode)
            {
                nextNode = nodesToVisit[i];
                fScoreCurrentSelectedNode = fScoreNode;
            }
        }

        return nextNode;
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
}