using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatCollider : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        MusicNode n = (MusicNode)transform.parent.GetComponent("MusicNode");
        n.Activated();
    }


}
