using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioData : MonoBehaviour
{

    //By default the buffer is set to a size of 2048
    //This can be changed by accessing the audio settings Object;
    public static float[] buffer = new float[2048];
    public int channels = 1;


    public void FillSamples(float[] samples, int channel)
    {
        AudioListener.GetSpectrumData(samples, channel, FFTWindow.Blackman);
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        buffer = data;
     
    }
}
