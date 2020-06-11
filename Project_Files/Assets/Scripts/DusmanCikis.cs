using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanCikis : MonoBehaviour
{
    public GameObject olusturacakObje;
    float aralik;
    // Start is called before the first frame update
    void Start()
    {
        aralik = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        aralik -= Time.deltaTime;
        if(aralik <= 0)
        {
            aralik = 3;
            GameObject go = GameObject.Instantiate(olusturacakObje);
            go.transform.position = transform.position;
        }
    }
}
