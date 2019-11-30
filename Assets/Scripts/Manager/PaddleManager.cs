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

    public GameObject leftSpriteBorder;
    public GameObject rightSpriteBorder;
    public Paddle PaddlePref;
    [SerializeField]
    public List<GameObject> Guns;
    public Paddle Paddle { get; set; } = null;
    public float leftScreenEdge { get; set; }
    public float rightScreenEdge { get; set; }
    public float speed;
    
    private Vector3 startPosition;
    void Start()
    {

        Init();
        leftScreenEdge = leftSpriteBorder.transform.position.x + leftSpriteBorder.transform.localScale.x * leftSpriteBorder.GetComponent<BoxCollider2D>().size.x;
        rightScreenEdge = rightSpriteBorder.transform.position.x;
       
    }
    private void Init()
    {
        Paddle = Instantiate(PaddlePref);
        Paddle.transform.parent = gameObject.transform;
        startPosition = Paddle.transform.position;
    }
    public void Reset()
    {
        Paddle.transform.position = startPosition;
        Paddle.transform.localScale = new Vector3(25, 40, 1);



    }

    // Update is called once per frame
    void Update()
    {
        

    }
    
    
    
}
