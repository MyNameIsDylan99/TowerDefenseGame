using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenManager : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
