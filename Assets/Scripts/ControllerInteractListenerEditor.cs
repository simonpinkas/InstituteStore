using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ControllerInteractListener))]
public class ControllerInteractListenerEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ControllerInteractListener myScript = (ControllerInteractListener)target;

        if (GUILayout.Button("PickUp"))
        {
        }
        
        if (GUILayout.Button("LetGo"))
        {
        }
    }
}