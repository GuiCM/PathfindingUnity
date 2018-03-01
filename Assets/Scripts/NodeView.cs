using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeView : MonoBehaviour
{
    public int[] edgesIndex;
    public int[] edgesCost;

    public Node node;

    public void InitNodeEdges()
    {
        if (node != null)
        {
            for (int i = 0; i < edgesIndex.Length; i++)
            {
                node.Neighboors.Add(new KeyValuePair<int, int>(edgesIndex[i], edgesCost[i]));
            }
        }
    }
}
