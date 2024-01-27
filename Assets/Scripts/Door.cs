using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    Animator mAnim;
    bool mIsClosed = true;
    bool mDoorFall = false;

    void Start()
    {
        mAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
           /* if (mIsClosed)
                OpenDoor();
            else
                CloseDoor();
           */
           if(mDoorFall == false)
            {
                mDoorFall = true;
                DoorFall();
            }
        }
    }

    public void OpenDoor()
    {
        mIsClosed = false;
        mAnim.SetBool("IsOpen", true);
    }

    public void CloseDoor()
    {
        mIsClosed = true;
        mAnim.SetBool("IsOpen", false);
    }

    public void DoorFall()
    {
        mAnim.SetBool("FallDown", true);
    }
}
