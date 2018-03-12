using UnityEngine;

public class LineDrawer : MonoBehaviour {

    [SerializeField]
    private GameObject linePrefab;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = linePrefab.GetComponent<LineRenderer>();
    }

    public void DrawLines(NodeView[] nodeViewCollection, int[] path)
    {
        lineRenderer.positionCount = path.Length;

        for (int i = 0; i < path.Length; i++)
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
}
