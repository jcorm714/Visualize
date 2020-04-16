using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxScale;
    public float speed;
    public float pitchBias;
    public float baseScale;
    private Vector3 scale;
    private Rigidbody2D body;
    private bool fading;
    private bool triggered;
    //used to check if the slider is animating 
    public void test()
    {
        Vector3 currScale = this.transform.localScale;
        if(currScale.x >= this.MaxScale)
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

    public void updateScaleFromAudio(float bias)
    {
        Vector3 currScale = this.transform.localScale;
        Vector3 newScale = new Vector3();

        float calc = bias * pitchBias;
        if (calc >= this.MaxScale)
        {
            newScale.x = MaxScale;
        } else if (calc <= this.baseScale)
        {
          
            newScale.x = baseScale;
        }
        else
        {
            newScale.x = calc;
        }
        
        newScale.z = currScale.z;
        newScale.y = currScale.y;
        this.transform.localScale = newScale;
    }

    public void reset()
    {
        Vector3 currScale = this.transform.localScale;
        Vector3 newScale = new Vector3();
        if (currScale.x - speed * Time.deltaTime <= baseScale)
        {
            newScale.x = baseScale;
        }
        else
        {
            newScale.x = currScale.x - speed * Time.deltaTime;
        }
        
        newScale.z = currScale.z;
        newScale.y = currScale.y;
        this.transform.localScale = newScale;

    }
    // Update is called once per frame
    void Update()
    {
        reset();
    }
}
