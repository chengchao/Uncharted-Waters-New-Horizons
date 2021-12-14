using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterMovementController))]
public class CharacterMovementControllerEditor : Editor
{
  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();

    var script = (CharacterMovementController)target;

    if (GUILayout.Button("Move Up"))
    {
      script.Move(Vector3Int.up);
    }

    if (GUILayout.Button("Move Down"))
    {
      script.Move(Vector3Int.down);
    }

    if (GUILayout.Button("Move Left"))
    {
      script.Move(Vector3Int.left);
    }

    if (GUILayout.Button("Move Right"))
    {
      script.Move(Vector3Int.right);
    }
  }
}
