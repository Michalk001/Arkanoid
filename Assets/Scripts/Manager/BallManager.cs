using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    #region Singleton
    private static BallManager _instance;

    public static BallManager Instance => _instance;

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



    public Ball Ball;

   
    public float initBallSpeed = 8000f;
    public int BallOnBoard { get; set; }
    private readonly float startPositionYFix = 5f;
    public List<Ball> Balls { get; set; } = null;
    private void Start()
    {
        Invoke("Init", 0.1f);
    }
    private void Init()
    {

        OneBall();
    }

    public void Reset()
    {
   
        StopBall();
        OneBall();
    }

    public void OneBall()
    {
        if(Balls != null)
            foreach (var item in Balls)
                Destroy(item.gameObject);
        Balls = null;
        Vector3 paddlePosition = PaddleManager.Instance.Paddle.gameObject.transform.position;
        Vector3 startPosition = new Vector3(paddlePosition.x, paddlePosition.y + startPositionYFix, paddlePosition.z);
        var _ball = Instantiate(Ball, startPosition, Quaternion.identity);
        _ball.transform.parent = gameObject.transform;
        Balls = new List<Ball>
        {
            _ball
        };

        BallOnBoard = Balls.Count;
    }

    public void StopBall()
    {
        foreach(var item in Balls)
        {
            item.Rb.isKinematic = false;
            item.Rb.Sleep();
            item.Rb.velocity = Vector2.zero;
        }
  
    }

    private void Update()
    {
      
            if (!GameManager.Instance.IsGameStart && !GameManager.Instance.gamePause)
            {

                if (Balls != null)
                {
                    Vector3 paddlePosition = PaddleManager.Instance.Paddle.gameObject.transform.position;
                    Vector3 ballPosition = new Vector3(paddlePosition.x, paddlePosition.y + startPositionYFix, 0);
                    foreach (var item in Balls)
                    {
                        item.transform.position = ballPosition;
                    }
              
                }
                bool touchStart = false;
                if (Input.touchCount > 0)
                    touchStart = true;
                if (Input.GetButtonDown("Jump")|| touchStart)
                {

                    foreach (var item in Balls)
                    {
                       
                            item.Rb.isKinematic = false;
                            item.Rb.velocity = Vector2.zero;
                            item.Rb.AddForce(new Vector2(0, initBallSpeed));
                        
                    }
                    GameManager.Instance.IsGameStart = true;
                }
            }
            if (!BoardlManager.Instance.PlayLVL)
            {
                StopBall();
            }
       
    }

   
    

}
