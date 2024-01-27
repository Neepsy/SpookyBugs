using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopOut : MonoBehaviour
{
    Animator mAnim;
    bool mHiding = true;
    //Enable this if the cutout object is going to drop and shatter
    public bool mDropCutout = false;
    public float mDropDelay = 2f;
    public bool mShatterobject = false;
    public bool mWiggle = false;
    public GameObject mCutout;


    void Start()
    {
        mAnim = GetComponent<Animator>();
    }


    void Update()
    {
        //temporary way to activate the object. To properly use this, call the RevealPopout() from wherever it is needed
        if(mHiding)
            if (Input.GetKeyDown(KeyCode.Space))   
                RevealPopOut();
        
    }

    public void RevealPopOut()
    {
        mHiding = false;
        mAnim.SetBool("Hiding", false);
        if (mDropCutout)
            StartCoroutine(DropWait());
        if (mWiggle)
            mAnim.SetBool("Wiggle", true);

    }


    IEnumerator DropWait()
    {
        yield return new WaitForSeconds(mDropDelay);
        DetachCutout();
    }
    public void DetachCutout()
    {
        if(mShatterobject)
            mCutout.GetComponent<GlassShatter>().enabled = true;

        mCutout.transform.SetParent(null);
        mCutout.GetComponent<Rigidbody>().AddForce(Random.Range(1,5), 0, Random.Range(0,3));
        mCutout.GetComponent<Rigidbody>().useGravity = true;
        mCutout.GetComponent<SphereCollider>().enabled = true;
    }
}
