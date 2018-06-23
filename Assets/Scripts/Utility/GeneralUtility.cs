using UnityEngine;

public class GeneralUtility : MonoBehaviour
{
    private static GeneralUtility instance;

    public static GeneralUtility Get
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    /// <summary>
    /// The game object used as container to store all the line renderer objects
    /// </summary>
    [SerializeField]
    private GameObject parentDijkstraLineRenderer;

    /// <summary>
    /// The game object used as container to store all A Star the line renderer objects
    /// </summary>
    [SerializeField]
    private GameObject parentAStarLineRenderer;

    public void ClearLineRenderers()
    {
        GameObject.FindGameObjectWithTag("SingleExecution").GetComponentInChildren<LineRenderer>().positionCount = 0;

        foreach (LineRenderer lineRenderer in parentDijkstraLineRenderer.GetComponentsInChildren<LineRenderer>())
        {
            lineRenderer.positionCount = 0;
        }

        foreach (LineRenderer lineRenderer in parentAStarLineRenderer.GetComponentsInChildren<LineRenderer>())
        {
            lineRenderer.positionCount = 0;
        }
    }
}