using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DijkstraPlacer))]
public class AStarPlacerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DijkstraPlacer dijkstraPlacer = (DijkstraPlacer)target;
        GUILayout.Space(10);
        if (GUILayout.Button("Invocar agentes"))
        {
            dijkstraPlacer.InvokeAllAgents();
        }
    }
}