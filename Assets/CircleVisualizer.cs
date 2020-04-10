using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleVisualizer : Visualizer
{

    public int radius;
    //angle between each slider
    public override void generate_sliders()
    {
        //divide the circle into equal portions 
        //then convert the angle into degrees
        float angle = ((2 * Mathf.PI) / numberOfSliders) * 180 / Mathf.PI;
        for (int i = 0; i < numberOfSliders; i++)
        {
            float currentAngle = angle * i;

            Vector3 sliderPos = new Vector3();
            sliderPos.z = 1;
            sliderPos.x = Mathf.Cos(currentAngle) * radius;
            sliderPos.y = Mathf.Sin(currentAngle) * radius;
            Vector3 sliderRot = new Vector3(0, 0, Mathf.Abs(currentAngle));

            var instance = Instantiate(slider, sliderPos, Quaternion.Euler(sliderRot));


            sliders[i] = instance;

        }
    }
}
