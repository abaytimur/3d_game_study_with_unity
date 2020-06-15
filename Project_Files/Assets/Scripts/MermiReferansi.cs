using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiReferansi : MonoBehaviour
{
    public Rigidbody mermiReferansi;
    
    public void AtesEt()
    {
        Rigidbody clone;
        clone = Instantiate(mermiReferansi, transform.position, transform.rotation);

        // Give the cloned object an initial velocity along the current
        // object's Z axis
        clone.velocity = transform.TransformDirection(Vector3.forward * 10);
    }
}
