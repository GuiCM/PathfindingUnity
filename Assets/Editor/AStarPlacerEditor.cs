using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AStarPlacer))]
public class DijkstraPlacerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AStarPlacer aStarPlacer = (AStarPlacer)target;
        GUILayout.Space(10);
        if (GUILayout.Button("Invocar agentes"))
        {
            aStarPlacer.InvokeAllAgents();
        }
    }
}