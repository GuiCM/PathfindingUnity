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
    /// Initializes a new array of Node and fill with the basic informations.
    /// </summary>
    /// <param name="nodeViewCollection">The collection of visual nodes from the editor.</param>
    public void InitializeNodesCollectionFromView(NodeView[] nodeViewCollection, bool useUnityDistances)
    {
        nodeCollection = new Node[nodeViewCollection.Length];

        // Initializes all the nodes
        for (int i = 0; i < nodeViewCollection.Length; i++)
        {
            nodeCollection[i] = new Node(nodeViewCollection[i].transform);

            nodeViewCollection[i].node = nodeCollection[i];
        }

        // Initializes all the nodes edges (this process needs to be done after all the nodes be 
        // already initialized)
        if (useUnityDistances)
        {
            for (int i = 0; i < nodeViewCollection.Length; i++)
            {
                nodeViewCollection[i].InitializeNodeEdgesWithUnityDistances();
            }
        }
        else
        {        
            for (int i = 0; i < nodeViewCollection.Length; i++)
            {
                nodeViewCollection[i].InitializeNodeEdges();
            }
        }
    }
}