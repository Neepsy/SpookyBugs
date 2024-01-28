using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public Image BlackScreen;
    public static SceneLoader INSTANCE;

    private Animator anim;


    private void Start()
    {
        if(INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        anim = BlackScreen.gameObject.GetComponent<Animator>();
        
    }

    public void LoadScene(string scene)
    {
        StartCoroutine(LoadSceneAsync(scene));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        //Fade in black screen
        anim.Play("Fadeout");
        yield return new WaitForSecondsRealtime(.75f);

        // Start loading the scene asynchronously and store the operation
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        anim.Play("Fadein");
    }
}
