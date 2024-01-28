using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    Animator mAnim;
    bool mIsClosed = true;
    public bool mCanClose = false;
    public bool mDoorFall = false;

    bool mIsPlayerClose = false;

    void Start()
    {
        mAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Space) && mIsPlayerClose)
        {
            if (!mDoorFall)
            {
                if (mIsClosed)
                    OpenDoor();
                else
                    CloseDoor();
            }
            else
            {
                mDoorFall = true;
                DoorFall();
            }
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            mIsPlayerClose = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mIsPlayerClose = false;
        }
    }

    public void OpenDoor()
    {
        mIsClosed = false;
        mAnim.SetBool("IsOpen", true);
    }

    public void CloseDoor()
    {
        if (!mCanClose)
            return;
        mIsClosed = true;
        mAnim.SetBool("IsOpen", false);
    }

    public void DoorFall()
    {
        mAnim.SetBool("FallDown", true);
    }
}
