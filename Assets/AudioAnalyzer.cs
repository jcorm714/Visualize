using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioAnalyzer : MonoBehaviour
{
    // Start is called before the first frame update
    private float[] spectrum;
    public int channel;
    public bool debug;
    private Renderer renderer;
    void Start()
    {
        //has to be a power of two for the buffer
        //larger sizes will be more accurate, but
        //causes way more time to work on them
        spectrum = new float[512];
        renderer = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    private void FixedUpdate()
    {
        AudioListener.GetOutputData(spectrum, channel);

        if (debug)
        {
            for (int i = 1; i < spectrum.Length - 1; i++)
            {
                Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
                Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
                Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
                Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
            }
        }

        int count = 0;
        float avg = 0;
        for (; count < spectrum.Length; count++)
        {
            avg += Mathf.Log(Mathf.Abs(spectrum[count]), 15);
        }
        float scale = Mathf.Abs(avg);
        this.transform.localScale = new Vector3(avg, avg, -2);

        float red = (255 % scale) * 2;
        float green = (128 % scale) * 2;
        float blue = (152 % scale) * 2;
        this.renderer.material.SetColor("_color", new Color(red, green, blue));
    }

}
