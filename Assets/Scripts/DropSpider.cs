using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpider : MonoBehaviour
{

    public GameObject mSpiderPrefab;
    public Transform mSpawnPoint;
    public GameObject cuteBoss;
    public AudioSource squeak;
    bool mSpawned = false;

    GameObject boss;

    private void OnTriggerEnter(Collider other)
    {
        if(!mSpawned)
            if(other.tag == "Player")
            {
                boss = Instantiate(mSpiderPrefab, mSpawnPoint.position, mSpawnPoint.rotation);
                mSpawned = true;
            }
    }

    public void Replace()
    {
        Vector3 pos = boss.transform.position;

        Instantiate(cuteBoss, pos, Quaternion.identity);
        Destroy(boss);
        squeak.Play();
    }
    public void EndGame()
    {
        SceneLoader.INSTANCE.LoadScene("Credits");
    }
}
