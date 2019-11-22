using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleManager : MonoBehaviour
{


    #region Singleton
    private static PaddleManager _instance;

    public static PaddleManager Instance => _instance;

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

    private BoxCollider2D boxCollider2D;
    public GameObject leftSpriteBorder;
    public GameObject rightSpriteBorder;
    [SerializeField]
    public List<Paddle> Paddles;
    [SerializeField]
    public List<GameObject> Guns;
    public Paddle Paddle { get; set; } = null;
    public float leftScreenEdge { get; set; }
    public float rightScreenEdge { get; set; }
    public float speed;
    public GameObject gun { get;set;} = null;
    private Vector3 startPosition;
    void Start()
    {

        Init();
        leftScreenEdge = leftSpriteBorder.transform.position.x + leftSpriteBorder.transform.localScale.x * leftSpriteBorder.GetComponent<BoxCollider2D>().size.x;
        rightScreenEdge = rightSpriteBorder.transform.position.x;
       
    }
    private void Init()
    {
        Paddle = Instantiate(Paddles[0]);
        Paddle.transform.parent = gameObject.transform;
        startPosition = Paddle.transform.position;
    }
    public void Reset()
    {
        Paddle.transform.position = startPosition;
        if(gun != null)
            gun.SetActive(false);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           
            var pos = Paddle.transform.position;
            Destroy(Paddle.gameObject);
            Paddle = Instantiate(Paddles[0]);
            Paddle.transform.parent = gameObject.transform;
            Paddle.transform.position = pos;
            boxCollider2D = Paddle.gameObject.GetComponent<BoxCollider2D>();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            var pos = Paddle.transform.position;
            Destroy(Paddle.gameObject);
            Paddle = Instantiate(Paddles[1]);
            Paddle.transform.parent = gameObject.transform;
            Paddle.transform.position = pos;
            boxCollider2D = Paddle.gameObject.GetComponent<BoxCollider2D>();
        }

         
    }
    
    public void GetBonus(string id,float time,bool pernament)
    {
        switch (id)
        {
            case "gun":
            {
               
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
                    BallManager.Instance.Ball._demage = 10;
                    break;
                }

        }
    }
    
}
