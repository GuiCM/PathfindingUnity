using UnityEngine;
using UnityEngine.UI;

public class NodesUI : MonoBehaviour
{
    [SerializeField]
    private GraphView graphView;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private GameObject textPrefab;

    private void Start()
    {
        DrawNodesIndex();
    }

    private void DrawNodesIndex()
    {
        foreach (NodeView nodeView in graphView.NodeViewCollection)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(nodeView.transform.position);
            pos.y += 25;

            GameObject textObject = Instantiate(textPrefab, canvas.transform);
            Text textComponent = textObject.GetComponent<Text>();

            textComponent.text = nodeView.name;
            textComponent.rectTransform.position = pos;
        }
    }
}
