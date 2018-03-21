using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TestDefaultDijkstra))]
public class TestDefaultDijkstraEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TestDefaultDijkstra testDefaultDijkstra = (TestDefaultDijkstra)target;

        GUILayout.Space(10);
        if (GUILayout.Button("Calcular Dijkstra (Implementação padrão)"))
        {
            testDefaultDijkstra.CallDefaultDijkstra();
        }       
    }
}
