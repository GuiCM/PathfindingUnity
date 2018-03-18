﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle the graph data.
/// </summary>
public class Graph
{
    /// <summary>
    /// Store all the node data informations.
    /// </summary>
    private Node[] nodeCollection;

    /// <summary>
    /// Retrieve the node data collection.
    /// </summary>
    public Node[] Nodes
    {
        get
        {
            return nodeCollection;
        }
    }

    /// <summary>
    /// Initializes a new array of Node and fill the basic informations.
    /// </summary>
    /// <param name="nodeViewCollection">The collection of visual nodes from the editor.</param>
    public void InitNodesCollectionFromView(NodeView[] nodeViewCollection)
    {
        nodeCollection = new Node[nodeViewCollection.Length];

        for (int i = 0; i < nodeViewCollection.Length; i++)
        {
            nodeCollection[i] = new Node(nodeViewCollection[i].nodeIndex);

            nodeViewCollection[i].node = nodeCollection[i];
            nodeViewCollection[i].InitializeNodeEdges();
        }
    }
}