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
    bool kilic1AlindiMi, kilic2AlindiMi, silahAlindiMi;
    public GameObject kilic1, kilic2;
    public BoxCollider kilic1Col, kilic2Col;
    private bool kilic1Kullaniliyor,kilic2Kullaniliyor;
    public GameObject silah;

    public GameObject mermi;
    public Transform mermiOlusmaNoktasi1;
    public float mermiHizi;

    AnimatorClipInfo[] myAnimatorClip;
    AnimatorStateInfo animationState;


    // Start is called before the first frame update
    void Start()
    {
        yumrukCol.enabled = false; 
        kilic1AlindiMi = false;
        kilic2AlindiMi = false;
        silahAlindiMi = false;
        //kilic1Col = kilic1.GetComponent<BoxCollider>();
        //kilic2Col = kilic1.GetComponent<BoxCollider>();
        kilic1Col.enabled = false;
        kilic2Col.enabled = false;
        kilic1Kullaniliyor = false;
        kilic2Kullaniliyor = false;
    }



    // Update is called once per frame
    void Update()
    {
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

        if (kilic1Kullaniliyor)
        {
            animationState = anim.GetCurrentAnimatorStateInfo(0);
            //myAnimatorClip = anim.GetCurrentAnimatorClipInfo(0);
            float myTime = animationState.normalizedTime;

            if (myTime % 1f > 0.4f && myTime % 1f < 0.9f)
            {
                kilic1Col.enabled = true;
            }
            else
            {
                kilic1Col.enabled = false;
            }
        }
        else
        {
            kilic1Col.enabled = false;
        }

        if (kilic2Kullaniliyor)
        {
            animationState = anim.GetCurrentAnimatorStateInfo(0);
            //myAnimatorClip = anim.GetCurrentAnimatorClipInfo(0);
            float myTime = animationState.normalizedTime;

            if (myTime % 1f > 0.5f && myTime % 1f < 0.9f)
            {
                kilic2Col.enabled = true;
            }
            else
            {
                kilic2Col.enabled = false;
            }
        }
        else
        {
            kilic2Col.enabled = false;
        }

        if ((kilic1AlindiMi== false) && (kilic2AlindiMi== false) && !silahAlindiMi)
        {
            kilic1.SetActive(false);
            kilic2.SetActive(false);
            silah.SetActive(false);
        }
        else if((kilic1AlindiMi == true) && (kilic2AlindiMi == false) && !silahAlindiMi)
        {
            kilic1.SetActive(true);
            kilic2.SetActive(false);
            silah.SetActive(false);
        }
        else if((kilic1AlindiMi == false) && (kilic2AlindiMi == true) && !silahAlindiMi)
        {
            kilic1.SetActive(false);
            kilic2.SetActive(true);
            silah.SetActive(false);
        }else if ((kilic1AlindiMi == false) && (kilic2AlindiMi == false) && silahAlindiMi)
        {
            kilic1.SetActive(false);
            kilic2.SetActive(false);
            silah.SetActive(true);
        }
       


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
            if((kilic1.activeInHierarchy== false) && (kilic2.activeInHierarchy == false) && !silah.activeInHierarchy)
            {
                yumrukAtilmakta = true;
                kilic1Kullaniliyor = false;
                kilic2Kullaniliyor = false;
                anim.SetBool("SavurYavasMi", false);
                anim.SetBool("SavurHizliMi", false);
                anim.SetBool("SilahKaldir", false);
                anim.SetBool("YumrukAtsinMi", true);
            }else if((kilic1.activeInHierarchy == true) && (kilic2.activeInHierarchy == false) && !silah.activeInHierarchy)
            {
                yumrukAtilmakta = false;
                kilic1Kullaniliyor = true;
                kilic2Kullaniliyor = false;
                anim.SetBool("SavurHizliMi", true);
                anim.SetBool("YumrukAtsinMi", false);
                anim.SetBool("SavurYavasMi", false);
                anim.SetBool("SilahKaldir", false);

            }
            else if((kilic1.activeInHierarchy == false) && (kilic2.activeInHierarchy == true) && !silah.activeInHierarchy)
            {
                yumrukAtilmakta = false;
                kilic1Kullaniliyor = false;
                kilic2Kullaniliyor = true;
                anim.SetBool("SavurHizliMi", false);
                anim.SetBool("YumrukAtsinMi", false);
                anim.SetBool("SilahKaldir", false);
                anim.SetBool("SavurYavasMi", true);
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("YumrukAtsinMi", false); 
            anim.SetBool("SavurYavasMi", false);
            anim.SetBool("SilahKaldir", false);
            anim.SetBool("SavurHizliMi", false);
            yumrukAtilmakta = false;
        }
        if (Input.GetMouseButton(1))
        {
            if ((kilic1.activeInHierarchy == false) && (kilic2.activeInHierarchy == false) && silah.activeInHierarchy)
            {
                yumrukAtilmakta = false;
                kilic1Kullaniliyor = false;
                kilic2Kullaniliyor = false;
                anim.SetBool("SavurHizliMi", false);
                anim.SetBool("YumrukAtsinMi", false);
                anim.SetBool("SilahKaldir", true);
                anim.SetBool("SavurYavasMi", false);

                if (Input.GetMouseButtonDown(0))
                {
                    anim.SetBool("AtesEt", true);
                    anim.Play("Armature|AtesEt");
                    AtesEt();
                }

                anim.SetBool("AtesEt", false);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("YumrukAtsinMi", false);
            anim.SetBool("SavurYavasMi", false);
            anim.SetBool("SilahKaldir", false);
            anim.SetBool("AtesEt", false);
            anim.SetBool("SavurHizliMi", false);
            yumrukAtilmakta = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * itisGucu * Time.deltaTime, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)){
            print("1e basildi");
            kilic1.SetActive(false);
            kilic2.SetActive(false);
            silah.SetActive(false);
            // anim.Play("Armature|Idle.001");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("2ye basildi");
            kilic1.SetActive(true);
            kilic2.SetActive(false);
            silah.SetActive(false);
            kilic1Kullaniliyor = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("3e basildi");
            kilic1.SetActive(false);
            kilic2.SetActive(true);
            silah.SetActive(false);
            kilic2Kullaniliyor = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            print("4e basildi");
            kilic1.SetActive(false);
            kilic2.SetActive(false);
            silah.SetActive(true);
        }

    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kilic1"))
        {
            kilic1AlindiMi = true;
            other.gameObject.SetActive(false);
            kilic1.SetActive(true);
            kilic2.SetActive(false);
            silah.SetActive(false);
        }
        else if (other.CompareTag("Kilic2"))
        {
            kilic2AlindiMi = true;
            other.gameObject.SetActive(false);
            kilic2.SetActive(true);
            kilic1.SetActive(false);
            silah.SetActive(false);
        }
        else if (other.CompareTag("Silah"))
        {
            silahAlindiMi = true;
            other.gameObject.SetActive(false);
            kilic2.SetActive(false);
            kilic1.SetActive(false);
            silah.SetActive(true);
        }
    }

    public void AtesEt()
    {

        GameObject olusanMermi1 = Instantiate(mermi, mermiOlusmaNoktasi1.position, mermiOlusmaNoktasi1.rotation);
        Rigidbody olusanMermiRB1 = olusanMermi1.GetComponent<Rigidbody>();
        olusanMermiRB1.velocity = mermiHizi * olusanMermi1.transform.up;

        Destroy(olusanMermi1, 5.5f);
    }

}
