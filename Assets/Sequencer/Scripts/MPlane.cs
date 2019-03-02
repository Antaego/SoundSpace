using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlane : MonoBehaviour
{
    
    
    public Transform endpos;
    public Transform beat_step;
    public float bpm;
    //initial position
    private Vector3 ipos;
    //length of each beat step
    private float step_len;
    //beats per second
    private float bps;
    //the change in xpos
    private float dz;
    //maximum z value
    private float z_max;
    // Start is called before the first frame update
    Vector3 dir;
    public bool activated = false;

    void Start()
    {


        print("step_len " + step_len);
        print("x_max " + z_max);
        print("bps " + bps);
        print("dx " + dz);
    }

    // Update is called once per frame
    void Update()
    {
       if (activated)
        {
            transform.Translate(0, dz * Time.deltaTime, 0);
            if (transform.localPosition.z >= z_max)
            {
                transform.localPosition = ipos;
            }
        }

    }

    public void Init()
    {
        ipos = transform.localPosition;


        //get a vector that points towards the end transform
        //dir = endpos - ipos;
        z_max = endpos.localPosition.z;
        //get the distance between nodes
        step_len = beat_step.localPosition.z - transform.localPosition.z;
        bps = bpm / 60 * transform.parent.localScale.x;
        dz = bps * step_len;
        activated = true;
    }




}
