using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TransformStruct))]
public class EdgeCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TransformStruct transformStruct = (TransformStruct)target;

        GUILayout.Space(100);

        transformStruct.edges[0].fromNode = (Transform)EditorGUILayout.ObjectField("Label:", transformStruct.edges[0].fromNode, typeof(Transform), true, GUILayout.ExpandWidth(false));
        transformStruct.toNode = (Transform)EditorGUILayout.ObjectField("Label:", transformStruct.toNode, typeof(Transform), true, GUILayout.ExpandWidth(false));
    }
}
