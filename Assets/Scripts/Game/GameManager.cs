using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AsyncOperation MAsyncLoad;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Has Started");
    }

    IEnumerator LoadCreditsSceneAsync()
    {
        string fCreditsSceneName = "Credits";

        // Start loading the scene asynchronously and store the operation
        MAsyncLoad = SceneManager.LoadSceneAsync(fCreditsSceneName);

        // Wait until the asynchronous scene fully loads
        while (!MAsyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadMenuSceneAsync()
    {
        string fMenuSceneName = "Menu";

        // Start loading the scene asynchronously and store the operation
        AsyncOperation MAsyncLoad = SceneManager.LoadSceneAsync(fMenuSceneName);

        // Wait until the asynchronous scene fully loads
        while (!MAsyncLoad.isDone)
        {
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Listen for a keypress for now Fix later?
        if( Input.GetKeyUp(KeyCode.M) )
        {
            StartCoroutine(LoadMenuSceneAsync());
        }
        else if( Input.GetKeyUp(KeyCode.C) )
        {
            StartCoroutine(LoadCreditsSceneAsync());
        }
    }
}
