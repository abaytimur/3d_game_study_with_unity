using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yumruk : MonoBehaviour
{
    public float vurusGucu;

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        
      
        if (other.gameObject.CompareTag("Parca"))
        {
            other.gameObject.GetComponentInParent<Dusman>().Die();
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * vurusGucu) ;

        }

    }
}
