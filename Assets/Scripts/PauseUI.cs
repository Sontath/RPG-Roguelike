using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUi;
    public InputHandler input;

    private void Start()
    {
        GameIsPaused = false;
    }

    public void Unfreeze()
    {
        input.IsFrozen = false;
    }

    private void Update()
    {
        if (input.GetPause())
        {
            if (GameIsPaused)
            {
                OnResume();
            }
            else
            {
                OnPause();
            }
        }
    }

    public void OnPause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f; // Pause game time
        GameIsPaused = true;
    }

    public void OnResume()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Unfreeze();
    }

    public void OnOptions()
    {

    }

    public void OnRestart()
    {
        SceneManager.LoadScene("Overworld");
    }

    public void OnExit()
    {
        OnResume();
        SceneManager.LoadScene("TitleScreen");
    }
}
