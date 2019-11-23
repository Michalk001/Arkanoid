using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMenager : MonoBehaviour
{
 

    #region Singleton
    private static BonusMenager _instance;

    public static BonusMenager Instance => _instance;

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


    private float counterGuns = 0f;
    private float counterOneHit = 0f;
    public void RunBonus(string id, float time, bool pernament)
    {
        switch (id)
        {
            case "gun":
                {
                    AddGuns(time, pernament);
                    break;
                }
            case "heart":
                {
                    GameManager.Instance.Life += 1;
                    break;
                }
            case "death":
                {
                    GameManager.Instance.Life = 0;
                    break;
                }
            case "oneHit":
                {
                    AddOneHit(time, pernament);
                    break;
                }
            case "paddleShort":
                {

                    ChangePaddle(1);
                    break;
                }
            case "paddleStandard":
                {
                    ChangePaddle(0);
                    break;
                }
        }

    }

    #region GunsBonus
    private void AddGuns(float time, bool pernament)
    {
       
        if (PaddleManager.Instance.gun == null)
        {
            PaddleManager.Instance.gun = Instantiate(PaddleManager.Instance.Guns[0], new Vector3(0.048f, 0.21f, 0), Quaternion.identity);
            PaddleManager.Instance.gun.transform.parent = PaddleManager.Instance.Paddle.gameObject.transform;
            PaddleManager.Instance.gun.transform.localPosition = new Vector3(0.048f, 0.21f, 0);
            PaddleManager.Instance.gun.gameObject.transform.localScale = new Vector3(0.0403f, 0.024f, 0);
        }
        else
            PaddleManager.Instance.gun.SetActive(true);
        if (!pernament)
            counterGuns = time;
    }
    private void HiddenGuns()
    {
        if (counterGuns <= 0f)
        {
            PaddleManager.Instance.gun.SetActive(false);
        }
        else
        {
            if(!GameManager.Instance.gamePause)
                counterGuns -= Time.deltaTime;
        }
    }
    #endregion


    #region oneHit

    private void AddOneHit(float time, bool pernament)
    {
        BallManager.Instance.Ball._demage = 100000;
        counterOneHit = time;

    }
    private void RemoveOneHit()
    {
        if (counterOneHit <= 0f)
        {
            BallManager.Instance.Ball._demage = BallManager.Instance.Ball.Demage;
        }
        else
        {
            if (!GameManager.Instance.gamePause)
                counterOneHit -= Time.deltaTime;
        }
    }
    #endregion

    #region ChangePaddle
  
    private void ChangePaddle(int id)
    {
        if (PaddleManager.Instance.Paddles.Count  <= id)
            return;
        var pos = PaddleManager.Instance.Paddle.transform.position;
        if (PaddleManager.Instance.gun != null)
        {
            PaddleManager.Instance.gun.transform.parent = null;
        }
        Destroy(PaddleManager.Instance.Paddle.gameObject);
        PaddleManager.Instance.Paddle = Instantiate(PaddleManager.Instance.Paddles[id]);
        PaddleManager.Instance.Paddle.transform.position = pos;
        PaddleManager.Instance.Paddle.transform.parent = PaddleManager.Instance.gameObject.transform;
        if (PaddleManager.Instance.gun != null)
        {
            PaddleManager.Instance.gun.transform.parent = PaddleManager.Instance.Paddle.gameObject.transform;
            PaddleManager.Instance.gun.gameObject.transform.localScale = new Vector3(0.041f, 0.024f, 0);
        }

    }
    #endregion

    public void Update()
    {
        HiddenGuns();
        RemoveOneHit(); 
    }

}
