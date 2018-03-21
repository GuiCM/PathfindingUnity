﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Test the DijkstraV2 implementation
/// </summary>
public class TestDijkstraV2 : MonoBehaviour
{
    /// <summary>
    /// The graph in the graphical representation (scene).
    /// </summary>
    [SerializeField]
    private GraphView graphView;

    /// <summary>
    /// The class used to draw the lines on the scene to show the path.
    /// </summary>
    [SerializeField]
    private LineDrawer lineDrawer;

    /// <summary>
    /// The node marked as the start.
    /// </summary>
    [SerializeField]
    private NodeView startNode;

    /// <summary>
    /// The node marked as the destiny.
    /// </summary>
    [SerializeField]
    private NodeView destinyNode;

    /// <summary>
    /// The graph data informations
    /// </summary>
    private Graph graph;

    /// <summary>
    /// The dijkstra v2 implementation
    /// </summary>
    private DijkstraV2 dijkstra;

    private void Start()
    {
        if (graphView == null)
        {
            Debug.LogWarning("GraphView object not attached to the TestDijkstraV2!");
            return;
        }

        if (lineDrawer == null)
        {
            Debug.LogWarning("LineDrawer object not attached to the TestDijkstraV2!");
            return;
        }

        dijkstra = new DijkstraV2();
        graph = graphView.graph;

        // FOR NOW
        MockNodeEdges();
    }

    /// <summary>
    /// Resolve the dijkstra algorithm using the version 2.
    /// </summary>
    public void CallTestDijkstraV2()
    {
        if (startNode == null || destinyNode == null)
        {
            Debug.LogWarning("É necessário atribuir um nó de início de um nó de destino para realizar a busca!");
            return;
        }

        destinyNode = graphView.NodeViewCollection[7];

        // dijkstra.CalculateDijkstra(graph.Nodes, this.startNode.node, this.destinyNode.node);
        dijkstra.CalculateDijkstra(graph.Nodes, graph.Nodes[0], graph.Nodes[7]);
        print(graph.Nodes[7].DistanceFromStartNode);

        ShowMainPath();
    }

    /// <summary>
    /// Create all the node edges.
    /// </summary>
    private void MockNodeEdges()
    {
        //Order the array by the nodeIndex, filled in editor mode, to access the correct node using the array index
        //NodeView[] nodeViewAux = graphView.NodeViewCollection.OrderBy(x => x.nodeIndex).ToArray();

        Node[] nodeAux = graphView.NodeViewCollection.Select(x => x.node).ToArray();

        // Node 1 (index 0)
        nodeAux[0].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[1], 2));
        nodeAux[0].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[6], 6));
        nodeAux[0].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[11], 10));

        // Node 2 (index 1)
        nodeAux[1].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[0], 2));
        nodeAux[1].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[6], 5));
        nodeAux[1].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[9], 3));
        nodeAux[1].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[3], 1));
        nodeAux[1].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[2], 5));

        // Node 3 (index 2)
        nodeAux[2].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[1], 5));
        nodeAux[2].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[9], 4));
        nodeAux[2].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[8], 5));
        nodeAux[2].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[4], 6));

        // Node 4 (index 3)
        nodeAux[3].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[1], 1));

        // Node 5 (index 4)
        nodeAux[4].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[8], 5));
        nodeAux[4].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[2], 6));
        nodeAux[4].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[10], 9));

        // Node 6 (index 5)
        nodeAux[5].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[6], 2));

        // Node 7 (index 6)
        nodeAux[6].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[0], 6));
        nodeAux[6].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[1], 5));
        nodeAux[6].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[5], 2));
        nodeAux[6].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[7], 7));

        // Node 8 (index 7)
        nodeAux[7].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[6], 7));
        nodeAux[7].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[8], 3));

        // Node 9 (index 8)
        nodeAux[8].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[2], 5));
        nodeAux[8].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[7], 3));
        nodeAux[8].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[4], 5));

        // Node 10 (index 9)
        nodeAux[9].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[1], 3));
        nodeAux[9].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[2], 4));
        nodeAux[9].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[10], 11));
        nodeAux[9].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[11], 3));

        // Node 11 (index 10)
        nodeAux[10].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[4], 9));
        nodeAux[10].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[9], 11));

        // Node 12 (index 11)
        nodeAux[11].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[0], 10));
        nodeAux[11].Neighboors.Add(new KeyValuePair<Node, int>(nodeAux[9], 3));
    }

    #region Auxiliar Methods

    private void ShowMainPath()
    {
        List<NodeView> nodesPath = new List<NodeView>();
        nodesPath.Add(destinyNode);

        Node parentNode = destinyNode.node.ParentNode;

        while (parentNode != null)
        {
            parentNode = parentNode.ParentNode;
            nodesPath.Add(graphView.NodeViewCollection.Where(x => x.node == parentNode).FirstOrDefault());
        }

        nodesPath.Add(graphView.NodeViewCollection.Where(x => x.node == parentNode).FirstOrDefault());

        lineDrawer.DrawPath(nodesPath);
    }

    #endregion Auxiliar Methods
}
