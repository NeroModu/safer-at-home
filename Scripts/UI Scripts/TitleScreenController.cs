using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{

    public GameObject titleScreen;

    public GameObject optionsScreen;

    public GameObject credits;

    public GameObject backGround;

    private bool keyDown = false;

    private void Awake()                          
    {
        credits.SetActive(true);
        optionsScreen.SetActive(true);
        titleScreen.SetActive(true);
    }

    void Start()
    {

        credits.SetActive(false);
        optionsScreen.SetActive(false);
        titleScreen.SetActive(true);
        backGround.SetActive(true);


    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!keyDown)
            {
                CloseOptions();
                CloseCredits();
            }
            keyDown = true;
        }
        else
        {
            keyDown = false;
        }
    }

    public void StartGame()
    {
        Debug.Log("Loading main scene");
        // Wait until the asynchronous scene fully loads
        StartCoroutine(LoadMainGame());
    }

    private IEnumerator LoadMainGame()
    {
        AsyncOperation startGame = SceneManager.LoadSceneAsync("Assets/Scenes/Game.unity", LoadSceneMode.Single);
        while (!startGame.isDone)
        {
            yield return null;
        }
    }

    public void Options()
    {
        Debug.Log("Opening Options Screen");
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        Debug.Log("ATTEMPTING TO CLOSE OPTIONS");
        if (optionsScreen.activeSelf)
        {
            Debug.Log("CLOSING OPTIONS SCREEN");
            optionsScreen.SetActive(false);
        }
        else
        {
            Debug.Log("WARNING: OPTIONS SCENE NOT OPEN");
        }
        //titleScreen.SetActive(true);
    }

    public void StartCredits()
    {
        credits.SetActive(true);
        titleScreen.SetActive(false);
        optionsScreen.SetActive(false);
    }

    public void CloseCredits()
    {
        Debug.Log("ATTEMPTING TO CLOSE CREDITS");
        if (credits.activeSelf)
        {
            Debug.Log("CLOSING CREDITSSCREEN");
            credits.SetActive(false);
        } else
        {
            Debug.Log("WARNING: CREDITS SCENE NOT OPEN");
        }
        titleScreen.SetActive(true);
    }


    public void Quit() // exits to main menu
    { 
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

}
