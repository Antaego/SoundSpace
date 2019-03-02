using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNode : MonoBehaviour
{
    private AudioSource sounds;
    private Material mat;
    public Color act;
    public Color deact;
    public Color sel;
    private bool selected;
    // Start is called before the first frame update
    void Start()
    {

        sounds = GetComponent<AudioSource>();
        mat = GetComponent<Renderer>().material;
        mat.color = deact;
    }

    // Update is called once per frame
    void Update()
    {

    }



    public IEnumerator Colorize()
    {
        mat.color = act;
        yield return new WaitForSeconds(0.1f);
        mat.color = deact;

    }


    public void SetClip(AudioClip clip)
    {
        sounds.clip = clip;
    }

    public void Selected()
    {
        selected = true;
        if (sounds.clip != null)
        {
            sounds.Play();
        }
        mat.color = sel;

    }

    public void Deselected()
    {
        selected = false;
        mat.color = deact;
    }

    public void Activated()
    {
        if (sounds.clip != null)
        {
            if (!selected)
            {
                StartCoroutine("Colorize", 0);
            }
            sounds.Play();
            
        }
    }

    public void OnMouseOver()
    {
        
    }

}
