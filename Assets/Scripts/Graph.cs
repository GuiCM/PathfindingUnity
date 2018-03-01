using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    public Node[] nodeCollection;

    public void InitNodesCollectionFromView(NodeView[] nodeViewCollection)
    {
        nodeCollection = new Node[nodeViewCollection.Length];

        for (int i = 0; i < nodeViewCollection.Length; i++)
        {
            nodeCollection[i] = new Node(i);
            nodeViewCollection[i].node = nodeCollection[i];

            //Just to change the node name in the view
            nodeViewCollection[i].name = "N" + i;
            nodeViewCollection[i].InitNodeEdges();
        }
    }
}
