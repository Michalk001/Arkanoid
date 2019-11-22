using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonGameMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartGame()
    {
        GameManager.Instance.Reset();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
