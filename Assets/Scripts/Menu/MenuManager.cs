using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject settingsPanel;

    // Start is called before the first frame update
    void Start()
    {
        creditsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    IEnumerator LoadGameSceneAsync()
    {
        string fGameSceneName = "Game";

        // Start loading the scene asynchronously and store the operation
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(fGameSceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void StartGame()
    {
        SceneLoader.INSTANCE.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeInHierarchy);
    }

    public void ToggleCredits()
    {
        SceneLoader.INSTANCE.LoadScene("Credits");
    }
}
