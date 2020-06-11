using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fener : MonoBehaviour
{
    public AudioSource audioSource1, audioSource2;
    bool fenerDurumu;
    public Light light2;
    // Start is called before the first frame update
    void Start()
    {
        fenerDurumu = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fenerDurumu = !fenerDurumu;
            light2.enabled = fenerDurumu;
            if (light2.enabled)
            {
                audioSource1.Play();
            }else if (!light2.enabled)
            {
                audioSource2.Play();
            }

        }
        
    }
}
