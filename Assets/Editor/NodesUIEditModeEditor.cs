using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NodesUIEditMode))]
public class NodesUIEditModeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        NodesUIEditMode nodesUIEditMode = (NodesUIEditMode)target;

        GUILayout.Space(10);
        if (GUILayout.Button("Mostrar nome dos nós"))
        {
            nodesUIEditMode.DrawNodesIndex();
        }
    }
}