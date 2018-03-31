using System.Collections.Generic;
using UnityEngine;

public class TestAStar : MonoBehaviour
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
    private AStar aStar;

    private void Start()
    {
        if (graphView == null)
        {
            Debug.LogWarning("GraphView object not attached to the TestAStar!");
            return;
        }

        if (lineDrawer == null)
        {
            Debug.LogWarning("LineDrawer object not attached to the TestAStar!");
            return;
        }

        aStar = new AStar();
        graph = graphView.graph;
    }

    public void CallTestAStar()
    {
        if (startNode == null || destinyNode == null)
        {
            Debug.LogWarning("É necessário atribuir um nó de início e um nó de destino para realizar a busca!");
            return;
        }               

        aStar.CalculateAStar(graph.Nodes, startNode.node, destinyNode.node);

        //Results
        print("Distância do percurso: " + destinyNode.node.DistanceFromStartNode +
           "\tNúmero de iterações: " + aStar.Iterations +
           "\tNúmero de nós visitados: " + aStar.VisitedNodesQuantity);

        ShowMainPath();
    }

    /// <summary>
    /// Iterate from the destiny node using the parent nodes to reach the start node.
    /// </summary>
    private void ShowMainPath()
    {
        List<Node> nodesPath = new List<Node>() { destinyNode.node };        

        Node node = destinyNode.node;

        while (node.ParentNode != null)
        {
            node = node.ParentNode;
            nodesPath.Add(node);
        }

        lineDrawer.DrawPath(nodesPath);
    }
}
