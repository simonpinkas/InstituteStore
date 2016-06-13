using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(IntervalRendererActivator))]
public class IntervalRendererActivatorEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        IntervalRendererActivator myScript = (IntervalRendererActivator)target;
        if (GUILayout.Button("ActivateTargets"))
        {
            myScript.IntervalActivateTargets();
        }

        if (GUILayout.Button("DeactivateTargets"))
        {
            myScript.IntervalDeactivateTargets();
        }

    }

}
