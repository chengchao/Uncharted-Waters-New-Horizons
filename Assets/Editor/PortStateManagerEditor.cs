using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PortStateManager))]
public class PortStateManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var script = (PortStateManager)target;

        if (GUILayout.Button("Enter Building"))
        {
            script.EnterBuilding();
        }

        if (GUILayout.Button("Leave Building"))
        {
            Debug.Log("leave building button pressed");
            script.LeaveBuilding();
        }
    }
}
