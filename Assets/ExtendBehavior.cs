using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public int length;
    public float speed;
    private Vector3 scale;
    private Rigidbody2D body;
    private bool fading;
    private bool triggered;
    //used to check if the slider is animating properly
    public void test()
    {
        Vector3 currScale = this.transform.localScale;
        if(currScale.x >= this.length)
        {
            
            fading = true;
        }

        if(currScale.x <= scale.x)
        {
            fading = false;
            //triggered = false;
        }
        if (triggered)
        {
            float sign = (fading) ? -1f : 1f;
            //print(sign);
            update_scale(sign);
        }

        
    }


    void update_scale(float sign)
    {
        
        Vector3 currScale = this.transform.localScale;
        Vector3 newScale = new Vector3();
        newScale.x = currScale.x + (speed * sign);
        newScale.z = currScale.z;
        newScale.y = currScale.y;
        this.transform.localScale = newScale;
    }


    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        scale = this.transform.position;
        fading = false;
        triggered = true;

    }

    // Update is called once per frame
    void Update()
    {
        test();
    }
}
