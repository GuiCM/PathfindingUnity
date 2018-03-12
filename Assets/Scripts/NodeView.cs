using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeView : MonoBehaviour
{
    public int[] destinyNodeIndex;
    public int[] edgesCost;

    public Node node;

    public int nodeIndex;

    public void InitNodeEdges()
    {
        nodeIndex = int.Parse(gameObject.name.Remove(0, 1));

        if (node != null)
        {
            for (int i = 0; i < destinyNodeIndex.Length; i++)
            {
                node.Neighboors.Add(new KeyValuePair<int, int>(destinyNodeIndex[i], edgesCost[i]));
            }
        }
    }
}
