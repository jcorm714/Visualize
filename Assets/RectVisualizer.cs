using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectVisualizer : Visualizer
{
    public float spacing;
    public float sliderBaseScale;
    public float sliderSpeed;
    public float sliderMaxScale;
    public override void generate_sliders()
    {
        
        for(int i = 0; i < numberOfSliders; i++)
        {
            Vector3 newPosition = new Vector3();
            newPosition.x = this.transform.position.x + spacing * i;
            newPosition.y = this.transform.position.y;
            newPosition.z = 1;

            Vector3 rotation = new Vector3(0, 0, 90);
            var s = Instantiate(slider, newPosition, Quaternion.Euler(rotation));
            s.name = "Slider: " + i;
            s.transform.localScale = new Vector3(10, 10, 1);
            s.GetComponent<ExtendBehavior>().speed = sliderSpeed;
            s.GetComponent<ExtendBehavior>().baseScale = sliderBaseScale;
            s.GetComponent<ExtendBehavior>().MaxScale = sliderMaxScale;
            s.GetComponent<ExtendBehavior>().pitchBias = 1;


            sliders[i] = s;
            
        }
    }

    public override void mutate_sliders()
    {
        AudioData.FillSamples(AudioData.buffer, 0);
        for(int i = 0; i < AudioData.buffer.Length; i++)
        {

            int idx = i;
            float pitchBias = Mathf.Log(Mathf.Abs(AudioData.buffer[i]));
            float volumeBias = AudioData.buffer[i] * 100;

            //sliders[idx].GetComponent<ExtendBehavior>().pitchBias = Mathf.Abs(pitchBias);
            float bias = volumeBias * Mathf.Abs(pitchBias);
            sliders[idx].GetComponent<ExtendBehavior>().updateScaleFromAudio(bias * 100);

        }
    }
}
