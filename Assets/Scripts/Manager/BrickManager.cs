﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    #region Singleton
    private static BrickManager _instance;

    public static BrickManager Instance => _instance;

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
    
    public List<Sprite> Sprites;
    public List<Sprite> IndestructibleSprites;
}
