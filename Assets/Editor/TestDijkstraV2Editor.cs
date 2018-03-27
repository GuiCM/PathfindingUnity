using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TestDijkstraV2))]
public class TestDijkstraV2Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TestDijkstraV2 testDijkstraV2 = (TestDijkstraV2)target;

        GUILayout.Space(10);
        if (GUILayout.Button("Calcular Dijkstra (V2)"))
        {
            testDijkstraV2.CallDijkstraV2();
        }
    }
}