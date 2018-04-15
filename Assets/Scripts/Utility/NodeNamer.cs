using UnityEngine;

[ExecuteInEditMode]
public class NodeNamer : MonoBehaviour
{
    public void NameAllNodes()
    {
        NodeView[] nodeViewCollection = GameObject.FindObjectsOfType<NodeView>();

        for (int i = 0; i < nodeViewCollection.Length; i++)
        {
            nodeViewCollection[i].name = (i + 1).ToString();
        }
    }
}