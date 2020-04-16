using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Visualizer : MonoBehaviour
{
    protected int numberOfSliders;
    public GameObject slider;
    //sliders to spread out in a circle position;
    protected GameObject[] sliders;
    // Start is called before the first frame update
    public abstract void generate_sliders();
    public abstract void mutate_sliders();
    void Start()
    {
        numberOfSliders = AudioData.buffer.Length;
        sliders = new GameObject[numberOfSliders];
        generate_sliders();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        mutate_sliders();
    }


}
