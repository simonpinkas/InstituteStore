using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(RendererEnabler))]
public class RendererEnablerEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RendererEnabler myScript = (RendererEnabler)target;
        if (GUILayout.Button("Enable Targets [For Testing]"))
        {
            myScript.IntervalEnableTargets();
        }

        if (GUILayout.Button("Disable Targets [For Testing]"))
        {
            myScript.IntervalDisableTargets();
        }

    }

}
