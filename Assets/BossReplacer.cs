using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossReplacer : MonoBehaviour
{
    public GameObject cuteBoss;
    public AudioSource squeak;
    public void Replace()
    {
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");

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
