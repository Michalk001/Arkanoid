using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    #region Singleton
    private static GameManager _instance = null;

    public static GameManager Instance => _instance;

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public bool IsGameStart;

    public int TotalScore { get; set; } = 0;

    public bool gamePause { get; set; } = false;

    public int _Life = 3;
    public int Life { get; set; } = 0;
    private void Start()
    {
        Init();
        
    }
    private void Init()
    {
        TotalScore = 0;
        Life = _Life;
        IsGameStart = false;
        gamePause = false;
        Time.timeScale = 1;

    }
    public void Reset()
    {
       
      
        Init();
        PaddleManager.Instance.Reset();
        BoardlManager.Instance.Reset();
        BallManager.Instance.Reset();
        UIManager.Instance.HideGameOver();
        UIManager.Instance.HideGameMenu();
        BonusManager.Instance.Reset();
    }


    private void Update()
    {
        ShowGameOver();
        ShowGameMenu();
        


    }
    private void ShowGameOver()
    {
        if (Life <= 0)
        {
            gamePause = true;
            Time.timeScale = 0;
            UIManager.Instance.ShowGameOver();
        }
    }
    private void ShowGameMenu()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
            {
                Time.timeScale = 1;
                gamePause = false;
                UIManager.Instance.HideGameMenu();
            }
            else
            {
                Time.timeScale = 0;
                gamePause = true;
                UIManager.Instance.ShowGameMenu();
               
            }
        }
    }

}
