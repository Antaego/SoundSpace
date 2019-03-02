using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{

    private bool selected = false;
    private Material mat;
    public Color sel;
    public Color desel;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mat.color = desel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Selected()
    {
        selected = true;
        mat.color = sel;

    }

    public void Deselected()
    {
        selected = false;
        mat.color = desel;
    }
}
