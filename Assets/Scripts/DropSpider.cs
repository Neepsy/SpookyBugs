using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpider : MonoBehaviour
{

    public GameObject mSpiderPrefab;
    public Transform mSpawnPoint;
    bool mSpawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!mSpawned)
            if(other.tag == "Player")
            {
                Instantiate(mSpiderPrefab, mSpawnPoint.position, mSpawnPoint.rotation);
                mSpawned = true;
            }
    }
}
