﻿using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class NodesUIEditMode : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private GameObject textPrefab;

    public void DrawNodesIndex()
    {
        NodeView[] nodeViewCollection = GameObject.FindObjectsOfType<NodeView>();

        int edgesCount = 0;

        foreach (NodeView nodeView in nodeViewCollection)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(nodeView.transform.position);
            pos.y += 25;

            GameObject textObject = Instantiate(textPrefab, canvas.transform);
            Text textComponent = textObject.GetComponent<Text>();

            textComponent.text = nodeView.name;
            textComponent.rectTransform.position = pos;

            edgesCount += nodeView.nodesToConect.Length;
        }

        print("Número de nós: " + nodeViewCollection.Length + "\t\tNúmero de arestas: " + edgesCount);
    }
}
