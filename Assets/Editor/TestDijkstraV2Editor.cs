using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TestDijkstra))]
public class TestDijkstraV2Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TestDijkstra testDijkstraV2 = (TestDijkstra)target;

        GUILayout.Space(10);
        if (GUILayout.Button("Calcular Dijkstra (V2)"))
        {
            testDijkstraV2.CallDijkstra();
        }
    }
}