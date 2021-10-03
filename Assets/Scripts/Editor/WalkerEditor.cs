using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Walker))]
public class WalkerEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if (GUILayout.Button("Manual upate")) {
            Walker walker = target as Walker;
            walker.UpdatePosition();
        }
    }
}
