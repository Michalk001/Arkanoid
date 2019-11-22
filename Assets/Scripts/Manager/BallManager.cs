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

    

    public Ball Ball { get; set; } = null;

    private Rigidbody2D RB;
    public float initBallSpeed = 8000f;

    [SerializeField]
    public List<Ball> Balls;
    private void Start()
    {
        Invoke("Init", 0.1f);
    }
    private void Init()
    {
        
        Vector3 paddlePosition = PaddleManager.Instance.Paddle.gameObject.transform.position;
        Vector3 startPosition = new Vector3(paddlePosition.x, paddlePosition.y, paddlePosition.z);
        Ball = Instantiate(Balls[0], startPosition, Quaternion.identity);
        Ball.transform.parent = gameObject.transform;
        RB = Ball.GetComponent<Rigidbody2D>();


    }

    public void Reset()
    {
        StopBall();
        Vector3 paddlePosition = PaddleManager.Instance.Paddle.gameObject.transform.position;
        Vector3 startPosition = new Vector3(paddlePosition.x, paddlePosition.y, paddlePosition.z);
    }

    public void StopBall()
    {
        RB.isKinematic = false;
        RB.Sleep();
        RB.velocity = Vector2.zero;
    }

    private void Update()
    {
      
            if (!GameManager.Instance.IsGameStart && !GameManager.Instance.gamePause)
            {

                if (Ball != null)
                {
                    Vector3 paddlePosition = PaddleManager.Instance.Paddle.gameObject.transform.position;
                    Vector3 ballPosition = new Vector3(paddlePosition.x, paddlePosition.y + 10.7f, 0);
                    Ball.transform.position = ballPosition;
                }
                if (Input.GetButtonDown("Jump"))
                {

                    RB.isKinematic = false;
                    RB.velocity = Vector2.zero;
                    RB.AddForce(new Vector2(0, initBallSpeed));
                    GameManager.Instance.IsGameStart = true;

                }
            }
            if (!BoardlManager.Instance.PlayLVL)
            {
                StopBall();
            }
       
    }

   
    

}
