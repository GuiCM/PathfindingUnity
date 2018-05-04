using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NodeNamer))]
public class UtilityNamerEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        NodeNamer nodeNamer = (NodeNamer)target;
        GUILayout.Space(10);
        if (GUILayout.Button("Nomear nós"))
        {
            nodeNamer.NameAllNodes();
        }
    }
}
