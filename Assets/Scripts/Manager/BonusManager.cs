using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
 

    #region Singleton
    private static BonusManager _instance;

    public static BonusManager Instance => _instance;


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

    private GameObject gun { get; set; } = null;

    public void Reset()
    {
        if(gun != null)
        {
            gun.SetActive(false);
        }
    }

    #region SelectBonus
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
    #endregion

    #region GunsBonus
    private bool hiddenGun = false;
    private void AddGuns(float time, bool pernament)
    {

        if (gun == null)
        {
            gun = Instantiate(PaddleManager.Instance.Guns[0], new Vector3(0.048f, 0.21f, 0), Quaternion.identity);
            gun.transform.parent = PaddleManager.Instance.Paddle.gameObject.transform;
            gun.transform.localPosition = new Vector3(0.048f, 0.21f, 0);
            gun.gameObject.transform.localScale = new Vector3(0.0403f, 0.024f, 0);

        }
        else
        {
            gun.SetActive(true);
            ResetBull();
        }
        if (!pernament)
        {
            counterGuns = time;
            hiddenGun = true;
        }
        else
        {
            hiddenGun = false;
        }

    }

    private void ResetBull()
    {
        var bb = gun.GetComponentsInChildren<Shoot>();
        foreach(var item in bb)
        {
            item.HiddenBulls();
        }
    }
    private void HiddenGuns()
    {
        if (counterGuns <= 0f && hiddenGun)
        {
            gun.SetActive(false);
           
        }
        else
        {
            if(!GameManager.Instance.gamePause)
                counterGuns -= Time.deltaTime;
        }
    }
    #endregion

    #region oneHit

    private bool disabledOneHit = false;

    private void AddOneHit(float time, bool pernament)
    {
        BallManager.Instance.Ball._demage = 100000;
        if (!pernament)
        {
            counterOneHit = time;
            disabledOneHit = true;
        }
        else
            disabledOneHit = false;

    }

   
    private void RemoveOneHit()
    {
        if (counterOneHit <= 0f && disabledOneHit)
        {
            BallManager.Instance.Ball._demage = BallManager.Instance.Ball.Demage;
            disabledOneHit = false;
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
        if (gun != null)
        {
            gun.transform.parent = null;
        }
        Destroy(PaddleManager.Instance.Paddle.gameObject);
        PaddleManager.Instance.Paddle = Instantiate(PaddleManager.Instance.Paddles[id]);
        PaddleManager.Instance.Paddle.transform.position = pos;
        PaddleManager.Instance.Paddle.transform.parent = PaddleManager.Instance.gameObject.transform;
        if (gun != null)
        {
            gun.transform.parent = PaddleManager.Instance.Paddle.gameObject.transform;
            gun.gameObject.transform.localScale = new Vector3(0.041f, 0.024f, 0);
        }

    }
    #endregion

    public void Update()
    {
        HiddenGuns();
        RemoveOneHit(); 
    }

}
