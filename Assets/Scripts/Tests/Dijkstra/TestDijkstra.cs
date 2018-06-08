using System.Collections.Generic;
using UnityEngine;

public class TestDijkstra : MonoBehaviour
{
    /// <summary>
    /// An instance of <see cref="GraphView"/> class.
    /// </summary>
    public GraphView graphView;

    /// <summary>
    /// The class used to draw the lines on the scene to show the path.
    /// </summary>
    public LineDrawer lineDrawer;

    /// <summary>
    /// The node marked as the start.
    /// </summary>
    public NodeView startNode;

    /// <summary>
    /// The node marked as the destiny.
    /// </summary>
    public NodeView destinyNode;

    /// <summary>
    /// Flag to control the execution
    /// </summary>
    public bool execute;

    /// <summary>
    /// The graph data informations
    /// </summary>
    private Graph graph;

    /// <summary>
    /// The dijkstra implementation
    /// </summary>
    private Dijkstra dijkstra;

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

        dijkstra = new Dijkstra();
        graph = graphView.graph;
    }

    /// <summary>
    /// Call the dijkstra implementation to resolve the path between two nodes
    /// </summary>
    public void CallDijkstra()
    {
        if (startNode == null || destinyNode == null)
        {
            Debug.LogWarning("É necessário atribuir um nó de início e um nó de destino para realizar a busca!");
            return;
        }

        dijkstra.ResolveDijkstra(graph.Nodes, startNode.node, destinyNode.node);

        // Show results
        string report = string.Format("Distância do percurso: {0}\tNúmero de iterações: {1}\tNúmero de nós visitados: {2}\tTempo total de execução (ms): {3}",
            destinyNode.node.DistanceFromStartNode, dijkstra.Iterations, dijkstra.VisitedNodesQuantity, dijkstra.TimeToFinishTheSearch);
        print(report);

        ShowMainPath();
    }

    public void Update()
    {
        if (execute)
        {
            dijkstra.ResolveDijkstra(graph.Nodes, startNode.node, destinyNode.node);
        }
    }

    #region Auxiliar Methods

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

    #endregion Auxiliar Methods
}