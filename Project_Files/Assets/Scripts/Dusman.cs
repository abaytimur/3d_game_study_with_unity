using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : MonoBehaviour
{
    Transform oyuncuYeri;
    AudioSource au;
    public Animator anim;
    public float dusmanIlerlemeHizi;
    bool olu;

    // Start is called before the first frame update
    void Start()
    {
        if (olu)
        {
            return;
        }

        SetKinematic(true);
        au = GetComponent<AudioSource>();
        gameObject.tag = "Dusman";
        oyuncuYeri = GameObject.Find("Duz_adam").transform;
        olu = false;
    }

    void SetKinematic(bool newValue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in bodies)
        {
            rb.isKinematic = newValue;
            rb.gameObject.tag = "Parca";
        }
    }

    public void Die()
    {
        GetComponent<Animator>().enabled = false;
        au.Play();
        SetKinematic(false);
        dusmanIlerlemeHizi = 0f;
        olu = true;
        Destroy(gameObject, 15);

        /*
            other.gameObject.SetActive(false);
            other.gameObject.transform.Translate(0f, 7f, 0f);   
            other.gameObject.SetActive(true);
         */
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((oyuncuYeri.position - transform.position ).normalized * dusmanIlerlemeHizi);
        transform.LookAt(oyuncuYeri);

        transform.Rotate(0, -90f, 0);

    }

    
}
