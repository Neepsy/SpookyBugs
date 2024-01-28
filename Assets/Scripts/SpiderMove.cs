using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : MonoBehaviour
{
    public float mDropTime = 1.5f;
    public float mMoveSpeed = 0.5f;
    public float mMoveTime = 1.5f;
    public Vector3 mPlayerPosition;

    private bool mCanMove = false;

    private void Start()
    {
        mPlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        StartCoroutine(DropTime());
    }

    private void Update()
    {
        if(mCanMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, mPlayerPosition, mMoveSpeed*Time.deltaTime);
        }
    }

    IEnumerator DropTime()
    {
        yield return new WaitForSeconds(mDropTime);
        mCanMove = true;
        StartCoroutine(MoveSpider());
    }

    IEnumerator MoveSpider()
    {
        yield return new WaitForSeconds(mMoveTime);
        mCanMove = false;
    }

}
