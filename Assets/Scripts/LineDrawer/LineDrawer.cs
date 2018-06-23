using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to draw lines in the scene
/// </summary>
public class LineDrawer : MonoBehaviour
{
    public LineRenderer LineRenderer
    {
        get
        {
            return lineRenderer;
        }
    }
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

    /// <summary>
    /// A reference to a line renderer
    /// </summary>
    private LineRenderer lineRenderer;

    private void Awake()
    {
        graphView = GameObject.FindObjectOfType<GraphView>();
        if (graphView == null)
            Debug.LogWarning("GraphView object not attached to the LineDrawer!");

        lineRenderer = Instantiate(linePrefab, GameObject.Find("SingleExecution").transform).GetComponent<LineRenderer>();
    }

    /// <summary>
    /// Set the line renderer's parent
    /// </summary>
    /// <param name="parent">The parent object</param>
    public void SetLineRendererParent(GameObject parent)
    {
        lineRenderer.transform.parent = parent.transform;
    }
    
    /// <summary>
    /// Draw a line between all the given nodes position to mark the way.
    /// </summary>
    /// <param name="path">A list of nodes.</param>
    public void DrawPath(List<Node> nodes)
    {
        lineRenderer.positionCount = nodes.Count;

        for (int i = 0; i < nodes.Count; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(nodes[i].ViewTransform.position.x, nodes[i].ViewTransform.position.y, nodes[i].ViewTransform.transform.position.z));
        }
    }

    /// <summary>
    /// Destroy the line renderer component and itself
    /// </summary>
    public void Destroy()
    {
        Destroy(lineRenderer.gameObject);
        Destroy(this.gameObject);
    }
}