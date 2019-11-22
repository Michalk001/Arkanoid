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

    

    public Ball initBall { get; set; } = null;

    private Rigidbody2D initRB;
    public float initBallSpeed = 8000f;

    [SerializeField]
    public List<Ball> Balls;
    private void Start()
    {
        Invoke("BallInit", 0.1f);
    }
    private void BallInit()
    {
        
        Vector3 paddlePosition = PaddleManager.Instance.Paddle.gameObject.transform.position;
        Vector3 startPosition = new Vector3(paddlePosition.x, paddlePosition.y, paddlePosition.z);
        initBall = Instantiate(Balls[0], startPosition, Quaternion.identity);
        initRB = initBall.GetComponent<Rigidbody2D>();


    }

    public void Reset()
    {
        StopBall();
        Vector3 paddlePosition = PaddleManager.Instance.Paddle.gameObject.transform.position;
        Vector3 startPosition = new Vector3(paddlePosition.x, paddlePosition.y, paddlePosition.z);
    }

    public void StopBall()
    {
        initRB.isKinematic = false;
        initRB.Sleep();
        initRB.velocity = Vector2.zero;
    }

    private void Update()
    {
      
            if (!GameManager.Instance.IsGameStart && !GameManager.Instance.gamePause)
            {

                if (initBall != null)
                {
                    Vector3 paddlePosition = PaddleManager.Instance.Paddle.gameObject.transform.position;
                    Vector3 ballPosition = new Vector3(paddlePosition.x, paddlePosition.y + 10.7f, 0);
                    initBall.transform.position = ballPosition;
                }
                if (Input.GetButtonDown("Jump"))
                {
               
                    initRB.isKinematic = false;
                    initRB.velocity = Vector2.zero;
                    initRB.AddForce(new Vector2(0, initBallSpeed));
                    GameManager.Instance.IsGameStart = true;

                }
            }
            if (!BoardlManager.Instance.PlayLVL)
            {
                StopBall();
            }
       
    }

   
    

}
