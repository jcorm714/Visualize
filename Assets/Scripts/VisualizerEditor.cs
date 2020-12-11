using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RectVisualizer))]
public class VisualizerEditor : Editor {

    public override void OnInspectorGUI()
    {

        if (!Application.isPlaying)
        {

            base.OnInspectorGUI();
            return;
        }



   
        Visualizer vis = (RectVisualizer)target;
        if (DrawDefaultInspector())
        {
            if (vis.autoUpdate)
            {
                vis.update_sliders();
            }
        }

        if (GUILayout.Button("Generate"))
        {
            vis.update_sliders();
        }
    }

}

