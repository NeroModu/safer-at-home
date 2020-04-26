using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenController : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseScreenUI;

    void Start()
    {

        pauseScreenUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape Pressed");
            if (gameIsPaused)
            {
                Debug.Log("Game was paused, resuming");
                Resume();
            }
            else
            {
                Debug.Log("Pausing Game");
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseScreenUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseScreenUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Exit() // exits to main menu
    {
        //Debug.Log("TO-DO, UNIMPLEMENTED EXIT TO MAIN MENU");
        StartCoroutine(LoadMainMenu());
    }

    private IEnumerator LoadMainMenu()
    {
        AsyncOperation startGame = SceneManager.LoadSceneAsync("Assets/Scenes/MainMenu.unity", LoadSceneMode.Single);
        while (!startGame.isDone)
        {
            yield return null;
        }
    }

}
