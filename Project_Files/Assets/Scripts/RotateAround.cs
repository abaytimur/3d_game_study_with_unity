using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public float hiz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, 300f*Time.deltaTime);
        transform.Translate(Vector3.forward*hiz* Time.deltaTime);
        if (transform.position.y >= 1f)
        {
            hiz = -hiz;
        }
        if(transform.position.y <= 0.6f)
        {
            hiz = -hiz;
        }
    }
}
