using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Resolve the A Star algorithm using Nodes and Qeue structures.
/// </summary>
public class AStar
{
    /// <summary>
    /// Generate a path between two nodes using the Dijkstra algorithm.
    /// </summary>
    /// <param name="graphNodes">The graph containing the nodes and their relationships.</param>
    /// <param name="startNode">The start node.</param>
    /// <param name="destinyNode">The destiny node.</param>
    public void CalculateAStar(Node[] graphNodes, Node startNode, Node destinyNode)
    {
        Queue<Node> nodesToVisit = new Queue<Node>();
        List<Node> visitedNodes = new List<Node>();

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
                if (!visitedNodes.Contains(neighboor.Key))
                {
                    nodesToVisit.Enqueue(neighboor.Key);
                }
            }
        }
    }
}