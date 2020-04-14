using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioAnalyzer : MonoBehaviour
{
    // Start is called before the first frame update
    public static float[] spectrum = new float[2048];
    public int channel;
    public bool debug;

    void Start()
    {
        //has to be a power of two for the buffer
        //larger sizes will be more accurate, but
        //causes way more time to work on them
 
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    private void FixedUpdate()
    {
        spectrum = AudioData.buffer;
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

        //int count = 0;
        //float avg = 0;
        
        //for (; count < spectrum.Length; count++)
        //{
            
        //    avg += Mathf.Log(Mathf.Abs(spectrum[count]), 3);
        //}
        //avg = avg / count;
        
        //float bias = Mathf.Abs(avg) * 8;
        //print(bias);
        //this.transform.localScale = new Vector3(bias, bias, -2);
    }



}
