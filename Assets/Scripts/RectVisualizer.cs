using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class RectVisualizer : Visualizer
{
    [Range(0, 1)]
    public float spacing;
    [Range(1, 10)]
    public float sliderSpeed;
    
    public float sliderBaseScale;
    public float sliderMaxScale;

    public void Start()
    {
     
        
        //float totatSpaceUsed = numberOfSliders * spacing;
        //float x = (Screen.width / 2) - (totatSpaceUsed / 2);
        //float y = Screen.height / 2;
        //float z = 0;
        //this.transform.position = new Vector3(x, y, z);
        
    
    }
    public override void generate_sliders()
    {
        Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        float totatSpaceUsed = numberOfSliders * spacing;
        float startX = cam.WorldToScreenPoint(this.transform.position).x - totatSpaceUsed;
        for (int i = 0; i < numberOfSliders; i++)
        {   
           
            Vector3 newPosition = new Vector3();
            newPosition.x = -startX + spacing * i + this.transform.position.x; 
            newPosition.y = this.transform.position.y;
            newPosition.z = 1;

            Vector3 rotation = new Vector3(0, 0, 90);
            var s = Instantiate(slider, newPosition, Quaternion.Euler(rotation));
            s.name = "Slider: " + i;
            s.transform.localScale = new Vector3(10, 10, 1);
            s.GetComponent<ExtendBehavior>().speed = sliderSpeed;
            s.GetComponent<ExtendBehavior>().baseScale = sliderBaseScale;
            s.GetComponent<ExtendBehavior>().MaxScale = sliderMaxScale;
            s.GetComponent<ExtendBehavior>().pitchBias = curve.Evaluate(i);

            sliders[i] = s;
            
        }
    }

    public override void mutate_sliders()
    {
        AudioData.FillSamples(AudioData.buffer, 0);
        for(int i = 0; i < AudioData.buffer.Length; i++)
        {

            int idx = i;
            float bias = AudioData.buffer[i] * 100;

            //sliders[idx].GetComponent<ExtendBehavior>().pitchBias = Mathf.Abs(pitchBias);
    
            sliders[idx].GetComponent<ExtendBehavior>().updateScaleFromAudio(bias * 100);

        }
    }

    public override void update_sliders()
    {
        for(int i = 0; i < sliders.Length; i++)
        {
            Vector3 newPosition = new Vector3();
            newPosition.x = this.transform.position.x * 2;
            newPosition.y = this.transform.position.y + spacing * i;
            newPosition.z = 1;
            sliders[i].transform.position = newPosition;
            sliders[i].GetComponent<ExtendBehavior>().speed = sliderSpeed;
            sliders[i].GetComponent<ExtendBehavior>().baseScale = sliderBaseScale;
            sliders[i].GetComponent<ExtendBehavior>().MaxScale = sliderMaxScale;
            sliders[i].GetComponent<ExtendBehavior>().pitchBias = curve.Evaluate(i);
        }
    }
}
