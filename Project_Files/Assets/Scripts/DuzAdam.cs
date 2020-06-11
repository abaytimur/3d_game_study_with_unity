using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEditor.Animations;
using UnityEngine;

public class DuzAdam : MonoBehaviour
{
    public Animator anim;
    public float hiz, donmeHizi, itisGucu;
    public Rigidbody rb;
    public BoxCollider yumrukCol;
    bool yumrukAtilmakta = false;

    public GameObject kilic1, kilic2;

    AnimatorClipInfo[] myAnimatorClip;
    AnimatorStateInfo animationState;


    // Start is called before the first frame update
    void Start()
    {
        yumrukCol.enabled = false;   

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * hiz *Time.deltaTime, Space.World);
            anim.SetBool("YurusunMu", true);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(-transform.up, donmeHizi * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(transform.up, donmeHizi * Time.deltaTime);
            }
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("YurusunMu", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * hiz * Time.deltaTime, Space.World);
            anim.SetBool("YurusunMu", true);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(transform.up, donmeHizi * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(-transform.up, donmeHizi * Time.deltaTime);
            }
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("YurusunMu", false);
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-transform.up, donmeHizi * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            transform.Rotate(transform.up, donmeHizi * Time.deltaTime);
        }
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("YumrukAtsinMi", true);
            yumrukAtilmakta = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("YumrukAtsinMi", false);
            yumrukAtilmakta = false;
        }

        if (yumrukAtilmakta)
        {
            animationState = anim.GetCurrentAnimatorStateInfo(0);
            //myAnimatorClip = anim.GetCurrentAnimatorClipInfo(0);
            float myTime = animationState.normalizedTime;

            if (myTime % 1f > 0.5f && myTime % 1f < 0.9f)
            {
                yumrukCol.enabled = true;
            }
            else
            {
                yumrukCol.enabled = false;
            }
        }
        else
        {
            yumrukCol.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * itisGucu * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
