using System.Collections.Generic;
using UnityEngine;

public class TestDijkstra : MonoBehaviour
{
    [SerializeField]
    private GraphView graphView;

    [SerializeField]
    private LineDrawer lineDrawer;

    [SerializeField]
    private NodeView startNode;

    [SerializeField]
    private NodeView destinyNode;

    private Graph graph;

    private Dijkstra dijkstra;

    private bool dijkstraDiagnostic = false;
    private float timeToRecord = 10f;
    private float timeRecording = 0f;
    private int fpsCount = 0;

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

    public void CallDijkstra()
    {
        if (startNode == null || destinyNode == null)
        {
            Debug.LogWarning("É necessário atribuir um nó de início e um nó de destino para realizar a busca!");
            return;
        }

        dijkstra.ResolveDijkstra(graph.Nodes, startNode.node, destinyNode.node);

        // Results
        string report = "Distância do percurso: " + destinyNode.node.DistanceFromStartNode +
            "\tNúmero de iterações: " + dijkstra.Iterations +
            "\tNúmero de nós visitados: " + dijkstra.VisitedNodesQuantity +
            "\tTempo total de execução (ms): " + dijkstra.TimeToFinishTheSearchMs +
            "\tTempo total de execução (s): " + dijkstra.TimeToFinishTheSearchS;
        print(report);

        ShowMainPath();

        dijkstraDiagnostic = true;
    }

    public void Update()
    {
        if (dijkstraDiagnostic)
        {
            timeRecording += Time.deltaTime;

            if (timeRecording >= timeToRecord)
            {
                dijkstraDiagnostic = false;
                print("PARA TUDOOO! " + timeRecording);
                print("FPS: " + fpsCount);

                timeRecording = 0f;
                fpsCount = 0;

                return;
            }

            /*Profiler.BeginSample("Dijkstra Sample");

            dijkstra.ResolveDijkstra(graph.Nodes, startNode.node, destinyNode.node);

            string report = "Distância do percurso: " + destinyNode.node.DistanceFromStartNode +
                "\tNúmero de iterações: " + dijkstra.Iterations +
                "\tNúmero de nós visitados: " + dijkstra.VisitedNodesQuantity +
                "\tTempo total de execução (ms): " + dijkstra.TimeToFinishTheSearchMs +
                "\tTempo total de execução (s): " + dijkstra.TimeToFinishTheSearchS;
            print(report);

            Profiler.EndSample();*/

            fpsCount++;
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

#region Removed Methods

/*
/// <summary>
/// Create all node edges.
/// </summary>
private void MockNodeEdges()
{
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
*/

#endregion Removed Methods