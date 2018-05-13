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
        int edgesCount = 0;

        foreach (NodeView nodeView in graphView.NodeViewCollection)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(nodeView.transform.position);
            pos.y += 20;

            GameObject textObject = Instantiate(textPrefab, canvas.transform);
            Text textComponent = textObject.GetComponent<Text>();

            textComponent.text = nodeView.name;
            textComponent.rectTransform.position = pos;

            edgesCount += nodeView.nodesToConect.Length;
        }

        print("Número de nós: " + graphView.NodeViewCollection.Length + "\t\tNúmero de arestas: " + edgesCount);
    }
}
