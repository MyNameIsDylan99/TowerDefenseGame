using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool IsGamePaused = false;
    private void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        PauseMenu.SetActive(false);
        IsGamePaused = false;
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        IsGamePaused = true;
    }
    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
        SceneManager.UnloadSceneAsync("GameScene");
    }
}
