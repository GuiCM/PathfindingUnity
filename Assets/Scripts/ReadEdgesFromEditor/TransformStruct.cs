using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TransformStruct : MonoBehaviour
{
    [SerializeField]
    public Transform fromNode;
    public Transform toNode;

    public TransformStruct[] edges = new TransformStruct[10];
}
