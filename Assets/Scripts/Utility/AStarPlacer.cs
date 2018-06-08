using System.Collections.Generic;
using UnityEngine;

public class AStarPlacer : MonoBehaviour
{
    /// <summary>
    /// An instance of <see cref="GraphView"/> class.
    /// </summary>
    public GraphView graphView;

    /// <summary>
    /// The TestDijkstra prefab
    /// </summary>
    public GameObject testAstar;

    /// <summary>
    /// The lineDrawer prefab
    /// </summary>
    public GameObject lineDrawer;

    /// <summary>
    /// The game object used as container to store all the A Star objects
    /// </summary>
    public GameObject parentAstar;

    /// <summary>
    /// The game object used as container to store all the line drawer objects
    /// </summary>
    public GameObject parentLineDrawers;

    /// <summary>
    /// The game object used as container to store all the line renderer objects
    /// </summary>
    public GameObject parentLineRenderer;

    /// <summary>
    /// Reference to frame capture utility
    /// </summary>
    public FrameCapture frameCapture;

    /// <summary>
    /// Store the A Star agents
    /// </summary>
    private List<TestAStar> agents;

    private void Awake()
    {
        agents = new List<TestAStar>();
    }

    /// <summary>
    /// Create the A Star agents
    /// </summary>
    public void CreateAgents()
    {
        for (int i = 0; i < AgentUtility.agentCount; i++)
        {
            GameObject testAstarInstance = Instantiate(testAstar, parentAstar.transform);
            GameObject lineDrawerInstance = Instantiate(lineDrawer, parentLineDrawers.transform);

            TestAStar testAstarScript = testAstarInstance.GetComponent<TestAStar>();
            testAstarScript.lineDrawer = lineDrawerInstance.GetComponent<LineDrawer>();
            testAstarScript.lineDrawer.SetLineRendererParent(parentLineRenderer);

            testAstarScript.graphView = this.graphView;

            testAstarScript.startNode = graphView.NodeViewCollection[graphView.startNodesIndex[i]];
            testAstarScript.destinyNode = graphView.NodeViewCollection[graphView.destinyNodesIndex[i]];

            agents.Add(testAstarScript);
        }
    }

    /// <summary>
    /// Enable all the A Star agents present on the scene to find the paths
    /// </summary>
    public void InvokeAllAgents()
    {
        frameCapture.aStarAgents = agents;

        foreach (TestAStar agent in agents)
        {
            agent.execute = !agent.execute;
        }

        frameCapture.Capture("A*");
    }

    /// <summary>
    /// Destroy all the A Star agents present on the scene
    /// </summary>
    public void ResetAgents()
    {
        foreach (TestAStar agent in agents)
        {
            agent.lineDrawer.Destroy();
            Destroy(agent.gameObject);
        }

        agents.Clear();
    }
}