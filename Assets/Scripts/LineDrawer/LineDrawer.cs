using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to draw lines in the scene
/// </summary>
public class LineDrawer : MonoBehaviour {

    /// <summary>
    /// The prefab of the line object.
    /// </summary>
    [SerializeField]
    private GameObject linePrefab;

    /// <summary>
    /// An instance of <see cref="GraphView"/> class.
    /// </summary>
    [SerializeField]
    private GraphView graphView;

    private void Start()
    {
        if (graphView == null)
            Debug.LogWarning("GraphView object not attached to the LineDrawer!");
    }

    /// <summary>
    /// Draw a line between all the given nodes position to mark the way.
    /// </summary>
    /// <param name="path">A list of the nodes index.</param>
    public void DrawPath(List<int> path)
    {        
        NodeView[] nodeViewCollection = graphView.NodeViewCollection;

        GameObject line = CreateLine();
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = path.Count;

        for (int i = 0; i < path.Count; i++)
        {
            // Find the node to get the position
            for (int j = 0; j < nodeViewCollection.Length; j++)
            {
                if (nodeViewCollection[j].nodeIndex.Equals(path[i]))
                {
                    NodeView node = nodeViewCollection[j];
                    lineRenderer.SetPosition(i, new Vector3(node.transform.position.x, 0.5f, node.transform.position.z));
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Draw a line between all the given nodes position to mark the way.
    /// </summary>
    /// <param name="path">A list of nodes.</param>
    public void DrawPath(List<Node> nodes)
    {
        GameObject line = CreateLine();
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = nodes.Count;

        for (int i = 0; i < nodes.Count; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(nodes[i].ViewTransform.position.x, nodes[i].ViewTransform.position.y, nodes[i].ViewTransform.transform.position.z));
        }
    }

    /// <summary>
    /// Try to find for the line game object on the scene, if not found, create one.
    /// </summary>
    /// <returns>A line object</returns>
    private GameObject CreateLine()
    {       
        LineRenderer line = GameObject.FindObjectOfType<LineRenderer>();
        if (line != null)
            return line.gameObject;

        return Instantiate(linePrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
