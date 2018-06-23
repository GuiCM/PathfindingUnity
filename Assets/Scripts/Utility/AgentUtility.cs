using UnityEngine;
using UnityEngine.UI;

public class AgentUtility : MonoBehaviour
{
    /// <summary>
    /// The current number of agents for each algorithm
    /// </summary>
    public static int agentCount;

    [SerializeField]
    private GraphView graphView;

    /// <summary>
    /// Utility class to instantiate and handle the A Star agents
    /// </summary>
    [SerializeField]
    private AStarPlacer aStarPlacer;

    /// <summary>
    /// Utility class to instantiate and handle the Dijkstra agents
    /// </summary>
    [SerializeField]
    private DijkstraPlacer dijkstraPlacer;

    /// <summary>
    /// The interface's agent number input
    /// </summary>
    [SerializeField]
    private InputField inputAgentsNumber;

    public void Start()
    {
        agentCount = 100;

        CreatePaths();

        dijkstraPlacer.CreateAgents();
        aStarPlacer.CreateAgents();
    }

    /// <summary>
    /// Create random start and destiny nodes to be used by the A Star and Dijkstra algorithms
    /// </summary>
    public void CreatePaths()
    {
        graphView.startNodesIndex.Clear();
        graphView.destinyNodesIndex.Clear();

        for (int i = 0; i < agentCount; i++)
        {
            int startNodeIndex = Random.Range(0, graphView.NodeViewCollection.Length);
            int destinyNodeIndex = Random.Range(0, graphView.NodeViewCollection.Length);

            graphView.startNodesIndex.Add(startNodeIndex);
            graphView.destinyNodesIndex.Add(destinyNodeIndex);
        }
    }

    /// <summary>
    /// Used by the interface to set the agent count
    /// </summary>
    public void SetAgentNumber()
    {
        agentCount = string.IsNullOrEmpty(inputAgentsNumber.text) ? 100 : int.Parse(inputAgentsNumber.text);

        dijkstraPlacer.ResetAgents();
        aStarPlacer.ResetAgents();

        CreatePaths();

        dijkstraPlacer.CreateAgents();
        aStarPlacer.CreateAgents();

        inputAgentsNumber.text = string.Empty;
    }
}