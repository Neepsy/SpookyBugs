using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPopOut : MonoBehaviour
{
    // Start is called before the first frame update
    public PopOut mObjecttoActivate;
    bool mActivated = false;
    private void OnTriggerEnter(Collider other)
    {
        if (mActivated)
            return;
        if(other.gameObject.tag == "Player")
        {
            mActivated = true;
            mObjecttoActivate.RevealPopOut();
        }
    }
}
