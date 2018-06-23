using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestDijkstra : MonoBehaviour
{
    public delegate void ExecuteMode();

    public ExecuteMode executeMode;

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
        GeneralUtility.Get.ClearLineRenderers();

        startNode = graphView.NodeViewCollection.FirstOrDefault(x => x.name == UIStatus.Get.inptDijkstraStartNode.text);
        destinyNode = graphView.NodeViewCollection.FirstOrDefault(x => x.name == UIStatus.Get.inptDijkstraDestinyNode.text);

        if (startNode == null || destinyNode == null)
        {
            UIStatus.Get.SetComponentText(UIStatus.Get.lblResults, "O nó de início ou de destino não foi encontrado no conjunto de nós do cenário!");
            return;
        }

        dijkstra.ResolveDijkstra(graph.Nodes, startNode.node, destinyNode.node);

        // Show results
        UIStatus.Get.SetComponentText(
            UIStatus.Get.lblResults,
            string.Format("Dijkstra resultados: \nDistância do caminho: {0} un.\nNúmero de iterações: {1}\nNúmero de nós visitados: {2}\nTempo total de execução (ms): {3}",
            destinyNode.node.DistanceFromStartNode, dijkstra.Iterations, dijkstra.VisitedNodesQuantity, dijkstra.TimeToFinishTheSearch)
        );
                    
        ShowMainPath();
    }

    public void Update()
    {
        if (execute)
        {
            executeMode();
        }
    }

    #region Auxiliar Methods

    /// <summary>
    /// Call resolve dijkstra without showing the generated paths
    /// </summary>
    public void ExecuteWithoutShowLines()
    {
        dijkstra.ResolveDijkstra(graph.Nodes, startNode.node, destinyNode.node);
    }

    /// <summary>
    /// Call resolve dijkstra showing the generated paths
    /// </summary>
    public void ExecuteShowingLines()
    {
        dijkstra.ResolveDijkstra(graph.Nodes, startNode.node, destinyNode.node);

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

    #endregion Auxiliar Methods
}