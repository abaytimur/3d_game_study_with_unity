using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Camera [] kamera;
    private int kamIndex=0;

    // Start is called before the first frame update
    void Start()
    {
        kamera[kamIndex].enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (kamIndex >= kamera.Length-1)
            {
                print(kamIndex);
                kamera[kamIndex].enabled = false;
                kamIndex = 0;
                kamera[kamIndex].enabled = true;
            }
            else
            {
                print("Else" + kamIndex);
                kamera[kamIndex].enabled = false;
                kamIndex++;
                kamera[kamIndex].enabled = true;
            }


            // R'ye basinca onden baksin karaktere
            // kamera2.enabled = !kamera2.enabled;
            // kamera1.enabled = !kamera1.enabled;
        }
        
    }
}
