using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectVisualizer : Visualizer
{
    public float spacing;
    public override void generate_sliders()
    {
        for(int i = 0; i < numberOfSliders; i++)
        {
            Vector3 newPosition = new Vector3();
            newPosition.x = -4 + spacing * i;
            newPosition.y = -1;
            newPosition.z = 1;

            Vector3 rotation = new Vector3(0, 0, 90);
            Instantiate(slider, newPosition, Quaternion.Euler(rotation));
            
        }
    }

}
