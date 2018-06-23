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

    [SerializeField]
    private GameObject textParent;

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

            GameObject textObject = Instantiate(textPrefab, textParent.transform);
            Text textComponent = textObject.GetComponent<Text>();

            textComponent.text = nodeView.name;
            textComponent.rectTransform.position = pos;

            edgesCount += nodeView.nodesToConect.Length;
        }

        UIStatus.Get.SetComponentText(UIStatus.Get.lblInformations, string.Format("Número de nós: {0}\nNúmero de arestas: {1}", graphView.NodeViewCollection.Length, edgesCount));
    }
}
