using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PortMapManager))]
public class PortMapManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var script = (PortMapManager)target;

        if (GUILayout.Button("Save Map"))
        {
            script.SaveMap();
        }

        if (GUILayout.Button("Load Map"))
        {
            script.LoadMap();
        }

        if (GUILayout.Button("Clear Map"))
        {
            script.ClearMap();
        }


    }
}
