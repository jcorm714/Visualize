using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectVisualizer : Visualizer
{
    public float spacing;
    public float sizeBias;
    public float sliderSpeed;
    public override void generate_sliders()
    {
        
        for(int i = 0; i < numberOfSliders; i++)
        {
            Vector3 newPosition = new Vector3();
            newPosition.x = this.transform.position.x + spacing * i;
            newPosition.y = -1;
            newPosition.z = 1;

            Vector3 rotation = new Vector3(0, 0, 90);
            var s = Instantiate(slider, newPosition, Quaternion.Euler(rotation));
            s.GetComponent<ExtendBehavior>().speed = sliderSpeed;
            sliders[i] = s;
            
        }
    }

    public override void mutate_sliders()
    {
        for(int i = 0; i < AudioData.buffer.Length; i++)
        {
            int idx = i % numberOfSliders;
            sliders[idx].GetComponent<ExtendBehavior>().updateScaleFromAudio(AudioData.buffer[i] * sizeBias);

        }
    }
}
