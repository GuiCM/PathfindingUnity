using System.Collections.Generic;
using UnityEngine;

public class DijkstraPlacer : MonoBehaviour
{
    /// <summary>
    /// An instance of <see cref="GraphView"/> class.
    /// </summary>
    public GraphView graphView;

    /// <summary>
    /// The TestDijkstra prefab
    /// </summary>
    public GameObject testDijkstra;

    /// <summary>
    /// The lineDrawer prefab
    /// </summary>
    public GameObject lineDrawer;

    /// <summary>
    /// The game object used as container to store all the TestDijkstra objects
    /// </summary>
    public GameObject parentDijkstra;

    /// <summary>
    /// The game object used as container to store all the line drawer objects
    /// </summary>
    public GameObject parentLineDrawers;

    /// <summary>
    /// The game object used as container to store all the line renderer objects
    /// </summary>
    public GameObject parentLineRenderer;

    /// <summary>
    /// The game object used as container to store all A Star the line renderer objects
    /// </summary>
    public GameObject parentAStarLineRenderer;

    /// <summary>
    /// Reference to frame capture utility
    /// </summary>
    public FrameCapture frameCapture;

    /// <summary>
    /// Store the dijkstra agents
    /// </summary>
    private List<TestDijkstra> agents;

    private void Awake()
    {
        agents = new List<TestDijkstra>();
    }

    /// <summary>
    /// Create the dijkstra agents
    /// </summary>
    public void CreateAgents()
    {
        for (int i = 0; i < AgentUtility.agentCount; i++)
        {
            GameObject testDijkstraInstance = Instantiate(testDijkstra, parentDijkstra.transform);
            GameObject lineDrawerInstance = Instantiate(lineDrawer, parentLineDrawers.transform);

            TestDijkstra testDijkstraScript = testDijkstraInstance.GetComponent<TestDijkstra>();
            testDijkstraScript.lineDrawer = lineDrawerInstance.GetComponent<LineDrawer>();
            testDijkstraScript.lineDrawer.SetLineRendererParent(parentLineRenderer);

            testDijkstraScript.graphView = this.graphView;

            testDijkstraScript.startNode = graphView.NodeViewCollection[graphView.startNodesIndex[i]];
            testDijkstraScript.destinyNode = graphView.NodeViewCollection[graphView.destinyNodesIndex[i]];

            agents.Add(testDijkstraScript);
        }
    }

    /// <summary>
    /// Enable all the dijkstra agents present on the scene to find the paths
    /// </summary>
    public void InvokeAllAgents()
    {
        frameCapture.dijkstraAgents = agents;
        GeneralUtility.Get.ClearLineRenderers();

        if (UIStatus.Get.ShowMainPathChecked())
        {
            foreach (TestDijkstra agent in agents)
            {
                agent.executeMode = agent.ExecuteShowingLines;
            }
        }
        else
        {
            foreach (TestDijkstra agent in agents)
            {                
                agent.executeMode = agent.ExecuteWithoutShowLines;
            }
        }

        foreach (TestDijkstra agent in agents)
        {
            agent.execute = true;
        }

        frameCapture.Capture("Dijkstra");
    }

    /// <summary>
    /// Destroy all the dijsktra agents present on the scene
    /// </summary>
    public void ResetAgents()
    {
        foreach (TestDijkstra agent in agents)
        {
            agent.lineDrawer.Destroy();
            Destroy(agent.gameObject);
        }

        agents.Clear();
    }
}