using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphView : MonoBehaviour
{
    private NodeView[] nodeViewCollection;
    private Graph graph = new Graph();

    void Start()
    {
        // Get all nodes from the editor mode
        nodeViewCollection = GameObject.FindObjectsOfType<NodeView>();

        InitNodes();

        PrintNodesWithEdges();
    }

    public void InitNodes()
    {
        // Initialize all the nodes data
        graph.InitNodesCollectionFromView(nodeViewCollection);
    }

    public void PrintNodesWithEdges()
    {        
        for (int i = 0; i < nodeViewCollection.Length; i++)
        {
            string text = nodeViewCollection[i].name + "; Arestas: ";

            for (int j = 0; j < nodeViewCollection[i].node.Neighboors.Count; j++)
            {
                text += "(" + nodeViewCollection[i].node.Neighboors[j].Key + "; " + nodeViewCollection[i].node.Neighboors[j].Value + ") || ";
            }

            print(text);
            print("------------------------------------------------------------");
        }                
    }
}