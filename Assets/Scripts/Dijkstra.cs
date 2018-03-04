using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra : MonoBehaviour
{
    public void GeneratePath(int[,] graph, int initialNode, int nodeCount)
    {
        var distanceFromStartNodeToNode = InitializeDistanceNodes(nodeCount); // Distance between the initial node, to all others node
        var isNodeVisited = new bool[nodeCount]; // The nodes that was already visited

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

            for (int j = 0; j < nodeCount; j++)
            {
                if ((graph[currentNode, j] > 0) && (distanceFromStartNodeToNode[currentNode] + graph[currentNode, j] < distanceFromStartNodeToNode[j]))
                {
                    distanceFromStartNodeToNode[j] = distanceFromStartNodeToNode[currentNode] + graph[currentNode, j];
                }
            }
        }
    }

    /// <summary>
    /// Initialize an array of distances using max int value
    /// </summary>
    /// <param name="nodeCount">The numbers of nodes present in the environment</param>
    /// <returns>An array of distances with maximum int capacity</returns>
    public int[] InitializeDistanceNodes(int nodeCount)
    {
        var distanceNodes = new int[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            distanceNodes[i] = int.MaxValue;
        }

        return distanceNodes;
    }
}
