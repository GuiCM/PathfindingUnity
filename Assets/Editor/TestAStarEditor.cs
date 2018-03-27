using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TestAStar))]
public class TestAStarEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TestAStar testAStar = (TestAStar)target;

        GUILayout.Space(10);
        if (GUILayout.Button("Calcular A*"))
        {
            testAStar.CallTestAStar();
        }
    }
}