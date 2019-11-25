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

    public List<Ball> Balls { get; set; } = null;
    private void Start()
    {
        Invoke("Init", 0.1f);
    }
    private void Init()
    {
        
        Vector3 paddlePosition = PaddleManager.Instance.Paddle.gameObject.transform.position;
        Vector3 startPosition = new Vector3(paddlePosition.x, paddlePosition.y, paddlePosition.z);
        var _ball = Instantiate(Ball, startPosition, Quaternion.identity);
        _ball.transform.parent = gameObject.transform;
        Balls = new List<Ball>();
        Balls.Add(_ball);
        var _ball2 = Instantiate(Ball, startPosition, Quaternion.identity);
        _ball2.transform.parent = gameObject.transform;

        Balls.Add(_ball2);
        BallOnBoard = Balls.Count;

    }

    public void Reset()
    {
        StopBall();
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
                    Vector3 ballPosition = new Vector3(paddlePosition.x, paddlePosition.y + 11f, 0);
                    foreach (var item in Balls)
                    {
                       // if(item)
                            item.transform.position = ballPosition;
                    }
              
                }
                if (Input.GetButtonDown("Jump"))
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
