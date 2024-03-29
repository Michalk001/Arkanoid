﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    #region Singleton
    private static UIManager _instance;

    public static UIManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public GameManager gameManager= null;
    public GameObject GameMenu;
    public GameObject GameOver;
    public GameStats GameStats;
    private GameStats _gameStats = null;
    private GameObject _gameMenu = null;
    private GameObject _gameOver = null;


    private void SetCamera(GameObject obj)
    {
        obj.gameObject.GetComponentInChildren<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        obj.gameObject.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
  
    }
   
    void Start()
    {
        SetCamera(GameMenu);
        SetCamera(GameOver);
        SetCamera(GameStats.gameObject);
        _gameStats = Instantiate(GameStats, gameObject.transform);
        _gameStats.gameManager = gameManager;
    }



    void Update()
    {
        
    }

    public void ShowGameMenu()
    {
        if (_gameMenu == null)
        {
            _gameMenu = Instantiate(GameMenu, gameObject.transform);
        }
        else
            _gameMenu.SetActive(true);
    }

    public void HideGameMenu()
    {
        if (_gameMenu != null)
            _gameMenu.SetActive(false);
    }

    public void ShowGameOver()
    {
        if (_gameOver == null)
        {
            _gameOver = Instantiate(GameOver, gameObject.transform);

        }
        else
            _gameOver.SetActive(true);
    }

    public void HideGameOver()
    {
        if(_gameOver !=null)
        _gameOver.SetActive(false);
    }
}
