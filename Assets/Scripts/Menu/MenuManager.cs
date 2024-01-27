using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject CreditsPanel;
    public GameObject SettingsPanel;


    private bool isCreditsOpen = false;
    private bool isSettingsOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        SettingsPanel.SetActive(isCreditsOpen);
        CreditsPanel.SetActive(isSettingsOpen);
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
        StartCoroutine(LoadGameSceneAsync());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSettings()
    {
        isSettingsOpen = !isSettingsOpen;
        SettingsPanel.SetActive(isSettingsOpen);
    }

    public void ToggleCredits()
    {
        isCreditsOpen = !isCreditsOpen;
        CreditsPanel.SetActive(isCreditsOpen);
    }
}
