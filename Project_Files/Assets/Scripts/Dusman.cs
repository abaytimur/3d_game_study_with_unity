using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : MonoBehaviour
{
    Transform oyuncuYeri;
    AudioSource au;
    public Animator anim;
    public float dusmanIlerlemeHizi;
    // Start is called before the first frame update
    void Start()
    {
        SetKinematic(true);
        au = GetComponent<AudioSource>();
        gameObject.tag = "Dusman";
        oyuncuYeri = GameObject.Find("Duz_adam").transform;

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
        dusmanIlerlemeHizi = 0.002f;
        Destroy(gameObject, 5);

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
